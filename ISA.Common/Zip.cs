using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Common
{
    public class Zip
    {
        static bool isInitialized = false;
        static string _password = "";
        static bool _passwordEnabled = false;
        static int BufferSize = 1024 * 10000; //(10 MB buffer)

        public static void Initialize()
        {
            if (!isInitialized)
            {
                //_passwordEnabled = bool.Parse(LookupInfo.GetValue("ZIP", "PASSWORD_ENABLED"));
                _passwordEnabled = bool.Parse(LookupInfo.GetValue("PASSWORD_ENABLED","ZIP"));
                _password = LookupInfo.GetValue("ZIP", "PASSWORD_ZIP"); ;
                isInitialized = true;
            }
        }

        public static string Password
        {
            get
            {
                Initialize();
                if (_passwordEnabled)
                {
                    return _password;
                }
                else
                {
                    return "";
                }
            }
        }

        public static void ZipFiles(string sourceFile, string zipFileName)
        {
            FileStream fileStreamIn = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            FileStream fileStreamOut = new FileStream(zipFileName, FileMode.Create, FileAccess.Write);
            ZipOutputStream zipOutStream = new ZipOutputStream(fileStreamOut);
            //zipOutStream.UseZip64 = UseZip64.Off;
            zipOutStream.Password = Password;


            byte[] buffer = new byte[BufferSize];

            ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFile));
            zipOutStream.PutNextEntry(entry);

            int size;
            do
            {
                size = fileStreamIn.Read(buffer, 0, buffer.Length);
                zipOutStream.Write(buffer, 0, size);
            } while (size > 0);

            zipOutStream.Close();
            fileStreamOut.Close();
            fileStreamIn.Close();
        }

        public static void ZipFiles(List<string> sourceFiles, string zipFileName)
        {
            FileStream fileStreamOut = new FileStream(zipFileName, FileMode.Create, FileAccess.Write);
            ZipOutputStream zipOutStream = new ZipOutputStream(fileStreamOut);
            //zipOutStream.UseZip64 = UseZip64.Off;
            zipOutStream.Password = Password;
            byte[] buffer = new byte[BufferSize];
            foreach (string srcFile in sourceFiles)
            {

                ZipEntry entry = new ZipEntry(Path.GetFileName(srcFile));
                zipOutStream.PutNextEntry(entry);
                FileStream fileStreamIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read);

                int size;
                do
                {
                    size = fileStreamIn.Read(buffer, 0, buffer.Length);
                    zipOutStream.Write(buffer, 0, size);
                }
                while (size > 0);
                fileStreamIn.Close();
            }
            zipOutStream.Close();
            fileStreamOut.Close();


        }


        public static void UnZipFiles(string zipFileName, string outputFolder, bool deleteZipFile)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipFileName));
            if (Password != null && Password != String.Empty)
                s.Password = Password;
            ZipEntry theEntry;
            string tmpEntry = String.Empty;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = outputFolder;
                string fileName = Path.GetFileName(theEntry.Name);
                // create directory 
                if (directoryName != "")
                {
                    Directory.CreateDirectory(directoryName);
                }
                if (fileName != String.Empty)
                {
                    if (theEntry.Name.IndexOf(".ini") < 0)
                    {
                        string fullPath = directoryName + "\\" + theEntry.Name;
                        fullPath = fullPath.Replace("\\ ", "\\");
                        string fullDirPath = Path.GetDirectoryName(fullPath);
                        if (!Directory.Exists(fullDirPath)) Directory.CreateDirectory(fullDirPath);
                        FileStream streamWriter = File.Create(fullPath);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = s.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                streamWriter.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        streamWriter.Close();
                    }
                }
            }
            s.Close();
            if (deleteZipFile)
                File.Delete(zipFileName);
        }
    }
}
