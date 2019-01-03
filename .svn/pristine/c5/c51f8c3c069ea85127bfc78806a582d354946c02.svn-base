using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Toko.DataTemplates;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using ISA.Toko.Class;

namespace ISA.Toko.Communicator
{
    public partial class frmFoxproDownloader : ISA.Toko.BaseForm
    {
        DataTable tblDownload;
        bool _isProcessing = false;


        public enum enDownloadType
        {
            BMK,
            BMK11,
            HPP,
            HPP11,
            Sales,
            Stock,
            Toko,
            StatusToko,
            PlafonToko,
            TokoDispensasi,
            TokoKhusus
        }

        enDownloadType _tableType;

        public frmFoxproDownloader(enDownloadType tableType)
        {
            InitializeComponent();
            _tableType = tableType;
        }


        private void frmFoxproDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isProcessing)
            {
                MessageBox.Show(Messages.Error.StillProcessing);
                e.Cancel = true;
            }
        }




        private void DownloadBMK()
        {
            int counter = 0;

            bool isBmk11 = LookupInfoValue.CekBmk11();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryBMK_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@id_hist", SqlDbType.VarChar, Tools.isNull(dr["id_hist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_stok", SqlDbType.VarChar, Tools.isNull(dr["id_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr["tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt_pasif", SqlDbType.DateTime, dr["tmt_pasif"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_std", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_std"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_net", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_net"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_b", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_m", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_m", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_k", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_k"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_k", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_k"], "0").ToString())));
                    //mus
                    db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.Int, int.Parse(Tools.isNull(dr["cash"], "0").ToString().Substring(0, Tools.isNull(dr["cash"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.Int, int.Parse(Tools.isNull(dr["top10"], "0").ToString().Substring(0, Tools.isNull(dr["top10"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.Int, int.Parse(Tools.isNull(dr["enduser"], "0").ToString().Substring(0, Tools.isNull(dr["enduser"], "0").ToString().Length - 3))));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_c", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_c"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_t", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_t"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_e", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_e"], "0").ToString())));
                    //

                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@dl", SqlDbType.VarChar, Tools.isNull(dr["dl"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr["nama_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrecstok", SqlDbType.VarChar, Tools.isNull(dr["idrecstok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr["satuan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sts_laba", SqlDbType.VarChar, Tools.isNull(dr["sts_laba"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (isBmk11)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@BmkDari11", SqlDbType.Int, 1));
                    }

                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadBMK11()
        {
            int counter = 0;

            bool isBmk11 = LookupInfoValue.CekBmk11();
            if (!isBmk11)
            {
                MessageBox.Show("Silahkan download Data BMK dari menu Download dari PSHO.");
                return;
            }

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryBMK_DOWNLOAD11"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@id_hist", SqlDbType.VarChar, Tools.isNull(dr["id_hist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_stok", SqlDbType.VarChar, Tools.isNull(dr["id_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr["tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt_pasif", SqlDbType.DateTime, dr["tmt_pasif"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_std", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_std"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_net", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_net"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_b", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_m", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_m", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_m"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@qmin_k", SqlDbType.Int, int.Parse(Tools.isNull(dr["qmin_k"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual_k", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual_k"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@dl", SqlDbType.VarChar, Tools.isNull(dr["dl"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr["nama_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrecstok", SqlDbType.VarChar, Tools.isNull(dr["idrecstok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr["satuan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.VarChar, Tools.isNull(dr["id_match"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sts_laba", SqlDbType.VarChar, Tools.isNull(dr["sts_laba"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    if (isBmk11)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@BmkDari11", SqlDbType.Int, 1));
                    }

                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadHPP()
        {
            int counter = 0;

            bool isHpp11 = LookupInfoValue.CekHpp11();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HistoryHPP_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@id_hist", SqlDbType.VarChar, Tools.isNull(dr["id_hist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_stok", SqlDbType.VarChar, Tools.isNull(dr["id_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idmain", SqlDbType.VarChar, Tools.isNull(dr["idmain"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_plist", SqlDbType.VarChar, Tools.isNull(dr["nm_plist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr["satuan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr["tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dr["tmt1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hjual", SqlDbType.Money, double.Parse(Tools.isNull(dr["hjual"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@id_mpric", SqlDbType.VarChar, Tools.isNull(dr["id_mpric"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    //DisplayReportHPP();
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }

            }

        }

        private void DownloadHPP11()
        {
            bool isHpp11 = LookupInfoValue.CekHpp11();
            if (!isHpp11)
            {
                MessageBox.Show("Silahkan download Data HPP dari menu Download dari PSHO.");
                return;
            }

            DownloadHPP();
        }

        private void DownloadSales()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Sales_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, Tools.isNull(dr["kd_sales"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_sales", SqlDbType.VarChar, Tools.isNull(dr["nm_sales"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_lahir", SqlDbType.DateTime, dr["tgl_lahir"]));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@target", SqlDbType.Money, double.Parse(Tools.isNull(dr["target"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@batas_od", SqlDbType.Money, double.Parse(Tools.isNull(dr["batas_od"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_masuk", SqlDbType.DateTime, dr["tgl_masuk"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_keluar", SqlDbType.DateTime, dr["tgl_keluar"]));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadStock()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Stok_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idmain", SqlDbType.VarChar, Tools.isNull(dr["idmain"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_plist", SqlDbType.VarChar, Tools.isNull(dr["nm_plist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kodesolo", SqlDbType.VarChar, Tools.isNull(dr["kodesolo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@hpp_sas", SqlDbType.Money, double.Parse(Tools.isNull(dr["hpp_sas"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lpasif"], false).ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@kendaraan", SqlDbType.VarChar, Tools.isNull(dr["kendaraan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@partNo", SqlDbType.VarChar, Tools.isNull(dr["partNo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr["merek"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satjual", SqlDbType.VarChar, Tools.isNull(dr["satjual"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@konversi", SqlDbType.Int, int.Parse(Tools.isNull(dr["konversi"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@satsolo", SqlDbType.VarChar, Tools.isNull(dr["satsolo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@oldcode", SqlDbType.VarChar, Tools.isNull(dr["oldcode"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@oldname", SqlDbType.VarChar, Tools.isNull(dr["oldname"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_mstk", SqlDbType.VarChar, Tools.isNull(dr["id_mstk"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@isi_koli", SqlDbType.Int, int.Parse(Tools.isNull(dr["isi_koli"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    //DisplayReportMasterStok();
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadToko()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                // db.Commands.Add(db.CreateCommand("usp_Toko_DOWNLOAD")); lama, HRI
                db.Commands.Add(db.CreateCommand("usp_Toko_DOWNLOAD_DBF"));
                bool ISPS = false;

                ISPS = tblDownload.Columns.Contains("TIPEBISNIS");
                //foreach (DataColumn dc in tblDownload.Columns)
                //{
                //    if (dc.ColumnName.ToUpper().Equals("TIPEBISNIS"))
                //    {
                //        ISPS = true;
                //        break;
                //    }
                //}

                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@idToko", SqlDbType.VarChar, Tools.isNull(dr["Idtoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, Tools.isNull(dr["daerah"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, Tools.isNull(dr["propinsi"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@noTelp", SqlDbType.VarChar, Tools.isNull(dr["notelp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idWil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@pngJwb", SqlDbType.VarChar, Tools.isNull(dr["pngjwb"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_Toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));

                    //db.Commands[0].Parameters.Add(new Parameter("@kd_Toko2", SqlDbType.VarChar, Tools.isNull(dr["kd_toko2"], "").ToString().Trim()));
                    //if (ISPS) matiin by HRI
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@TipeBisnis", SqlDbType.VarChar, "PARTAI"));
                    //}
                    //else
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@TipeBisnis", SqlDbType.VarChar, "PS"));
                    //}


                    db.Commands[0].Parameters.Add(new Parameter("@piutang_b", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@piutang_j", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_j"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_jual"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@to_jual", SqlDbType.Money, double.Parse(Tools.isNull(dr["to_retpot"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@to_retpot", SqlDbType.Money, double.Parse(Tools.isNull(dr["piutang_b"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@jkw_kredit", SqlDbType.Int, int.Parse(Tools.isNull(dr["jkw_kredit"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@no_Toko", SqlDbType.VarChar, Tools.isNull(dr["no_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl1st", SqlDbType.DateTime, dr["tgl1st"]));
                    db.Commands[0].Parameters.Add(new Parameter("@exist", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["exist"], false).ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lpasif"], false).ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@idclass", SqlDbType.VarChar, Tools.isNull(dr["idclass"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@hari_krm", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_krm"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@exp_norm", SqlDbType.VarChar, Tools.isNull(dr["exp_norm"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@grade", SqlDbType.VarChar, Tools.isNull(dr["grade"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@plafon_1st", SqlDbType.Money, double.Parse(Tools.isNull(dr["plafon_1st"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@flag", SqlDbType.VarChar, Tools.isNull(dr["flag"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@hari_sls", SqlDbType.Int, int.Parse(Tools.isNull(dr["hari_sls"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@cab", SqlDbType.VarChar, Tools.isNull(dr["cab"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@cab2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@cab1", SqlDbType.VarChar, Tools.isNull(dr["cab1"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@l_edit", SqlDbType.VarChar, Tools.isNull(dr["l_edit"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec_post", SqlDbType.VarChar, Tools.isNull(dr["idrec_post"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_edit", SqlDbType.DateTime, dr["tgl_edit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@no_urut", SqlDbType.VarChar, Tools.isNull(dr["no_urut"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@alm_rumah", SqlDbType.VarChar, Tools.isNull(dr["alm_rumah"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@pengelola", SqlDbType.VarChar, Tools.isNull(dr["pengelola"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl_lahir", SqlDbType.DateTime, dr["tgl_lahir"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hp", SqlDbType.VarChar, Tools.isNull(dr["hp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@status", SqlDbType.VarChar, Tools.isNull(dr["status"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@th_berdiri", SqlDbType.VarChar, Tools.isNull(dr["th_berdiri"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lruko", SqlDbType.Bit, bool.Parse(Tools.isNull(dr["lruko"], false).ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@jml_cabang", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_cabang"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@jml_sales", SqlDbType.Int, int.Parse(Tools.isNull(dr["jml_sales"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@kinerja", SqlDbType.VarChar, Tools.isNull(dr["kinerja"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@reff_sls", SqlDbType.VarChar, Tools.isNull(dr["reff_sls"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@reff_col", SqlDbType.VarChar, Tools.isNull(dr["reff_col"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@reff_spv", SqlDbType.VarChar, Tools.isNull(dr["reff_spv"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_survey", SqlDbType.Money, double.Parse(Tools.isNull(dr["plf_survey"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@bdg_usaha", SqlDbType.VarChar, Tools.isNull(dr["bdg_usaha"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, Tools.isNull(dr["FAX"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@bangunan", SqlDbType.VarChar, Tools.isNull(dr["BANGUNAN"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@habis_kontrak", SqlDbType.DateTime, dr["HBS_KNTRK"]));
                    db.Commands[0].Parameters.Add(new Parameter("@jenis_produk", SqlDbType.VarChar, Tools.isNull(dr["JNS_PROD"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, Tools.isNull(dr["PEMILIK"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@jenis_kelamin", SqlDbType.VarChar, Tools.isNull(dr["JEN_KEL"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tempat_lhr", SqlDbType.VarChar, Tools.isNull(dr["TPT_LHR"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, Tools.isNull(dr["EMAIL"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@no_rekening", SqlDbType.VarChar, Tools.isNull(dr["NO_REK"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_bank", SqlDbType.VarChar, Tools.isNull(dr["NAMA_BANK"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, Tools.isNull(dr["NO_MEMBER"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@hobi", SqlDbType.VarChar, Tools.isNull(dr["HOBI"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@no_npwp", SqlDbType.VarChar, Tools.isNull(dr["NO_NPWP"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@mediaByr", SqlDbType.VarChar, Tools.isNull(dr["mediabyr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@angsuran", SqlDbType.Money, double.Parse(Tools.isNull(dr["angsuran"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@ketBayar", SqlDbType.VarChar, Tools.isNull(dr["ketbayar"], "").ToString().Trim()));

                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadPlafonToko()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_PlafonToko_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, dr["tanggal"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Decimal, dr["plf_fb"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_fx", SqlDbType.Decimal, dr["plf_fx"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_fa", SqlDbType.Decimal, dr["plf_fa"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_kb", SqlDbType.Decimal, dr["plf_kb"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_kh", SqlDbType.Decimal, dr["plf_kh"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_kv", SqlDbType.Decimal, dr["plf_kv"]));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_kg", SqlDbType.Decimal, dr["plf_kg"]));
                    db.Commands[0].Parameters.Add(new Parameter("@max_credit", SqlDbType.Decimal, dr["max_credit"]));
                    db.Commands[0].Parameters.Add(new Parameter("@max_fb", SqlDbType.Decimal, dr["max_fb"]));
                    db.Commands[0].Parameters.Add(new Parameter("@max_fx", SqlDbType.Decimal, dr["max_fx"]));
                    db.Commands[0].Parameters.Add(new Parameter("@max_fa", SqlDbType.Decimal, dr["max_fa"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmptoko", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }

        }
        private void DownloadStatusToko()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_StatusToko_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, Tools.isNull(dr["c1"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@nm_toko", SqlDbType.VarChar, Tools.isNull(dr["nm_toko"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr["tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt_pasif", SqlDbType.DateTime, dr["tmt_pasif"]));
                    db.Commands[0].Parameters.Add(new Parameter("@sts", SqlDbType.VarChar, Tools.isNull(dr["sts"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@ksts", SqlDbType.VarChar, Tools.isNull(dr["ksts"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(dr["ket"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@rd", SqlDbType.VarChar, Tools.isNull(dr["rd"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_match", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@stampUser", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadTokoDispensasi()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TokoDispensasi_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, Tools.isNull(dr["daerah"], "").ToString().Trim()));

                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));

                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dr["tmt1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dr["tmt2"]));

                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));

                    db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void DownloadTokoKhusus()
        {
            int counter = 0;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_TokoKhusus_DOWNLOAD"));
                foreach (DataRow dr in tblDownload.Rows)
                {
                    Guid _RowID = new Guid(dr["RowID"].ToString().Trim());
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.VarChar, Tools.isNull(dr["TglAktif"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglPasif", SqlDbType.VarChar, Tools.isNull(dr["TglPasif"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["Ket"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["kd_gdg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagUpload", SqlDbType.VarChar, Tools.isNull(dr["fupload"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, Tools.isNull(dr["fupload"], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();

                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus.Text = counter.ToString("#,##0") + "/" + tblDownload.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();
                }
            }
        }

        private void frmFoxproDownloader_Load(object sender, EventArgs e)
        {
            string fileName = "";
            string fileZIPName = "DBFMATCH";
            switch (_tableType)
            {

                case enDownloadType.BMK:
                    fileName = "tmpbmk.DBF";
                    break;
                case enDownloadType.BMK11:
                    fileName = "tmpbmk.DBF";
                    break;
                case enDownloadType.HPP:
                    fileName = "HjlTmp.DBF";
                    break;
                case enDownloadType.HPP11:
                    fileName = "HjlTmp.DBF";
                    break;
                case enDownloadType.Sales:
                    fileName = "salestmp.DBF";
                    break;
                case enDownloadType.StatusToko:
                    fileName = "ststmp.DBF";
                    break;
                case enDownloadType.Stock:
                    fileName = "stktmp.DBF";
                    break;
                case enDownloadType.Toko:
                    fileName = "tokotmp.DBF";
                    break;
                case enDownloadType.PlafonToko:
                    fileName = "Plftmp.DBF";
                    break;
                case enDownloadType.TokoDispensasi:
                    fileName = "tokodtmp.DBF";
                    break;
                case enDownloadType.TokoKhusus:
                    fileName = "tmpTokoKhusus.DBF";
                    break;
            }

            fileName = GlobalVar.DbfDownload + "\\" + fileName;

            bool isExtracted = true;

            if (!File.Exists(fileName))
                isExtracted = UnzipFile(fileZIPName, fileName);

            if (isExtracted)
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        tblDownload = Foxpro.ReadFile(fileName);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblDownload.Columns.Add(newcol);

                        dataGridView2.DataSource = tblDownload;

                        lblDownloadStatus.Text = "0/" + tblDownload.Rows.Count.ToString("#,##0");
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = tblDownload.Rows.Count;
                        this.Title = fileName;
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }


        private bool UnzipFile(string sourceZIPFileName, string FileName)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload; // +"\\" + sourceZIPFileName;
            string zipFile = GlobalVar.DbfDownload + "\\" + sourceZIPFileName + ".ZIP";
            if (File.Exists(zipFile))
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                Zip.UnZipFiles(zipFile, extractFileLocation, false);
                this.Title = zipFile;
                //this.Text = title;
                //cmdDownload.Enabled = true;
                retVal = true;
            }
            else
            {
                this.Title = "File " + zipFile + " tidak ada.";

                //cmdDownload.Enabled = false;
                MessageBox.Show("File: " + zipFile + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }



        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            if (tblDownload.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _isProcessing = true;
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    switch (_tableType)
                    {
                        case enDownloadType.BMK:
                            DownloadBMK();
                            break;
                        case enDownloadType.BMK11:
                            DownloadBMK11();
                            break;
                        case enDownloadType.HPP:
                            DownloadHPP();
                            DisplayReportHPP();
                            break;
                        case enDownloadType.HPP11:
                            DownloadHPP11();
                            break;
                        case enDownloadType.Sales:
                            DownloadSales();
                            break;
                        case enDownloadType.Stock:
                            DownloadStock();
                            //DisplayReportMasterStok();
                            break;
                        case enDownloadType.Toko:
                            DownloadToko();
                            break;
                        case enDownloadType.StatusToko:
                            DownloadStatusToko();
                            break;
                        case enDownloadType.PlafonToko:
                            DownloadPlafonToko();
                            break;
                        case enDownloadType.TokoDispensasi:
                            DownloadTokoDispensasi();
                            break;
                        case enDownloadType.TokoKhusus:
                            DownloadTokoKhusus();
                            break;

                    }

                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    _isProcessing = false;
                    this.Cursor = Cursors.Default;
                }
            }
        }


        #region Generate
        private ExcelPackage ProcessMaterStok()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "MasterStok";

            ex.Workbook.Worksheets.Add("Master STok");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 7;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 3;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 70;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 70;
            ws.Cells[1, 7].Worksheet.Column(7).Width = 15;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 2, 1, MaxCol].Merge = true;
            ws.Cells[1, 2].Value = "Laporan     : LAPORAN DOWNLOAD MASTER STOK";
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 2, 2, MaxCol].Merge = true;
            ws.Cells[2, 2].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", DateTime.Today);
            ws.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 2].Value = "KODE BARU"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA MASTER BARU"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "SAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "KODE LAMA"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "NAMA MASTER LAMA"; ws.Cells[5, 6, 6, 6].Merge = true;
            ws.Cells[5, 7].Value = "KETERANGAN"; ws.Cells[5, 7, 6, 7].Merge = true;

            ws.Cells[5, 2, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 2, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;

            foreach (DataRow dr1 in tblDownload.Rows)
            {
                ws.Cells[rowx, 2].Value = dr1["Idmain"];
                ws.Cells[rowx, 3].Value = dr1["Nm_plist"];

                ws.Cells[rowx, 4].Value = dr1["Satsolo"];

                ws.Cells[rowx, 5].Value = dr1["Oldcode"];

                ws.Cells[rowx, 6].Value = dr1["Oldname"];

                ws.Cells[rowx, 7].Value = dr1["Keterangan"];



                rowx++;
            }


            ws.Cells[5, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 2, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            return ex;
        }


        private ExcelPackage ProcessHpp()
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "HPP";

            ex.Workbook.Worksheets.Add("HPP");
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            // Width
            int MaxCol = 6;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 3;
            ws.Cells[1, 2].Worksheet.Column(2).Width = 20;
            ws.Cells[1, 3].Worksheet.Column(3).Width = 70;
            ws.Cells[1, 4].Worksheet.Column(4).Width = 15;
            ws.Cells[1, 5].Worksheet.Column(5).Width = 20;
            ws.Cells[1, 6].Worksheet.Column(6).Width = 45;
            //ws.Cells[1, 7].Worksheet.Column(7).Width = 15;



            //ws.Cells[3, 1, 3, 3].Merge = true;

            // Title
            ws.Cells[1, 2, 1, MaxCol].Merge = true;
            ws.Cells[1, 2].Value = "Laporan     : HPP TER-DOWNLOAD";
            ws.Cells[1, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[1, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[2, 2, 2, MaxCol].Merge = true;
            ws.Cells[2, 2].Value = "Periode     : " + string.Format("{0:dd MMMM yyyy}", DateTime.Today);
            ws.Cells[2, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[2, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Cells[3, 1].Value = "Update      : ";

            //Header
            ws.Cells[5, 2].Value = "KODE BARANG"; ws.Cells[5, 2, 6, 2].Merge = true;
            ws.Cells[5, 3].Value = "NAMA BARANG YANG BELUM SAMA DENGAN 11"; ws.Cells[5, 3, 6, 3].Merge = true;
            ws.Cells[5, 4].Value = "SAT"; ws.Cells[5, 4, 6, 4].Merge = true;
            ws.Cells[5, 5].Value = "HARGA"; ws.Cells[5, 5, 6, 5].Merge = true;
            ws.Cells[5, 6].Value = "KETERANGAN"; ws.Cells[5, 6, 6, 6].Merge = true;

            ws.Cells[5, 2, 6, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[5, 2, 6, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;



            int rowx = 7;

            foreach (DataRow dr1 in tblDownload.Rows)
            {
                ws.Cells[rowx, 2].Value = dr1["Idmain"];
                ws.Cells[rowx, 3].Value = dr1["Nm_plist"];

                ws.Cells[rowx, 4].Value = dr1["Satuan"];

                ws.Cells[rowx, 5].Value = Convert.ToDouble(dr1["Hjual"]);
                ws.Cells[rowx, 5].Style.Numberformat.Format = "#,##0.##;(#,##0.##);0";

                ws.Cells[rowx, 6].Value = dr1["Keterangan"];



                rowx++;
            }


            ws.Cells[5, 2, 5, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[5, 2, 5, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            ws.Cells[6, 2, 6, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.Aqua);
            var border = ws.Cells[5, 2, rowx - 1, MaxCol].Style.Border;
            border.Bottom.Style =
            border.Top.Style =
            border.Left.Style =
            border.Right.Style = ExcelBorderStyle.Thin;

            return ex;
        }
        #endregion

        private void DisplayReportMasterStok()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ProcessMaterStok());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Download_SasStok " + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private void DisplayReportHPP()
        {
            try
            {
                List<ExcelPackage> exs = new List<ExcelPackage>();
                exs.Add(ProcessHpp());

                #region Generate File
                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = "C:\\Temp\\";
                sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
                sf.FileName = "Download_HPP" + GlobalVar.Gudang;
                // sf.FileName = "Rekonsiliasi Harian PJK + PIUT";

                sf.OverwritePrompt = true;
                if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
                {
                    string file = sf.FileName.ToString();
                    Byte[] bin1 = exs[0].GetAsByteArray();
                    File.WriteAllBytes(file, bin1);
                    MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                    Process.Start(sf.FileName.ToString());
                }
            }
                #endregion

            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }
    }
}
