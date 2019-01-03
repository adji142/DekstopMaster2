using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ISA.DAL;
using System.IO;
using ISA.Common;
using System.Windows.Forms;

namespace ISA.Finance.Kasir.Budget
{
    public partial class frmAccBiaya : ISA.Controls.BaseForm
    {
        enum enumModus { Upload, Download, Clear };
        enumModus Modus;
        List<string> files = new List<string>();
        string _downPath, _tempPath, fileZipName;
        protected DataTable dtAjuanAccBiaya;

        public frmAccBiaya()
        {
            InitializeComponent();
            rangeDateBox1.FromDate = DateTime.Today.AddDays(DateTime.Today.Day * -1 + 1);
            rangeDateBox1.ToDate = DateTime.Today;
        }

        private void btnTABEL_Click(object sender, EventArgs e)
        {
            frmPerkiraanAccBiaya ifrm = new frmPerkiraanAccBiaya();
            ifrm.Show();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAccBiaya_Load(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetEnable();
            IsiComboDownload();
            RefreshGrid();
        }

        private void rangeDateBox1_Leave(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #region functions
        private void RefreshGrid()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dgTransAccBiaya.DataSource = dt;
            }
        }
        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\ISA-AjuanACCBiaya.zip";
            if (File.Exists(fileZipName)) File.Delete(fileZipName);
            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str)) File.Delete(str);
            }
        }
        private void SetEnable()
        {
            panelDownload.Visible = Modus == enumModus.Download;
            cmdUPLOAD.Enabled = Modus == enumModus.Clear;
            cmdDOWNLOAD.Enabled = Modus == enumModus.Clear;
        }
        private void IsiComboDownload()
        {
            _downPath = GlobalVar.DbfDownload;
            string[] files = Directory.GetFiles(_downPath);
            List<string> ar = new List<string>();
            int n = 0;
            foreach (string file in files)
            {
                n = n + 1;
                ar.Add(file);
            }
            cboFiles.DataSource = ar;
            fileZipName = cboFiles.Text.ToString();
        }
        private void DownloadProses()
        {
            string fileName = _tempPath + "TransAccTmp.DBF";
            DataTable result = ValidateFile(fileName, dtAjuanAccBiaya);

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_AccBy_DownloadAjuan"));
                foreach (DataRow dr in result.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.VarChar, dr["RowID"].ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, dr["Keterangan"].ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoAcc", SqlDbType.VarChar, dr["NoAcc"].ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAcc", SqlDbType.Date, dr["TglAcc"]));
                    db.Commands[0].Parameters.Add(new Parameter("@UploadKe00", SqlDbType.Date, dr["UploadKe00"]));
                    db.Commands[0].ExecuteNonQuery();
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
        #endregion

        private void cmdUPLOAD_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "TransAccTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical)) File.Delete(Physical);
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@UploadKe11", SqlDbType.Date, DateTime.Today));
                dt = db.Commands[0].ExecuteDataTable();

            }
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("RowID", "RowID", Foxpro.enFoxproTypes.Char, 36));
            fields.Add(new Foxpro.DataStruct("CabangID", "CabangID", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglAjuan", "TglAjuan", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Transaksi", "Transaksi", Foxpro.enFoxproTypes.Char, 5));
            fields.Add(new Foxpro.DataStruct("NoPerk", "NoPerk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("NoBukti", "NoBukti", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("Uraian", "Uraian", Foxpro.enFoxproTypes.Char, 55));
            fields.Add(new Foxpro.DataStruct("Rp", "Rp", Foxpro.enFoxproTypes.Numeric, 17));
            fields.Add(new Foxpro.DataStruct("NoAcc", "NoAcc", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("TglAcc", "TglAcc", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 55));
            fields.Add(new Foxpro.DataStruct("UploadKe11", "UploadKe11", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("UploadKe00", "UploadKe00", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TransAccTmp", fields, dt);
            ZipFile(files);
            MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\ISA-AjuanACCBiaya.zip");

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_AccBy_Ajuan_UPLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.Date, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                db.Commands[0].Parameters.Add(new Parameter("@UploadKe11", SqlDbType.Date, DateTime.Today));
                db.Commands[0].Parameters.Add(new Parameter("@IsUpdate", SqlDbType.Bit, true));
                db.Commands[0].ExecuteNonQuery();
            }
            Modus = enumModus.Clear;
            RefreshGrid();
        }

        private void cmdDOWNLOAD_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Download;
            SetEnable();
        }

        private void cmdDownloadClose_Click(object sender, EventArgs e)
        {
            Modus = enumModus.Clear;
            SetEnable();
        }

        private void cmdDownloadGo_Click(object sender, EventArgs e)
        {
            _tempPath = GlobalVar.DbfDownload + "\\AccBiaya\\";
            if (!Directory.Exists(_tempPath)) Directory.CreateDirectory(_tempPath);
            else
            {
                string[] files = Directory.GetFiles(_tempPath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            Zip.UnZipFiles(fileZipName, _tempPath, false);

            DownloadProses();
            MessageBox.Show(Messages.Confirm.ProcessFinished);
            Modus = enumModus.Clear;
            SetEnable();
            RefreshGrid();
        }

    }
}
