using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Trading.Class;
using System.IO;
using ISA.DAL;
using System.Data.OleDb;

namespace ISA.Trading.Communicator
{
    //Created By: Iwan, 19 August 2011
    public partial class frmUploadPajak : ISA.Trading.BaseForm
    {
        string fileZipName = Application.StartupPath + "\\UPLPT\\UPLPT.ZIP";
        string fileHeader = "TMPHTRJ";
        string fileDetail = "TMPDTRJ";
        string fileUploadZip = GlobalVar.DbfUpload + "\\UPLFA.ZIP";
        int lCabang = 1;
        int nCabang = 1;
        string idTransaction = string.Empty;

        DataSet dsResult;

        public frmUploadPajak()
        {
            InitializeComponent();
        }

        private void UnzipDatabaseTemplate()
        {
            if (File.Exists(fileZipName))
            {
                Zip.UnZipFiles(fileZipName, GlobalVar.DbfUpload, false);
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                UnzipDatabaseTemplate();
                UploadHeader();
                UploadDetail();
                ZipFile();
                MessageBox.Show("Upload selesai. Lokasi file: " + fileUploadZip);
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

        private void UploadHeader()
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("idhtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("cab1", "cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("cab2", "cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("cab3", "cab3", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("no_rq", "no_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_rq", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_do", "no_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_do", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_nota", "no_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_nota", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("no_sj", "no_sj", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_trm", "tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("hr_krdt", "hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("nm_toko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("al_kirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("rp_jual", "rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_jual2", "rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_jual3", "rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_net", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_net2", "rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_net3", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("pot_rp2", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("pot_rp3", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("rp_fee1", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("rp_fee2", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Laudit", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Memo, 10));
            fields.Add(new Foxpro.DataStruct("catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("catatan2", "catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("catatan3", "catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("catatan4", "catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("tgl_strm", "tgl_strm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tgl_reord", "tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("lbo", "lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("id_link", "id_link", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("id_tr", "id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("hari_krm", "hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("hari_sls", "hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("shift", "shift", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("checker_1", "checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("checker_2", "checker_2", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("cab0", "cab0", Foxpro.enFoxproTypes.Char, 2));

            Foxpro.CreateDBFForUPLPT(GlobalVar.DbfUpload + "\\", fileHeader, fields, dsResult.Tables[0], pbUpload1);
        }

        private void UploadDetail()
        {
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

            Foxpro.CreateDBFForUPLPT(GlobalVar.DbfUpload + "\\", fileDetail, fields, dsResult.Tables[1], pbUpload2);
        }

        private void ZipFile()
        {
            List<string> files = new List<string>();

            files.Add(GlobalVar.DbfUpload + "\\" + fileHeader + ".dbf");
            files.Add(GlobalVar.DbfUpload + "\\" + fileHeader + ".fpt");
            files.Add(GlobalVar.DbfUpload + "\\" + fileDetail + ".dbf");

            if (File.Exists(fileUploadZip))
            {
                File.Delete(fileUploadZip);
            }

            Zip.ZipFiles(files, fileUploadZip);

            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeUpload.FromDate == null || rangeUpload.ToDate == null)
            {
                rangeUpload.Focus();
                return;
            }
            
            if (!string.IsNullOrEmpty(cbUpload.Text))
            {

                pbUpload1.Value = 0;
                pbUpload2.Value = 0;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_UPLPT_UPLOAD"));
                        db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeUpload.FromDate));
                        db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeUpload.ToDate));
                        db.Commands[0].Parameters.Add(new Parameter("@initCab", SqlDbType.VarChar, GlobalVar.CabangID));
                        db.Commands[0].Parameters.Add(new Parameter("@initPer", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                        db.Commands[0].Parameters.Add(new Parameter("@Pos", SqlDbType.Int, cbPos.Checked == true ? 1 : 0));
                        db.Commands[0].Parameters.Add(new Parameter("@idTr", SqlDbType.VarChar, idTransaction));
                        db.Commands[0].Parameters.Add(new Parameter("@lCabang", SqlDbType.Int, lCabang));
                        dsResult = db.Commands[0].ExecuteDataSet();

                        if (dsResult.Tables[0].Rows.Count > 0)
                        {
                            gvUpload1.DataSource = dsResult.Tables[0];
                            gvUpload2.DataSource = dsResult.Tables[1];
                            cmdUpload.Enabled = true;
                        }
                        else
                        {
                            gvUpload1.DataSource = null;
                            gvUpload2.DataSource = null;
                            cmdUpload.Enabled = false;
                            MessageBox.Show("Tidak ada data");
                            rangeUpload.Focus();
                        }
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
            else
            {
                MessageBox.Show("Tujuan upload tidak boleh kosong");
                cbUpload.Focus();
            }
        }

        private void frmUploadPajak_Load(object sender, EventArgs e)
        {
            gvUpload1.AutoGenerateColumns = true;
            gvUpload2.AutoGenerateColumns = true;
            isiDataPerusahaan();
        }

        private void isiDataPerusahaan()
        { 
            using (Database db = new Database())
            {
                cbUpload.Items.Add(GlobalVar.PerusahaanName);

                db.Commands.Add(db.CreateCommand("usp_PT_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                DataTable dt = db.Commands[0].ExecuteDataTable();
                
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cbUpload.Items.Add(dr["Nama"].ToString());
                        idTransaction = dr["TransactionType"].ToString();
                        nCabang++;
                    }
                }
            }
        }

        private void cbUpload_Leave(object sender, EventArgs e)
        {
            if (nCabang == 1)
            {
                idTransaction = "ALL";
                lCabang = 1;
            }
            else
            {
                if (cbUpload.Text.Equals(GlobalVar.PerusahaanName))
                {
                    lCabang = 1;
                }
                else
                {
                    lCabang = 0;
                }
            }
        }
    }
}
