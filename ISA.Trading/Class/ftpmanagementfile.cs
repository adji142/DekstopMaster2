
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;


namespace ISA.Trading.Class
{
     class ftpmanagementfile
    {

        static string ftpServerIP = "ktptoko.sas-autoparts.com";
        static string ftpUserID = "administrator";
        static string ftpPassword = "password11";
        static string Foldername = "ISAPalurTrading";

        /// <summary>
        /// Method to upload the specified file to the specified FTP Server
        /// </summary>
        /// <param name="filename">file full name to be uploaded</param>
        /// 
        public static string GetFileSize(long numBytes)
        {
            string fileSize = "";

            if (numBytes > 1073741824)
                fileSize = String.Format("{0:0.00} Gb", (double)numBytes / 1073741824);
            else if (numBytes > 1048576)
                fileSize = String.Format("{0:0.00} Mb", (double)numBytes / 1048576);
            else
                fileSize = String.Format("{0:0} Kb", (double)numBytes / 1024);

            if (fileSize == "0 Kb")
                fileSize = "1 Kb";	// min.							
            return fileSize;
        }

        public static void Upload(string filepath, string filname)
        {
            FileInfo fileInf = new FileInfo(filepath);
            string uri = "ftp://" + ftpServerIP + "/" + Foldername + "/" + filname;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            long FileSize = fileInf.Length;
            
            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;
            
            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();
           
            //try
            //{
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();
                
                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                    
                    

                    // update the user interface
                    
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Upload Error");
            //}
        }

        public static void Upload(string filepath, string filname, object senderbw)
        {
            FileInfo fileInf = new FileInfo(filepath);

            string uri = "ftp://" + ftpServerIP + "/" + Foldername + "/" + filname;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            
            // Copy the contents of the file to the request stream.
            long FileSize = fileInf.Length;
            string FileSizeDescription = GetFileSize(FileSize);
            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
            // Stream to which the file to be upload is written
            Stream strm = reqFTP.GetRequestStream();
            long SentBytes = 0;
            // Read from the file stream 2kb at a time
            contentLen = fs.Read(buff, 0, buffLength);

            // Till Stream content ends
            while (contentLen != 0)
            {
                // Write Content from the file stream to the FTP Upload Stream
                strm.Write(buff, 0, contentLen);
                contentLen = fs.Read(buff, 0, buffLength);

                SentBytes += contentLen;

                // update the user interface
                string SummaryText = String.Format("Transferred {0} / {1}", GetFileSize(SentBytes), FileSizeDescription);
                (senderbw as BackgroundWorker).ReportProgress((int)(((decimal)SentBytes / (decimal)FileSize) * 100), SummaryText);

                // update the user interface

            }

            // Close the file stream and the Request Stream
            strm.Close();
            fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        public static void DeleteFTP(string fileName)
        {
            try
            {
                fileName = Foldername + "/" + fileName;

                string uri = "ftp://" + ftpServerIP + "/" + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FTP 2.0 Delete");
            }
        }

        public static string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
                //MessageBox.Show(result.ToString().Split('\n'));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }

        public static string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                //MessageBox.Show(reader.ReadToEnd());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                //MessageBox.Show(response.StatusDescription);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }

        public static void Download(string folderpath, string fileName)
        {

           // fileName = Foldername + "/" + fileName;
            FtpWebRequest reqFTP;
            try
            {
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                //folderpath = <<The full path where the file is to be created.>>, 
                FileStream outputStream; //new FileStream();
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                
                outputStream = new FileStream(folderpath + "\\" + fileName, FileMode.Create);
               
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Download(string folderpath, string fileName, object senderbw)
        {

            long sizefile = GetFileSizes(fileName);
            FtpWebRequest reqFTP;
            try
            {
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                //folderpath = <<The full path where the file is to be created.>>, 
                FileStream outputStream; 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>

                outputStream = new FileStream(folderpath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                long SentBytes = 0;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                string FileSizeDescription = GetFileSize(sizefile);
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    SentBytes += readCount;
                    string SummaryText = String.Format("Transferred {0} / {1}", GetFileSize(SentBytes), FileSizeDescription);
                    (senderbw as BackgroundWorker).ReportProgress((int)(((decimal)SentBytes / (decimal)sizefile) * 100), SummaryText);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public static bool CekExistFile(string filename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.GetResponse();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static long GetFileSizes(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;
                
                ftpStream.Close();
                response.Close();
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            return fileSize;
        }

        public static DateTime filemodified(string filename)
        {
            FtpWebRequest reqFTP;
            DateTime filedate = new DateTime();
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                filedate = response.LastModified;

                ftpStream.Close();
                response.Close();
            }
            catch (WebException e)
            {
                String status = ((FtpWebResponse)e.Response).StatusDescription;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            return filedate;
        }

        public static void Rename(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + Foldername + "/" + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                
                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
