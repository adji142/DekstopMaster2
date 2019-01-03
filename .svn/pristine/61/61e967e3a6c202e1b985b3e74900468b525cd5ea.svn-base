using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Toko.Master
{
    public partial class frmPromoDownload : ISA.Toko.BaseForm
    {
        DataTable tblPromo, tblDetailPromo, tblDPromo, tblCPromo, tblBPromo;
        Guid _RowIDHeader, _RowIDDetail;


        private void insertHeaderPromo()
        {
            int counter = 0;
            int result = 0;
            
            using (Database db = new Database())
            {
                    foreach (DataRow dr in tblPromo.Rows) {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("usp_Promo_Header_Download"));
                            _RowIDHeader = Guid.NewGuid();
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, dr["tmt1"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dr["tmt2"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_sk", SqlDbType.DateTime, dr["tgl_sk"]));
                            db.Commands[0].Parameters.Add(new Parameter("@no_sk", SqlDbType.VarChar, Tools.isNull(dr["no_sk"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, Tools.isNull(dr["idtr"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_klaim", SqlDbType.DateTime, dr["tgl_klaim"]));
                            db.Commands[0].Parameters.Add(new Parameter("@sync_flag", SqlDbType.Bit,Tools.getBit(dr["id_match"] )));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                            result = db.Commands[0].ExecuteNonQuery();


                            if (result >= 0)
                            {
                                dr["cUploaded"] = true;
                                counter++;
                                progressBar1.Increment(1);
                                lblPrmo.Text = counter.ToString("#,##0") + "/" + tblPromo.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }
                    }               
            }
            
        }
        private void insertDetailPromo()
        {
            int counter2 = 0;
            int result2 = 0;
           
             using (Database db = new Database()){

                 foreach (DataRow drd in tblDetailPromo.Rows )
                 {      
                            _RowIDDetail  = Guid.NewGuid();
                            db.Commands.Add(db.CreateCommand("usp_Promo_Detail_Download"));
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDDetail ));
                            
                            db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime, drd["tmt1"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, drd["tmt2"]));
                            db.Commands[0].Parameters.Add(new Parameter("@id_tr", SqlDbType.VarChar, Tools.isNull(drd["id_tr"], "").ToString().Trim()));
                             db.Commands[0].Parameters.Add(new Parameter("@q_min", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["q_min"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@q_max", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["q_max"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@s_min", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["s_min"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@s_max", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["s_max"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar,  Tools.isNull(drd["satuan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_1"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_2", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_3", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_3"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["pot_rp"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@hrg_promo", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["hrg_promo"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@harga_max", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["harga_max"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@harga_min", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["harga_min"], "0").ToString().Trim())));
                           
                            db.Commands[0].Parameters.Add(new Parameter("@klp", SqlDbType.VarChar ,  Tools.isNull(drd["klp"], "0").ToString().Trim() ));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar ,  Tools.isNull(drd["id_brg"], "").ToString().Trim() ) );
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(drd["nama_stok"], "0").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, Tools.isNull(drd["idtr"], "0").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar , Tools.isNull(drd["idrec"], "0").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@sync_flag", SqlDbType.Bit ,  Tools.getBit(drd["id_match"]) )); 
                            db.Commands[0].Parameters.Add(new Parameter("@lob", SqlDbType.Bit, Tools.getBit(drd["lob"]) ));
                            db.Commands[0].Parameters.Add(new Parameter("@fa2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fa2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fa4", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fa4"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fb2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fb2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fb4", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fb4"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fc2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fc2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fc4", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fc4"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fe2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fe2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fe4", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fe4"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fx2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fx2"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fx4", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fx4"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fab", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fab"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@fal", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["fal"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@far", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["far"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                           // db.BeginTransaction();
                            result2 = db.Commands[0].ExecuteNonQuery();
                           // db.CommitTransaction();
                 
                            if (result2 >= 0)
                            {
                                drd["cUploaded"] = true;
                                counter2++;
                                progressBar2.Increment(1);
                                lblDetailPromo.Text = counter2.ToString("#,##0") + "/" + tblDetailPromo.Rows.Count.ToString("#,##0");
                                this.Refresh();
                                this.Invalidate();
                                Application.DoEvents();
                            }
               
                    }
               }
        }

        private void insertBPromo()
        {
            
            using (Database db = new Database())
            {
                int counter3 = 0;
                int result3 = 0;
                if (DVBpromo.RowCount > 0)
                {
                   // DataRow[] dtrPromoB = tblBPromo.Select("idrec ='" + drd["idrec"].ToString() + "'");
                    foreach (DataRow drdB in tblBPromo.Rows)
                    {

                        db.Commands.Add(db.CreateCommand("usp_Promo_B_Detail_Download"));
                        //add parameters
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[0].Parameters.Add(new Parameter("@idtr", SqlDbType.VarChar, Tools.isNull(drdB["idtr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(drdB["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(drdB["nama_stok"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, Tools.isNull(drdB["satuan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(drdB["idrec"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@sync_flag", SqlDbType.Bit, Tools.getBit(drdB["id_match"] ) ));
                        db.Commands[0].Parameters.Add(new Parameter("@item_code", SqlDbType.VarChar, Tools.isNull(drdB["item_code"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@harga", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drdB["harga"], "0").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@kd_tr", SqlDbType.VarChar, Tools.isNull(drdB["kd_tr"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@id_detail", SqlDbType.VarChar, Tools.isNull(drdB["id_detail"], "").ToString().Trim()));

                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                        // db.BeginTransaction();
                        result3 = db.Commands[0].ExecuteNonQuery();
                        // db.CommitTransaction();

                        if (result3 >= 0)
                        {
                            drdB["cUploaded"] = true;
                            counter3++;
                            progressBar3.Increment(1);
                            lblBpromo.Text = counter3.ToString("#,##0") + "/" + tblBPromo.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                    }
                }

            }
          
        }
        private void insertCPromo()
        {
            int result4 = 0;
             int counter4 = 0;
            // DataRow[] dtrPromoC = tblCPromo.Select("idrec ='" + drd["idrec"].ToString() + "'");
                        
               using (Database db = new Database()) {
                foreach (DataRow drdC in tblCPromo.Rows)
                {
                 
                    db.Commands.Add(db.CreateCommand("usp_Promo_C_Detail_Download"));
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, Tools.isNull(drdC["nama_stok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(drdC["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar,  Tools.isNull(drdC["satuan"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@qty_bns", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drdC["qty_bns"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_jual", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drdC["h_jual"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drdC["disc_1"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drdC["pot_rp"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@max_bns", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drdC["max_bns"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(drdC["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar,  Tools.isNull(drdC["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@iddrec", SqlDbType.VarChar,  Tools.isNull(drdC["iddrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sync_flag", SqlDbType.Bit,  Tools.getBit(drdC["id_match"])));
                     
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                    // db.BeginTransaction();
                    result4 = db.Commands[0].ExecuteNonQuery();
                    // db.CommitTransaction();

                    if (result4 >= 0)
                    {
                        drdC["cUploaded"] = true;
                        counter4++;
                        progressBar4.Increment(1);
                        lblCpromo.Text = counter4.ToString("#,##0") + "/" + tblCPromo.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                }
            }
        }
        private void insertDPromo()
        {
            int counter5 = 0;
            int result5 = 0;

            using (Database db = new Database())
            {
                foreach (DataRow drdC in tblDPromo.Rows)
                {

                    db.Commands.Add(db.CreateCommand("usp_Promo_D_Detail_Download"));
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_gdg", SqlDbType.VarChar, Tools.isNull(drdC["kd_gdg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_cab", SqlDbType.VarChar, Tools.isNull(drdC["kd_cab"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_gudang", SqlDbType.VarChar, Tools.isNull(drdC["nm_gudang"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drdC["disc_1"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, Tools.isNull(drdC["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@nm_toko", SqlDbType.VarChar, Tools.isNull(drdC["nm_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, Tools.isNull(drdC["kd_sales"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(drdC["idrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@iddrec", SqlDbType.VarChar, Tools.isNull(drdC["iddrec"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@sync_flag", SqlDbType.Bit, Tools.getBit(drdC["id_match"])));

                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                    // db.BeginTransaction();
                    result5 = db.Commands[0].ExecuteNonQuery();
                    // db.CommitTransaction();

                    if (result5 >= 0)
                    {
                        drdC["cUploaded"] = true;
                        counter5++;
                        progressBar5.Increment(1);
                        lblDpromo.Text = counter5.ToString("#,##0") + "/" + tblDPromo.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                }
            }
        }
     

        public void Download()
        {           
           
          

            if (DVPromo.RowCount > 0)
            {
                insertHeaderPromo();
            }

            if (DVdetailPromo.RowCount > 0)
            {
                 insertDetailPromo();

            }
              if (DVBpromo.RowCount > 0)
            {
                insertBPromo();
            }
            if (DVCpromo.RowCount > 0)
            {
                insertCPromo();
            }
            if (DVDpromo.RowCount > 0)
            {
                insertDPromo();
            }

                          
           
        }


        public frmPromoDownload()
        {
            InitializeComponent();
        }

        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void LoadGridFromDBF()
        {
            try
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

                string fileNameH = "hptmp.DBF";
                string fileNameD = "dptmp.DBF";
                string fileNamePromoB = "brgtmp.DBF";
                string fileNamePromoC = "cptmp.DBF";
                string fileNamePromoD = "ddptmp.DBF";



                fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
                fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;
                fileNamePromoB = GlobalVar.DbfDownload + "\\" + fileNamePromoB;
                fileNamePromoC = GlobalVar.DbfDownload + "\\" + fileNamePromoC;
                fileNamePromoD = GlobalVar.DbfDownload + "\\" + fileNamePromoD;


                if (File.Exists(fileNameH))
                {

                    tblPromo = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblPromo.Columns.Add(newcol);

                    DVPromo.DataSource = tblPromo;
                    lblPrmo.Text = "0/" + tblPromo.Rows.Count.ToString("#,##0");
                     progressBar1.Minimum = 0;
                     progressBar1.Maximum = tblPromo.Rows.Count;
                    this.DialogResult = DialogResult.OK;

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
                        tblDetailPromo = Foxpro.ReadFile(fileNameD);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblDetailPromo.Columns.Add(newcol);

                        DVdetailPromo.DataSource = tblDetailPromo;
                        lblDetailPromo.Text = "0/" + tblDetailPromo.Rows.Count.ToString("#,##0");
                        progressBar2.Minimum = 0;
                        progressBar2.Maximum = tblDetailPromo.Rows.Count;
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


                if (File.Exists(fileNamePromoB))
                {
                    try
                    {
                        tblBPromo = Foxpro.ReadFile(fileNamePromoB);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblBPromo.Columns.Add(newcol);

                        DVBpromo.DataSource = tblBPromo;
                        lblBpromo.Text = "0/" + tblBPromo.Rows.Count.ToString("#,##0");
                        progressBar3.Minimum = 0;
                        progressBar3.Maximum = tblBPromo.Rows.Count;
                        this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    MessageBox.Show("File " + fileNamePromoB + " tidak ada");
                    return;
                }


                if (File.Exists(fileNamePromoC))
                {
                    try
                    {
                        tblCPromo = Foxpro.ReadFile(fileNamePromoC);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblCPromo.Columns.Add(newcol);

                        DVCpromo.DataSource = tblCPromo;
                        lblCpromo.Text = "0/" + tblCPromo.Rows.Count.ToString("#,##0");
                        progressBar4.Minimum = 0;
                        progressBar4.Maximum = tblCPromo.Rows.Count;
                        this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    MessageBox.Show("File " + fileNamePromoC + " tidak ada");
                    return;
                }

                if (File.Exists(fileNamePromoD))
                {
                    try
                    {
                        tblDPromo = Foxpro.ReadFile(fileNamePromoD);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        tblDPromo.Columns.Add(newcol);

                        DVDpromo.DataSource = tblDPromo;
                        lblDpromo.Text = "0/" + tblDPromo.Rows.Count.ToString("#,##0");
                        progressBar5.Minimum = 0;
                        progressBar5.Maximum = tblDPromo.Rows.Count;
                        this.DialogResult = DialogResult.OK;
                    }

                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    MessageBox.Show("File " + fileNamePromoD + " tidak ada");
                    return;
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        
        private void commandButton1_Click(object sender, EventArgs e)
        {
          

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Data Promo ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPromoDownload_Load(object sender, EventArgs e)
        {
            this.Title = "Download Master Promo";
            DVPromo.AutoGenerateColumns = true;
            DVdetailPromo.AutoGenerateColumns = true;
            DVBpromo.AutoGenerateColumns = true;
            DVCpromo.AutoGenerateColumns = true;
            DVDpromo.AutoGenerateColumns = true;
            LoadGridFromDBF();
        }

        private void lblDownloadStatus1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
