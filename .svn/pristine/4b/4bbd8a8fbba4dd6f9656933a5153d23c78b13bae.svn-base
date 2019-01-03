using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;
using System.Xml;

namespace ISA.Publisher
{
    public partial class PublishUpdate : Form
    {
        string _fileZipName, _folderZipName;

        public PublishUpdate()
        {
            InitializeComponent();
        }


        private void Publish()
        {
            DataTable dt = new DataTable();
            DataTable InitCurVersion = new DataTable();
            string pathPublish = string.Empty;
            string curversion, prevversion, xmlappid, xmlcurversion, xmlprevversion;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Temp";
            openFileDialog1.Filter = "zip file (*.zip)|*.zip";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _fileZipName = openFileDialog1.FileName;

                    if (MessageBox.Show("Download Data ini " + openFileDialog1.FileNames[0].ToString() + " ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;

                    }


                    _folderZipName = _fileZipName.ToUpper().Replace(".ZIP", string.Empty);

                    if (!Directory.Exists(_folderZipName))
                    {
                        Directory.CreateDirectory(_folderZipName);
                    }
                    else
                    {
                        string[] filesA = Directory.GetFiles(_folderZipName);

                        foreach (string file in filesA)
                        {
                            File.Delete(file);
                        }
                    }


                    Zip.UnZipFiles(_fileZipName, _folderZipName, false);



                    string[] filesB = Directory.GetFiles(_folderZipName);

                    foreach (string file in filesB)
                    {

                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        pathPublish=Class.AppSetting.GetValue("PUBLISH_LOCATION");
                        if (fi.Extension == ".xml")
                        {
                            XmlDocument xdoc = new XmlDocument();

                            xdoc.Load(file);

                            XmlNodeList xlist = xdoc.SelectNodes("root/row");
                            if (xlist.Count > 0)
                            {
                                for (int i = 0; i < xlist.Count; i++)
                                {
                                    //if (xlist[i].Attributes["appid"].Value == "ISA.Trading" || xlist[i].Attributes["appid"].Value == "ISA.Finance")
                                    //{
                                        xmlappid = xlist[i].Attributes["appid"].Value;
                                        xmlcurversion = xlist[i].Attributes["curversion"].Value;
                                        xmlprevversion = xlist[i].Attributes["prevversion"].Value;

                                        InitCurVersion = GetInitialCurrentVersion(xmlappid);

                                        if (InitCurVersion.Rows.Count > 0)
                                        {
                                            //pathPublish = Tools.isNull(InitCurVersion.Rows[0]["AppPath"], "").ToString();
                                            curversion = Tools.isNull(InitCurVersion.Rows[0]["CurVersion"], "").ToString();
                                            prevversion = Tools.isNull(InitCurVersion.Rows[0]["PrevVersion"], "").ToString();


                                            if (xmlprevversion == curversion || xmlcurversion==curversion)
                                            {

                                                ExecutePublish(_folderZipName, pathPublish);

                                                using (Database db = new Database())
                                                {
                                                    db.Commands.Add(db.CreateCommand("usp_AppVersion_UPDATE"));
                                                    db.Commands[0].Parameters.Add(new Parameter("@AppID", SqlDbType.VarChar, xmlappid));
                                                    db.Commands[0].Parameters.Add(new Parameter("@CurVersion", SqlDbType.VarChar, xmlcurversion));
                                                    db.Commands[0].Parameters.Add(new Parameter("@PrevVersion", SqlDbType.VarChar, xmlprevversion));
                                                    db.Commands[0].ExecuteNonQuery();
                                                }

                                                MessageBox.Show("Proses Publish " + xmlappid + " Berhasil");

                                            }
                                            else
                                            {
                                                MessageBox.Show("Versi update tidak sesuai dengan versi di server.\nUpdate Prev Version : " + xmlprevversion + "\nProgram Curent Version : " + curversion + "\nProses Publish " + xmlappid + " Gagal");
                                            }


                                        }

                                    //}
                                }

                            }
                        }


                    }

                }
            }
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                if (fi.Name != "config.xml" && fi.Extension != ".sql")
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }


        private void cmdPublish_Click(object sender, EventArgs e)
        {
            Publish();
            //MessageBox.Show("Proses Publish Selesai");
        }


        private void ExecutePublish(string folderZipName, string pathPublish)
        {
            string[] files = Directory.GetFiles(folderZipName);

            foreach (string file in files)
            {
                
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.Name != "config.xml")
                {
                    if (fi.Extension == ".sql")
                    {

                        //System.Diagnostics.Process.Start(file);
                        //System.Diagnostics.Process.Start(file);
                        string command = ("sqlcmd");
                        string arg = string.Format("-S localhost -E -t 0 -i \"{0}\"", file);
                        System.Diagnostics.Process.Start(command, arg);
                    }
                    //else
                    //{
                    //    string destFile = System.IO.Path.Combine(pathPublish, System.IO.Path.GetFileName(file));
                    //    File.Copy(file, destFile, true);
                    //}
                }
            }
            DirectoryInfo d1 = new System.IO.DirectoryInfo(folderZipName);
            DirectoryInfo d2 = new System.IO.DirectoryInfo(pathPublish);
            CopyAll(d1, d2);
        }

        private DataTable GetInitialCurrentVersion(string appID)
        {           
            string pathPublish, curversion, prevversion;
            DataTable dt = new DataTable();
            DataTable InitCurVersion = new DataTable();


            InitCurVersion.Columns.Add(new DataColumn("AppPath", typeof(System.String)));
            InitCurVersion.Columns.Add(new DataColumn("CurVersion", typeof(System.String)));
            InitCurVersion.Columns.Add(new DataColumn("PrevVersion", typeof(System.String)));



            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_AppVersion_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@AppID", SqlDbType.VarChar, appID));
                dt = db.Commands[0].ExecuteDataTable();

            }


            pathPublish = Tools.isNull(dt.Rows[0]["AppPath"], "").ToString();
            curversion = Tools.isNull(dt.Rows[0]["CurVersion"], "").ToString();
            prevversion = Tools.isNull(dt.Rows[0]["PrevVersion"], "").ToString();



            DataRow dr = InitCurVersion.NewRow();
            dr["AppPath"] = pathPublish;
            dr["CurVersion"] = curversion;
            dr["PrevVersion"] = prevversion;
            InitCurVersion.Rows.Add(dr);
                        
            return InitCurVersion;

        }

    }
}
