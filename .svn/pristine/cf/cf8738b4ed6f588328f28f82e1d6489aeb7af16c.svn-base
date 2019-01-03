using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;
using ISA.Finance.Class;
using System.Diagnostics;

namespace ISA.Finance.GL
{
    public partial class frmDownloadPerkiraan : ISA.Finance.BaseForm
    {
        string fileZipName = GlobalVar.DbfDownload + "\\NoPerk.zip";
        string _tempPath;
        protected DataTable
        dtPerkiraan;

        public frmDownloadPerkiraan()
        {
            InitializeComponent();
        }

        private void frmDownloadPerkiraan_Load(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\NoPerk\\";

            if (!Directory.Exists(_tempPath))
            {
                Directory.CreateDirectory(_tempPath);
            }
            else
            {
                string[] files = Directory.GetFiles(_tempPath);

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, _tempPath, false);
                txtStatus.Text = "FOUND";
                cmdYes.Enabled = true;
            }
            else
            {
                txtStatus.Text = "NONE";
                cmdYes.Enabled = false;
                return;
            }
        }

        private void DownloadPerkiraan()
        {


            string fileName = _tempPath + "NoPerkTmp.DBF";
            //lblTableName.Text = "TokoToSales is Downloading";

            DataTable result = ValidateFile(fileName, dtPerkiraan);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadPerkiraanKoneksi"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    //_counterRow = 0;
                    //_total = result.Rows.Count;
                    //lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();
                    //_counterTable = _counterTable + 1;
                    //lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {                                                

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@Hapus", SqlDbType.Int, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["hapus"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        
                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                        //this.refreshForm(_counterRow);
                    }
                }

                //ShowNotepad(result);
               
            }
        }

        private void DownloadReportDesign()
        {
            string fileName = _tempPath + "DesignTmp.DBF";
            //lblTableName.Text = "TokoToSales is Downloading";

            DataTable result = ValidateFile(fileName, dtPerkiraan);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadReportDesign"));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Report", SqlDbType.VarChar, Tools.isNull(dr["Report"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, Tools.isNull(dr["ref"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoUrut", SqlDbType.VarChar, Tools.isNull(dr["NoUrut"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, Tools.isNull(dr["Tipe"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["Keterangan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Formula", SqlDbType.VarChar, Tools.isNull(dr["Formula"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Lminus", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr["Lminus"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TUnderline", SqlDbType.Int, Tools.isNull(dr["TUnderline"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DUnderline", SqlDbType.Int, Tools.isNull(dr["DUnderline"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bold", SqlDbType.Int, Tools.isNull(dr["Bold"], "").ToString().Trim()));
                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                    }
                }
            }
        }

        private void DownloadData(string namaFile, string sp, string[] param, string[] kolom)
        {
            string fileName = _tempPath + namaFile;
            DataTable result = ValidateFile(fileName, dtPerkiraan);

            MessageBox.Show(result.Rows.Count.ToString());


            if (result != null)
            {
                 using (Database db = new Database(GlobalVar.DBName))
                 {
                    db.Commands.Add(db.CreateCommand(sp));
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    int z;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        for (z = 0; z < param.Length; ++z) {
                            string parameter = param[z];
                            string barisKolom = kolom[z];
                            if (SecurityManager.UserID == barisKolom) {
                                db.Commands[0].Parameters.Add(new Parameter(parameter, SqlDbType.VarChar, Tools.isNull(barisKolom, "").ToString().Trim()));
                            } else {
                                db.Commands[0].Parameters.Add(new Parameter(parameter, SqlDbType.VarChar, Tools.isNull(dr[barisKolom], "").ToString().Trim()));
                            }
                        } 
                        
                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                        //this.refreshForm(_counterRow);
                    } 
                } 
            }
        }


        private void ShowNotepad(DataTable dt)
        {
           try
           {
               BuildString data = new BuildString();

               data.PROW(true, 1, "HASIL DOWNLOAD NO.PERK DARI 11");
               data.PROW(true, 1, "===============================================================================================");
               data.PROW(true, 1, data.PrintVerticalLine2());
               data.PROW(false, 3, "REF");
               data.PROW(false, 7, data.PrintVerticalLine2());
               data.PROW(false, 10, "No.Perkiraan");
               data.PROW(false, 24, data.PrintVerticalLine2());
               data.PROW(false, 50, "Nama Perkiraan");
               data.PROW(false, 96, data.PrintVerticalLine2());
               data.PROW(true, 1, "-----------------------------------------------------------------------------------------------");
               foreach(DataRow dr in dt.Rows)
               {
                   data.PROW(true, 1, data.PrintVerticalLine2());
                   data.PROW(false,3,Tools.isNull(dr["ref"], "").ToString().Trim());
                   data.PROW(false, 7, data.PrintVerticalLine2());
                   data.PROW(false, 10, Tools.isNull(dr["no_perk"], "").ToString().Trim());
                   data.PROW(false, 24, data.PrintVerticalLine2());
                   data.PROW(false, 26, Tools.isNull(dr["uraian"], "").ToString().Trim());
                   data.PROW(false, 96, data.PrintVerticalLine2());
               }
               data.PROW(true, 1, "===============================================================================================");
               data.Eject();

               if (File.Exists(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt"))
               {
                   File.Delete(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt");
               }               

               data.SendToTxt("NoPerk.txt", data.GenerateString());
               Process.Start(Properties.Settings.Default.OutputFile + "\\" + "NoPerk.txt");
               

           }
           catch (Exception ex)
           {
               Error.LogError(ex);
               MessageBox.Show(ex.Message);
           }
           
        }

        private DataTable ValidateFile(string fileName, DataTable table)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    table = Foxpro.ReadFile(fileName);

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                //MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }

        
        private void DownloadProcess()
        {
            //if (cekFile("KodeTmp.DBF"))
            //{
            //    string namaFile = "KodeTmp.DBF";
            //    string sp = "[psp_GL_DownloadPerkiraanKoneksiKode]";
            //    string[] param = { "@Kode", "@Uraian", "@LastUpdateBy" };
            //    string[] kolom = { "Kode", "Uraian", SecurityManager.UserID };
            //    DownloadData(namaFile, sp, param, kolom);
            //}

            if (cekFile("hKoneksiTmp.DBF"))
            {
                string namaFile = "hKoneksiTmp.DBF";
                string sp = "[psp_GL_DownloadPerkiraanKoneksi]";
                string[] param = { "@RecordID", "@Kode", "@Uraian", "@LastUpdateBy" };
                string[] kolom = { "RecordID", "Kode", "Uraian", SecurityManager.UserID };
                DownloadData(namaFile, sp, param, kolom);
            }

            //if (cekFile("dKoneksiTmp.DBF"))
            //{
            //    string namaFile = "dKoneksiTmp.DBF";
            //    string sp = "[psp_GL_DownloadPerkiraanKoneksiDetail]";
            //    string[] param = { "@RecordID", "@HRecordID", "@NoPerkiraan", "@Uraian", "@Mdl",
            //                        "@KodeTrn", "@KodeCabang", "@LastUpdatedBy"};
            //    string[] kolom = { "RecordID", "HRecordID", "No_PERK", "Uraian", "Mdl",
            //                        "KodeTrn", "KodeCabang",  SecurityManager.UserID};
            //    DownloadData(namaFile, sp, param, kolom);
            //} 

            //if (cekFile("NoPerkTmp.DBF")) 
            //{ 
            //    DownloadPerkiraan(); 
            //}

            //if (cekFile("DesignTmp.DBF"))
            //{
            //    DownloadReportDesign();
            //}

        }

        private bool cekFile(string namaFile) {
            string fileName = _tempPath + namaFile;
            DataTable result = ValidateFile(fileName, dtPerkiraan);
            if(result !=null) {
                return true;
            } else {
                return false;
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DownloadProcess();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
