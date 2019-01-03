using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.DataTemplates;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Toko.Communicator
{
    public partial class frmBonusPengajuanDari11Download : ISA.Toko.BaseForm
    {
        DataTable dt;

        public frmBonusPengajuanDari11Download()
        {
            InitializeComponent();
        }

        private void frmACCBonusDownload_Load(object sender, EventArgs e)
        {
            ExtractData();
        }

        private void ExtractFile(string fileName)
        {
            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\ACCBNS11.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\ACCBNS11.zip");
            }

            string fileName = GlobalVar.DbfDownload + "\\Bnstmp.dbf";

            if (File.Exists(fileName))
            {
                try
                {
                    dt = new DataTable();
                    dt = Foxpro.ReadFile(fileName);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dt.Columns.Add(newcol);

                    dataGridView1.DataSource = dt;
                    lblDownloadStatus.Text = "0/" + dt.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

        private void Download()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database())
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PerolehanBonusSales_DOWNLOAD"));
                        db.Commands[i].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dt.Rows[i]["kd_sales"]));
                        db.Commands[i].Parameters.Add(new Parameter("@periode", SqlDbType.VarChar, dt.Rows[i]["periode"]));
                        db.Commands[i].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dt.Rows[i]["no_acc"]));
                        db.Commands[i].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, dt.Rows[i]["tgl_acc"]));
                        db.Commands[i].Parameters.Add(new Parameter("@rpACC", SqlDbType.Money, dt.Rows[i]["rp_acc"]));
                        db.Commands[i].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    }

                    db.BeginTransaction();
                    int result;
                    for (int j = 0; j < db.Commands.Count; j++)
                    {
                        result = db.Commands[j].ExecuteNonQuery();

                        if (result != 0)
                        {
                            dt.Rows[j]["cUploaded"] = true;
                            progressBar1.Increment(1);
                            lblDownloadStatus.Text = j.ToString("#,##0") + "/" + dt.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                    db.CommitTransaction();

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

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Potongan Penjualan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Download();
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
