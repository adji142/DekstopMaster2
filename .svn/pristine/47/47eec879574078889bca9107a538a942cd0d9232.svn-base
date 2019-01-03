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
using ISA.Trading;
using ISA.Trading.Class;
using System.IO.Compression;

namespace ISA.Trading.Communicator
{
    public partial class FrmStokbufferUpload : ISA.Trading.BaseForm
    {
        #region "Global"
        string buffFileName = "nstmp";
        DataSet dsResult = new DataSet();
        //DataTable dtUploadMaster, dtUploadPart;
        DateTime Date;
        #endregion
        
//#region "Function"
        public void RefreshData(DateTime date)
        {
            progressBar1.Value = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_buffer_upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, date));
                    dsResult = db.Commands[0].ExecuteDataSet();
                    dataGridView1.DataSource = dsResult.Tables[0];
                }
                //dt.DefaultView.Sort = "NamaStok ASC";
                
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
//#endregion

        public FrmStokbufferUpload()
        {
            InitializeComponent();
        }

        private void FrmStokbufferUpload_Load(object sender, EventArgs e)
        {

            //txtGudangAsal.GudangID = GlobalVar.Gudang;
            dataGridView1.AutoGenerateColumns = true;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd,MMMM,yyyy";
            //RefreshData(Date);
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dsResult.Tables.Count == 0)
            {
                cmdSearch.PerformClick();
                return;
            }

            if (dsResult.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Tidak data yang diupload");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Upload(buffFileName);
                ZipFile(buffFileName);
                this.Cursor = Cursors.Default;
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\dbfmatch.zip");
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Date = dateTimePicker1.Value;
            RefreshData(Date);
        }

        private void Upload(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("idrec", "Idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("id_brg", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("tmt1", "tmt1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("tmt2", "tmt2", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("qbuffer", "qbuffer", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("catatan", "catatan", Foxpro.enFoxproTypes.Char, 50));
            fields.Add(new Foxpro.DataStruct("kd_gdg", "kd_gdg", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("avgjual", "avgjual", Foxpro.enFoxproTypes.Numeric, 10));
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0], progressBar1);
        }

        private void ZipFile(string FileName1)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";


            string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
            files.Add(fileName1);


            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);

            }


        }



    }
}
