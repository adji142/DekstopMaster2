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
using System.Data.SqlClient;

namespace ISA.Finance.GL
{
    public partial class frmDownloadPerkiraanKoneksi : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        List<string> files = new List<string>();
        string fileZipName = GlobalVar.DbfDownload + "\\NoPerk.zip";
        string _tempPath;
        protected DataTable dtPerkiraan;
        int _count1;

        public frmDownloadPerkiraanKoneksi()
        {
            InitializeComponent();
        }

        private void frmDownloadPerkiraanKoneksi_Load(object sender, EventArgs e)
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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DownloadProcess();
        }

        private void LoadData()
        {
            //dt.Columns.Add(new DataColumn("Nomor", typeof(System.Int32)));
            //dt.Columns.Add(new DataColumn("Nama", typeof(System.String)));
            //dt.Columns.Add(new DataColumn("Count", typeof(System.Int32)));

            //AddRow(1, "PerkiraanKoneksiKode", 0);
            //AddRow(2, "PerkiraanKoneksi", 0);
            //AddRow(3, "PerkiraanKoneksiDetail", 0);
            //gridUpload.DataSource = dt;
        }

        private void AddRow(int no, string name, int count)
        {
            //DataRow dr = dt.NewRow();
            //dr["Nomor"] = no;
            //dr["Nama"] = name;
            //dr["Count"] = count;
            //dt.Rows.Add(dr);
        }


        private void DownloadProcess()
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
            }
            else
            {
                MessageBox.Show("File : " + fileZipName + " tidak ditemukan !");
                return;
            }

            try
            {
                DownloadKoneksiKode();
                DownloadKoneksiHeader();
                DownloadKoneksiDetail();

                //DownloadStaff();
                //DownloadBank();
                //DownloadKasbon(); // Field Status Diisi Apa ????
                //DownloadInden();
                //DownloadVoucherJurnal();
                //DownloadKartuPiutang();
                //DownloadTransferBank();
                //DownloadIndenDetail();
                //DownloadVoucherJournalDetail();
                //DownloadBBM();
                //DownloadGiro();
                //DownloadTransferBankDetail();
                //DownloadBankDetail();
                //DownloadBukti();
                //DownloadBuktiDetail();
                //DownloadPinjamanPegawai();
                //DownloadIndenSubDetail();
                //DownloadGiroTolak();
                //DownloadTagihan();
                //DownloadTagihanDetail();
                //DownloadIndenSuperDetail();
                //DownloadKartuPiutangDetail();
                //DownloadGiroTolakDetail();
                //DownloadTagihanSubDetail();
                //DownloadBBK();
                //DownloadGiroInternal();

                ////Deleted Record
                //ExecDelete();
                MessageBox.Show(Messages.Confirm.ProcessFinished);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void DownloadKoneksiKode()
        {
            string fileName = _tempPath + "KodeTmp.DBF";
            DataTable result = ValidateFile(fileName, dt);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadPerkiraanKoneksiKode"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["Kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }


        private void DownloadKoneksiHeader()
        {
            string fileName = _tempPath + "HKoneksiTmp.DBF";
            DataTable result = ValidateFile(fileName, dt);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadPerkiraanKoneksi"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["RecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Tools.isNull(dr["Kode"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdateBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
            }
        }


        private void DownloadKoneksiDetail()
        {
            string fileName = _tempPath + "DKoneksiTmp.DBF";
            DataTable result = ValidateFile(fileName, dt);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_GL_DownloadPerkiraanKoneksiDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["RecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["HRecordID"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["No_Perk"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["Uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Mdl", SqlDbType.VarChar, Tools.isNull(dr["Mdl"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTrn", SqlDbType.VarChar, Tools.isNull(dr["KodeTrn"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, Tools.isNull(dr["KodeCabang"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
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
                MessageBox.Show("File: " + fileName + " tidak ditemukan !");
                table = null;
            }
            return table;
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
