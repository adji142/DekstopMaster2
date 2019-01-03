using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Common;
using ISA.DAL;
using System.IO;




namespace ISA.Finance.VWil
{
    public partial class frmRiwayatIDWilUpload : ISA.Finance.BaseForm
    {
        DataTable dt = new DataTable();
        List<string> files = new List<string>();
        int _countTable = 0;
        int _countRow = 0;

        public frmRiwayatIDWilUpload()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                files.Clear();
                UploadProcess();
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\WIL" + GlobalVar.CabangID + ".zip");
                lblTableName.Visible = false;
                lblCountRow.Visible = false;
                _countTable = 0;
                RefreshCounter();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadProcess()
        {
            lblTableName.Visible = true;
            lblCountRow.Visible = true;
            UploadReIDWil(); RefreshCounter();
            ZipFile(files);
        }

        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\WIL" + GlobalVar.CabangID + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }


        private void RefreshCounter()
        {

            _countRow = 0;
        }

        private void UploadReIDWil()
        {
            SqlDataReader dr;
            lblTableName.Text = "ReWilID Is Uploading";
            string TableName = "ReIDWil";
            string FileName = "wiltmp";
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";

            files.Add(Physical);
            files.Add(Indexing);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("id_rec", "id_rec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("oldwil", "oldwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("lrefresh", "lrefresh", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            
            //fields.Add(new Foxpro.DataStruct("rp_crd", "rp_crd", Foxpro.enFoxproTypes.Numeric, 14));
            //fields.Add(new Foxpro.DataStruct("rp_dbt", "rp_dbt", Foxpro.enFoxproTypes.Numeric, 14));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("id_rec", "id_rec"));


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_VWIL_Upload"));
                db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));              
                db.Open();
                dr = db.Commands[0].ExecuteReader();
                Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, progressBar1, lblCountRow);
                
                db.Close();
                lblTableName.Text = "";
            }

            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, TableName));
                db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                DataTable dt = db.Commands[0].ExecuteDataTable();
                Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "idtr");
            }
        }
    }
}
