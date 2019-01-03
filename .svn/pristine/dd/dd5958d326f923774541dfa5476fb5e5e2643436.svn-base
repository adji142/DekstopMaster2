using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;

namespace ISA.Trading.Communicator
{
    public partial class frmPlafonTokoDownload : ISA.Trading.BaseForm
    {

        DataTable tblHeader;

        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            int result = 0;

            using (Database db = new Database())
            {
                // HEADERS

                foreach (DataRow dr in tblHeader.Rows)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Data_PlafonToko_Download"));
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["Plf_fb"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@plf_fx", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["Plf_fx"], "0").ToString().Trim())));
                   db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();
                    if (result >= 0)
                    {
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                    db.CommitTransaction();
                }

            }
        }


        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void LoadGridFromDBF()
        {

            try
            {
                if (File.Exists(GlobalVar.DbfDownload + "\\Download\\dbfmatch.zip"))
                {
                    ExtractFile(GlobalVar.DbfDownload + "\\Download\\dbfmatch.zip");
                }
                else
                {
                    MessageBox.Show("File " + GlobalVar.DbfDownload + "\\Download\\dbfmatch.zip tidak ada");
                    return;
                }

                string fileNameH = "Plftmp.DBF";



                fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;


                if (File.Exists(fileNameH))
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHeader;
                    lblDownloadStatus1.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("File " + fileNameH + " tidak ada");
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
        }
        
        public frmPlafonTokoDownload()
        {
            InitializeComponent();

        }

        private void btnDownld_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Data Toko ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

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
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPlafonTokoDownload_Load(object sender, EventArgs e)
        {
            this.Title = "Plafon Toko Download";
            dataGridView1.AutoGenerateColumns = true;
            LoadGridFromDBF();
        }

    
    }
}
