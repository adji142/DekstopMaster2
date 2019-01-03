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
    public partial class frmRsDownload : ISA.Toko.BaseForm
    {
        DataSet dsResult = new DataSet();
        DataSet dsReport = new DataSet();
        DataTable dt = new DataTable();
        string _fileZipName,_folderZipName, _cabang,_tempPath = GlobalVar.DbfDownload;
        enum flag { OrderPenjualan = 0, NotaPenjualan };

        List<string> FileNames = new List<string>();
        List<string> files = new List<string>();

        DataTable tblHeader;
        DataTable tblDetail;
        DataTable tblLinkNota;
        DataTable tblHeaderRet;
        DataTable tblDetailRet;
        DataTable tblKoreksiPj;
        DataTable tblKoreksiRj;
        DataTable tblPotongan;


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
            files.Clear();
            FileNames.Clear();

            FileNames.Add("Hrjtmp"); //0
            FileNames.Add("drjtmp"); //1

            FileNames.Add("Hpjtmp");//2
            FileNames.Add("Dpjtmp");//3

            FileNames.Add("Pottmp");//4
            FileNames.Add("Kortmp");//5

            int i = 0;
            foreach (string s in FileNames)
            {
                files.Add(_folderZipName+ "\\" +FileNames[i].ToString()+ ".dbf");
                i++;
            }
           
        }

        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }


        public void RefreshData()
        {
            try
            {
            this.Cursor = Cursors.WaitCursor;
            Stream myStream = null;
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = _tempPath;
            openFileDialog1.Filter = "zip file ("+_fileZipName+".zip)|"+_fileZipName+".zip";
            MessageBox.Show("Refresh klick");

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("not ok1");
                return;
            }

                MessageBox.Show("ok nu");
                if ((myStream = openFileDialog1.OpenFile()) == null)
                {
                    return;
                }
                    _fileZipName = openFileDialog1.FileName;
                    MessageBox.Show(_fileZipName);

                    _folderZipName = _fileZipName.ToUpper().Replace(".ZIP", string.Empty);
                    MessageBox.Show(_folderZipName);

                    if (!Directory.Exists(_folderZipName))
                    {
                        Directory.CreateDirectory(_folderZipName);
                    }
                    else
                    {
                        string[] files = Directory.GetFiles(_folderZipName);
                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }
                    }


                    Zip.UnZipFiles(_fileZipName, _folderZipName, false);

                    initFiles();
                    LoadData();
                    comboBox1.SelectedIndex = 1;
                    gvUpload1.DataSource = dsResult.Tables[2];
                    gvUpload2.DataSource = dsResult.Tables[3];
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

        private void LoadData()
        {
            dsResult.Clear();
            dsResult = new DataSet();
            int i = 0;
            foreach (string s in files)
            {
                dsResult.Tables.Add(Foxpro.ReadFile(files[i].ToString())    );
                dsResult.Tables[i].TableName = FileNames[i].ToString();
                i++;
            }
        }

        private void ProsesDownload()
        {
            //DownloadNotaC2();
            //LinkNotaRsopac();
            //DownloadNota();
            //LinkNota();
            //DownloadReturPenjualan();
            //DownloadKoreksiPenjualan();
            //DownloadKoreksiReturPenjualan();
            //DownloadPenjualanPotongan();
        }

