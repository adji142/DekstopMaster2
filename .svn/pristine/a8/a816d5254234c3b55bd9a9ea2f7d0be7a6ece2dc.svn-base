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
    public partial class frmPembelianUpload : ISA.Toko.BaseForm
    {

#region "Function & Variable"
        string _hFileName = "HpbTemp";
        string _dFileName = "DpbTemp";
        DataSet dsResult = new DataSet();

        public void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    HeaderprogressBar.Value = 0;
                    DetailprogressBar.Value = 0;

                    db.Commands.Add(db.CreateCommand("[usp_NotaPembelian_Upload]"));
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

            string fileZipName = GlobalVar.DbfUpload + "\\Pbtemp.zip";
            files.Add(fileName1);
            files.Add(fileName2);

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

            fields.Add(new Foxpro.DataStruct("Idtr", "Idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("No_rq", "No_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_rq", "Tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_do", "No_do", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Tgl_trans", "Tgl_trans", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_nota", "No_nota", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Tgl_nota", "Tgl_nota", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("No_sj", "No_sj", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("Tgl_sj", "Tgl_sj", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Pemasok", "Pemasok", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Rp_beli", "Rp_beli", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Rp_net", "Rp_net", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Disc_1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Expedisi", "Expedisi", Foxpro.enFoxproTypes.Char, 9));
            fields.Add(new Foxpro.DataStruct("Laudit", "Laudit", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("Id_disc", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Ppn", "Ppn", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Id_match", "Id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Cab", "Cab", Foxpro.enFoxproTypes.Char, 2));

            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[0],HeaderprogressBar);
        }

        private void Upload2(String FileName)
        {

            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("idrec", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("idtr", "idtr", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Nama_stok", "Nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("Klp", "Klp", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("J_rq", "J_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("J_do", "J_do", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("J_sj", "J_sj", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("J_nota", "J_nota", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("J_retur", "J_retur", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Satuan", "Satuan", Foxpro.enFoxproTypes.Char, 3));
            fields.Add(new Foxpro.DataStruct("Catatan", "Catatan", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Tgl_trm", "Tgl_trm", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("H_beli", "H_beli", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("H_pokok", "H_pokok", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Hpp_solo", "Hpp_solo", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Disc_1", "Disc_1", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_2", "Disc_2", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Disc_3", "Disc_3", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("Id_disc", "Id_disc", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("Pot_rp", "Pot_rp", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("Ppn", "Ppn", Foxpro.enFoxproTypes.Numeric, 3));
            fields.Add(new Foxpro.DataStruct("Pemasok", "Pemasok", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("Id_match", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("Id_Brg", "Id_Brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("Kd_gdg", "Kd_gdg", Foxpro.enFoxproTypes.Char, 4));
            
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1],DetailprogressBar);
        }
#endregion

        public frmPembelianUpload()
        {
            InitializeComponent();
        }

        private void frmPembelianUpload_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            rangeDateBox1.Focus();
            dataGridHeader.AutoGenerateColumns = true;
            dataGridDetail.AutoGenerateColumns = true;
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
           if (dataGridHeader.Rows.Count ==0 || dataGridDetail.Rows.Count ==0)
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
               MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi file: " + GlobalVar.DbfUpload + "\\Pbtemp.zip");
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
