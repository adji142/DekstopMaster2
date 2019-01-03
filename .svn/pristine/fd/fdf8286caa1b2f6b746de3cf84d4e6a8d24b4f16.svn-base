using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace ISA.Trading
{
    public partial class frmDebug2 : ISA.Trading.BaseForm
    {
        
        public frmDebug2()
        {
            InitializeComponent();
        }

        private void frmDebug2_Load(object sender, EventArgs e)
        {
            this.RefreshData();
            maskedTextBox1.Mask = "00-00-0000";
            maskedTextBox1.AllowPromptAsInput = true;
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(validateTes);
        }

        void validateTes(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid date";
                toolTip1.Show("Format tanggal dd-MM-yyyy", maskedTextBox1, maskedTextBox1.Location, 5000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Char.ConvertFromUtf32(205).ToString();
            WriteToFile("C:\\Temp\\test.txt", "Í");

        }

        private void WriteToFile(string fullFileName, string contents)
        {


            //set up a filestream
            FileStream fs = new
            FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text

            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream

            sw.BaseStream.Seek(0, SeekOrigin.Begin);

            //add the text 
            sw.Write(contents);
            //sw.WriteLine(contents);
            //add the text to the underlying filestream

            sw.Flush();
            //close the writer
            sw.Close();


        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dt;
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

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Tab)
            //{
            //    Control ctrl = (Control)sender;
            //    while (!(ctrl is BaseForm))
            //    {
            //        ctrl = ctrl.Parent;
            //    }
            //    this.SelectNextControl(ctrl, true, false, true, true);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (customGridView1.SelectedCells.Count > 0)
            //{
            //    textBox1.Text = customGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
            //}

            if (customGridView1.SelectedCells.Count > 0)
            {
                textBox1.Text = customGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "\0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string _connStrTemplate = "Provider = VFPOLEDB;Data Source={0}";
            

            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    // Get incompleted Job
                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 0));
                    dt = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("usp_FoxproInjection_UPDATE"));

                    // Loop for each incompleted job
                    if (dt.Rows.Count > 0)
                    {
                        string connDatabaseStr = string.Format(_connStrTemplate, @"\\SAS2008\database$");
                        string connKasirStr = string.Format(_connStrTemplate, @"\\SAS2008\kasir$");

                        using (OleDbConnection connDatabase = new OleDbConnection(connDatabaseStr), connKasir = new OleDbConnection(connKasirStr))
                        {
                            connDatabase.Open();
                            connKasir.Open();
                            //Create Commands
                            OleDbCommand cmdDatabase = new OleDbCommand();
                            cmdDatabase.Connection = connDatabase;

                            OleDbCommand cmdKasir = new OleDbCommand();
                            cmdKasir.Connection = connKasir;

                            foreach (DataRow dr in dt.Rows)
                            {
                                string script = dr["Script"].ToString();
                                //inject to foxpro                                                                    
                                if (dr["Target"].ToString().ToUpper() == "KASIR")
                                {
                                    cmdKasir.CommandText = script;
                                    cmdKasir.CommandType = CommandType.Text;
                                    cmdKasir.ExecuteNonQuery();
                                }
                                else
                                {
                                    cmdDatabase.CommandText = script;
                                    cmdDatabase.CommandType = CommandType.Text;
                                    cmdDatabase.ExecuteNonQuery();
                                }
                                
                                //Update table FoxproInjection, set complete to true
                                db.Commands[1].Parameters.Clear();
                                db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dr["RowID"]));
                                db.Commands[1].Parameters.Add(new Parameter("@complete", SqlDbType.Bit, 1));
                                db.Commands[1].Parameters.Add(new Parameter("@runDate", SqlDbType.DateTime, DateTime.Now));
                                db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, "ISA.WinServices"));
                                db.Commands[1].ExecuteNonQuery();                                
                            }
                            connDatabase.Close();
                            connKasir.Close();
                        }                        
                    }
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        

            
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = monthYearBox1.FirstDateOfMonth;
            rangeDateBox1.ToDate = monthYearBox1.LastDateOfMonth;


        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            int a, b,M,Y;
            int w1=0,w2 = 0;
            a = (int)monthYearBox1.FirstDateOfMonth.Day;
            b = (int)monthYearBox1.LastDateOfMonth.Day;

            r1.FromDate = monthYearBox1.FirstDateOfMonth;
            r5.ToDate = monthYearBox1.LastDateOfMonth;

            M = (int)monthYearBox1.LastDateOfMonth.Month;
            Y=(int)monthYearBox1.LastDateOfMonth.Year;
            bool f = false; bool t = false;
            string hari = string.Empty;
            DateTime jam = DateTime.Now;
            for (int i = a; i <= b;i++ )
            {
                jam = new DateTime(Y, M, i);
                hari = jam.DayOfWeek.ToString();
                if (hari=="Monday")
                {
                    w1++;
                    f = true;
                }else if (hari=="Monday")
                {

                }
                    if (f)
                    {
                        switch (w1)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                        f = false;
                    }

                    if (t)
                    {
                        switch (w2)
                        {
                            case 1:
                                rangeDateBox1.ToDate = jam;
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                        t= false;
                    }
               
            }

           
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            DataTable dti =new DataTable();
            dti = dta.GetChanges(DataRowState.Deleted);

            
            dta.AcceptChanges();


        }

        private void cheksum_Click(object sender, EventArgs e)
        {
              OpenFileDialog openFileDialog1 = new OpenFileDialog();
             Stream myStream = null;
            openFileDialog1.InitialDirectory = GlobalVar.DbfDownload;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    myStream.Dispose();
                    string files = openFileDialog1.FileName;
                    openFileDialog1.Dispose();
                    lblcheksum.Text = GetMD5HashFromFile(files);
                 }
            }
        }


        protected string GetMD5HashFromFile(string fileName)
        {
          FileStream file = new FileStream(fileName, FileMode.Open);
          MD5 md5 = new MD5CryptoServiceProvider();
          byte[] retVal = md5.ComputeHash(file);
          file.Close();
          ASCIIEncoding enc = new ASCIIEncoding();
          return enc.GetString(retVal);
        }

        List<string> files = new List<string>();

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

 
        #region Collector
        private void UploadCollector()
        {
            SqlDataReader dr;
            string FileName = "TmpCol" + GlobalVar.CabangID;

            string TableName = "Collector";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Collector' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("CollectorID", "id_colect", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("Kode", "kd_colec", Foxpro.enFoxproTypes.Char, 31));
                fields.Add(new Foxpro.DataStruct("Nama", "nm_colec", Foxpro.enFoxproTypes.Char, 60));
                fields.Add(new Foxpro.DataStruct("TglLahir", "tgl_lahir", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("Alamat", "alamat", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("Target", "target", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("BatasOD", "batas_od", Foxpro.enFoxproTypes.Char, 20));
                fields.Add(new Foxpro.DataStruct("TglMasuk", "tgl_masuk", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("TglKeluar", "tgl_keluar", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("BarangA", "barang_a", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("BarangB", "barang_b", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("BarangC", "barang_c", Foxpro.enFoxproTypes.Numeric, 13));
                fields.Add(new Foxpro.DataStruct("BarangE", "barang_e", Foxpro.enFoxproTypes.Numeric, 3));
  
                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("kd_toko", "KODE_TOKO"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_Collector"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
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
        #endregion


        #region Stok
        private void UploadStok()
        {
            SqlDataReader dr;
            string FileName = "StkTmp" + GlobalVar.CabangID;

            string TableName = "Stok";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Stok' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Bundle", "bundel", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("KodeSolo", "kodesolo", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HrgJual", "hjual", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Hpp", "hpp", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Kendaraan", "kendaraan", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("NamaTertera", "nm_tertera", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("PartNo", "partno", Foxpro.enFoxproTypes.Char, 21));
                fields.Add(new Foxpro.DataStruct("Merek", "merek", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("Dibungkus", "dibungkus", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SumberDr", "sumber_dr", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("ProsesID", "idproses", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SatSolo", "sat_solo", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Material", "material", Foxpro.enFoxproTypes.Char, 19));
                fields.Add(new Foxpro.DataStruct("SatJual", "sat_jual", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hpp_solo", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HPPSas", "hpp_sas", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HPPSolo", "hppsolo", Foxpro.enFoxproTypes.Numeric, 8));
                fields.Add(new Foxpro.DataStruct("KodeRak", "kd_rak", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KodeRak1", "kd_rak1", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("KodeRak2", "kd_rak2", Foxpro.enFoxproTypes.Char, 7));
                fields.Add(new Foxpro.DataStruct("JB", "jb", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("StatusPasif", "lpasif", Foxpro.enFoxproTypes.Logical, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("Flag1", "flag1", Foxpro.enFoxproTypes.Char, 2));
                fields.Add(new Foxpro.DataStruct("TglOpname", "tgl_opnm", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("TglAwal", "tgl_awal", Foxpro.enFoxproTypes.DateTime, 8));
                fields.Add(new Foxpro.DataStruct("QAwal", "q_awal", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("HariRataRata", "q_opnm", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("RppAwal", "rpp_awal", Foxpro.enFoxproTypes.Numeric, 12));
                fields.Add(new Foxpro.DataStruct("QJual", "q_jual", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QBeli", "q_beli", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QReturJual", "q_retj", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QReturBeli", "q_retb", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QOrderJual", "q_ordj", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("PrediksiLamaKirim", "q_ordb", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QMutasi", "q_mutasi", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QKrsi", "q_krsi", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QAngd", "q_angd", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QSelisih", "q_slsh", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("QAkhir", "q_akhir", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("StokMin", "stokmin", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("StokMax", "stokmax", Foxpro.enFoxproTypes.Numeric, 9));
                fields.Add(new Foxpro.DataStruct("IsiKoli", "isi_koli", Foxpro.enFoxproTypes.Numeric, 4));

                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_Stok"));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
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
        #endregion

        #region Tagihan

        private void UploadTagihan()
        {
            SqlDataReader dr;
            string FileName = "HTagihan" + GlobalVar.CabangID;

            string TableName = "Tagihan";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'Tagihan' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "id_reg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NoReg", "no_reg", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("TglReg", "tgl_reg", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("TglKembali", "tgl_kbl", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("CollectorID", "nm_coll", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Wilayah", "wilayah", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("Periode1", "periode_1", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("Periode2", "periode_2", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("TLama", "t_lama", Foxpro.enFoxproTypes.Char, 21));
                fields.Add(new Foxpro.DataStruct("Kasir", "nm_kasir", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Char, 1));
                fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 3));
               
                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_Tagihan"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
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
        #endregion

        #region TagihanDetail
        private void UploadTagihanDetail()
        {
            SqlDataReader dr;
            string FileName = "DTagihan" + GlobalVar.CabangID;

            string TableName = "TagihanDetail";
            label1.Text = TableName;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                pbSyncUpload.Value = 0;
                lblProgress.Text = "Data 'TagihanDetail' is Uploading...";
                refreshForm();
                string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
                //string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
                //files.Add(Indexing);
                files.Add(Physical);

                if (File.Exists(Physical))
                {
                    File.Delete(Physical);
                }

                List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

                fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("HRecordID", "id_reg", Foxpro.enFoxproTypes.Char, 23));
                fields.Add(new Foxpro.DataStruct("KPRecID", "idkp", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("Flag", "flag", Foxpro.enFoxproTypes.Char, 73));
                fields.Add(new Foxpro.DataStruct("TglInden", "tgl_tagih", Foxpro.enFoxproTypes.Char, 3));
                fields.Add(new Foxpro.DataStruct("RpNota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("RpBayar", "rp_bayar", Foxpro.enFoxproTypes.Numeric, 7));
                fields.Add(new Foxpro.DataStruct("RpTagih", "rp_tagih", Foxpro.enFoxproTypes.Char, 43));
                fields.Add(new Foxpro.DataStruct("Keterangan", "ket", Foxpro.enFoxproTypes.Char, 43));
               
                List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
                //index.Add(new Foxpro.IndexStruct("idrec", "ID_REC"));

                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_UPLOAD_TagihanDetail"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    db.Open();
                    dr = db.Commands[0].ExecuteReader();
                    Foxpro.WriteReaderToFile(GlobalVar.DbfUpload + "\\", FileName, fields, dr, index, this, pbSyncUpload, lblUploadCount);
                    db.Close();
                    lblProgress.Text = "";
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
        #endregion

    }
}
