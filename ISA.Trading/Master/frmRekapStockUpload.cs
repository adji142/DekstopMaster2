using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.IO;
using ISA.Trading.Class;
using System.Xml;

namespace ISA.Trading.Master
{
    public partial class frmRekapStockUpload : ISA.Trading.BaseForm
    {       
        public frmRekapStockUpload()
        {
            InitializeComponent();
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try 
            {
                using(Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RekapStock_LIST_Upload"));
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime, mybPeriode.FirstDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, mybPeriode.LastDateOfMonth));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, GlobalVar.Gudang));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                if(dt.Rows.Count <= 0)
                {
                    MessageBox.Show("No Data !!");
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                Upload(dt);
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Proses Upload Selesai.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void Upload(DataTable dt) 
        {
            string file = GenerateXML(dt);

            ZipFile(file);
        }

        private string GenerateXML(DataTable data)
        {
            string path = GlobalVar.DbfUpload + "\\FTP\\UPLOAD\\RekapStock\\";
            string filePath = path + "Data" + GlobalVar.Gudang + ".xml";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            StringWriter writer = new StringWriter();
            data.TableName = "RekapStock";
            data.WriteXml(filePath, XmlWriteMode.IgnoreSchema, true);
            return filePath;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRekapStockUpload_Load(object sender, EventArgs e)
        {
            mybPeriode.Month = GlobalVar.DateOfServer.Month;
            mybPeriode.Year = GlobalVar.DateOfServer.Year;
        }

        private void ZipFile(string files)
        {
            string fileZipName = GlobalVar.DbfUpload + "\\FTP\\UPLOAD\\RekapStock\\Data" + GlobalVar.Gudang + ".zip";

            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(files))
            {
                File.Delete(files);
            }
        } 
    }
}
