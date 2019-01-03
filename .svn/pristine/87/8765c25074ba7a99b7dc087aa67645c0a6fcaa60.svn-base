using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;


namespace ISA.Finance.DKNForm
{
    public partial class frmDownloadDKNPilih : ISA.Finance.BaseForm
    {
        DataTable tblHeader;
        DataTable dtSdhDownload;

        public frmDownloadDKNPilih()
        {
            InitializeComponent();
        }

        private void cmdBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
            {
                ISA.Common.Zip.UnZipFiles(txtFileName.Text, GlobalVar.DbfDownload, false);
                ExtractData();
                DKNForm.frmDownloadDKNExecute ifrmChild = new DKNForm.frmDownloadDKNExecute(tblHeader);
                ifrmChild.WindowState = FormWindowState.Maximized;
                ifrmChild.ShowDialog();

            }
            else
            {
                MessageBox.Show("File tidak ada");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExtractData()
        {
            string fileNameH = "datahi.dbf";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);
                    //foreach (DataRow dr in tblHeader.Rows)
                    //{
                    //    dr["no_perk"] = "";
                    //}
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        

    }
}
