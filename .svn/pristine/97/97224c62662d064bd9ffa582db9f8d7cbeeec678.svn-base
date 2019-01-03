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
    public partial class frmPotonganUpload : ISA.Trading.BaseForm
    {

        #region "Function & Variable"
        string KodeGudang="";
        string _hFileName = "";
        DataSet dsResult = new DataSet();

        public void RefreshData()
        {
            HeaderprogressBar.Value = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PenjualanPotongan_Upload]"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, rangeDateBox1.FromDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, rangeDateBox1.ToDate.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, lookupGudang.GudangID));

                    dsResult = db.Commands[0].ExecuteDataSet();

                    dataGridHeader.DataSource = dsResult.Tables[0];
                  

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

        private void ZipFile(string FileName1)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";


            string fileZipName = GlobalVar.DbfUpload + "\\DBFMATCH.zip";
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

            MessageBox.Show("Upload selesai, lokasi file upload: " + fileZipName + " kirim file ke gudang: " + lookupGudang.GudangID);
        }

        private void Upload1(String FileName)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();
        
            fields.Add(new Foxpro.DataStruct("TrID", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("PotID", "Idpot", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Nopot", "Nopot", Foxpro.enFoxproTypes.Char, 11));
            fields.Add(new Foxpro.DataStruct("TglPot", "Tgl_pot", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Dil", "Dil", Foxpro.enFoxproTypes.Numeric, 8));
            fields.Add(new Foxpro.DataStruct("Disc", "Disc", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("TglACC", "Tgl_acc", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("RpNet", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("DilACC", "Dil_acc", Foxpro.enFoxproTypes.Numeric, 11));
            fields.Add(new Foxpro.DataStruct("CatACC", "Cat_acc", Foxpro.enFoxproTypes.Char, 17));
            fields.Add(new Foxpro.DataStruct("DiscACC", "Disc_acc", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Dib", "Dib", Foxpro.enFoxproTypes.Numeric, 8));
            fields.Add(new Foxpro.DataStruct("Dib_ACC", "Dib_acc", Foxpro.enFoxproTypes.Numeric, 10));
            fields.Add(new Foxpro.DataStruct("IdLink", "Id_link", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KodeToko", "Kd_toko", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("StatusACC", "Acc", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "Id_match", Foxpro.enFoxproTypes.Char, 1));
         
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0], HeaderprogressBar);
        }
       
        private void DisplayReport()
        {
          
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("KodeGudang", lookupGudang.GudangID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptPotonganUpload.rdlc", rptParams, dsResult.Tables[1], "dsNotaPenjualan_Data");
            ifrmReport.Show();

        }
#endregion

        public frmPotonganUpload()
        {
            InitializeComponent();
        }

        private void frmPotonganUpload_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            dataGridHeader.AutoGenerateColumns = true;
        }

        private void cmdClosse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
         if (dataGridHeader.RowCount==0)
         {
             cmdSearch.Focus();
             return;
         }

         try
         {
             this.Cursor = Cursors.WaitCursor;

             Upload1(_hFileName);
           
             ZipFile(_hFileName);
             this.Cursor = Cursors.Default;
             //MessageBox.Show(Messages.Confirm.ProcessFinished);
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

        private void lookupGudang_Leave(object sender, EventArgs e)
        {
            if (lookupGudang.NamaGudang.Trim()=="")
            {
                lookupGudang.GudangID = "";
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (lookupGudang.GudangID=="")
            {
                lookupGudang.Focus();
                return;
            }

            KodeGudang = lookupGudang.GudangID;
            _hFileName = "POT" + KodeGudang;
            RefreshData();
        }

    }
}
