using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.FTP;
using System.IO;
using ISA.Toko.Class;

//using ISA.Trading.DataTemplates;
//using Microsoft.Reporting.WinForms;
//using System.IO.Compression;


namespace ISA.Toko.CommunicatorISA
{
    public partial class frmDOAntarCabangUpload : ISA.Toko.BaseForm
    {
        #region "Global"
        string _hFileName = "Htjtmp";
        string _dFileName = "Dtjtmp";

        DataSet dsResult = new DataSet();        
        string Gudang;
        string cCab = GlobalVar.CabangID;
        int counter1 = 0;
        int counter2 = 0;

        #endregion

        public frmDOAntarCabangUpload()
        {
            InitializeComponent();
        }

        private void frmDOAntarCabangUpload_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now.Date;
            rangeDateBox1.ToDate = DateTime.Now.Date;
            lookupGudang1.GudangID = string.Empty;
            gridViewNotaPembelian.AutoGenerateColumns = true;
            gridViewNotaPembelianDetail.AutoGenerateColumns = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lookupGudang1.GudangID))
            {
                Gudang = string.Empty;
            }
            else
            {
                Gudang = lookupGudang1.GudangID;
            }
            RefreshData();
        }

        private void RefreshData()
        {
            pbUpload1.Value = 0;
            pbUpload2.Value = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_DOAntarCabang_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                    db.Commands[0].Parameters.Add(new Parameter("@Cab", SqlDbType.VarChar, cCab));
                    dsResult = db.Commands[0].ExecuteDataSet();

                    if(dsResult.Tables.Count > 0)
                    {
                        gridViewNotaPembelian.DataSource = dsResult.Tables[0];
                        gridViewNotaPembelianDetail.DataSource = dsResult.Tables[1];
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada");
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


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }


        /*private DataSet GetSyncData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_OrderPenjualan_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualan";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    counter1++;
                    pbUpload1.Minimum = 0;
                    pbUpload1.Maximum = ds.Tables[0].Rows.Count;
                    pbUpload1.Increment(1);
                }

                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("psp_UPLOAD_OrderPenjualanDetail_ISA"));
                db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, Gudang));
                dt = db.Commands[0].ExecuteDataTable();
                dt.TableName = "OrderPenjualanDetail";
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }
                foreach (DataRow dr2 in ds.Tables[1].Rows)
                {
                    counter2++;
                    pbUpload2.Minimum = 0;
                    pbUpload2.Maximum = ds.Tables[1].Rows.Count;
                    pbUpload2.Increment(1);
                }
            }
            return ds;
        }*/


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
                ZipFile(_hFileName, _dFileName);
                this.Cursor = Cursors.Default;
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang+Gudang + ".zip");


                /*this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();
                if (ds.Tables.Count > 0)
                {
                    string Target = lookupGudang1.GudangID; 
                    string fileOuput = FtpEngine.UploadDirectory + "\\" + "OPJ-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
                    if (FTP.FtpEngine.Upload(Target, fileOuput))
                    {

                        MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.UploadFailed);
                    }
                }
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
                }*/
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

        private void ZipFile(string FileName1, string FileName2)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            //string fileName3 = GlobalVar.DbfUpload + "\\" + FileName3 + ".dbf";
            //string fileName4 = GlobalVar.DbfUpload + "\\" + FileName4 + ".dbf";
            //string fileIndex = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            //string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";

            string fileZipName = GlobalVar.DbfUpload + "\\" + GlobalVar.Gudang+Gudang + ".zip";
            files.Add(fileName1);
            files.Add(fileName2);
            //files.Add(fileName3);
            //files.Add(fileName4);
            //files.Add(fileIndex);

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1) && File.Exists(fileName2))
            {
                File.Delete(fileName1);
                File.Delete(fileName2);
                //File.Delete(fileName3);
                //File.Delete(fileName4);
                //File.Delete(fileIndex);
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

            fields.Add(new Foxpro.DataStruct("Cabang1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cabang2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cabang3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("NoRequest", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglRequest", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoDO", "No_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglDO", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoACCPiutang", "No_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglACCPiutang", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoSJ", "No_sj", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("HariKredit", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("KodeSales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Namatoko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("AlamatKirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("SumRpJual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("isClosed", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "No_dobo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglReorder", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("StatusBO", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("TransactionType", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("HariKirim", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("HariSales", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("NoACCPusat", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Cicil", "Cicil", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("SumRpJual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpJual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SumRpNet2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp2", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PotRp3", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("TglSJ", "tglsj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TglTrm", "tgltrm" , Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Rpfee1", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rpfee2", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("checker_1", "checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("checker_2", "checker_2", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("syncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0], pbUpload1);
        }

        private void Upload2(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            fields.Add(new Foxpro.DataStruct("HtrID", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("BarangID", "Id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("NamaStok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("SatJual", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Klp", "Klp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyRequest", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyDO", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtySJ", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyNota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyRetur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("HrgJual", "H_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Disc2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Disc3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 6));
            fields.Add(new Foxpro.DataStruct("Pot", "pot_rp", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("DiscFormula", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Hpokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("HppSolo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("QtyKoli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("KoliAwal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("KoliAkhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("NoKoli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
            fields.Add(new Foxpro.DataStruct("KetKoli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("NoACC", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idmatch", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("NBOPrint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Idkoreksi", "id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("TglSJ", "tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], pbUpload2);
        }

    }
}
