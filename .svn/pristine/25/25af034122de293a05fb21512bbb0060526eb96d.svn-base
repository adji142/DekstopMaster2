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
    public partial class frmPenjualanNotaUpload11 : ISA.Trading.BaseForm
    {
        DataSet dsResult = new DataSet();
        string FileName1 = "Htj2tmp";
        string FileName2 = "Dtj2tmp";

        public frmPenjualanNotaUpload11()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables[0].Rows.Count > 0 && dsResult.Tables[1].Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\DBFMATCH.zip");
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
            if (SecurityManager.IsAOperator())
            {
                MessageBox.Show("Bagian operator tidak mempunyai hak akses untuk melakukan upload nota ke 11", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (rangeNota.FromDate != null && rangeNota.ToDate != null)
                {
                    RefreshData();
                    cmdUpload.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Tanggal Nota tidak boleh kosong", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    db.Commands.Add(db.CreateCommand("usp_PenjualanNotaKe11_UPLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.Char, GlobalVar.CabangID));
                    dsResult = db.Commands[0].ExecuteDataSet();

                    gvUpload1.DataSource = dsResult.Tables[0];
                    gvUpload2.DataSource = dsResult.Tables[1];

                    pbUpload1.Value = 0;
                    pbUpload2.Value = 0;
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

        private void frmPenjualanNotaUpload11_Load(object sender, EventArgs e)
        {
            rangeNota.FromDate = DateTime.Now;
            rangeNota.ToDate = DateTime.Now;
        }

        private void Upload()
        {
            string Physical1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string Physical2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";

            if (File.Exists(Physical1))
            {
                File.Delete(Physical1);
            }

            if (File.Exists(Physical2))
            {
                File.Delete(Physical2);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("Idhtr", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idtr", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Cab1", "Cab1", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cab2", "Cab2", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Cab3", "Cab3", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("No_rq", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_rq", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_do", "No_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_do", "Tgl_do", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_nota", "No_nota", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_nota", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_sj", "No_sj", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_sj", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Hr_krdt", "Hr_krdt", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Kd_toko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Kd_sales", "Kd_sales", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Nm_toko", "Nm_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("Al_kirim", "Al_kirim", Foxpro.enFoxproTypes.Char, 60));
            fields.Add(new Foxpro.DataStruct("Kota", "Kota", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("Rp_jual", "Rp_jual", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_jual2", "Rp_jual2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_jual3", "Rp_jual3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_net", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_net2", "Rp_net2", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_net3", "Rp_net3", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc_1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Pot_rp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("Pot_rp2", "Pot_rp2", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("Pot_rp3", "Pot_rp3", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("Rp_fee1", "Rp_fee1", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Rp_fee2", "Rp_fee2", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Laudit", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Id_disc", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Catatan1", "Catatan1", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan2", "Catatan2", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan3", "Catatan3", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan4", "Catatan4", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Catatan5", "Catatan5", Foxpro.enFoxproTypes.Char, 40));
            fields.Add(new Foxpro.DataStruct("Tgl_strm", "Tgl_strm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Tgl_reord", "Tgl_reord", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Lbo", "Lbo", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Id_match", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Id_link", "Id_link", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Id_tr", "Id_tr", Foxpro.enFoxproTypes.Char, 2));
            fields.Add(new Foxpro.DataStruct("Hari_krm", "Hari_krm", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Hari_sls", "Hari_sls", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 2));
            fields.Add(new Foxpro.DataStruct("No_acc", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Shift", "Shift", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Checker_1", "Checker_1", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Checker_2", "Checker_2", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("Cab0", "Cab0", Foxpro.enFoxproTypes.Char, 2));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName1, fields, dsResult.Tables[0], pbUpload1);


            List<Foxpro.DataStruct> fields2 = new List<Foxpro.DataStruct>();

            fields2.Add(new Foxpro.DataStruct("Idrec", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("Idtr", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("Nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields2.Add(new Foxpro.DataStruct("Klp", "Klp", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("J_rq", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("J_do", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("J_sj", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("J_nota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("J_retur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("J_koli", "J_koli", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Koli_awal", "Koli_awal", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Koli_akhir", "Koli_akhir", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("No_koli", "No_koli", Foxpro.enFoxproTypes.Char, 15));
            fields2.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields2.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("Tgl_sj", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields2.Add(new Foxpro.DataStruct("H_jual", "H_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("H_pokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("Hpp_solo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields2.Add(new Foxpro.DataStruct("Disc_1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Disc_2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Disc_3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields2.Add(new Foxpro.DataStruct("Pot_rp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields2.Add(new Foxpro.DataStruct("Id_disc", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("Id_koreksi", "Id_koreksi", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("Kd_toko", "Kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields2.Add(new Foxpro.DataStruct("No_bodo", "No_bodo", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("Id_match", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields2.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));
            fields2.Add(new Foxpro.DataStruct("No_acc", "No_acc", Foxpro.enFoxproTypes.Char, 7));
            fields2.Add(new Foxpro.DataStruct("Ket_koli", "Ket_koli", Foxpro.enFoxproTypes.Char, 20));
            fields2.Add(new Foxpro.DataStruct("Id_brg", "Id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields2.Add(new Foxpro.DataStruct("Kd_gdg", "Kd_gdg", Foxpro.enFoxproTypes.Char, 4));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName2, fields2, dsResult.Tables[1], pbUpload2);

        }

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";

            string fileZipName = GlobalVar.DbfUpload + "\\DBFMATCH.zip";

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

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeNota.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeNota.ToDate).ToString("dd/MM/yyyy"));

            List<ReportParameter> rptParams = new List<ReportParameter>();
            
            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptPenjualanNotaUpload11.rdlc", rptParams, dsResult.Tables[2], "dsSales_Data");

            ifrmReport.Show();

        }
    }
}
