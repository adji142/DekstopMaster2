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
    public partial class frmDownloadJournal : Form
    {
        string fileZipName = GlobalVar.DbfDownload + "\\Journal_" + GlobalVar.Gudang + ".zip";
        string _tempPath;
        protected DataTable
        dtJurnal;

        public frmDownloadJournal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadJournal_Load(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\jurnal\\";
            //MessageBox.Show(fileZipName);
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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DownloadProcess();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
        }

        private void DownloadProcess()
        {
            //MessageBox.Show("masuk DownloadProcess");
            // buat fungsi untuk mencek file yang berada di zip

            if (cekFile("JournalTmp.DBF"))
            {
               
                string namaFile = "JournalTmp.DBF";
                string sp = "[psp_GL_DownloadJournal]";
                string[] param = {"@idtrans", "@tanggal",
			                       "@no_reff", "@uraian","@src",
                                    "@kd_gdg", "@id_match","@LastUpdatedBy"};
                string[] kolom = {"idtrans", "tanggal",
			                       "no_reff", "uraian", "src", 
                                   "kd_gdg", "id_match",  SecurityManager.UserID};
                DownloadData(namaFile, sp, param, kolom);
            }
            else { MessageBox.Show("file JournalTmp tidak ditemukan"); return; }


            if (cekFile("TransactTmp.DBF"))
            {
                string namaFile = "TransactTmp.DBF";
                string sp = "[psp_GL_DownloadTransact]";
                string[] param = { "@idrec", "@idtrans",
			                        "@no_perk", "@Uraian", "@debet",
			                        "@kredit", "@dk", "@LastUpdatedBy"};
                string[] kolom = { "idrec", "idtrans",
			                        "no_perk", "Uraian", "debet",
			                        "kredit","dk", SecurityManager.UserID};
                DownloadData(namaFile, sp, param, kolom);
            }
            else { MessageBox.Show("file TransactTmp tidak ditemukan"); return; }
          
            
        }

         private bool cekFile(string namaFile) {
            string fileName = _tempPath + namaFile;
            
            DataTable result = ValidateFile(fileName, dtJurnal);
            if(result !=null) {
                return true;
            } else {
                return false;
            }
        }

        private void DownloadData(string namaFile, string sp, string[] param, string[] kolom)
        {


            string fileName = _tempPath + namaFile;
            DataTable result = ValidateFile(fileName, dtJurnal);

            if (result != null)
            {
                //MessageBox.Show(fileName + " 1 " + GlobalVar.DBName);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    //MessageBox.Show(result.Rows.Count.ToString());

                    db.Commands.Add(db.CreateCommand(sp));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    int z;
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        for (z = 0; z < param.Length; ++z)
                        {
                            string parameter = param[z];
                            string barisKolom = kolom[z];
                            if (SecurityManager.UserID == barisKolom)
                            {
                                //MessageBox.Show(barisKolom);
                                db.Commands[0].Parameters.Add(new Parameter(parameter, SqlDbType.VarChar, Tools.isNull(barisKolom, "").ToString().Trim()));
                            }
                            else
                            {
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
    }
}
