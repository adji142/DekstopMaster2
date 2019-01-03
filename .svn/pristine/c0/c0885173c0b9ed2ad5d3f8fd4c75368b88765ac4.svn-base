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

namespace ISA.Trading.Communicator
{
    public partial class frmPenjualanNotaDownloadC2 : ISA.Trading.BaseForm
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtSudahDownload = new DataTable();
        DataTable dtProses = new DataTable();
        DataTable dtPJ2 = new DataTable();
        DataTable dtNoDetail = new DataTable();

        enum flag { OrderPenjualan = 0, NotaPenjualan};

        string title = "Download Nota Penjualan Dari C2";
        
        public frmPenjualanNotaDownloadC2()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lookupGudang.GudangID))
            {
                MessageBox.Show("Tentukan ID Gudang yang ingin didownload", "Download", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LoadFile();
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    DownloadData();
                    LinkNota();
                    if (dtProses.Rows.Count == 0 && dtSudahDownload.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data yang didownload.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                        cmdDownload.Enabled = false;
                        DisplayReport();
                    }
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

        private void frmPenjualanNotaDownloadC2_Load(object sender, EventArgs e)
        {
            cmdDownload.Enabled = false;
            gvDownload1.AutoGenerateColumns = true;
            gvDownload2.AutoGenerateColumns = true;
        }

        private bool UnzipFile(string sourceZIPFileName, string FileName)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\hppatmp";

            if (File.Exists(sourceZIPFileName))
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                Zip.UnZipFiles(sourceZIPFileName, extractFileLocation, false);
                retVal = true;
            }
            else
            {
                //lblFileNameLocation.Text = "File " + sourceZIPFileName + " tidak ada.";
                cmdDownload.Enabled = false;
                MessageBox.Show("File: " + sourceZIPFileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void LoadFile()
        {
            string fileName = lookupGudang.GudangID + GlobalVar.Gudang;
            string fileName1 = fileName + "\\Htj2tmp.dbf";
            string fileName2 = fileName + "\\Dtj2tmp.dbf";
            string fileZIPName = fileName + ".zip";

            fileName1 = GlobalVar.DbfDownload + "\\" + fileName1;
            fileName2 = GlobalVar.DbfDownload + "\\" + fileName2;

            fileZIPName = GlobalVar.DbfDownload + "\\" + fileZIPName;

            if (UnzipFile(fileName, fileName1, fileName2))
            {
                if (File.Exists(fileName1) && File.Exists(fileName2))
                {
                    try
                    {
                        dt1 = Foxpro.ReadFile(fileName1);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        dt1.Columns.Add(newcol);

                        gvDownload1.DataSource = dt1;
                        lblDownloadCount1.Text = "0/" + dt1.Rows.Count.ToString("#,##0");
                        pbDownload1.Minimum = 0;
                        pbDownload1.Maximum = dt1.Rows.Count;
                        lblInfo1.Text = fileName1;

                        dt2 = Foxpro.ReadFile(fileName2);
                        DataColumn newcol2 = new DataColumn("cUploaded");
                        newcol2.DataType = Type.GetType("System.Boolean");
                        dt2.Columns.Add(newcol2);

                        gvDownload2.DataSource = dt2;
                        lblDownloadCount2.Text = "0/" + dt2.Rows.Count.ToString("#,##0");
                        pbDownload2.Minimum = 0;
                        pbDownload2.Maximum = dt2.Rows.Count;
                        lblInfo2.Text = fileName2;

                        pbDownload1.Value = 0;
                        pbDownload2.Value = 0;

                        this.DialogResult = DialogResult.OK;

                        cmdDownload.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    lblInfo1.Text = "File " + fileName1 + " tidak ada.";
                    lblInfo2.Text = "File " + fileName2 + " tidak ada.";
                    cmdDownload.Enabled = false;
                    MessageBox.Show("File: " + fileName1 + " / " + fileName2 + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UnzipFile(string sourceZIPFileName, string FileName1, string FileName2)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\" + sourceZIPFileName;
            string zipFile = GlobalVar.DbfDownload + "\\" + sourceZIPFileName + ".zip";
            if (File.Exists(zipFile))
            {
                if (File.Exists(FileName1))
                {
                    File.Delete(FileName1);
                }

                if (File.Exists(FileName2))
                {
                    File.Delete(FileName2);
                }

                Zip.UnZipFiles(zipFile, extractFileLocation, false);
                this.Title = zipFile;
                this.Text = title;
                cmdDownload.Enabled = true;
                retVal = true;
            }
            else
            {
                this.Title = "File " + zipFile + " tidak ada.";

                cmdDownload.Enabled = false;
                MessageBox.Show("File: " + zipFile + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private double GetNetDisc(double bruto, double disc1, double disc2, double disc3, string discFormula)
        {
            double retVal = 0;
            DataTable dt;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_GetNetDiskon"));
                db.Commands[0].Parameters.Add(new Parameter("@nBruto", SqlDbType.Money, bruto));
                db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Money, disc1));
                db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Money, disc2));
                db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Money, disc3));
                db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, discFormula));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 1)
            {
                retVal = double.Parse(dt.Rows[0]["Result"].ToString());
            }

            return retVal;
        }

        private void DisplayReport()
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();

            #region dtReport1

            DataTable dtReport1 = new DataTable();
            dtReport1.Columns.Add("Cabang2", typeof(string));
            dtReport1.Columns.Add("Nota", typeof(string));
            dtReport1.Columns.Add("TglNota", typeof(DateTime));
            dtReport1.Columns.Add("DO", typeof(string));
            dtReport1.Columns.Add("TglDO", typeof(DateTime));
            dtReport1.Columns.Add("Sales", typeof(string));
            dtReport1.Columns.Add("Toko", typeof(string));
            dtReport1.Columns.Add("Alamat", typeof(string));
            dtReport1.Columns.Add("Kota", typeof(string));
            dtReport1.Columns.Add("NamaStok", typeof(string));
            dtReport1.Columns.Add("Jumlah", typeof(int));
            dtReport1.Columns.Add("Harga", typeof(double));
            dtReport1.Columns.Add("Diskon", typeof(double));
            dtReport1.Columns.Add("nPot", typeof(double));

            string cabang2 = string.Empty;
            string noNota = string.Empty;
            DateTime tglNota;
            string noDO = string.Empty;
            DateTime tglDO;
            string sales = string.Empty;
            string namaToko = string.Empty;
            string alamat = string.Empty;
            string kota = string.Empty;
            string namaStok = string.Empty;
            int jumlah = 0;
            double harga = 0;
            //double nBruto = 0;
            double nDiskon = 0;
            //double nPot = 0;

            foreach (DataRow dr in dtProses.Rows)
            {
                cabang2 = Tools.isNull(dr["Cab2"], "").ToString().Trim();
                noNota = Tools.isNull(dr["No_sj"], "").ToString().Trim();
                tglNota = DateTime.Parse(Tools.isNull(dr["Tgl_sj"],DBNull.Value).ToString());
                noDO = Tools.isNull(dr["No_do"], "").ToString().Trim();
                tglDO = DateTime.Parse(Tools.isNull(dr["Tgl_do"], DBNull.Value).ToString());
                sales = Tools.isNull(dr["kd_sales"], "").ToString().Trim();
                namaToko = Tools.isNull(dr["Nm_toko"], "").ToString().Trim();
                alamat = Tools.isNull(dr["Al_kirim"], "").ToString().Trim();
                kota = Tools.isNull(dr["kota"], "").ToString().Trim();

                double pot;
                double disc1;
                double disc2;
                double disc3;
                string discFormula;

                DataRow[] orderDetails = dt2.Select("idtr='" + dr["idtr"].ToString() + "'");
                foreach (DataRow drd in orderDetails)
                {
                    namaStok = Tools.isNull(drd["Nama_stok"], "").ToString().Trim();
                    disc1 = double.Parse(Tools.isNull(drd["disc_1"], "").ToString());
                    disc2 = double.Parse(Tools.isNull(drd["disc_2"], "").ToString());
                    disc3 = double.Parse(Tools.isNull(drd["disc_3"], "").ToString());
                    discFormula = Tools.isNull(drd["Id_disc"], "").ToString().Trim();
                    jumlah = int.Parse(Tools.isNull(drd["J_sj"], "0").ToString());
                    harga = double.Parse(Tools.isNull(drd["H_jual"], "").ToString());
                    nDiskon = (jumlah * harga) - GetNetDisc((jumlah * harga), disc1, disc2, disc3, discFormula);
                    pot = double.Parse(Tools.isNull(drd["Pot_rp"], "").ToString()) * double.Parse(Tools.isNull(drd["J_sj"], "").ToString());
                    
                    dtReport1.Rows.Add(cabang2, noNota, tglNota, noDO, tglDO, sales, namaToko, alamat, kota, namaStok, jumlah, harga, nDiskon, pot);    
                }
            }
            #endregion

            rptParams.Add(new ReportParameter("Gudang", lookupGudang.GudangID));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            dtPJ2.Columns["Cab2"].ColumnName = "Cabang2";
            dtPJ2.Columns["No_sj"].ColumnName = "Nota";
            dtPJ2.Columns["Tgl_sj"].ColumnName = "TglNota";
            dtPJ2.Columns["Kd_sales"].ColumnName = "Sales";
            dtPJ2.Columns["Nm_toko"].ColumnName = "Toko";
            dtPJ2.Columns["Al_kirim"].ColumnName = "Alamat";
            dtPJ2.Columns["Kota"].ColumnName = "Kota";

            dtNoDetail.Columns["Cab2"].ColumnName = "Cabang2";
            dtNoDetail.Columns["No_sj"].ColumnName = "Nota";
            dtNoDetail.Columns["Tgl_sj"].ColumnName = "TglNota";
            dtNoDetail.Columns["Kd_sales"].ColumnName = "Sales";
            dtNoDetail.Columns["Nm_toko"].ColumnName = "Toko";
            dtNoDetail.Columns["Al_kirim"].ColumnName = "Alamat";
            dtNoDetail.Columns["Kota"].ColumnName = "Kota";

            pTable.Add(dtReport1);
            pTable.Add(dtPJ2);
            pTable.Add(dtNoDetail);

            pDatasetName.Add("dsSales_Data");
            pDatasetName.Add("dsSales_Data1");
            pDatasetName.Add("dsSales_Data2");

            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptPenjualanNotaDownloadC2.rdlc", rptParams, pTable, pDatasetName);

            ifrmReport.Show();
            
        }

        public void DownloadData()
        {
            int counter1 = 0;
            int counter2 = 0;
            int flagRecord = 0;
            string cabang1 = string.Empty;
            string cabang2 = string.Empty;
            string htriId_np = string.Empty;
            string recordId_np = string.Empty;
            string idhtr = string.Empty;
            string idtr = string.Empty;

            dtSudahDownload = dt1.Clone();
            dtProses = dt1.Clone();
            dtPJ2 = dt1.Clone();
            dtNoDetail = dt1.Clone();
            int stat = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanNotaC2_NP_DOWNLOAD"));
                    
                    foreach (DataRow dr in dt1.Rows)
                    {
                        cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                        cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                        htriId_np = Tools.isNull(dr["idhtr"], "").ToString().Trim();
                        recordId_np = Tools.isNull(dr["Idtr"], "").ToString().Trim();
                        idhtr = Tools.isNull(dr["Idhtr"], "").ToString().Trim();
                        idtr = Tools.isNull(dr["Idtr"], "").ToString().Trim();

                        if (cabang2 == lookupGudang.GudangID && cabang1 == GlobalVar.CabangID)
                        {
                            if (ValidateData(idhtr, (int)flag.OrderPenjualan) == false)
                            {
                                dtPJ2.ImportRow(dr);
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
                                db.Commands[0].Parameters.Add(new Parameter("@TglSuratJalan", SqlDbType.DateTime, Tools.isNull(dr["Tgl_sj"],DBNull.Value)));
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
                                stat =Convert.ToInt32( db.Commands[0].ExecuteScalar());

                                dr["cUploaded"] = true;

                                DataRow[] orderDetails = dt2.Select("idtr='" + dr["idtr"].ToString() + "'");

                                if (orderDetails.Length == 0)
                                {
                                    dtNoDetail.ImportRow(dr);
                                }
                                else
                                {
                                    dtProses.ImportRow(dr);
                                }

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
                                    /*Tambahan*/
                                    //db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                                    db.Commands[1].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(Tools.isNull(drd["h_Jual"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc1", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_1"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc2", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_2"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Disc3", SqlDbType.Money, double.Parse(Tools.isNull(drd["disc_3"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(drd["pot_rp"], "0").ToString())));
                                    db.Commands[1].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                                    /**/
                                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], "0").ToString())));

                                    db.Commands[1].ExecuteNonQuery();

                                    drd["cUploaded"] = true;
                                    counter2++;
                                    pbDownload2.Increment(1);
                                    lblDownloadCount2.Text = counter2.ToString("#,##0") + "/" + dt2.Rows.Count.ToString("#,##0");
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
                            pbDownload1.Increment(1);
                            lblDownloadCount1.Text = counter1.ToString("#,##0") + "/" + dt1.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                            db.CommitTransaction();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void LinkNota()
        {
            try
            {
                string cabang1 = "";
                string cabang2 = "";
                string recordId_np = "";
                foreach (DataRow dr in dt1.Rows)
                {
                    cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                    cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                    recordId_np = Tools.isNull(dr["Idtr"], "").ToString();

                    if (cabang2 == lookupGudang.GudangID && cabang1 == GlobalVar.CabangID && recordId_np.Trim()!="")
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("[usp_PenjualanNotaC2_NP_LinkPiutang]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RecordIDNota", SqlDbType.VarChar, recordId_np));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy2", SqlDbType.VarChar, SecurityManager.UserID));
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
    }
}
