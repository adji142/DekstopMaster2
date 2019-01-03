using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Common;

namespace ISA.Finance.Register
{
    public partial class frmUploadDownloadTagihan : ISA.Finance.BaseForm
    {
        List<string> files = new List<string>();
        string fileZipName = GlobalVar.DbfDownload + "\\KAS" + GlobalVar.Gudang + ".zip";
        string _tempPath;
        protected DataTable
        dtTagihan,
        dtTagihanDetail,
        dtTagihanSubDetail;

        public frmUploadDownloadTagihan()
        {
            InitializeComponent();
        }

        private void UploadTagihan()
        {
            DataSet ds = new DataSet();
            string Physical = GlobalVar.DbfUpload + "\\" + "TmpHTag.DBF";
            files.Add(Physical);
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            string Physical2 = GlobalVar.DbfUpload + "\\" + "TmpDTag.DBF";
            files.Add(Physical2);
            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }

            string Physical3 = GlobalVar.DbfUpload + "\\" + "TmpDKun.DBF";
            files.Add(Physical3);
            if (File.Exists(Physical3))
            {
                File.Delete(Physical3);
            }


            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("psp_KASIR_UPLOAD_TagihanOnly"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                ds = db.Commands[0].ExecuteDataSet();

            }

            
            label2.Text = "Tagihan";
            label2.Refresh();
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("no_reg", "no_reg", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("tgl_reg", "tgl_reg", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("colector", "colector", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("n_nota", "n_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("n_bayar", "n_bayar", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("n_tagih", "n_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("wilayah", "wilayah", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("periode_1", "periode_1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("periode_2", "periode_2", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("t_lama", "t_lama", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("nm_kasir", "nm_kasir", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("rp_tunai", "rp_tunai", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("lbr_giro", "lbr_giro", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("ntoko1", "ntoko1", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("ntoko2", "ntoko2", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("lbr_nota", "lbr_nota", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("rp_only", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("tgl_kbl", "tgl_kbl", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 3));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpHTag", fields, ds.Tables[0], progressBar1);

            //TAGIHAN DETAIL

            label2.Text = "TagihanDetail";
            label2.Refresh();
            List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();
            fields2.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("id_reg", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("idkp", "idkp", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("idwil", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("nama_toko", "nama_toko", Foxpro.enFoxproTypes.Char, 31));
            fields2.Add(new Foxpro.DataStruct("kd_sales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields2.Add(new Foxpro.DataStruct("tgl_tr", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("no_tr", "no_tr", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("tgl_jt", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("rp_nota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_bayar", "rp_bayar", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_tagih", "rp_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("p_lama", "p_lama", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_giro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_cash", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_trf", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_mutasi", "rp_mutasi", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_pot", "rp_pot", Foxpro.enFoxproTypes.Numeric, 10));
            fields2.Add(new Foxpro.DataStruct("rp_disc", "rp_disc", Foxpro.enFoxproTypes.Numeric, 10));
            fields2.Add(new Foxpro.DataStruct("rp_retur", "rp_retur", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("no_bpp", "no_bpp", Foxpro.enFoxproTypes.Char, 10));
            fields2.Add(new Foxpro.DataStruct("rp_only", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
            fields2.Add(new Foxpro.DataStruct("rp_exp", "rp_exp", Foxpro.enFoxproTypes.Numeric, 12));
            fields2.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("tgl_tagih", "tgl_tagih", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("flag", "flag", Foxpro.enFoxproTypes.Logical, 1));
            fields2.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 30));
            fields2.Add(new Foxpro.DataStruct("idtagih", "idtagih", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("nm_coll", "nm_coll", Foxpro.enFoxproTypes.Numeric, 10));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDTag", fields2, ds.Tables[1], progressBar1);

            //TAGIHAN SUB DETAIL
            label2.Text = "TagihanSubDetail";
            label2.Refresh();
            List<Foxpro.DataStruct> fields3 = new List<Foxpro.DataStruct>();
            fields3.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("iddrec", "iddrec", Foxpro.enFoxproTypes.Char, 23));
            fields3.Add(new Foxpro.DataStruct("tanggal", "tanggal", Foxpro.enFoxproTypes.DateTime, 8));
            fields3.Add(new Foxpro.DataStruct("ket", "ket", Foxpro.enFoxproTypes.Char, 60));
            fields3.Add(new Foxpro.DataStruct("rp_ind", "rp_ind", Foxpro.enFoxproTypes.Numeric, 14));
            fields3.Add(new Foxpro.DataStruct("idmatch", "idmatch", Foxpro.enFoxproTypes.Char, 1));

            Foxpro.WriteFile(GlobalVar.DbfUpload, "TmpDKun", fields3, ds.Tables[2], progressBar1);


        }

        private void DownloadTagihan()
        {

            string fileName = _tempPath + "TmpHTag.DBF";

            DataTable result = ValidateFile(fileName, dtTagihan);

            if (result != null)
            {
                label2.Text = "Tagihan";
                label2.Refresh();
                int total = result.Rows.Count;
                progressBar1.Maximum = total;
                progressBar1.Value = 0;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_Tagihan"));
                    foreach (DataRow dr in result.Rows)
                    {
                        progressBar1.Increment(1);

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, Tools.isNull(dr["no_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglReg", SqlDbType.DateTime, Tools.isNull(dr["tgl_reg"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKembali", SqlDbType.DateTime, Tools.isNull(dr["tgl_kbl"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@CollectorID", SqlDbType.VarChar, Tools.isNull(dr["colector"], "")));
                        db.Commands[0].Parameters.Add(new Parameter("@Wilayah", SqlDbType.VarChar, (Tools.isNull(dr["wilayah"], ""))));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode1", SqlDbType.DateTime, (Tools.isNull(dr["periode_1"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Periode2", SqlDbType.DateTime, (Tools.isNull(dr["periode_2"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@TLama", SqlDbType.Money, Tools.isNull(dr["t_lama"], "0").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kasir", SqlDbType.VarChar, ISA.Common.Tools.isNullOrEmpty(dr["nm_kasir"].ToString().Trim(), "")));
                        db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                    }

                }
            }
        }

        private void DownloadTagihanDetail()
        {

            string fileName = _tempPath + "TmpDTag.DBF";

            DataTable result = ValidateFile(fileName, dtTagihanDetail);
            int total = result.Rows.Count;
            progressBar1.Maximum = total;
            progressBar1.Value = 0;
            if (result != null)
            {
                label2.Text = "TagihanDetail";
                label2.Refresh();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TagihanDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        progressBar1.Increment(1);
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["id_reg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, Tools.isNull(dr["idkp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.Bit, Tools.isNull(dr["flag"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglInden", SqlDbType.DateTime, Tools.isNull(dr["tgl_tagih"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_nota"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_bayar"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpTagih", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_tagih"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "0").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();


                    }

                }
            }
        }

        private void DownloadTagihanSubDetail()
        {

            string fileName = _tempPath + "TmpDKun.DBF";

            DataTable result = ValidateFile(fileName, dtTagihanSubDetail);
            int total = result.Rows.Count;
            progressBar1.Maximum = total;
            progressBar1.Value = 0;
            if (result != null)
            {
                label2.Text = "TagihanDetail";
                label2.Refresh();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TagihanSubDetail"));
                    foreach (DataRow dr in result.Rows)
                    {
                        progressBar1.Increment(1);
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TanggalKunjung", SqlDbType.DateTime, Tools.isNull(dr["tanggal"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RpInd", SqlDbType.Money, int.Parse(Tools.isNull(dr["rp_ind"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["idmatch"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                }
            }
        }



        private void UploadProcess()
        {
            try
            {
                UploadTagihan();
                ZipFile(files);
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\KAS" + GlobalVar.Gudang + ".ZIP");

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

        private void DownloadProcess()
        {
            _tempPath = GlobalVar.DbfDownload + "\\KAS" + GlobalVar.Gudang + "\\";

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
                DownloadTagihan();
                DownloadTagihanDetail();
                DownloadTagihanSubDetail();

                //Deleted Record
                //ExecDelete();
                MessageBox.Show(Messages.Confirm.ProcessFinished);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ZipFile(List<string> files)
        {


            string fileZipName = GlobalVar.DbfUpload + "\\KAS" + GlobalVar.Gudang + ".zip";

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
            this.Cursor = Cursors.WaitCursor;
            label2.Visible = true;

            if (rdoUpload.Checked)
            {
                UploadProcess();
            }
            else if (rdoDownload.Checked)
            {
                DownloadProcess();
            }
            else
            {
                MessageBox.Show("Tentukan Pilihan !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
            label2.Visible = false;
        }

        private void rdoUpload_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoUpload.Checked==true)
                rangeDateBox1.Enabled = true;
            else
                rangeDateBox1.Enabled = false;
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

        private void frmUploadDownloadTagihan_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            rangeDateBox1.ToDate = DateTime.Today;
        }

    }
}
