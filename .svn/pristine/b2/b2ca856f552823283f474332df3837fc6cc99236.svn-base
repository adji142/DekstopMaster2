using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
//using ISA.Controls;
using System.IO;
using ISA.Common;


namespace ISA.Finance.DKNForm
{
    public partial class frmUploadDKN : ISA.Finance.BaseForm
    {
        List<string> files = new List<string>();

        DataTable dt = new DataTable();

        public frmUploadDKN()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate != null && rangeDateBox1.ToDate != null)
            {
                RefreshData();
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_UploadDKN_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                //dt.DefaultView.Sort = "NamaToko, KodeToko, TglAktif";
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }        

        private void Upload()
        {
            string Physical = GlobalVar.DbfUpload + "\\" + "datahi.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("Tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoDKN", "no_dkn", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("DK", "dk", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Cabang", "cabang", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("HRecordID", "idhead", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("CD", "cd", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Src", "src", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("RecordID", "iddetail", Foxpro.enFoxproTypes.Char, 25));
            fields.Add(new Foxpro.DataStruct("NoPerkiraan", "no_perk", Foxpro.enFoxproTypes.Char, 12));
            fields.Add(new Foxpro.DataStruct("Uraian", "uraian", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("Jumlah", "jumlah", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("Dari", "dari", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Tolak", "ltolak", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Alasan", "alasan", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("HrowID", "HrowID", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("dtRowID", "dtRowID", Foxpro.enFoxproTypes.Char, 50));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "datahi", fields, dt, pbUpload);
        }


        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\DKN_" + GlobalVar.Gudang + ".zip";

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

        private void frmUploadDKN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void UpdateSyncFlag()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Upload_DKN"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                try
                {                    
                    Upload();
                    UpdateSyncFlag();
                    ZipFile(files);
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\datahi.dbf");
                    //DisplayReport();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

       

        
       



    }
}
