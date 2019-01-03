using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Toko.Class;
using ISA.DAL;
using System.IO;

//Created By    : Iwan, 12 August 2011

namespace ISA.Toko.Communicator
{
    public partial class frmBackOrderUpload : ISA.Toko.BaseForm
    {
        List<string> files = new List<string>();
        DataSet dsResult;

        public frmBackOrderUpload()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackOrderUpload_Load(object sender, EventArgs e)
        {
            txTglBO.FromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txTglBO.ToDate = DateTime.Today;
            cmdUpload.Enabled = false;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                UploadBO();
                ZipFile(files);
                cmdUpload.Enabled = false;
            }
            else
            {
                MessageBox.Show("Data tidak ada");
            }
        }

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void UploadBO()
        {
            SqlDataReader dr;
            string FileName = "Hhbotmp";
            string FileName2 = "Dhbotmp";
            
            try
            {
                this.Cursor = Cursors.WaitCursor;

                refreshForm();

                #region Header BO
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                string Fpt = GlobalVar.DbfUpload + "\\" + FileName + ".fpt";

                files.Add(Indexing);
                files.Add(Physical);
                files.Add(Fpt);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("idhtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
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
                fields.Add(new Foxpro.DataStruct("expedisi", "expedisi", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("laudit", "laudit", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Memo, 4));
                fields.Add(new Foxpro.DataStruct("catatan1", "catatan1", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("catatan2", "catatan2", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("catatan3", "catatan3", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("catatan4", "catatan4", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
                fields.Add(new Foxpro.DataStruct("no_dobo", "no_dobo", Foxpro.enFoxproTypes.Char, 7));
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

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                index.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));
                #endregion

                #region Detail BO
                string Physical2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
                string Indexing2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".cdx";

                files.Add(Indexing2);
                files.Add(Physical2);

                if (File.Exists(Physical2))
                {
                    File.Delete(Physical2);
                }

                List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

                fields2.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("idhtr", "idhtr", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("nama_stok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields2.Add(new Foxpro.DataStruct("klp", "klp", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("j_rq", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("j_do", "j_do", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("j_sj", "j_sj", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("j_nota", "j_nota", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("j_retur", "j_retur", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("j_koli", "j_koli", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("koli_awal", "koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("koli_akhir", "koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("no_koli", "no_koli", Foxpro.enFoxproTypes.Char, 15));
                fields2.Add(new Foxpro.DataStruct("satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
                fields2.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 23));
                fields2.Add(new Foxpro.DataStruct("tgl_sj", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
                fields2.Add(new Foxpro.DataStruct("h_jual", "h_jual", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("h_pokok", "h_pokok", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("hpp_solo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
                fields2.Add(new Foxpro.DataStruct("disc_1", "disc_1", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("disc_2", "disc_2", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("disc_3", "disc_3", Foxpro.enFoxproTypes.Numeric, 5));
                fields2.Add(new Foxpro.DataStruct("pot_rp", "pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
                fields2.Add(new Foxpro.DataStruct("id_disc", "id_disc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("id_koreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("kd_toko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
                fields2.Add(new Foxpro.DataStruct("no_bodo", "no_bodo", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields2.Add(new Foxpro.DataStruct("nprint", "nprint", Foxpro.enFoxproTypes.Numeric, 1));
                fields2.Add(new Foxpro.DataStruct("no_acc", "no_acc", Foxpro.enFoxproTypes.Char, 7));
                fields2.Add(new Foxpro.DataStruct("ket_koli", "ket_koli", Foxpro.enFoxproTypes.Char, 20));

                List<Foxpro.IndexStruct> index2 = new List<Foxpro.IndexStruct>();
                index2.Add(new Foxpro.IndexStruct("idhtr", "IDHTR"));
                #endregion

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_OrderPenjualan_UPLOAD_BO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txTglBO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txTglBO.ToDate));
                    db.Open();

                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbUpload1, lblUploadCount, false);
                    
                    if (dr.NextResult())
                    {
                        Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName2, fields2, dr, index2, this, pbUpload2, lblUploadCount, false);
                    }
                    dr.Close();
                    db.Close();
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_OrderPenjualan_UPLOAD_BO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, txTglBO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, txTglBO.ToDate));
                    dsResult = db.Commands[0].ExecuteDataSet();
                    
                    gvUpload1.DataSource = dsResult.Tables[0];
                    gvUpload2.DataSource = dsResult.Tables[1];

                    pbUpload1.Value = 0;
                    pbUpload2.Value = 0;
                    pbUpload1.Maximum = dsResult.Tables[0].Rows.Count;
                    pbUpload2.Maximum = dsResult.Tables[1].Rows.Count;

                    cmdUpload.Enabled = true;
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

        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\uplbo" + GlobalVar.CabangID + ".ZIP";

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

            MessageBox.Show("Upload BO selesai, lokasi file: " + fileZipName);
        }
    }
}
