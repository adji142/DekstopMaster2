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

namespace ISA.Toko.Penjualan
{
    public partial class frmPenjualanDODownloadPos : ISA.Toko.BaseForm       
    {
        DataTable dtDownload = new DataTable();
       
        enum flag { OrderPenjualan=0, Toko, OrderPenjualanDetail };

        string title = "Download Transaksi Dari Pos Ke Cab";
        
        public frmPenjualanDODownloadPos()
        {
            InitializeComponent();
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
                    DisplayReport();
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

        private void frmPenjualanDODownloadPos_Load(object sender, EventArgs e)
        {
            this.gvDownload1.AutoGenerateColumns = true;
            LoadFile();
        }

        private bool UnzipFile(string FileName)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload;
            string zipFile = GlobalVar.DbfDownload + "\\DBFMATCH.ZIP";
            if (File.Exists(zipFile))
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
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

        

        private void LoadFile()
        {
            string fileName1 = "Htjtmp.dbf";

            fileName1 = GlobalVar.DbfDownload + "\\" + fileName1;

            if (UnzipFile(fileName1))
            {
                if (File.Exists(fileName1))
                {
                    try
                    {
                        dtDownload = Foxpro.ReadFile(fileName1);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        dtDownload.Columns.Add(newcol);

                        gvDownload1.DataSource = dtDownload;
                        lblDownloadCount1.Text = "0/" + dtDownload.Rows.Count.ToString("#,##0");
                        pbDownload1.Minimum = 0;
                        pbDownload1.Maximum = dtDownload.Rows.Count;
                        lblInfo1.Text = fileName1;

                        pbDownload1.Value = 0;

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
                    cmdDownload.Enabled = false;
                    MessageBox.Show("File: " + fileName1 + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DownloadData()
        {
            int counter1 = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiDariPos_DOWNLOAD"));
                foreach (DataRow dr in dtDownload.Rows)
                {
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID",SqlDbType.VarChar,Tools.isNull(dr["idhtr"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1",SqlDbType.VarChar,Tools.isNull(dr["cab1"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2",SqlDbType.VarChar,Tools.isNull(dr["cab2"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDo",SqlDbType.VarChar,Tools.isNull(dr["no_do"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglDO",SqlDbType.DateTime,Tools.isNull(dr["tgl_do"],DBNull.Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang",SqlDbType.VarChar,Tools.isNull(dr["no_nota"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, Tools.isNull(dr["tgl_nota"], DBNull.Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko",SqlDbType.VarChar,Tools.isNull(dr["kd_toko"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales",SqlDbType.VarChar,Tools.isNull(dr["kd_sales"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko",SqlDbType.VarChar,Tools.isNull(dr["nm_toko"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim",SqlDbType.VarChar,Tools.isNull(dr["al_kirim"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota",SqlDbType.VarChar,Tools.isNull(dr["kota"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@rp_net", SqlDbType.Money, double.Parse(Tools.isNull(dr["rp_net"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpACCPiutang",SqlDbType.Money,double.Parse(Tools.isNull(dr["rp_net3"],"0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpPlafonToko",SqlDbType.Money,double.Parse(Tools.isNull(dr["pot_rp2"],"0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpPiutangTerakhir",SqlDbType.Money,double.Parse(Tools.isNull(dr["pot_rp3"],"0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpGiroTolakTerakhir",SqlDbType.Money,double.Parse(Tools.isNull(dr["rp_fee1"],"0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpOverdue",SqlDbType.Money,double.Parse(Tools.isNull(dr["rp_fee2"],"0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1",SqlDbType.VarChar,Tools.isNull(dr["catatan"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5",SqlDbType.VarChar,Tools.isNull(dr["catatan5"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO",SqlDbType.VarChar,Tools.isNull(dr["no_dobo"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag",SqlDbType.VarChar,Tools.isNull(dr["id_match"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID",SqlDbType.VarChar,Tools.isNull(dr["id_link"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID",SqlDbType.VarChar,Tools.isNull(dr["checker_1"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType",SqlDbType.VarChar,Tools.isNull(dr["id_tr"],"").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();

                    dr["cUploaded"] = true;

                    db.CommitTransaction();
                  
                    counter1++;
                    pbDownload1.Increment(1);
                    lblDownloadCount1.Text = counter1.ToString("#,##0") + "/" + dtDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void UpdateLinkID()
        {
            DataTable dt;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetLinkIDOrderPenjualanPos_DOWNLOAD"));

                    for (int i = 0; i < dtDownload.Rows.Count; i++)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dtDownload.Rows[i]["idhtr"].ToString()));
                        dt = db.Commands[0].ExecuteDataTable();

                        if (dt.Rows.Count > 0)
                        {
                            dtDownload.Rows[i]["id_link"] = dt.Rows[0]["LinkID"];
                        }
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

        private void DisplayReport()
        {
            UpdateLinkID();

            dtDownload.Columns["no_do"].ColumnName = "NoDo";
            dtDownload.Columns["tgl_do"].ColumnName = "TglDO";
            dtDownload.Columns["kd_sales"].ColumnName = "KodeSales";
            dtDownload.Columns["nm_toko"].ColumnName = "NamaToko";
            dtDownload.Columns["al_kirim"].ColumnName = "AlamatKirim";
            dtDownload.Columns["kota"].ColumnName = "Kota";
            dtDownload.Columns["cab1"].ColumnName = "Cabang1";
            dtDownload.Columns["id_link"].ColumnName = "LinkID";

            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptPenjualanDODownloadPos.rdlc", rptParams, dtDownload, "dsOrderPenjualan_Data3");
            ifrmReport.Show();

        }
    }
}
