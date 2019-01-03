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

namespace ISA.Finance.GL
{
    public partial class frmUploadJournal : ISA.Finance.BaseForm
    {
        List<string> files = new List<string>();
        

        public frmUploadJournal()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUploadJournal_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
        }

        private void UploadJournal()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "JournalTmp.DBF"; 
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_Journal"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

            


            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idtrans", "idtrans", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_reff", "no_reff", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("src", "src", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));            
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, Physical, fields, dt);
        }

        private void UploadJournalDetail()
        {
            DataTable dt = new DataTable();
            string Physical = GlobalVar.DbfUpload + "\\" + "TransactTmp.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_GL_UPLOAD_JournalDetail"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();

            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtrans", "idtrans", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_perk", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("debet", "debet", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("kredit", "kredit", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("dk", "dk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("lsub", "lsub", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("hapus", "hapus", Foxpro.enFoxproTypes.Numeric, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "TransactTmp", fields, dt);
        }

        private void UploadProcess()
        {
            try
            {
                UploadJournal();
                UploadJournalDetail();
                ZipFile(files);
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\Journal_" + GlobalVar.Gudang + ".ZIP");

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\Journal_" + GlobalVar.Gudang + ".zip";

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

        private void cmdYes_Click(object sender, EventArgs e)
        {
            UploadProcess();
        }


    }
}
