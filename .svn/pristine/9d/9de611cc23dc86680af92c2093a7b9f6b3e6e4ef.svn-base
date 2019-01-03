using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using System.IO.Compression;

namespace ISA.Trading.Communicator
{
    public partial class frmAntargudangUpload : ISA.Trading.BaseForm
    {
#region "Global"
        string _hFileName = "Hagtmp";
        string _dFileName = "Dagtmp";
        string _MFileName = "Stoktmp";
        string _PFileName = "Parttmp";
        
        DataSet dsResult = new DataSet();
        DataTable dtUploadMaster, dtUploadPart;
        DateTime Date;
#endregion

#region "Function"
        public void RefreshData(DateTime date)
        {
            HeaderprogressBar.Value = 0;
            DetailprogressBar.Value = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                  

                    db.Commands.Add(db.CreateCommand("usp_AntarGudang_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime,date));
                    db.Commands[0].Parameters.Add(new Parameter("@drGudang", SqlDbType.VarChar , txtGudangAsal.GudangID));
                    db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar,lookupGudang.GudangID ));
                    dsResult = db.Commands[0].ExecuteDataSet();
                   
                    dataGridHeader.DataSource = dsResult.Tables[0];
                    dataGridDetail.DataSource = dsResult.Tables[1];

                 
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

        private void ZipFile(string FileName1, string FileName2, string FileName3, string FileName4)
        {
            List<string> files = new List<string>();
           
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".dbf";
            string fileName4 = GlobalVar.DbfUpload + "\\" + FileName4 + ".dbf";
            string fileIndex = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileName3);
            files.Add(fileName4);
            files.Add(fileIndex);
           
            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName)) 
            {
                File.Delete(fileZipName);
            }

             Zip.ZipFiles(files, fileZipName);

