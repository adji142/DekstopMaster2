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

namespace ISA.Toko.Communicator
{
    public partial class frmPenjualanDODownload00 : ISA.Toko.BaseForm
    {
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtSudahDownload = new DataTable();
        DataTable dtToko = new DataTable();
        DataTable dtProses = new DataTable();

        enum flag { OrderPenjualan=0, Toko, OrderPenjualanDetail };

        string title = "Download Transaksi Dari 00";
        
        public frmPenjualanDODownload00()
        {
            InitializeComponent();
            this.Location = new Point(390, 200);
        }

        private void cmdDonwload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    DownloadData();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenjualanDODownload00_Load(object sender, EventArgs e)
        {
            gvDownload1.AutoGenerateColumns = true;
            gvDownload2.AutoGenerateColumns = true;
            this.Location = new Point(390, 200);
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

        private void LoadFile()
        {
            string fileName = lookupGudang.GudangID + GlobalVar.Gudang;
            string fileName1 = fileName + "\\Htjtmp.dbf";
            string fileName2 = fileName + "\\Dtjtmp.dbf";
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

        private bool ValidateData(string param, int flag)
        { 
            int retVal = 0;
            DataTable dt;

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiDari00_CekData_DOWNLOAD"));
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

        public void DownloadData()
        {
            int counter1 = 0;
            int counter2 = 0;
            int flagRecord = 0;
            string cabang1 = string.Empty;
            string cabang2 = string.Empty;
            string cabang3 = string.Empty;
            string idhtr = string.Empty;
            string tokoID = string.Empty;
            string noRequest = string.Empty;

            dtSudahDownload = dt1.Clone();
            dtToko = dt1.Clone();
            dtProses = dt1.Clone();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiDari00_OP_DOWNLOAD"));
                foreach (DataRow dr in dt1.Rows)
                {
                    //string naph = Tools.isNull(dr["NoAccPusat"],"").ToString().Trim();
                    //string cNoAccPiutang = Tools.isNull(dr["NoAccPiutang"], "").ToString().Trim().Substring(0, 1);

                    //if ((cNoAccPiutang == "F" || cNoAccPiutang == "S") && naph == "")
                    //{
                    //    naph = "AUTOACC";
                    //}

                    //grid and form status
                    cabang1 = Tools.isNull(dr["cab1"], "").ToString().Trim();
                    cabang2 = Tools.isNull(dr["cab2"], "").ToString().Trim();
                    cabang3 = Tools.isNull(dr["cab3"], "").ToString().Trim();
                    idhtr = Tools.isNull(dr["idhtr"], "").ToString().Trim();
                    tokoID = Tools.isNull(dr["kd_toko"], "").ToString().Trim();
                    noRequest = Tools.isNull(dr["no_rq"], "").ToString().Trim();

                    if (!noRequest.Contains("!"))
                    {
                        noRequest = noRequest.Length < 6 ? noRequest + "!" : noRequest.Substring(0, 5) + "!";
                    }
                    // Debug process: cabang2 + cabang3 == GlobalVar.Gudang
                    //if (cabang2 + cabang3 == GlobalVar.Gudang)
                    //{

                        flagRecord = ValidateData(idhtr, (int)flag.OrderPenjualan) == true ? 1 : 0;

                        if(flagRecord == 1)
                        {
                            dtSudahDownload.ImportRow(dr); 
                        }
                        else
                        {
                            dtProses.ImportRow(dr);
                        }
                        //Debug process: ValidateData(tokoID, (int)flag.Toko) == true && cabang1 != GlobalVar.CabangID
                        if (ValidateData(tokoID, (int)flag.Toko) == true && cabang1 != GlobalVar.CabangID)
                        {
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@FlagRecord", SqlDbType.Int, flagRecord));
                            db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(dr["idhtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, Tools.isNull(dr["cab3"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, noRequest));
                            db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, Tools.isNull(dr["tgl_rq"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, Tools.isNull(dr["no_do"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, Tools.isNull(dr["tgl_do"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, Tools.isNull(dr["no_acc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, Tools.isNull(dr["checker_1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, Tools.isNull(dr["no_nota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_net3"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, Tools.isNull(dr["al_kirim"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Int, double.Parse(Tools.isNull(dr["disc_1"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Int, double.Parse(Tools.isNull(dr["disc_2"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Int, double.Parse(Tools.isNull(dr["disc_3"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Int, double.Parse(Tools.isNull(dr["pot_rp2"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@SaldoPiutang", SqlDbType.Int, double.Parse(Tools.isNull(dr["pot_rp3"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyTolak", SqlDbType.Int, double.Parse(Tools.isNull(dr["rp_fee1"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.Int, double.Parse(Tools.isNull(dr["rp_fee2"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["laudit"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, Tools.isNull(dr["catatan1"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, Tools.isNull(dr["catatan2"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, Tools.isNull(dr["catatan3"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, Tools.isNull(dr["catatan4"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, Tools.isNull(dr["catatan5"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(dr["no_dobo"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, Tools.isNull(dr["tgl_reord"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lbo"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@TrasacType", SqlDbType.VarChar, Tools.isNull(dr["id_tr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, Tools.isNull(dr["expedisi"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["hr_krdt"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Cicil", SqlDbType.Int, int.Parse(Tools.isNull(dr["Cicil"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();

                            dr["cUploaded"] = true;

                            DataRow[] orderDetails = dt2.Select("idhtr='" + dr["idhtr"].ToString() + "'");

                            if (orderDetails.Length == 0)
                            {
                                MessageBox.Show(String.Format(Messages.Confirm.NoDetailData, dr["no_do"].ToString()));
                            }

                            db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiDari00_OPD_DOWNLOAD"));
                            foreach (DataRow drd in orderDetails)
                            {
                                db.Commands[1].Parameters.Clear();
                                db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["idrec"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, Tools.isNull(drd["idhtr"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["id_brg"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_rq"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, int.Parse(Tools.isNull(drd["j_do"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@HrgJual", SqlDbType.Money, double.Parse(Tools.isNull(drd["h_jual"], "").ToString().Trim())));
                                //db.Commands[1].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(drd["kd_toko"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@Disc1", SqlDbType.Int, double.Parse(Tools.isNull(drd["disc_1"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@Disc2", SqlDbType.Int, double.Parse(Tools.isNull(drd["disc_2"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@Disc3", SqlDbType.Int, double.Parse(Tools.isNull(drd["disc_3"], "0").ToString())));
                                db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, double.Parse(Tools.isNull(drd["pot_rp"], "").ToString().Trim())));
                                db.Commands[1].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, Tools.isNull(drd["no_bodo"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@NoACC", SqlDbType.VarChar, Tools.isNull(drd["no_acc"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(drd["catatan"], "").ToString().Trim()));
                                db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.Commands[1].ExecuteNonQuery();

                                drd["cUploaded"] = true;
                                counter2++;
                                pbDownload2.Increment(1);
                                lblDownloadCount2.Text = counter2.ToString("#,##0") + "/" + dt2.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }
                            db.CommitTransaction();
                        }
                        else
                        {
                            dtToko.ImportRow(dr);
                        }

                        counter1++;
                        pbDownload1.Increment(1);
                        lblDownloadCount1.Text = counter1.ToString("#,##0") + "/" + dt1.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    //}
                    //db.CommitTransaction();
                }
            }
        }

        private void DisplayReport()
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();
            List<DataTable> pTable = new List<DataTable>();
            List<string> pDatasetName = new List<string>();

            rptParams.Add(new ReportParameter("Gudang", lookupGudang.GudangID));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            dtProses.Columns["no_do"].ColumnName = "NoDo";
            dtProses.Columns["tgl_do"].ColumnName = "TglDO";
            dtProses.Columns["kd_sales"].ColumnName = "KodeSales";
            dtProses.Columns["nm_toko"].ColumnName = "NamaToko";
            dtProses.Columns["al_kirim"].ColumnName = "Alamat";
            dtProses.Columns["kota"].ColumnName = "Kota";
            dtProses.Columns["cab1"].ColumnName = "Cabang1";
            dtProses.Columns["cab2"].ColumnName = "Cabang2";
            dtProses.Columns["no_acc"].ColumnName = "NoAcc";

            dtSudahDownload.Columns["no_do"].ColumnName = "NoDo";
            dtSudahDownload.Columns["tgl_do"].ColumnName = "TglDO";
            dtSudahDownload.Columns["kd_sales"].ColumnName = "KodeSales";
            dtSudahDownload.Columns["nm_toko"].ColumnName = "NamaToko";
            dtSudahDownload.Columns["al_kirim"].ColumnName = "Alamat";
            dtSudahDownload.Columns["kota"].ColumnName = "Kota";
            dtSudahDownload.Columns["cab1"].ColumnName = "Cabang1";
            dtSudahDownload.Columns["cab2"].ColumnName = "Cabang2";
            dtSudahDownload.Columns["no_acc"].ColumnName = "NoAcc";

            dtToko.Columns["no_do"].ColumnName = "NoDo";
            dtToko.Columns["tgl_do"].ColumnName = "TglDO";
            dtToko.Columns["kd_sales"].ColumnName = "KodeSales";
            dtToko.Columns["nm_toko"].ColumnName = "NamaToko";
            dtToko.Columns["al_kirim"].ColumnName = "Alamat";
            dtToko.Columns["kota"].ColumnName = "Kota";
            dtToko.Columns["cab1"].ColumnName = "Cabang1";
            dtToko.Columns["cab2"].ColumnName = "Cabang2";
            dtToko.Columns["no_acc"].ColumnName = "NoAcc";

            pTable.Add(dtProses);
            pTable.Add(dtSudahDownload);
            pTable.Add(dtToko);
            
            pDatasetName.Add("dsOrderPenjualan_Data");
            pDatasetName.Add("dsOrderPenjualan_Data1");
            pDatasetName.Add("dsOrderPenjualan_Data2");

            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptPenjualanDODownload00.rdlc", rptParams, pTable, pDatasetName);

            ifrmReport.Show();

        }
    }
}
