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

namespace ISA.Toko.Communicator
{
    public partial class frmAntarGudangDownload : ISA.Toko.BaseForm
    {
#region "Function & Variable"
        DataTable tblHeader;
        DataTable tblDetail;


        DataTable tblStok;
        DataTable tblStokPart;

        Guid _RowIDHeader;
        Guid _RowID;
        String _RecordIDHeader;
        Guid _RowIDStok;

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
            int result2 = 0;
            using (Database db = new Database())
            {
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_Antargudang_Download"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    string KodeGudang = Tools.isNull(dr["ke_gud"], "").ToString();
                    if (KodeGudang == GlobalVar.Gudang)
                    {
                        //add parameters
                        _RowIDHeader = Guid.NewGuid();
                        _RecordIDHeader = Tools.isNull(dr["idhkrmagud"], "").ToString().Trim();
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@DrGudang", SqlDbType.VarChar, Tools.isNull(dr["dr_gud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeGudang", SqlDbType.VarChar, Tools.isNull(dr["ke_gud"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@TglKirim", SqlDbType.DateTime, dr["tgl_krm"]));
                        
                        if (KodeGudang=="2803")
                          db.Commands[0].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, Tools.isNull(dr["Tgl_trm"],GlobalVar.DateTimeOfServer)));

                        db.Commands[0].Parameters.Add(new Parameter("@noAG", SqlDbType.VarChar, Tools.isNull(dr["no_ag"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, Tools.isNull(dr["pengirim"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Penerima", SqlDbType.VarChar, Tools.isNull(dr["penerima"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DrCheck1", SqlDbType.VarChar, Tools.isNull(dr["drcheck1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@DrCheck2", SqlDbType.VarChar, Tools.isNull(dr["drcheck2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeCheck1", SqlDbType.VarChar, Tools.isNull(dr["kecheck1"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KeCheck2", SqlDbType.VarChar, Tools.isNull(dr["kecheck2"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, Tools.isNull(dr["exp"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NoKendaraan", SqlDbType.VarChar, Tools.isNull(dr["no_kend"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaSopir", SqlDbType.VarChar, Tools.isNull(dr["nm_sopir"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@KirimTerimaID", SqlDbType.VarChar, Tools.isNull(dr["id_krmtrm"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();

                        result = db.Commands[0].ExecuteNonQuery();


                        if (result == 1 || result == 0)
                        {

                            //grid and form status
                            dr["cUploaded"] = true;
                            counter++;
                            progressBar1.Increment(1);
                            lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }

                        //DO DETAILS

                        DataRow[] orderDetails = tblDetail.Select("idhkrmagud='" + dr["idhkrmagud"].ToString() + "'");

                        if (orderDetails.Length == 0)
                        {
                            MessageBox.Show(Messages.Confirm.NoDetailData);
                           
                        }

                        db.Commands.Add(db.CreateCommand("usp_AntargudangDetail_Download"));
                        foreach (DataRow drd in orderDetails)
                        {
                            //add parameters
                            db.Commands[1].Parameters.Clear();
                            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                            db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Iddkrmagud"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@TransactionID", SqlDbType.VarChar, Tools.isNull(drd["Idhkrmagud"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@Kodebarang", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@qtyKirim", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["qty_krm"], "0").ToString().Trim())));

                            if (KodeGudang == "2803")
                                db.Commands[1].Parameters.Add(new Parameter("@QtyTerima", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["qty_krm"], "0").ToString().Trim())));

                            db.Commands[1].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(drd["catatan"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@ongkos", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["ongkos"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Convert.ToInt32(Tools.isNull(drd["id_match"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["qty_do"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                            result2 = db.Commands[1].ExecuteNonQuery();

                            //grid and form status
                            if (result2 == 0 || result2 == 1)
                            {
                                drd["cUploaded"] = true;
                                counter++;
                                progressBar2.Increment(1);
                                lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }

                        }

                        db.CommitTransaction();
                    }
                }

            }
        }
#endregion

        public frmAntarGudangDownload()
        {
            InitializeComponent();
        }

        private void frmAntarGudangDownload_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\dbfmatch.zip tidak ada");
                return;
            }
           
            string fileNameH = "Hagtmp.dbf";
            string fileNameD = "Dagtmp.dbf";
            string fileNameS = "Stoktmp.dbf";
            string fileNameSP = "Parttmp.DBF";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;
            fileNameS = GlobalVar.DbfDownload + "\\" + fileNameS;
            fileNameSP = GlobalVar.DbfDownload + "\\" + fileNameSP;


            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHeader;
                    lblDownloadStatus1.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
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

            if (File.Exists(fileNameD))
            {
                try
                {
                    tblDetail = Foxpro.ReadFile(fileNameD);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblDetail.Columns.Add(newcol);

                    dataGridView3.DataSource = tblDetail;
                    lblDownloadStatus2.Text = "0/" + tblDetail.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = tblDetail.Rows.Count;
                    this.Title = fileNameD;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameD + " tidak ada");
                return;
            }


            if (File.Exists(fileNameS))
            {
                try
                {
                    tblStok = Foxpro.ReadFile(fileNameS);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStok.Columns.Add(newcol);

                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameS + " tidak ada");
                return;
            }

            if (File.Exists(fileNameSP))
            {
                try
                {
                    tblStokPart = Foxpro.ReadFile(fileNameSP);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblStokPart.Columns.Add(newcol);

                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileNameSP + " tidak ada");
                return;
            }



        }

        private void downloadStok()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            //int result2 = 0;
            int result3 = 0;
            using (Database db = new Database())
            {
                // Master Stok
                db.Commands.Add(db.CreateCommand("usp_MasterStok_Download"));
                counter = 0;
                foreach (DataRow dr in tblStok.Rows)
                {
                    //add parameters
                    //counter = 0;
                    _RowIDStok = Guid.NewGuid();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDStok));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["Idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, Tools.isNull(dr["ID_BRG"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Tools.isNull(dr["Nama_Stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kendaraan", SqlDbType.VarChar, Tools.isNull(dr["Kendaraan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PartNo", SqlDbType.VarChar, Tools.isNull(dr["partno"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Merek", SqlDbType.VarChar, Tools.isNull(dr["Merek"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SatSolo", SqlDbType.VarChar, Tools.isNull(dr["Sat_solo"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SatJual", SqlDbType.VarChar, Tools.isNull(dr["Sat_jual"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    //db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();


                    if (result == 1 || result == 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        //progressBar1.Increment(1);
                        //lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblStok.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                }


                if (tblStokPart != null)
                {
                    //STOKPART
                    db.Commands.Add(db.CreateCommand("usp_StokPart_Download"));
                    counter = 0;
                    foreach (DataRow dr2 in tblStokPart.Rows)
                    {
                        //counter = 0;
                        //add parameters
                        db.Commands[1].Parameters.Clear();
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[1].Parameters.Add(new Parameter("@RowIDStok", SqlDbType.UniqueIdentifier, _RowIDStok));
                        db.Commands[1].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr2["Id_brg"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(dr2["Nama_stok"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr2["Idrec"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@sat_jual", SqlDbType.VarChar, Tools.isNull(dr2["Sat_jual"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@merek", SqlDbType.VarChar, Tools.isNull(dr2["Merek"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, Tools.isNull(dr2["Jenis"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@kelompok", SqlDbType.VarChar, Tools.isNull(dr2["Kelompok"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@supplier", SqlDbType.VarChar, Tools.isNull(dr2["Supplier"], "").ToString().Trim()));
                        //Convert.ToInt32(Tools.isNull(dr2["Id_tr"], "0").ToString().Trim())))Int32.Parse
                        db.Commands[1].Parameters.Add(new Parameter("@id_tr", SqlDbType.VarChar, Tools.isNull(dr2["Id_tr"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@r1", SqlDbType.NChar, Tools.isNull(dr2["R1"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@r2", SqlDbType.NChar, Tools.isNull(dr2["R2"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@r3", SqlDbType.NChar, Tools.isNull(dr2["R3"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@r4", SqlDbType.NChar, Tools.isNull(dr2["R4"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@cash", SqlDbType.NChar, Tools.isNull(dr2["Cash"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@top10", SqlDbType.NChar, Tools.isNull(dr2["Top10"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@enduser", SqlDbType.NChar, Tools.isNull(dr2["Enduser"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        //db.BeginTransaction();

                        result3 = db.Commands[1].ExecuteNonQuery();

                        //grid and form status
                        if (result3 == 0 || result3 == 1)
                        {
                            dr2["cUploaded"] = true;
                            counter++;
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }

                    }
                }

            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download AntarGudang ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    downloadStok();
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