#region Nota
        private bool ValidateData(string param, int flag)
        {
            int retVal = 0;
            DataTable dt;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_CekData_DOWNLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@param", SqlDbType.VarChar, param));
                db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.Int, flag));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 1)
            {
                retVal = int.Parse(dt.Rows[0]["Result"].ToString());
            }

            return retVal == 1 ? true : false;
        }

        public void DownloadRsopac()
        {
            if (gvUpload1.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                try
                {
                    DownloadNotaRsopac();               // ok
                    LinkNotaRsopac();                   // ok
                    DownloadReturPenjualan();           // ok
                    DownloadKoreksiPenjualan();         // (-) langsung link ke piutang
                    DownloadKoreksiReturPenjualan();    // (-) langusng link ke piutang
                    DownloadPenjualanPotongan();        // (-) langusng link ke piutang        
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }


        public void DownloadNotaRsopac()
        {
            int counter1 = 0;
            int counter2 = 0;
            int flagRecord = 0;
            int flagRecordDo = 0;
            string cabang1 = string.Empty;
            string cabang2 = string.Empty;
            string htriId_np = string.Empty;
            string recordId_np = string.Empty;
            string idhtr = string.Empty;
            string idtr = string.Empty;

            pbUpload1.Value = 0;
            pbUpload1.Maximum = tblHeader.Rows.Count;
            //pbUpload1.Maximum = dsResult.Tables["Hpjtmp"].Rows.Count;
            
            pbUpload2.Value = 0;
            pbUpload2.Maximum = tblDetail.Rows.Count;
            //pbUpload2.Maximum = dsResult.Tables["Dpjtmp"].Rows.Count;

            if (pbUpload1.Maximum > 0)
            {
                int stat = 0;

                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_NP_DOWNLOAD"));

                        foreach (DataRow dr in tblHeader.Rows)
                        //foreach (DataRow dr in dsResult.Tables["Hpjtmp"].Rows)
                        {
                            cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                            cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                            htriId_np = Tools.isNull(dr["idhtr"], "").ToString().Trim();
                            recordId_np = Tools.isNull(dr["Idtr"], "").ToString().Trim();
                            idhtr = Tools.isNull(dr["Idhtr"], "").ToString().Trim();
                            idtr = Tools.isNull(dr["Idtr"], "").ToString().Trim();

                            if (cabang2 == Tools.Left(lookupGudang.GudangID, 2) && cabang1 == GlobalVar.CabangID)
                            {
                                if (ValidateData(idhtr, (int)flag.OrderPenjualan) == false)
                                {
                                }
                                else
                                {
                                    flagRecord = ValidateData(idtr, (int)flag.NotaPenjualan) == true ? 1 : 0;

                                    db.Commands[0].Parameters.Clear();
                                    db.Commands[0].Parameters.Add(new Parameter("@FlagRecord", SqlDbType.Int, flagRecord));
                                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, htriId_np));
                                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordId_np));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(dr["No_nota"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, Tools.isNull(dr["Tgl_nota"], DBNull.Value)));
                                    db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, Tools.isNull(dr["No_sj"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["Tgl_sj"], DBNull.Value)));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["Tgl_trm"], DBNull.Value)));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglSerahTerimaChecker", SqlDbType.DateTime, Tools.isNull(dr["Tgl_strm"], DBNull.Value)));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglExpedisi", SqlDbType.DateTime, Tools.isNull(dr["Tgl_reord"], DBNull.Value)));
                                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["Al_kirim"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["Laudit"], "0").ToString())));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["Catatan1"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["Catatan2"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["Catatan3"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["Catatan4"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["Catatan5"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["Id_link"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Nprint", SqlDbType.Int, int.Parse(Tools.isNull(dr["Nprint"], "0").ToString())));
                                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["Id_tr"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Checker1", SqlDbType.VarChar, Tools.isNull(dr["Checker_1"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Checker2", SqlDbType.VarChar, Tools.isNull(dr["Checker_2"], "").ToString().Trim()));
                                    /*Tamabahan*/
                                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString())));
                                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                                    /**/
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                    db.BeginTransaction();
                                    stat = Convert.ToInt32(db.Commands[0].ExecuteScalar());

                                    if (pbUpload2.Maximum > 0)
                                    {
                                        DataTable dtR = tblDetail.Copy();
                                        dtR.DefaultView.RowFilter = "idtr='" + recordId_np + "'";
                                        DataTable result = dtR.DefaultView.ToTable().Copy();
                                        if (result == null)
                                            return;

                                        db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_NPD_DOWNLOAD"));
                                        foreach (DataRow drd in result.Rows)
                                        {
                                            db.Commands[1].Parameters.Clear();
                                            db.Commands[1].Parameters.Add(new Parameter("@HtrID_NP", SqlDbType.VarChar, htriId_np));
                                            db.Commands[1].Parameters.Add(new Parameter("@RecordID_NP", SqlDbType.VarChar, recordId_np));
                                            db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Idrec"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(drd["Idtr"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(drd["Kd_gdg"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_sj"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_nota"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@QtyKoli", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_koli"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@KoliAwal", SqlDbType.Int, int.Parse(Tools.isNull(drd["Koli_awal"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@KoliAkhir", SqlDbType.Int, int.Parse(Tools.isNull(drd["Koli_akhir"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@NoKoli", SqlDbType.VarChar, Tools.isNull(drd["No_koli"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(drd["Catatan"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@KetKoli", SqlDbType.VarChar, Tools.isNull(drd["Ket_koli"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, Tools.isNull(drd["Nprint"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(Tools.isNull(drd["h_Jual"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_1"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_2"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_3"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(drd["pot_rp"], "0").ToString())));
                                            db.Commands[1].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                                            db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                            db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], "0").ToString())));

                                            db.Commands[1].ExecuteNonQuery();
                                            pbUpload2.Increment(1);
                                        }
                                        this.Refresh();
                                        this.Invalidate();
                                        Application.DoEvents();
                                        db.CommitTransaction();
                                    }
                                }
                                counter1++;
                                pbUpload1.Increment(1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DownloadNota()
        {
            int counter1 = 0;
            int counter2 = 0;
            int flagRecord = 0;
            int flagRecordDo = 0;
            string cabang1 = string.Empty;
            string cabang2 = string.Empty;
            string htriId_np = string.Empty;
            string recordId_np = string.Empty;
            string idhtr   = string.Empty;
            string idtr = string.Empty;
            pbUpload2.Value = 0;
            pbUpload2.Maximum = dsResult.Tables["Dpjtmp"].Rows.Count;

            pbUpload1.Value = 0;
            pbUpload1.Maximum = dsResult.Tables["Hpjtmp"].Rows.Count;

            MessageBox.Show("Sampai sini ok");

            //dtSudahDownload = dt1.Clone();
            //dtProses = dt1.Clone();
            //dtPJ2 = dt1.Clone();
            //dtNoDetail = dt1.Clone();
            int stat = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_NP_DOWNLOAD"));

                    foreach (DataRow dr in dsResult.Tables["Hpjtmp"].Rows)
                    {
                        cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                        cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                        htriId_np = Tools.isNull(dr["idhtr"], "").ToString().Trim();
                        recordId_np = Tools.isNull(dr["Idtr"], "").ToString().Trim();
                        idhtr = Tools.isNull(dr["Idhtr"], "").ToString().Trim();
                        idtr = Tools.isNull(dr["Idtr"], "").ToString().Trim();

                        if (cabang2 == Tools.Left(lookupGudang.GudangID, 2) && cabang1 == GlobalVar.CabangID)
                        {
                            if (ValidateData(idhtr, (int)flag.OrderPenjualan) == false)
                            {
                            }
                            else
                            {
                                flagRecord = ValidateData(idtr, (int)flag.NotaPenjualan) == true ? 1 : 0;

                                db.Commands[0].Parameters.Clear();
                                db.Commands[0].Parameters.Add(new Parameter("@FlagRecord", SqlDbType.Int, flagRecord));
                                db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, htriId_np));
                                db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, recordId_np));
                                db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, Tools.isNull(dr["No_nota"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, Tools.isNull(dr["Tgl_nota"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@NoSuratJalan", SqlDbType.VarChar, Tools.isNull(dr["No_sj"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["Tgl_sj"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["Tgl_trm"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@TglSerahTerimaChecker", SqlDbType.DateTime, Tools.isNull(dr["Tgl_strm"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@TglExpedisi", SqlDbType.DateTime, Tools.isNull(dr["Tgl_reord"], DBNull.Value)));
                                db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["Al_kirim"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["Kota"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["Laudit"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["Catatan1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["Catatan2"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["Catatan3"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["Catatan4"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["Catatan5"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["Id_link"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Nprint", SqlDbType.Int, int.Parse(Tools.isNull(dr["Nprint"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["Id_tr"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Checker1", SqlDbType.VarChar, Tools.isNull(dr["Checker_1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Checker2", SqlDbType.VarChar, Tools.isNull(dr["Checker_2"], "").ToString().Trim()));
                                /*Tamabahan*/
                                db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString())));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                                /**/
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.BeginTransaction();
                                stat = Convert.ToInt32(db.Commands[0].ExecuteScalar());

                                DataRow[] orderDetails = dsResult.Tables["Dpjtmp"].Select("idtr='" + dr["idtr"].ToString() + "'");

                                db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_NPD_DOWNLOAD"));
                                foreach (DataRow drd in orderDetails)
                                {
                                    db.Commands[1].Parameters.Clear();
                                    db.Commands[1].Parameters.Add(new Parameter("@HtrID_NP", SqlDbType.VarChar, htriId_np));
                                    db.Commands[1].Parameters.Add(new Parameter("@RecordID_NP", SqlDbType.VarChar, recordId_np));
                                    db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Idrec"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(drd["Idtr"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(drd["Kd_gdg"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_sj"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_nota"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@QtyKoli", SqlDbType.Int, int.Parse(Tools.isNull(drd["J_koli"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@KoliAwal", SqlDbType.Int, int.Parse(Tools.isNull(drd["Koli_awal"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@KoliAkhir", SqlDbType.Int, int.Parse(Tools.isNull(drd["Koli_akhir"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@NoKoli", SqlDbType.VarChar, Tools.isNull(drd["No_koli"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(drd["Catatan"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@KetKoli", SqlDbType.VarChar, Tools.isNull(drd["Ket_koli"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@NPackingListPrint", SqlDbType.VarChar, Tools.isNull(drd["Nprint"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(Tools.isNull(drd["h_Jual"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_1"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_2"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_3"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(drd["pot_rp"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], "0").ToString())));

                                    db.Commands[1].ExecuteNonQuery();
                                    pbUpload2.Increment(1);

                                    this.Refresh();
                                    this.Invalidate();
                                    Application.DoEvents();
                                }
                                //if (stat==1)
                                //{// buka sp na Comment yg foxpro n Uncomment yg isa
                                //    db.Commands.Add(db.CreateCommand("psp_PenjualanNotaC2_Download_link"));
                                //    db.Commands[2].Parameters.Clear();
                                //    db.Commands[2].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["Tgl_trm"], DBNull.Value)));
                                //    db.Commands[2].Parameters.Add(new Parameter("@RcordID", SqlDbType.VarChar, recordId_np));
                                //    db.Commands[2].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                                //    db.Commands[2].Parameters.Add(new Parameter("@Flag", SqlDbType.Int, flagRecord));

                                //    db.Commands[2].ExecuteNonQuery();
                                //}
                            }
                            counter1++;
                            pbUpload1.Increment(1);

                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                            db.CommitTransaction();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void LinkNotaRsopac()
        {
            try
            {
                string cabang1 = "";
                string cabang2 = "";
                string recordId_np = "";

                pbUpload2.Value = 0;
                pbUpload2.Maximum = tblHeader.Rows.Count;

                foreach (DataRow dr in tblHeader.Rows)
                //foreach (DataRow dr in dsResult.Tables["Hpjtmp"].Rows)
                {
                    cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                    cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                    recordId_np = Tools.isNull(dr["Idtr"], "").ToString();

                    if (cabang2 == Tools.Left(lookupGudang.GudangID, 2) && cabang1 == GlobalVar.CabangID && recordId_np.Trim() != "")
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_PenjualanNotaC2_Download_link"));
                            db.Commands[0].Parameters.Add(new Parameter("@RcordID", SqlDbType.VarChar, recordId_np));
                            db.Commands[0].Parameters.Add(new Parameter("@user", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    pbUpload2.Increment(1);
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();

                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {

            }
        }


        private void LinkNota()
        {
            try
            {
                string cabang1 = "";
                string cabang2 = "";
                string recordId_np = "";
                foreach (DataRow dr in dsResult.Tables["Hpjtmp"].Rows)
                {
                    cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                    cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                    recordId_np = Tools.isNull(dr["Idtr"], "").ToString();

                    if (cabang2 == Tools.Left(lookupGudang.GudangID, 2) && cabang1 == GlobalVar.CabangID && recordId_np.Trim() != "")
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_PenjualanNotaC2_Download_link"));
                            db.Commands[0].Parameters.Add(new Parameter("@RcordID", SqlDbType.VarChar, recordId_np));
                            db.Commands[0].Parameters.Add(new Parameter("@user", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {

            }
        }

#endregion

#region Retur

        public void DownloadReturPenjualan()
        {
            try
            {
                string cabang1 = "";
                string cabang2 = "";
                string recordId_np = "";

                //DataTable dtR = tblHeaderRet.Copy(); //dsResult.Tables["Hrjtmp"].Copy();
                //dtR.DefaultView.RowFilter = "Cab1='"+GlobalVar.CabangID+"' AND Cab2='"+Tools.Left(lookupGudang.GudangID, 2)+"'";
                //DataTable result =dtR.DefaultView.ToTable().Copy();
                //if (result == null)
                //    return;

                pbUpload1.Value = 0;
                pbUpload1.Maximum = tblHeaderRet.Rows.Count;

                pbUpload2.Value = 0;
                pbUpload2.Maximum = tblDetailRet.Rows.Count;

                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualan"));
                        foreach (DataRow dr in tblHeaderRet.Rows)
                        //foreach (DataRow dr in result.Rows)
                        {
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoMPR", SqlDbType.VarChar, Tools.isNull(dr["no_memo"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoNotaRetur", SqlDbType.VarChar, Tools.isNull(dr["no_ret"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoTolak", SqlDbType.VarChar, Tools.isNull(dr["no_tolak"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMPR", SqlDbType.DateTime, Tools.isNull(dr["tgl_memo"], DBNull.Value)));

                            db.Commands[0].Parameters.Add(new Parameter("@TglNotaRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_ret"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTolak", SqlDbType.DateTime, Tools.isNull(dr["tgl_tolak"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengambilan", SqlDbType.VarChar, Tools.isNull(dr["pngmbln"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglPengambilan", SqlDbType.DateTime, Tools.isNull(dr["tgl_pngmb"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@TglGudang", SqlDbType.DateTime, Tools.isNull(dr["tgl_gudang"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@BagPenjualan", SqlDbType.VarChar, Tools.isNull(dr["bag_penj"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));

                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dr["laudit"].ToString().Trim().Equals("False") ? 0 : 1));
                            db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, int.Parse(Tools.isNull(dr["nprint"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRQRetur", SqlDbType.DateTime, Tools.isNull(dr["tgl_rqret"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].ExecuteNonQuery();
                           
                            pbUpload1.Increment(1);
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                            
                        }
                    }

                    foreach (DataRow dr in tblHeaderRet.Rows)
                    //foreach (DataRow dr in result.Rows)
                    {
                        DownloadReturPenjualanDetail(dr["idretur"].ToString());
                    }

                
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Retur Penjualan \n" + ex.Message);
                Error.LogError(ex1);
            }
        }

        public void DownloadReturPenjualanDetail(string REturID_)
        {
            try
            {
                //DataTable dtR = dsResult.Tables["Drjtmp"].Copy();
                DataTable dtR = tblDetailRet.Copy();    // dsResult.Tables["Drjtmp"].Copy();
                dtR.DefaultView.RowFilter = "idretur='" + REturID_ + "'";
                DataTable result = dtR.DefaultView.ToTable().Copy();

                if (result != null)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ReturPenjualanDetail"));
                        foreach (DataRow dr in result.Rows)
                        {
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ReturID", SqlDbType.VarChar, Tools.isNull(dr["idretur"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NotaJualDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["iddtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, Tools.isNull(dr["kdretur"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyGudang", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_gudang"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_terima"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTarik", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_tarik"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyMemo", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_memo"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, int.Parse(Tools.isNull(dr["q_tolak"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, Tools.isNull(dr["kategori"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[0].Parameters.Add(new Parameter("@NotaAsal", SqlDbType.VarChar, Tools.isNull(dr["asalnota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.VarChar, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@Pot", SqlDbType.VarChar, double.Parse(Tools.isNull(dr["pot_rp"], "0").ToString().Trim())));
                            db.Commands[0].ExecuteNonQuery();
                            pbUpload2.Increment(1);
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();

                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ex1 = new Exception("Download Retur Penjualan Detail \n" + ex.Message);
                Error.LogError(ex1);
            }
        }
#endregion

#region Koreksi
        public void DownloadKoreksiPenjualan()
        {
            //pbUpload1.Value = 0;
            //pbUpload1.Maximum = dsResult.Tables["Kortmp"].Rows.Count;
            //DataTable result = dsResult.Tables["Kortmp"].Copy();

            DataTable result = tblKoreksiPj.Copy();
            DataRow[] results= result.Select("sumber='NPJ'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiPenjualan"));
                    foreach (DataRow dr in results)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NotaJualDetailRecID", SqlDbType.VarChar, (Tools.isNull(dr["id_detail"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        pbUpload1.Increment(1);
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                  
                }
            }
        }

        public void DownloadKoreksiReturPenjualan()
        {
            //DataTable result = dsResult.Tables["Kortmp"].Copy();
            DataTable result = tblKoreksiPj.Copy();
            DataRow[] results = result.Select("sumber='NRJ'");
            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_KoreksiReturPenjualan"));
                    foreach (DataRow dr in results)
                    {
                        string x = Tools.isNull(dr["id_detail"], "").ToString().Trim();
                        MessageBox.Show(x);

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@ReturJualDetailRecID", SqlDbType.VarChar, (Tools.isNull(dr["id_detail"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["no_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["id_brg"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        //db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, Tools.isNull(dr["sumber"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJualKoreksi", SqlDbType.Money, (Tools.isNull(dr["h_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, (Tools.isNull(dr["n_koreksi"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        pbUpload1.Increment(1);
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                    
                }
            }
        }

#endregion

#region Pot
        public void DownloadPenjualanPotongan()
        {

            //pbUpload2.Value = 0;
            //pbUpload2.Maximum = dsResult.Tables["Pottmp"].Rows.Count;
            //DataTable result = dsResult.Tables["Pottmp"].Copy();

            DataTable result = tblPotongan.Copy();

            if (result != null)
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_PenjualanPotongan"));
                    foreach (DataRow dr in result.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@TrID", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PotID", SqlDbType.VarChar, Tools.isNull(dr["Idpot"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoPot", SqlDbType.VarChar, (Tools.isNull(dr["Nopot"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TglPot", SqlDbType.DateTime, Tools.isNull(dr["Tgl_pot"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Dil", SqlDbType.Money, double.Parse(Tools.isNull(dr["Dil"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Disc", SqlDbType.Decimal, Decimal.Parse(Tools.isNull(dr["Disc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@RpNet", SqlDbType.Money, double.Parse(Tools.isNull(dr["Rp_net"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["Catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglACC", SqlDbType.DateTime, Tools.isNull(dr["Tgl_acc"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@DilACC", SqlDbType.Money, double.Parse(Tools.isNull(dr["Dil_acc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@CatACC", SqlDbType.VarChar, Tools.isNull(dr["Cat_acc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DiscACC", SqlDbType.Decimal, decimal.Parse(Tools.isNull(dr["Disc_acc"], 0).ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@IdLink", SqlDbType.VarChar, (Tools.isNull(dr["id_link"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusACC", SqlDbType.Bit, dr["acc"].Equals("1") ? 1 : 0));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                        pbUpload2.Increment(1);
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                        
                    }
                   
                }
            }
        }
#endregion


        public frmRsDownload()
        {
            InitializeComponent();
        }

        private void DisplayReport()
        {
            string periode="";
           // periode = String.Format("{0} s/d {1}", ((DateTime)rangeNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeNota.ToDate).ToString("dd/MM/yyyy"));

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

        private void frmRsDownload_Load(object sender, EventArgs e)
        {
            initCBO();
            gvUpload1.AutoGenerateColumns = true;
            gvUpload2.AutoGenerateColumns = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (lookupGudang.GudangID=="")
            {
                lookupGudang.Focus();
                return;
            }
            
            _fileZipName = lookupGudang.GudangID + GlobalVar.Gudang;
            //RefreshData();

            if (File.Exists(GlobalVar.DbfDownload + "\\" + _fileZipName+".zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\"+_fileZipName+".zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\"+_fileZipName+".zip tidak ada");
                return;
            }

            string fileNameH = "Hpjtmp.dbf";
            string fileNameD = "Dpjtmp.dbf";
            string fileRetjH = "Hrjtmp.dbf";
            string fileRetjD = "Drjtmp.dbf";
            string fileKorPj = "Kortmp.dbf";
            string filePotPj = "Pottmp.dbf";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;
            fileRetjH = GlobalVar.DbfDownload + "\\" + fileRetjH;
            fileRetjD = GlobalVar.DbfDownload + "\\" + fileRetjD;
            fileKorPj = GlobalVar.DbfDownload + "\\" + fileKorPj;
            filePotPj = GlobalVar.DbfDownload + "\\" + filePotPj;

            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cDownloaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    gvUpload1.DataSource = tblHeader;
                    //lblDownloadStatus1.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    //pbUpload1.Minimum = 0;
                    //pbUpload1.Maximum = tblHeader.Rows.Count;
                    this.Title = "Download Nota Penjualan";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameH + " tidak ada");
                return;
            }


            if (File.Exists(fileNameD))
            {
                try
                {
                    tblDetail = Foxpro.ReadFile(fileNameD);
                    DataColumn newcol = new DataColumn("cDownload");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblDetail.Columns.Add(newcol);

                    gvUpload2.DataSource = tblDetail;
                    //lblDownloadStatus2.Text = "0/" + tblDetail.Rows.Count.ToString("#,##0");
                    //pbUpload2.Minimum = 0;
                    //pbUpload2.Maximum = tblDetail.Rows.Count;
                    this.Title = "Download Nota Penjualan Detail";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameD + " tidak ada");
                return;
            }

            if (File.Exists(fileRetjH))
            {
                try
                {
                    tblHeaderRet = Foxpro.ReadFile(fileRetjH);
                    DataColumn newcol = new DataColumn("cDownloaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeaderRet.Columns.Add(newcol);

                    //gvUpload1.DataSource = tblHeaderRet;
                    //lblDownloadStatus1.Text = "0/" + tblHeaderRet.Rows.Count.ToString("#,##0");
                    //pbUpload1.Minimum = 0;
                    //pbUpload1.Maximum = tblHeaderRet.Rows.Count;
                    this.Title = "Download Retur Penjualan";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileRetjH + " tidak ada");
                return;
            }

            if (File.Exists(fileRetjD))
            {
                try
                {
                    tblDetailRet = Foxpro.ReadFile(fileRetjD);
                    DataColumn newcol = new DataColumn("cDownloaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblDetailRet.Columns.Add(newcol);

                    //gvUpload2.DataSource = tblDetailRet;
                    //lblDownloadStatus2.Text = "0/" + tblDetailRet.Rows.Count.ToString("#,##0");
                    //pbUpload2.Minimum = 0;
                    //pbUpload2.Maximum = tblDetailRet.Rows.Count;
                    this.Title = "Download Retur Penjualan Detail";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileRetjD + " tidak ada");
                return;
            }

            if (File.Exists(fileKorPj))
            {
                try
                {
                    tblKoreksiPj = Foxpro.ReadFile(fileKorPj);
                    DataColumn newcol = new DataColumn("cDownloaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblKoreksiPj.Columns.Add(newcol);

                    //gvUpload2.DataSource = tblDetailRet;
                    //lblDownloadStatus2.Text = "0/" + tblDetailRet.Rows.Count.ToString("#,##0");
                    //pbUpload2.Minimum = 0;
                    //pbUpload2.Maximum = tblKoreksiPj.Rows.Count;
                    this.Title = "Download Retur Penjualan Detail";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileKorPj + " tidak ada");
                return;
            }

            if (File.Exists(filePotPj))
            {
                try
                {
                    tblPotongan = Foxpro.ReadFile(filePotPj);
                    DataColumn newcol = new DataColumn("cDownloaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblPotongan.Columns.Add(newcol);

                    //gvUpload2.DataSource = tblDetailRet;
                    //lblDownloadStatus2.Text = "0/" + tblDetailRet.Rows.Count.ToString("#,##0");
                    //pbUpload2.Minimum = 0;
                    //pbUpload2.Maximum = tblPotongan.Rows.Count;
                    this.Title = "Download Retur Penjualan Detail";
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + filePotPj + " tidak ada");
                return;
            }
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
            //if (dsResult.Tables.Count>0)
            //if (tblHeader.Rows.Count > 0)
            //{
            //    try
            //    {
                    this.Cursor = Cursors.WaitCursor;
                    cmdUpload.Enabled = false;
                    DownloadRsopac(); 
                    //ProsesDownload();
                    MessageBox.Show(Messages.Confirm.ProcessFinished);
                   // DisplayReport();
                    
            //    }
            //    catch (Exception ex)
            //    {
            //        Error.LogError(ex);
            //    }
            //    finally
            //    {
            //        this.Cursor = Cursors.Default;
            //        cmdUpload.Enabled = true;
            //    }
            //}
            //else
           // {
            //    MessageBox.Show(Messages.Error.FailDownload);
           // }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
