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
    public partial class frmHPPRataRataUpload : ISA.Trading.BaseForm
    {
        DataTable dtResult = new DataTable();
        
        string FileName = "hppatmp";

        public frmHPPRataRataUpload()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (dtResult == null)
            {
                cmdSearch.PerformClick();
            }

            if (dtResult.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    Upload();
                    ZipFile();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\" + FileName + ".zip");
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (dateProsesHPP.DateValue != null)
            {
                RefreshData();
            }
            else
            {
                MessageBox.Show("Masukan tanggal proses HPP rata-rata", "Upload HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmHPPRataRataUpload_Load(object sender, EventArgs e)
        {
            dateProsesHPP.DateValue = DateTime.Now;
            dtResult = null;
        }

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HPPRataRata_UPLOAD"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglAktif", SqlDbType.DateTime, dateProsesHPP.DateValue));
                    dtResult = db.Commands[0].ExecuteDataTable();
                    gvHPP.DataSource = dtResult;
                    pbUpload.Value = 0;
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
            if (dtResult.Rows.Count == 0)
            {
                return;
            }
            pbUpload.Value = 0;
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            
            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("HistoryID", "id_hist", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("RecordID", "id_stok", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeBarang", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("TglAktif", "tmt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("HPP", "hpp", Foxpro.enFoxproTypes.Numeric, 9));
            fields.Add(new Foxpro.DataStruct("HPPAverage", "hpp_ave", Foxpro.enFoxproTypes.Numeric, 9));
            fields.Add(new Foxpro.DataStruct("Satuan", "satuan", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Keterangan", "keterangan", Foxpro.enFoxproTypes.Char, 43));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));

            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtResult);
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dtResult, pbUpload);
        }

        private void ZipFile()
        {
            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";
            string fileZipName = GlobalVar.DbfUpload + "\\" + FileName + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            List<string> files = new List<string>();
            files.Add(fileName1);

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
            }
        }
    }
}
