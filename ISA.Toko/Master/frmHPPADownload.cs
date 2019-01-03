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

using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Toko.Master
{
    public partial class frmHPPADownload : ISA.Toko.BaseForm
    {
#region "Function & Variable"
        DataTable tblHPPA;
        
        Guid _RowID;
       

        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload,false);  
        }

        private void DeleteFile(string FileName)
        {

        }
        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;

            using (Database db = new Database())
            {
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_Hppa_Download"));
                foreach (DataRow dr in tblHPPA.Rows)
                {
                    //add parameters
                    _RowID = Guid.NewGuid();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HistoryID", SqlDbType.VarChar, Tools.isNull(dr["Id_hist"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(dr["Id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, dr["Tmt"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HPP", SqlDbType.Money, Tools.isNull(dr["Hpp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@HPPA", SqlDbType.Money, Tools.isNull(dr["Hpp_ave"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Satuan", SqlDbType.VarChar, Tools.isNull(dr["Satuan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["Keterangan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();


                    if (result == 1 || result == 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHPPA.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }

                    db.CommitTransaction();
                }
            }
        }
#endregion

        public frmHPPADownload()
        {
            InitializeComponent();
        }

        private void frmAntarGudangDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\hppatmp.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\hppatmp.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\hppatmp.zip tidak ada");
                return;
            }
           
            string fileNameH = "Hppatmp.dbf";
            


            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            

            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHPPA = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHPPA.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHPPA;
                    lblDownloadStatus1.Text = "0/" + tblHPPA.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHPPA.Rows.Count;
                    this.Title = fileNameH;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            { 
                MessageBox.Show("File " + fileNameH + " tidak ada");
                return;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download HPP Rata-Rata ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    Download();

                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }


    }
}
