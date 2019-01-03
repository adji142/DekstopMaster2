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

namespace ISA.Toko.Rsopac
{
    public partial class frmRsUpload : ISA.Toko.BaseForm
    {
        DataSet dsResult = new DataSet();
        DataSet dsReport = new DataSet();
        DataTable dt = new DataTable();
        List<string> FileNames = new List<string>();
        List<string> files = new List<string>();

        private void initCBO()
        {

            dt.Columns.Add("Nama");
            dt.Rows.Add("Retur");
            dt.Rows.Add("Nota");
            dt.Rows.Add("Pot");
            dt.Rows.Add("Kortrans");

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nama";
            comboBox1.ValueMember = "Nama";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initFiles()
        {
            FileNames.Add("Hrjtmp");
            FileNames.Add("drjtmp");

            FileNames.Add("Hpjtmp");
            FileNames.Add("Dpjtmp");

            FileNames.Add("Pottmp");
            FileNames.Add("Kortmp");

            foreach (string s in FileNames)
            {
                files.Add(GlobalVar.DbfUpload + "\\" + s + ".dbf");
            }
            //idx
            files.Add(GlobalVar.DbfUpload + "\\" + FileNames[0].ToString() + ".CDX");
            files.Add(GlobalVar.DbfUpload + "\\" + FileNames[1].ToString() + ".CDX");
            files.Add(GlobalVar.DbfUpload + "\\" + FileNames[2].ToString() + ".CDX");
            files.Add(GlobalVar.DbfUpload + "\\" + FileNames[3].ToString() + ".CDX");

            DelFile();
           
        }

        private void DelFile()
        {
            foreach (string s in files)
            {
                if (File.Exists(s))
                {
                    File.Delete(s);
                }
            }
        }

        private void ZipFile()
        {

            string fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + lookupGudang.GudangID + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            DelFile();
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RsOpac_UPLOAD_C1"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang.GudangID));
                    dsResult = db.Commands[0].ExecuteDataSet();

                    db.Commands.Add(db.CreateCommand("rsp_RsOpac_UPLOAD_C1"));
                    db.Commands[1].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeNota.FromDate));
                    db.Commands[1].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeNota.ToDate));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.Char, lookupGudang.GudangID));
                    dsReport = db.Commands[1].ExecuteDataSet();

                   
                }
                comboBox1.SelectedIndex = 0;
                gvUpload1.DataSource = dsResult.Tables[0];
                gvUpload2.DataSource = dsResult.Tables[1];

                pbUpload1.Value = 0;
                pbUpload2.Value = 0;

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
            DelFile();
#region "Retur"
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


            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[0].ToString(), fields, dsResult.Tables[0], pbUpload1, index);


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


            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[1].ToString(), fields2, dsResult.Tables[1], pbUpload2,index2);

#endregion
           
