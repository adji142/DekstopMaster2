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
    public partial class frmReturPembelianUpload : ISA.Trading.BaseForm
    {

#region "Function & Variable"
        string _hFileName = "Hrbtemp";
        string _dFileName = "Drbtemp";
        DataSet dsResult = new DataSet();

        public void RefreshData()
        {
            HeaderprogressBar.Value = 0;
            DetailprogressBar.Value = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelian_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));

                    dsResult = db.Commands[0].ExecuteDataSet();
                   
                    dataGridHeader.DataSource = dsResult.Tables[0];
                    dataGridDetail.DataSource = dsResult.Tables[1];

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

        private void ZipFile(string FileName1, string FileName2)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileIndex = GlobalVar.DbfUpload + "\\" + FileName1 + ".CDX";
            string fileIndex2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            string fileZipName = GlobalVar.DbfUpload + "\\Retbtmp.zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileIndex);
            files.Add(fileIndex2);

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
                File.Delete(fileIndex);
                File.Delete(fileIndex2);
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
            /*
              HrbTemp (Idretur,No_mpr,No_retur,Tgl_retur,Pemasok,Penerima,Tgl_keluar,;
	  Rp_nilai,Pengirim,Id_match,Laudit,Nprint)
             
             */
            fields.Add(new Foxpro.DataStruct("Idretur", "Idretur", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("No_mpr", "No_mpr", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("No_retur", "No_retur", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_retur", "Tgl_retur", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Pemasok", "Pemasok", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Penerima", "Penerima", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("Tgl_keluar", "Tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Rp_nilai", "Rp_nilai", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Pengirim", "Pengirim", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("Id_match", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Laudit", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Nprint", "Nprint", Foxpro.enFoxproTypes.Numeric, 1));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("Idretur", "IDRETUR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0],HeaderprogressBar,index);
        }

        private void Upload2(String FileName)
        {

            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
            /*
             INSERT INTO Drbtemp (Idrec,Idretur,Idhtr,Iddtr,Kdretur,Nama_stok,Pemasok,Q_gudang,;
              Q_terima,Satuan,Klp,H_beli,H_net,H_pokok,Hpp_solo,Pot_rp,Id_disc,Disc_1,Disc_2,Disc_3,;
              Id_koreksi,Catatan,Tgl_keluar,Tgl_beli,Id_brg,Kd_gdg)
             */
            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idretur", "Idretur", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Idhtr", "Idhtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Iddtr", "Iddtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Kdretur", "Kdretur", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("Pemasok", "Pemasok", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Q_gudang", "Q_gudang", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Q_terima", "Q_terima", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Klp", "Klp", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("H_beli", "H_beli", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("H_net", "H_net", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("H_pokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Hpp_solo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Pot_rp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Id_disc", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Disc_1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Tgl_keluar", "Tgl_keluar", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Tgl_beli", "Tgl_beli", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Id_Brg", "Id_Brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Kd_gdg", "Kd_gdg", Foxpro.enFoxproTypes.Char, 4));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idrec", "IDREC"));
            index.Add(new Foxpro.IndexStruct("idretur", "IDRETUR"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1],DetailprogressBar,index);
        }

        private void DisplayReport()
        {
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate).ToString("dd/MM/yyyy"));
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptReturPembelianUpload.rdlc", rptParams, dsResult.Tables[1], "dsReturPembelian_Data");
            ifrmReport.Show();

        }
#endregion

        public frmReturPembelianUpload()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.Rows.Count == 0 || dataGridDetail.Rows.Count == 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Upload1(_hFileName);
                Upload2(_dFileName);
                ZipFile(_hFileName, _dFileName);
                this.Cursor = Cursors.Default;
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\Retbtmp.zip");
                DisplayReport();
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

        private void frmReturPembelianUpload_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            dataGridHeader.AutoGenerateColumns = true;
            dataGridDetail.AutoGenerateColumns = true;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
