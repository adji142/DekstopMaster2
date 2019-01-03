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
    public partial class frmTokoDownloadData : ISA.Toko.BaseForm
    {
        DataTable tblHeader;
        DataTable tblDetail;
        Guid _RowIDHeader;
        String _RecordIDHeader;

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

                string fileNameH = "tokotmp.DBF";
                string fileNameD = "ststmp.DBF";


                fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
                fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;

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


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void Download()
        {
            int counter = 0;
            int counter2 = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            int result2 = 0;
            using (Database db = new Database())
            {
                // HEADERS
               
                foreach (DataRow dr in tblHeader.Rows)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_Data_Toko_HO_Download"));
                    //add parameters
                    _RowIDHeader = Guid.NewGuid();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@TokoID", SqlDbType.VarChar, Tools.isNull(dr["idtoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, Tools.isNull(dr["namatoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, Tools.isNull(dr["alamat"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, Tools.isNull(dr["kota"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, Tools.isNull(dr["notelp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr["idwil"] , "").ToString().Trim())); 
                    db.Commands[0].Parameters.Add(new Parameter("@PenanggungJawab", SqlDbType.VarChar, Tools.isNull(dr["pngjwb"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PiutangB", SqlDbType.Money , Convert.ToDouble(Tools.isNull(dr["piutang_b"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@PiutangJ", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["piutang_j"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Plafon", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["plafon"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@ToJual", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["to_jual"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@ToRetPot", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["to_retpot"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@JangkaWaktuKredit", SqlDbType.Int, Convert.ToInt16(Tools.isNull(dr["jkw_kredit"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, Tools.isNull(dr["cab2"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Tgl1st", SqlDbType.DateTime, dr["tgl1st"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Exist", SqlDbType.Bit, Convert.ToBoolean(Tools.isNull(dr["exist"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@ClassID", SqlDbType.VarChar, Tools.isNull(dr["idclass"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Tools.getBit(dr["id_match"]))); 
                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int , Convert.ToInt16(Tools.isNull(dr["hari_krm"], "0").ToString().Trim()  )));
                    db.Commands[0].Parameters.Add(new Parameter("@KodePos", SqlDbType.VarChar, ""));// Tools.isNull(dr["kd_pos"], "").ToString().Trim())); 
                    db.Commands[0].Parameters.Add(new Parameter("@Grade", SqlDbType.VarChar, Tools.isNull(dr["grade"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Plafon1st", SqlDbType.Money,  Convert.ToDouble(Tools.isNull(dr["plafon_1st"], "0").ToString().Trim() ) ));
                    db.Commands[0].Parameters.Add(new Parameter("@Flag", SqlDbType.VarChar, Tools.isNull(dr["flag"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Bentrok", SqlDbType.VarChar, "" )) ;// Tools.isNull(dr["bentrok"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, Tools.getBit(dr["lpasif"]) ));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, Convert.ToInt16(Tools.isNull( dr["hari_sls"], "0").ToString().Trim()  )));
                    db.Commands[0].Parameters.Add(new Parameter("@Daerah", SqlDbType.VarChar, Tools.isNull(dr["daerah"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, Tools.isNull(dr["propinsi"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@AlamatRumah", SqlDbType.VarChar, Tools.isNull(dr["alm_rumah"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Pengelola", SqlDbType.VarChar, Tools.isNull(dr["pengelola"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglLahir", SqlDbType.DateTime, dr["tgl_lahir"]));
                    db.Commands[0].Parameters.Add(new Parameter("@HP", SqlDbType.VarChar, Tools.isNull(dr["hp"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(dr["status"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@ThnBerdiri", SqlDbType.VarChar, Tools.isNull(dr["th_berdiri"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusRuko", SqlDbType.Bit, Tools.getBit(dr["lruko"])));
                    db.Commands[0].Parameters.Add(new Parameter("@JmlCabang", SqlDbType.Int,  Convert.ToInt16(Tools.isNull( dr["jml_cabang"], "0").ToString().Trim() ) ));
                    db.Commands[0].Parameters.Add(new Parameter("@JmlSales", SqlDbType.VarChar, Tools.isNull(dr["jml_sales"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kinerja", SqlDbType.VarChar, Tools.isNull(dr["kinerja"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@BidangUsaha", SqlDbType.VarChar, Tools.isNull(dr["bdg_usaha"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@RefSales", SqlDbType.VarChar, Tools.isNull(dr["reff_sls"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@RefCollector", SqlDbType.VarChar, Tools.isNull(dr["reff_col"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@RefSupervisor", SqlDbType.VarChar, Tools.isNull(dr["reff_spv"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@PlafonSurvey", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["plf_survey"], "0").ToString().Trim() )  ));
                    db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, "" ));
                    db.Commands[0].Parameters.Add(new Parameter("@bangunan", SqlDbType.VarChar, "" ));
                    db.Commands[0].Parameters.Add(new Parameter("@habis_kontrak", SqlDbType.DateTime , SqlDateTime.Null ));
                    db.Commands[0].Parameters.Add(new Parameter("@jenis_produk", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_pemilik", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@tempat_lhr", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@no_rekening", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@nama_bank", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hobi", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@no_npwp", SqlDbType.VarChar, "")); 
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();


                    if (result >= 0)
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
                    db.CommitTransaction();
                }
                    //Status toko

                   // DataRow[] orderDetails = tblDetail.Select("Kd_toko ='" + dr["kd_toko"].ToString() + "'");

                if (dataGridView3.RowCount > 0)
                {

                    foreach (DataRow drd in tblDetail.Rows)
                    {

                        db.Commands.Add(db.CreateCommand("usp_Data_StatusToko_HO_Download"));
                        //add parameters
                        db.Commands[1].Parameters.Clear();
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[1].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, Tools.isNull(drd["C1"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(drd["Kd_toko"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, drd["tmt"]));
                        db.Commands[1].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Tools.isNull(drd["sts"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["idrec"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(drd["ket"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Tools.getBit(drd["id_match"])));
                        db.Commands[1].Parameters.Add(new Parameter("@KStatus", SqlDbType.VarChar, Tools.isNull(drd["ksts"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@Roda", SqlDbType.VarChar, Tools.isNull(drd["rd"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(drd["idwil"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@TglPasif", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();
                        result2 = db.Commands[1].ExecuteNonQuery();

                        //grid and form status
                        if (result2 >= 0)
                        {
                            drd["cUploaded"] = true;
                            counter2++;
                            progressBar2.Increment(1);
                            lblDownloadStatus2.Text = counter2.ToString("#,##0") + "/" + tblDetail.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }
                        db.CommitTransaction();
                    }

                }

                
                        
            }
        }

        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        public frmTokoDownloadData()
        {
            InitializeComponent();
        }

        private void frmTokoDownloadData_Load(object sender, EventArgs e)
        {
            this.Title = "Download Master Toko";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView3.AutoGenerateColumns = true;
            LoadGridFromDBF();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
           
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
    }
}