#region "Nota"
            List<Foxpro.DataStruct> fields3 = new List<Foxpro.DataStruct>();

            fields3.Add(new Foxpro.DataStruct("idhtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("cab1", "cab1", Foxpro.enFoxproTypes.Char, 2));
            fields3.Add(new Foxpro.DataStruct("cab2", "cab2", Foxpro.enFoxproTypes.Char, 2));
            fields3.Add(new Foxpro.DataStruct("cab3", "cab3", Foxpro.enFoxproTypes.Char, 2));
            fields3.Add(new Foxpro.DataStruct("no_rq", "no_rq", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("tgl_rq", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("no_do", "no_do", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("tgl_do", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("no_nota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("tgl_nota", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("no_sj", "no_sj", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("tgl_trm", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("hr_krdt", "hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields3.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields3.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields3.Add(new Foxpro.DataStruct("nm_toko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields3.Add(new Foxpro.DataStruct("al_kirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields3.Add(new Foxpro.DataStruct("kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields3.Add(new Foxpro.DataStruct("rp_jual", "rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("rp_jual2", "rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("rp_jual3", "rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("rp_net", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("rp_net2", "rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("rp_net3", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields3.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields3.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields3.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields3.Add(new Foxpro.DataStruct("pot_rp2", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields3.Add(new Foxpro.DataStruct("pot_rp3", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields3.Add(new Foxpro.DataStruct("rp_fee1", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
            fields3.Add(new Foxpro.DataStruct("rp_fee2", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
            fields3.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields3.Add(new Foxpro.DataStruct("Laudit", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields3.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields3.Add(new Foxpro.DataStruct("catatan2", "catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields3.Add(new Foxpro.DataStruct("catatan3", "catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields3.Add(new Foxpro.DataStruct("catatan4", "catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields3.Add(new Foxpro.DataStruct("catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields3.Add(new Foxpro.DataStruct("tgl_strm", "tgl_strm", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("tgl_reord", "tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("lbo", "lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields3.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields3.Add(new Foxpro.DataStruct("id_link", "id_link", Foxpro.enFoxproTypes.Char, 1));
            fields3.Add(new Foxpro.DataStruct("id_tr", "id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields3.Add(new Foxpro.DataStruct("hari_krm", "hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields3.Add(new Foxpro.DataStruct("hari_sls", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields3.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields3.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
            fields3.Add(new Foxpro.DataStruct("shift", "shift", Foxpro.enFoxproTypes.Char, 1));
            fields3.Add(new Foxpro.DataStruct("checker_1", "checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields3.Add(new Foxpro.DataStruct("checker_2", "checker_2", Foxpro.enFoxproTypes.Char, 11));
            fields3.Add(new Foxpro.DataStruct("cab0", "cab0", Foxpro.enFoxproTypes.Char, 2));

            List<Foxpro.IndexStruct> index3 = new List<Foxpro.IndexStruct>();
            index3.Add(new Foxpro.IndexStruct("idtr", "ID_TR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[2].ToString(), fields3, dsResult.Tables[2], pbUpload1,index3);


            List<Foxpro.DataStruct> fields4 = new List<Foxpro.DataStruct>();

            fields4.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields4.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields4.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields4.Add(new Foxpro.DataStruct("klp", "Klp", Foxpro.enFoxproTypes.Char, 3));
            fields4.Add(new Foxpro.DataStruct("j_rq", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("j_do", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("j_sj", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("j_nota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("j_koli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("j_retur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("koli_awal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("koli_akhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("no_koli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
            fields4.Add(new Foxpro.DataStruct("satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
            fields4.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
            fields4.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields4.Add(new Foxpro.DataStruct("h_jual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields4.Add(new Foxpro.DataStruct("h_pokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields4.Add(new Foxpro.DataStruct("hpp_solo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields4.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields4.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields4.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields4.Add(new Foxpro.DataStruct("id_koreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields4.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields4.Add(new Foxpro.DataStruct("no_bodo", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
            fields4.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields4.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields4.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
            fields4.Add(new Foxpro.DataStruct("ket_koli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));
            fields4.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields4.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));

            List<Foxpro.IndexStruct> index4 = new List<Foxpro.IndexStruct>();
            index4.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[3].ToString(), fields4, dsResult.Tables[3], pbUpload2,index4);
#endregion

#region "Potongan"
            List<Foxpro.DataStruct> fields5 = new List<Foxpro.DataStruct>();

            fields5.Add(new Foxpro.DataStruct("Idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields5.Add(new Foxpro.DataStruct("Idpot", "idpot", Foxpro.enFoxproTypes.Char, 23));
            fields5.Add(new Foxpro.DataStruct("NoPot", "Nopot", Foxpro.enFoxproTypes.Char, 11));
            fields5.Add(new Foxpro.DataStruct("Tgl_pot", "Tgl_pot", Foxpro.enFoxproTypes.DateTime, 8));
            fields5.Add(new Foxpro.DataStruct("Dil", "Dil", Foxpro.enFoxproTypes.Numeric, 8));
            fields5.Add(new Foxpro.DataStruct("Disc", "Disc", Foxpro.enFoxproTypes.Numeric, 5));
            fields5.Add(new Foxpro.DataStruct("Rp_net", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields5.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 17));
            fields5.Add(new Foxpro.DataStruct("Tgl_acc", "Tgl_acc", Foxpro.enFoxproTypes.DateTime, 8));
            fields5.Add(new Foxpro.DataStruct("Dil_acc", "Dil_acc", Foxpro.enFoxproTypes.Numeric, 11));
            fields5.Add(new Foxpro.DataStruct("Cat_acc", "Cat_acc", Foxpro.enFoxproTypes.Char, 17));
            fields5.Add(new Foxpro.DataStruct("Disc_acc", "Disc_acc", Foxpro.enFoxproTypes.Numeric, 5));
            fields5.Add(new Foxpro.DataStruct("Dib", "Dib", Foxpro.enFoxproTypes.Numeric, 8));
            fields5.Add(new Foxpro.DataStruct("Dib_acc", "Dib_acc", Foxpro.enFoxproTypes.Numeric, 10));
            fields5.Add(new Foxpro.DataStruct("Id_match", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields5.Add(new Foxpro.DataStruct("Id_link", "Id_link", Foxpro.enFoxproTypes.Char, 23));
            fields5.Add(new Foxpro.DataStruct("Kd_toko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields5.Add(new Foxpro.DataStruct("acc", "acc", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[4].ToString(), fields5, dsResult.Tables[4], pbUpload1);
#endregion
   
#region "Koreksi"
            List<Foxpro.DataStruct> fields6 = new List<Foxpro.DataStruct>();

            fields6.Add(new Foxpro.DataStruct("id_koreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields6.Add(new Foxpro.DataStruct("IdTr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields6.Add(new Foxpro.DataStruct("id_detail", "id_detail", Foxpro.enFoxproTypes.Char, 23));
            fields6.Add(new Foxpro.DataStruct("TglKoreksi", "tglkoreksi", Foxpro.enFoxproTypes.DateTime, 8));
            fields6.Add(new Foxpro.DataStruct("no_koreksi", "no_koreksi", Foxpro.enFoxproTypes.Char, 11));
            fields6.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields6.Add(new Foxpro.DataStruct("klp", "klp", Foxpro.enFoxproTypes.Char, 3));
            fields6.Add(new Foxpro.DataStruct("j_nota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields6.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
            fields6.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 40));
            fields6.Add(new Foxpro.DataStruct("h_jual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields6.Add(new Foxpro.DataStruct("h_pokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields6.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields6.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields6.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields6.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields6.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields6.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields6.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields6.Add(new Foxpro.DataStruct("Sumber", "sumber", Foxpro.enFoxproTypes.Char, 3));
            fields6.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields6.Add(new Foxpro.DataStruct("h_koreksi", "h_koreksi", Foxpro.enFoxproTypes.Numeric, 12));
            fields6.Add(new Foxpro.DataStruct("dt_link", "dt_link", Foxpro.enFoxproTypes.Char, 23));
            fields6.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
            fields6.Add(new Foxpro.DataStruct("n_koreksi", "n_koreksi", Foxpro.enFoxproTypes.Numeric, 6));
            fields6.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));

            //List<Foxpro.IndexStruct> index6 = new List<Foxpro.IndexStruct>();
            //index6.Add(new Foxpro.IndexStruct("id_koreksi", "ID_KOREKSI"));


            Foxpro.WriteFile(GlobalVar.DbfUpload, FileNames[5].ToString(), fields6, dsResult.Tables[5], pbUpload2);
#endregion

        }

        public frmRsUpload()
        {
            InitializeComponent();
        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeNota.ToDate).ToString("dd/MM/yyyy"));

            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));


            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(dsReport.Tables[0]);
            pTable.Add(dsReport.Tables[1]);
            pTable.Add(dsReport.Tables[2]);
            pTable.Add(dsReport.Tables[3]);
           


            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsSales_Data");
            pDatasetName.Add("dsSales_Data1");
            pDatasetName.Add("dsSales_Data2");
            pDatasetName.Add("dsSales_Data3");
            

            frmReportViewer ifrmReport = new frmReportViewer("Rsopac.rptRsOpac.rdlc", rptParams,pTable, pDatasetName);

            ifrmReport.Show();
        }

        private void frmRsUpload_Load(object sender, EventArgs e)
        {
            initCBO();
            rangeNota.FromDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            rangeNota.ToDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1).AddMonths(+1).AddDays(-1);
            gvUpload1.AutoGenerateColumns = true;
            gvUpload2.AutoGenerateColumns = true;
            
            initFiles();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (lookupGudang.GudangID=="")
            {
                lookupGudang.Focus();
                return;
            }
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count==0)
            {
                return;
            }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            gvUpload1.DataSource = dsResult.Tables[0];
                            gvUpload2.DataSource = dsResult.Tables[1];
                        }
                        break;
                    case 1:
                        {
                            gvUpload1.DataSource = dsResult.Tables[2];
                            gvUpload2.DataSource = dsResult.Tables[3];
                        }
                        break;
                    case 2:
                        {
                            gvUpload1.DataSource = dsResult.Tables[4];
                            gvUpload2.DataSource = null;
                        }
                        break;
                    case 3:
                        {
                            gvUpload1.DataSource = dsResult.Tables[5];
                            gvUpload2.DataSource = null;
                        }
                        break;
                }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count>0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    cmdUpload.Enabled = false;
                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang + lookupGudang.GudangID + ".zip");

                    DisplayReport();
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    cmdUpload.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
