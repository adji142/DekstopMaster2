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
    public partial class frmPenjualanDOUploadPos : ISA.Toko.BaseForm
    {
        DataTable dtResult = new DataTable();

        string FileName1 = "htjtmp";

        public frmPenjualanDOUploadPos()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dtResult.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Upload telah selesai. Lokasi file: " + GlobalVar.DbfUpload + "\\" + "DBFMATCH.ZIP");
                    DisplayReport();
                    cmdUpload.Enabled = false;
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
            else
            {
                MessageBox.Show(Messages.Error.NotFound);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            if (rangeDO.FromDate != null && rangeDO.ToDate != null && !String.IsNullOrEmpty(txtAccPos.Text))
            {
                RefreshData();
            }
            else
            {
                MessageBox.Show("Tanggal DO atau Upload ACC Pos tidak boleh kosong", "Upload Transaksi Penjualan DO ke Pos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                if(string.IsNullOrEmpty(txtAccPos.Text))
                {
                    txtAccPos.Focus();
                }
                else
                {
                    rangeDO.Focus();
                }
            }
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanDOTransaksiPos_UPLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@dateFrom", SqlDbType.DateTime, rangeDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@dateTo", SqlDbType.DateTime, rangeDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cPerusahaan", SqlDbType.VarChar, txtAccPos.Text));
                    dtResult = db.Commands[0].ExecuteDataTable();

                    gvUpload1.DataSource = dtResult;
                    
                    pbUpload1.Value = 0;

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

        private void Upload()
        {
            string Physical1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";

            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }
            
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("HtrID", "idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Cabang1", "cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cabang2", "cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("NoDo", "no_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglDO", "tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoACCPiutang", "no_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglACCPiutang", "tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("NamaToko", "nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("AlamatKirim", "al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("Kota", "kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("rp_net", "rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpACCPiutang", "rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpPlafonToko", "pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("RpPiutangTerakhir", "pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("RpGiroTolakTerakhir", "rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("RpOverdue", "rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Catatan1", "catatan", Foxpro.enFoxproTypes.Memo, 4));
            fields.Add(new Foxpro.DataStruct("Catatan5", "catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("NoDOBO", "no_dobo", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("LinkID", "id_link", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("ACCPiutangID", "checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("TransactionType", "id_tr", Foxpro.enFoxproTypes.Char, 2));

            Foxpro.WriteFile(GlobalVar.DbfUpload + "\\", FileName1, fields, dtResult, pbUpload1);

            UpdateLinkID();
        }

        private void UpdateLinkID()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PenjualanDPosUpdateLink_UPLOAD"));

                    foreach (DataRow dr in dtResult.Rows)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dr["HtrID"].ToString()));
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

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName1 + ".FPT";
            string fileZipName = GlobalVar.DbfUpload + "\\" + "DBFMATCH.ZIP";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1);
            files.Add(fileName2);

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }

            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }
        }

        private void frmPenjualanDOUpload_Load(object sender, EventArgs e)
        {
            rangeDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDO.ToDate = DateTime.Now;
        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDO.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDO.ToDate).ToString("dd/MM/yyyy"));
            
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            
            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptPenjualanDOUploadPos.rdlc", rptParams, dtResult, "dsOrderPenjualan_Data3");
            ifrmReport.Show();

        }
    }
}
