using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;

namespace ISA.Finance.Piutang
{
    public partial class frmDownloadPiutang : ISA.Finance.BaseForm
    {
        string fileZipName = GlobalVar.DbfDownload + "\\APIMATCH.zip";
        string _tempPath;
        protected DataTable
        dtTokoToSales,
        dtKartuPiutangDetail,
        dtKartuPiutang,
        dtGiroTolakDetail,
        dtGiroTolak;
        int _counterTable = 0;
        int _counterRow = 0;
        int _total = 0;

        public frmDownloadPiutang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadPiutang_Load(object sender, EventArgs e)
        {
            
        }

        private void DownloadTokoToSales()
        {
            string fileName = _tempPath + "TmpTk2.DBF";
            lblTableName.Text = "TokoToSales is Downloading";

            DataTable result = ValidateFile(fileName, dtTokoToSales);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_TokoToSales"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    _counterRow = 0;
                    _total = result.Rows.Count;
                    lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();
                    _counterTable = _counterTable + 1;
                    lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {
             

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangBerjalan", SqlDbType.Money, Tools.isNull(dr["piutang_b"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@PiutangJatuhTempo", SqlDbType.Money, Tools.isNull(dr["piutang_j"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].ExecuteNonQuery();
                        progressBar1.Increment(1);
                        this.refreshForm(_counterRow);
                    }
                }
               
            }
        }

