using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Trading.Communicator
{
    public partial class frmBonusDataDownload : ISA.Trading.BaseForm
    {
        DataTable dt1, dt2, dt3;

        public frmBonusDataDownload()
        {
            InitializeComponent();
        }

        private void frmBonusDataDownload_Load(object sender, EventArgs e)
        {
            ExtractData();
        }

        private void ExtractFile(string fileName)
        {
            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\BNSTMP.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\BNSTMP.zip");
            }

            string
                fileName1 = GlobalVar.DbfDownload + "\\Grstktmp.dbf",
                fileName2 = GlobalVar.DbfDownload + "\\Dtstktmp.dbf",
                fileName3 = GlobalVar.DbfDownload + "\\Grprdtmp.dbf";

            // Read table 1 (Grstktmp)
            if (File.Exists(fileName1))
            {
                try
                {
                    dt1 = new DataTable();
                    dt1 = Foxpro.ReadFile(fileName1);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dt1.Columns.Add(newcol);

                    dataGridView1.DataSource = dt1;
                    lblDlStatus1.Text = "0/" + dt1.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt1.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            // Read table 2 (Dtstktmp)
            if (File.Exists(fileName2))
            {
                try
                {
                    dt2 = new DataTable();
                    dt2 = Foxpro.ReadFile(fileName2);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dt2.Columns.Add(newcol);

                    dataGridView2.DataSource = dt2;
                    lblDlStatus2.Text = "0/" + dt2.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = dt2.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            // Read table 3 (Grprdtmp)
            if (File.Exists(fileName3))
            {
                try
                {
                    dt3 = new DataTable();
                    dt3 = Foxpro.ReadFile(fileName3);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dt3.Columns.Add(newcol);

                    dataGridView3.DataSource = dt3;
                    lblDlStatus3.Text = "0/" + dt3.Rows.Count.ToString("#,##0");
                    progressBar3.Minimum = 0;
                    progressBar3.Maximum = dt3.Rows.Count;
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
                    int counter = 0;
                    int i;

                    for (i = 0; i < dt1.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_StokGroup_DOWNLOAD"));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, dt1.Rows[i]["id_grstok"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@namaGroup", SqlDbType.VarChar, dt1.Rows[i]["nama_group"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@formula", SqlDbType.Float, dt1.Rows[i]["formula"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@formula2", SqlDbType.Float, dt1.Rows[i]["formula2"]));
                        counter++;
                    }

                    for (i = 0; i < dt2.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_StokDetail_DOWNLOAD"));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, dt2.Rows[i]["id_grstok"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dt2.Rows[i]["idrec"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tglAktif", SqlDbType.DateTime, dt2.Rows[i]["tgl_aktif"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tglPasif", SqlDbType.DateTime, dt2.Rows[i]["tgl_pasif"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tglFresh", SqlDbType.DateTime, dt2.Rows[i]["tgl_fresh"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokMin", SqlDbType.Int, dt2.Rows[i]["stok_min"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokAkhir", SqlDbType.Int, dt2.Rows[i]["stok_akhir"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokAkh", SqlDbType.Int, dt2.Rows[i]["stok_akh"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt2.Rows[i]["idmain"]));
                        counter++;
                    }

                    for (i = 0; i < dt3.Rows.Count; i++)
                    {
                        db.Commands.Add(db.CreateCommand("usp_PeriodeGroup_DOWNLOAD"));
                        db.Commands[counter].Parameters.Add(new Parameter("@stokGroupID", SqlDbType.VarChar, dt3.Rows[i]["id_grstok"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tglAktif", SqlDbType.DateTime, dt3.Rows[i]["tmt2"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tglPasif", SqlDbType.DateTime, dt3.Rows[i]["tmt2"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@qty", SqlDbType.Int, dt3.Rows[i]["qty"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@prosen", SqlDbType.Float, dt3.Rows[i]["prosen"]));
                        db.Commands[counter].Parameters.Add(new Parameter("@tempo", SqlDbType.Int, dt3.Rows[i]["tempo"]));
                        counter++;
                    }

                    /******************************************************************************************/
                    db.BeginTransaction();
                    
                    int result;
                    counter = 0;

                    // execute command untuk table 1
                    for (i = 0; i < dt1.Rows.Count; i++)
                    {
                        result = db.Commands[counter].ExecuteNonQuery();
                        counter++;
                        if (result != 0)
                        {
                            dt1.Rows[i]["cUploaded"] = true;
                            progressBar1.Increment(1);
                            lblDlStatus1.Text = (i + 1).ToString("#,##0") + "/" + dt1.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                    // execute command untuk table 2
                    for (i = 0; i < dt2.Rows.Count; i++)
                    {
                        result = db.Commands[counter].ExecuteNonQuery();
                        counter++;

                        if (result != 0)
                        {
                            dt2.Rows[i]["cUploaded"] = true;
                            progressBar2.Increment(1);
                            lblDlStatus2.Text = (i+1).ToString("#,##0") + "/" + dt2.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                    // execute command untuk table 3
                    for (i = 0; i < dt3.Rows.Count; i++)
                    {
                        result = db.Commands[counter].ExecuteNonQuery();
                        counter++;

                        if (result != 0)
                        {
                            dt3.Rows[i]["cUploaded"] = true;
                            progressBar3.Increment(1);
                            lblDlStatus3.Text = (i + 1).ToString("#,##0") + "/" + dt3.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }

                    db.CommitTransaction();
                    /******************************************************************************************/
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
            if (dataGridView1.Rows.Count == 0 && dataGridView2.Rows.Count == 0 && dataGridView3.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Data Bonus?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
