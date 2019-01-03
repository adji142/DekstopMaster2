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
    public partial class frmPersediaanUploadINPMAN : ISA.Trading.BaseForm
    {
        DataTable dtResult = new DataTable();
        List<string> files = new List<string>();
        string FileName = "DATAMAN";
        string ZipName = "dbfmatch";
        ErrorProvider err = new ErrorProvider();

        public frmPersediaanUploadINPMAN()
        {
            InitializeComponent();
        }

        private void Upload()
        {
            if (dtResult.Rows.Count == 0)
            {
                return;
            }
            pbUpload.Value = 0;
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string Indexing = GlobalVar.DbfUpload + "\\" + FileName + ".cdx";
            files.Add(Indexing);
            files.Add(Physical);

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("BarangID", "idmain", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("FromDate", "Tmt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("ToDate", "Tmt1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("QtyAwal", "Awal", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyBeli", "Beli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturBeli", "Rbeli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyKoreksiBeli", "Kbeli", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyJual", "Jual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturJual", "Rjual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyJualAntarCab", "Jualcab", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyReturJualAntarCab", "Rjualcab", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyKoreksiJual", "Kjual", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtySelisih", "Selisih", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyMutasi", "Mutasi", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyAkhir", "Akhir", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("KodeGudang", "Kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Syncflag", "Id_match", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Hpp", "Hpp", Foxpro.enFoxproTypes.Numeric, 15));
            fields.Add(new Foxpro.DataStruct("NKorJual", "Korpj", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorRetJual", "Korrj", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorBeli", "Korpb", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NKorRetBeli", "Korrb", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("NAG", "Ag", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyADJOpname", "Adjopnm", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("QtyAdjClosing", "Adjstok", Foxpro.enFoxproTypes.Numeric, 10));
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtResult);
            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("idmain", "IDMAIN"));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtResult, pbUpload,index);
        }

        private void ZipFile(List<string> files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\" + ZipName + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            foreach (string str in files)
            {
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
        }

        private void frmPersediaanUploadINPMAN_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            toDate.DateValue = DateTime.Now;
            fromDate.SetValue(new DateTime(toDate.DateValue.Value.Year, toDate.DateValue.Value.Month, 1));
        }

        private void toDate_Validating(object sender, CancelEventArgs e)
        {
            if (toDate.DateValue.HasValue)
            {
                fromDate.SetValue(new DateTime(toDate.DateValue.Value.Year, toDate.DateValue.Value.Month, 1));
            }else
            {
                toDate.Focus();
                err.SetError(toDate, "harus Di isi!!!");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if ((fromDate.DateValue.HasValue) && (toDate.DateValue.HasValue))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_StokGudang_Upload_INPMAN"));
                        db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate.DateValue.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate.DateValue.Value));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        dtResult = db.Commands[0].ExecuteDataTable();
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

            if (dtResult.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile(files);
                    this.Cursor = Cursors.Default;
                    label2.Text = "Lokasi file: " + GlobalVar.DbfUpload + "\\" + ZipName + ".zip";
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\" + ZipName + ".zip");
                    //DisplayReport();
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
                dtResult = null;
            }
        }
    }
}