             if (File.Exists(fileName1) && File.Exists(fileName2) && File.Exists(fileIndex))
             {
                 File.Delete(fileName1);
                 File.Delete(fileName2);
                 File.Delete(fileName3);
                 File.Delete(fileName4);
                 File.Delete(fileIndex);
             }

           
        }

        private void Upload1(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RecordID", "Idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("DrGudang", "Dr_gud", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("KeGudang", "Ke_gud", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("TglKirim", "Tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglTerima", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoAG", "No_ag", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Pengirim", "Pengirim", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Penerima", "Penerima", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("DrCheck1", "Drcheck1", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("DrCheck2", "Drcheck2", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("KeCheck1", "Kecheck1", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("KeCheck2", "Kecheck2", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("expedisi", "Exp", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("NoKendaraan", "No_kend", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("NamaSopir", "Nm_sopir", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("KirimTerimaID", "Id_krmtrm", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("No_dobo", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Lbo", "Lbo", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("No_rq", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_rq", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));//tglkirim
            fields.Add(new Foxpro.DataStruct("No_do", "No_do", Foxpro.enFoxproTypes.Char, 7));//nomer ag
            fields.Add(new Foxpro.DataStruct("Tgl_do", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));//tgl_kirim
            fields.Add(new Foxpro.DataStruct("Tgl_sj", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0],HeaderprogressBar);

            /*update syncflag*/
            using (Database db = new Database())
            {
                string _recordID = dsResult.Tables[0].Rows[0]["RecordID"].ToString();
                db.Commands.Add(db.CreateCommand("usp_AntarGudangSyncFlag_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
                db.Commands[0].ExecuteNonQuery();
            }

        }

        private void Upload2(String FileName)
        {
           
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            
            fields.Add(new Foxpro.DataStruct("Iddkrmagud", "Iddkrmagud", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idhkrmagud", "Idhkrmagud", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Id_Brg", "Id_Brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char,73));
            fields.Add(new Foxpro.DataStruct("Qty_krm", "Qty_krm", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Qty_trm", "Qty_trm", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("HPP", "hpp", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("Ongkos", "Ongkos", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("drGud", "Drgud", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("keGud", "Kegud", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Tgl_krm", "Tgl_krm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Qty_do", "Qty_do", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("No_bodo", "No_bodo", Foxpro.enFoxproTypes.Char, 7));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idhkrmagud","IDHKRMAGUD"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1],DetailprogressBar,index);

            /*update syncflag*/
            for (int i = 0; i < dsResult.Tables[1].Rows.Count; i++)
            {
                string _recordID = dsResult.Tables[1].Rows[i]["Iddkrmagud"].ToString();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AntarGudangDetailSyncFlag_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        
        }

        private void Upload3(String FileName)
        {
            //for (int i = 0; i < dsResult.Tables[1].Rows.Count; i++)
            //{
            //    string barangid = dsResult.Tables[1].Rows[i]["Id_Brg"].ToString();
            //    using (Database db = new Database())
            //    {
            //        db.Commands.Add(db.CreateCommand("usp_MasterStok_UploadDBF"));
            //        db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
            //        dtUploadMaster = db.Commands[0].ExecuteDataTable();
            //    }
            //}

            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Bundle", "Bundle", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("KodeSolo", "Kodesolo", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("Kendaraan", "Kendaraan", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("NamaTertera", "Nm_tertera", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("PartNo", "Partno", Foxpro.enFoxproTypes.Char, 21));
            fields.Add(new Foxpro.DataStruct("Merek", "Merek", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Dibungkus", "Dibungkus", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("SumberDr", "Sumber_dr", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("ProsesID", "Idproses", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Material", "Material", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("SatJual", "Sat_jual", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("SatSolo", "Sat_solo", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("KodeRak", "Kd_rak", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("KodeRak1", "Kd_rak1", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("KodeRak2", "Kd_rak2", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("JB", "Jb", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("StatusPasif", "Lpasif", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("StokMin", "Stokmin", Foxpro.enFoxproTypes.Numeric, 9));
            fields.Add(new Foxpro.DataStruct("StokMax", "Stokmax", Foxpro.enFoxproTypes.Numeric, 9));
            fields.Add(new Foxpro.DataStruct("IsiKoli", "Isi_koli", Foxpro.enFoxproTypes.Numeric, 9));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[2], HeaderprogressBar);
        }

        private void Upload4(String FileName)
        {

            for (int i = 0; i < dsResult.Tables[1].Rows.Count; i++)
            {
                string barangid = dsResult.Tables[1].Rows[i]["Id_Brg"].ToString();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_StokPart_UploadDBF"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangid", SqlDbType.VarChar, barangid));
                    dtUploadPart = db.Commands[0].ExecuteDataTable();
                }
            }

            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("id_brg", "Id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("idrec", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("sat_jual", "Sat_jual", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("merek", "Merek", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("jenis", "Jenis", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("kelompok", "Kelompok", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("supplier", "Supplier", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("id_tr", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("r1", "R1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("r2", "R2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("r3", "R3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("r4", "R4", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("lpasif", "Lpasif", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("cash", "Cash", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("top10", "Top10", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("enduser", "Enduser", Foxpro.enFoxproTypes.Numeric, 6));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtUploadPart, HeaderprogressBar);
        }

        #endregion


        public frmAntargudangUpload()
        {
            InitializeComponent();
        }

        private void frmAntargudangUpload_Load(object sender, EventArgs e)
        {
            txtGudangAsal.Text = GlobalVar.Gudang;
            txtGudangAsal.GudangID = GlobalVar.Gudang;
           // Date = DateTime.Now;
            //txtTahun.Text = DateTime.Now.Year.ToString();
            //cboBulan.Text = DateTime.Now.Month.ToString();
            dataGridHeader.AutoGenerateColumns = true;
            dataGridDetail.AutoGenerateColumns = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            //dateTimePicker1.ShowUpDown = true;
            //cboBulan.Focus();
        }

        private void lookupGudang_SelectData(object sender, EventArgs e)
        {

           
            if (Tools.Left(lookupGudang.GudangID.ToString(),2) != Tools.Left(GlobalVar.CabangID.ToString(),2))
            {
                MessageBox.Show("Hanya Antar Cabang !");
                this.DialogResult = DialogResult.OK;
                lookupGudang.NamaGudang = "";
                lookupGudang.GudangID = "";
                lookupGudang.Focus();
                return;
            }


        }

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim()=="")
            {
                lookupGudang.GudangID = "";
                lookupGudang.KodeCabang = "";
            }
        }

        //private void cmdUpload_Click(object sender, EventArgs e)
        //{
        //    if (dsResult.Tables.Count == 0)
        //    {
        //        cmdSearch.PerformClick();
        //        return;
        //    }

        //    if (dsResult.Tables[0].Rows.Count == 0 || dsResult.Tables[1].Rows.Count == 0)
        //    {
        //        MessageBox.Show("Tidak data yang diupload");
        //        return;
        //    }

        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        Upload1(_hFileName);
        //        Upload2(_dFileName);
        //        Upload3(_MFileName);
        //        Upload4(_PFileName);
        //        ZipFile(_hFileName, _dFileName, _MFileName, _PFileName);
        //        this.Cursor = Cursors.Default;
        //        MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\dbfmatch.zip");
        //        //DisplayReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        Error.LogError(ex);
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}

        private void cmdSearch_Click(object sender, EventArgs e)
        {
        
            if (lookupGudang.GudangID=="")
            {
                lookupGudang.Focus();
                return;
            }
            //Date = new DateTime(Convert.ToInt32(txtTahun.Text), Convert.ToInt32(cboBulan.Text), 1);
            Date = dateTimePicker1.Value;
            RefreshData(Date);

        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count == 0)
            {
                cmdSearch.PerformClick();
                return;
            }

            if (dsResult.Tables[0].Rows.Count == 0 || dsResult.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("Tidak data yang diupload");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Upload1(_hFileName);
                Upload2(_dFileName);
                Upload3(_MFileName);
                Upload4(_PFileName);
                ZipFile(_hFileName, _dFileName, _MFileName, _PFileName);
                this.Cursor = Cursors.Default;
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\dbfmatch.zip");
                //DisplayReport();
                for (int i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    string recordid = dsResult.Tables[0].Rows[i]["RecordID"].ToString();

                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_UPLOAD_AntarGudangUploadSynchFlag_ISA"));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, recordid));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    using (Database db = new Database())
                    {
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("psp_UPLOAD_AntarGudangDetailUploadSynchFlag_ISA"));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, recordid));
                        db.Commands[0].ExecuteNonQuery();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
