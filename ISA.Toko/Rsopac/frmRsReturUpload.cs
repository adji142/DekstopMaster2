using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Toko.Class;
using System.Data.SqlClient;

namespace ISA.Toko.Rsopac
{
    public partial class frmRsReturUpload : ISA.Toko.BaseForm
    {

        DataSet dsResult = new DataSet();
        string FileName1 = "Hrj2tmp";
        string FileName2 = "Drj2tmp";
        string FileName = "DtjTmp";

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1;
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2;
            string fileName3 = GlobalVar.DbfUpload + "\\" + FileName;
            //string fileName3 = GlobalVar.DbfUpload + "\\" + FileName1 + ".FPT";

            string fileZipName = GlobalVar.DbfUpload + "\\" + "DBFMATCH.zip";
                //+ GlobalVar.Gudang + lookupGudang.GudangID + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1+".dbf");
            files.Add(fileName2 + ".dbf");
            files.Add(fileName1 + ".cdx");
            files.Add(fileName2 + ".cdx");
            files.Add(fileName3 + ".dbf");
            files.Add(fileName3 + ".cdx");
            //files.Add(fileName3);

            Zip.ZipFiles(files, fileZipName);


            foreach (string s in files)
            {
                if (File.Exists(s))
                {
                    File.Delete(s);
                }
            }

        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RsOpac_UPLOAD_ReturPenjualan_C1"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, GlobalVar.CabangID));
                    dsResult = db.Commands[0].ExecuteDataSet();

                    gvUpload1.DataSource = dsResult.Tables[0];
                    gvUpload2.DataSource = dsResult.Tables[1];

                    pbUpload1.Value = 0;
                    pbUpload2.Value = 0;
                }

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
       
        private void UploadNotaPenjualanDetail()
        {
            ProgressBar pbSyncUpload = new ProgressBar();
            TextBox lblProgress = new TextBox();
            Label lbll = new Label();
            lbll.Text = "";
            SqlDataReader dr;
            DataRow[] drr = dsResult.Tables[1].Select("kategori='1' AND iddtr<>''");

            pbSyncUpload.Value = 0;
            pbSyncUpload.Maximum = drr.Length;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'NotaPenjualanDetail' is Uploading...";
               // refreshForm();
                string Physical =  FileName + ".dbf";
                string Indexing = FileName + ".cdx";
              
                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("klp", "Klp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("j_rq", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("j_do", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("j_sj", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("j_nota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("j_koli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("j_retur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("koli_awal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("koli_akhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("no_koli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
                fields.Add(new Foxpro.DataStruct("satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("h_jual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("h_pokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("hpp_solo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("id_koreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("no_bodo", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("ket_koli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[psp_RSOPAC_UPLOAD_Retur_NotaPenjualanDetail]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.Char, GlobalVar.CabangID));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, progressBar1, lbll);
                    db.Close();
                  
                }

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DeletedHistory_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, "NotaPenjualanDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Int, 0));
                    DataTable dt = db.Commands[0].ExecuteDataTable();
                    Foxpro.InsertDeletedRecord(GlobalVar.DbfUpload + "\\", FileName, fields, dt, "idrec");
                }
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
            string Physical1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string Physical2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string Physical3 = GlobalVar.DbfUpload + "\\" + FileName1 + ".cdx";
            string Physical4 = GlobalVar.DbfUpload + "\\" + FileName2 + ".cdx";

            if (File.Exists(GlobalVar.DbfUpload + "\\" + FileName + ".cdx"))
            {
                File.Delete(GlobalVar.DbfUpload + "\\" + FileName + ".cdx");
            }

            if (File.Exists(GlobalVar.DbfUpload + "\\" + FileName + ".dbf"))
            {
                File.Delete(GlobalVar.DbfUpload + "\\" + FileName + ".dbf");
            }
            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }

            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }

            if (File.Exists(Physical3))
            {
                File.Delete(Physical3);
            }

            if (File.Exists(Physical4))
            {
                File.Delete(Physical4);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("cab1", "cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("cab2", "cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("idretur", "idretur", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_memo", "no_memo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("no_ret", "no_ret", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("no_tolak", "no_tolak", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_memo", "tgl_memo", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_ret", "tgl_ret", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_tolak", "tgl_tolak", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("nm_toko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("al_kirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("pngmbln", "pngmbln", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("tgl_pngmb", "tgl_pngmb", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_gudang", "tgl_gudang", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("rp_nilai1", "rp_nilai1", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_nilai2", "rp_nilai2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_nilai3", "rp_nilai3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_nilai", "rp_nilai", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("bag_penj", "bag_penj", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("penerima", "penerima", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("dt_link", "dt_link", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("laudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("tgl_rqret", "tgl_rqret", Foxpro.enFoxproTypes.DateTime, 8));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idretur", "IDRETUR"));
            

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName1, fields, dsResult.Tables[0], pbUpload1,index);


            List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();
            fields2.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("idretur", "idretur", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("idhtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("iddtr", "iddtr", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("kdretur", "kdretur", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields2.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields2.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("asalnota", "asalnota", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("klp", "klp", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("q_memo", "q_memo", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("q_tarik", "q_tarik", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("q_terima", "q_terima", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("q_gudang", "q_gudang", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("q_tolak", "q_tolak", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("h_jual", "h_jual", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("h_net1", "h_net1", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("h_net2", "h_net2", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("h_net3", "h_net3", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("h_net", "h_net", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("h_pokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("hpp_solo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 8));
            fields2.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("id_koreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 30));
            fields2.Add(new Foxpro.DataStruct("catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 30));
            fields2.Add(new Foxpro.DataStruct("tgl_gudang", "tgl_gudang", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("kategori", "kategori", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
            fields2.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 6));

            List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
            index2.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

            
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName2, fields2, dsResult.Tables[1], pbUpload2,index2);

        }

        public frmRsReturUpload()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (SecurityManager.IsAOperator())
            {
                MessageBox.Show("Bagian operator tidak mempunyai hak akses untuk melakukan upload nota ke 11", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (rangeNota.FromDate != null && rangeNota.ToDate != null && !string.IsNullOrEmpty(lookupGudang.GudangID))
                {
                    RefreshData();

                    cmdUpload.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Tanggal Nota/Kode gudang tidak boleh kosong", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables[0].Rows.Count > 0 && dsResult.Tables[1].Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    UploadNotaPenjualanDetail();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + lookupGudang.GudangID + ".zip");
                
                    cmdUpload.Enabled = false;
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

        private void frmRsRetur_Load(object sender, EventArgs e)
        {
            rangeNota.FromDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            rangeNota.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(+1).AddDays(-1);
            gvUpload1.AutoGenerateColumns = true;
            gvUpload2.AutoGenerateColumns = true;
        }
    }
}