        private void DownloadKartuPiutangDetail()
        {
            string fileName = _tempPath + "TmpDpi.DBF";
            lblTableName.Text = "KartuPiutangDetail is Downloading";
            string laudit;

            DataTable result = ValidateFile(fileName, dtKartuPiutangDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_KartuPiutangDetail"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    _counterRow = 0;
                    _total = result.Rows.Count;
                    lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();
                    _counterTable = _counterTable + 1;
                    lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {
                       

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_tr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, Tools.isNull(dr["kd_trans"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Tools.isNull(dr["debet"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJTGiro", SqlDbType.DateTime, Tools.isNull(dr["cbg_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBuktiKasMasuk", SqlDbType.VarChar, Tools.isNull(dr["no_bkm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoGiro", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                        laudit = Tools.isNull(dr["laudit"], "0").ToString();

                        if (laudit == "False")
                        {
                            laudit = "0";
                        }
                        else if (laudit == "True")
                        {
                            laudit = "1";
                        }

                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, int.Parse(laudit)));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();                        
                        progressBar1.Increment(1);
                        this.refreshForm(_counterRow);
                    }
                }
              
            }
        }

        private void DownloadKartuPiutang()
        {
            string fileName = _tempPath + "TmpKpi.DBF";
            lblTableName.Text = "KartuPiutang is Downloading";

            DataTable result = ValidateFile(fileName, dtKartuPiutang);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_KartuPiutang"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    _counterRow = 0;
                    _total = result.Rows.Count;
                    lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();
                    _counterTable = _counterTable + 1;
                    lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {                        

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["id_kp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, Tools.isNull(dr["tgl_tr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, Tools.isNull(dr["no_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktu", SqlDbType.Int, int.Parse((Tools.isNull(dr["jk_waktu"], "0").ToString()))));
                        db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, (Tools.isNull(dr["tgl_jt"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["uraian"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(ISA.Common.Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@KeteranganTagih", SqlDbType.VarChar, Tools.isNull(dr["ket_tagih"], "").ToString().TrimEnd()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();                        
                        progressBar1.Increment(1);
                        this.refreshForm(_counterRow);
                    }
                }
              
            }
        }

        private void DownloadGiroTolakDetail()
        {
            string fileName = _tempPath + "TmpDbg.DBF";
            lblTableName.Text = "GiroTolakDetail is Downloading";

            DataTable result = ValidateFile(fileName, dtGiroTolakDetail);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_GiroTolakDetail"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    _counterRow = 0;
                    _total = result.Rows.Count;
                    lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();

                    _counterTable = _counterTable + 1;
                    lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {
                        

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.DateTime, Tools.isNull(dr["tgl_byr"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, Tools.isNull(dr["kd_bayar"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Tools.isNull(dr["kredit"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, Tools.isNull(dr["cbg_jt"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["uraian"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, (Tools.isNull(dr["dstamp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, (Tools.isNull(dr["no_bkm"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, Tools.isNull(dr["Bank"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().TrimEnd()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();                        
                        progressBar1.Increment(1);
                        this.refreshForm(_counterRow);
                    }
                }
               
                
            }
        }

        private void DownloadGiroTolak()
        {
            
            string fileName = _tempPath + "TmpHbg.DBF";
            lblTableName.Text = "GiroTolak is Downloading";
            string laudit;

            DataTable result = ValidateFile(fileName, dtGiroTolak);

            if (result != null)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    
                    db.Commands.Add(db.CreateCommand("psp_KASIR_DOWNLOAD_GiroTolak"));

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = result.Rows.Count;
                    progressBar1.Value = 0;
                    _counterRow = 0;
                    _total = result.Rows.Count;
                    lblCounterRow.Text = _counterRow.ToString() + "/" + _total.ToString();

                    _counterTable = _counterTable + 1;
                    lblCounterTable.Text = _counterTable.ToString() + " of 5";

                    foreach (DataRow dr in result.Rows)
                    {                        

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, Tools.isNull(dr["idkp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["Alasan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglGiro", SqlDbType.DateTime, Tools.isNull(dr["Tgl_Giro"], DBNull.Value)));
                        db.Commands[0].Parameters.Add(new Parameter("@CbgJt", SqlDbType.DateTime, (Tools.isNull(dr["Cbg_jt"], DBNull.Value))));
                        db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, (Tools.isNull(dr["Uraian"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, (Tools.isNull(dr["Debet"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Dibayar", SqlDbType.Money, Tools.isNull(dr["Dibayar"], "0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["KD_sales"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNullOrEmpty(dr["id_match"].ToString().Trim(), "0"))));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBKM", SqlDbType.VarChar, Tools.isNull(dr["no_bkm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoBG", SqlDbType.VarChar, Tools.isNull(dr["no_bg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Bank", SqlDbType.VarChar, (Tools.isNull(dr["Bank"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, (Tools.isNull(dr["no_acc"], "").ToString().Trim())));
                        laudit = (Tools.isNull(dr["laudit"], "0").ToString());

                        if (laudit == "False")
                        {
                            laudit = "0";
                        }
                        else if (laudit == "True")
                        {
                            laudit = "1";
                        }

                        db.Commands[0].Parameters.Add(new Parameter("@Audit", SqlDbType.Bit, int.Parse(laudit)));
                        db.Commands[0].Parameters.Add(new Parameter("@KetTagih", SqlDbType.VarChar, Tools.isNull(dr["ket_tagih"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();                       
                        progressBar1.Increment(1);
                        this.refreshForm(_counterRow);
                    }

                }
               
            }
        }

        private void DownloadProcess()
        {
            _tempPath = GlobalVar.DbfDownload + "\\APIMATCH\\";

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


            DownloadTokoToSales();
            DownloadKartuPiutang();
            DownloadKartuPiutangDetail();
            DownloadGiroTolak();
            DownloadGiroTolakDetail();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            try
            {
                lblTableName.Visible = true;
                lblCounterRow.Visible = true;
                DownloadProcess();
                MessageBox.Show(Messages.Confirm.ProcessFinished);
                lblTableName.Visible = false;
                lblCounterRow.Visible = false;
                _counterTable = 0;
                lblCounterTable.Text = _counterTable + " of 5";

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
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


        private void refreshForm(int count)
        {
            _counterRow++;
            lblCounterRow.Text = _counterRow.ToString() + "/" +_total.ToString();
            this.Refresh();
            this.Invalidate();            
            
        }
    }
}
