using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;


namespace ISA.Trading.Master
{
    public partial class FrmHargaJualDownload : BaseForm
    {
        public FrmHargaJualDownload()
        {
            InitializeComponent();
        }
        #region "Function & Variable"
        DataTable tblStokPart;
        DataTable tblBMK;
     
        Guid _RowID;
        Guid _newRowIDStok;


        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void DeleteFile(string FileName)
        {

        }
        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            int result2 = 0;
            using (Database db = new Database())
            {
                // Master StokPart
                db.Commands.Add(db.CreateCommand("usp_StokPart_Download"));
                foreach (DataRow dr in tblStokPart.Rows)
                {
                    //add parameters
                    _RowID = Guid.NewGuid();
                    _newRowIDStok = Guid.NewGuid();
                  
                   
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDStok", SqlDbType.UniqueIdentifier, _newRowIDStok));
                    db.Commands[0].Parameters.Add(new Parameter("@Id_brg", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr["nama_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Idrec", SqlDbType.VarChar, Tools.isNull(dr["Idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sat_jual", SqlDbType.VarChar, Tools.isNull(dr["sat_jual"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr["merek"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, Tools.isNull(dr["Jenis"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Tools.isNull(dr["Kelompok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@supplier", SqlDbType.VarChar, Tools.isNull(dr["Supplier"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_tr", SqlDbType.VarChar, Tools.isNull(dr["Id_tr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@r1", SqlDbType.NChar, Tools.isNull(dr["R1"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@r2", SqlDbType.NChar,Tools.isNull(dr["R2"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@r3", SqlDbType.NChar, Tools.isNull(dr["R3"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@r4", SqlDbType.NChar, Tools.isNull(dr["R4"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.VarChar, Tools.isNull(dr["Lpasif"], "").ToString().Trim()));
                    //db.Commands[0].Parameters.Add(new Parameter("@Idmatch", SqlDbType.VarChar, Tools.isNull(dr["Idmatch"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, Tools.isNull(dr["Cash"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, Tools.isNull(dr["top10"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, Tools.isNull(dr["enduser"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();
                    result = db.Commands[0].ExecuteNonQuery();

                    if (result == 1 || result == 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblStokPart.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }


                    //BMK

                    db.Commands.Add(db.CreateCommand("usp_HistoryBMKDepo_DOWNLOAD"));
                    foreach (DataRow dr1 in tblBMK.Rows)
                    {

                        //add parameters
                        db.Commands[1].Parameters.Clear();
                        db.Commands[1].Parameters.Add(new Parameter("@id_hist", SqlDbType.VarChar, Tools.isNull(dr1["id_hist"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@id_stok", SqlDbType.VarChar, Tools.isNull(dr1["id_stok"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@tmt", SqlDbType.DateTime, dr1["tmt"]));
                        db.Commands[1].Parameters.Add(new Parameter("@tmt_pasif", SqlDbType.DateTime, dr1["tmt_pasif"]));
                        db.Commands[1].Parameters.Add(new Parameter("@hjual_std", SqlDbType.NChar, Tools.isNull(dr1["hjual_std"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@h_net", SqlDbType.NChar, Tools.isNull(dr1["h_net"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@qmin_b", SqlDbType.NChar, Tools.isNull(dr1["qmin_b"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@hjual_b", SqlDbType.NChar, Tools.isNull(dr1["hjual_b"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@qmin_m", SqlDbType.NChar, Tools.isNull(dr1["qmin_m"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@hjual_m", SqlDbType.NChar, Tools.isNull(dr1["hjual_m"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@qmin_k", SqlDbType.NChar,Tools.isNull(dr1["qmin_k"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@hjual_k", SqlDbType.NChar, Tools.isNull(dr1["hjual_k"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, Tools.isNull(dr1["ket"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@dl", SqlDbType.VarChar, Tools.isNull(dr1["dl"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr1["nama_stok"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@idrecstok", SqlDbType.VarChar, Tools.isNull(dr1["idrecstok"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(dr1["satuan"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@id_match", SqlDbType.VarChar, Tools.isNull(dr1["id_match"], "0").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@sts_laba", SqlDbType.VarChar, Tools.isNull(dr1["sts_laba"], "0").ToString().Trim()));
                        
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                      //  MessageBox.Show("oo");
                       
                        //db.BeginTransaction();

                        result2 = db.Commands[1].ExecuteNonQuery();

                        //grid and form status
                        //if (result2 == 1 || result2 == 0)
                        //{
                            dr1["cUploaded"] = true;
                            counter++;
                            progressBar2.Increment(1);
                            lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblBMK.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        //}


                        //STOKPART
                        //db.Commands.Add(db.CreateCommand("usp_StokPart_Download"));
                        //foreach (DataRow dr2 in tblStokPart.Rows)
                        //{
                        //    //add parameters
                        //    db.Commands[2].Parameters.Clear();
                        //    db.Commands[2].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@RowIDStok", SqlDbType.UniqueIdentifier, _RowID));
                        //    db.Commands[2].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr2["Id_brg"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr2["Nama_stok"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr2["Idrec"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@sat_jual", SqlDbType.VarChar, Tools.isNull(dr2["Sat_jual"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr2["Merek"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, Tools.isNull(dr2["Jenis"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Tools.isNull(dr2["Kelompok"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@supplier", SqlDbType.VarChar, Tools.isNull(dr2["Supplier"], "").ToString().Trim()));
                        //    //Convert.ToInt32(Tools.isNull(dr2["Id_tr"], "0").ToString().Trim())))Int32.Parse
                        //    db.Commands[2].Parameters.Add(new Parameter("@id_tr", SqlDbType.VarChar, Tools.isNull(dr2["Id_tr"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@r1", SqlDbType.NChar, Tools.isNull(dr2["R1"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@r2", SqlDbType.NChar, Tools.isNull(dr2["R2"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@r3", SqlDbType.NChar, Tools.isNull(dr2["R3"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@r4", SqlDbType.NChar, Tools.isNull(dr2["R4"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, Tools.isNull(dr2["Cash"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, Tools.isNull(dr2["Top10"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, Tools.isNull(dr2["Enduser"], "").ToString().Trim()));
                        //    db.Commands[2].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //    //db.BeginTransaction();

                        //    result3 = db.Commands[2].ExecuteNonQuery();

                        //    //grid and form status
                        //    //if (result3 == 0 || result3 == 1)
                        //    //{
                        //    //    dr2["cUploaded"] = true;
                        //    //    counter++;
                        //    //    progressBar3.Increment(1);
                        //    //    //-label9.Text = counter.ToString("#,##0") + "/" + tblStokPart.Rows.Count.ToString("#,##0");
                        //    //    this.Refresh();
                        //    //    this.Invalidate();
                        //    //    Application.DoEvents();
                        //    //}

                        //}
                   }
                    db.CommitTransaction();
                }

            }
        }

        #endregion

        private void FrmHargaJualDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\DBFMATCH.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\DBFMATCH.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\DBFMATCH.zip tidak ada");
                return;
            }

            string fileNameS = "Parttmp.dbf";
            string fileNameB = "tmpbmk.dbf";
            //string fileNameP = "Sptmp.dbf";

            fileNameS = GlobalVar.DbfDownload + "\\" + fileNameS;
            fileNameB = GlobalVar.DbfDownload + "\\" + fileNameB;
         //   fileNameP = GlobalVar.DbfDownload + "\\" + fileNameP;

            if (File.Exists(fileNameS))
            {
                try
                {
                    tblStokPart = Foxpro.ReadFile(fileNameS);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStokPart.Columns.Add(newcol);

                    dataGridView1.DataSource = tblStokPart;
                    lblDownloadStatus1.Text = "0/" + tblStokPart.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblStokPart.Rows.Count;
                    label2.Text = fileNameS;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            //else
            //{
            //    MessageBox.Show("File " + fileNameS + " tidak ada");
            //    return;
            //}

            if (File.Exists(fileNameB))
            {
                try
                {
                    tblBMK  = Foxpro.ReadFile(fileNameB);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblBMK.Columns.Add(newcol);

                    dataGridView2.DataSource = tblBMK;
                    lblDownloadStatus2.Text = "0/" + tblBMK.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = tblBMK.Rows.Count;
                    label4.Text = fileNameB;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameB + " tidak ada");
                return;
            }

            //if (File.Exists(fileNameP))
            //{
            //    try
            //    {
            //        tblStokPart = Foxpro.ReadFile(fileNameP);
            //        DataColumn newcol = new DataColumn("cUploaded");
            //        newcol.DataType = Type.GetType("System.Boolean");
            //        tblStokPart.Columns.Add(newcol);

            //        //-dataGridView5.DataSource = tblStokPart;
            //        //-label9.Text = "0/" + tblStokPart.Rows.Count.ToString("#,##0");
            //        progressBar3.Minimum = 0;
            //        progressBar3.Maximum = tblStokPart.Rows.Count;
            //        this.Title = fileNameP;
            //        this.DialogResult = DialogResult.OK;
            //    }

            //    catch (Exception ex)
            //    {
            //        Error.LogError(ex);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("File " + fileNameP + " tidak ada");
            //    return;
            //}
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            cmdDownload.Enabled = false;
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Harga Jual ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                //this.Enabled = false;

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
                    //this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
            cmdDownload.Enabled = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
