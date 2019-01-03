using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Trading.Class;
using System.IO;
using ISA.DAL;
using System.Data.OleDb;

namespace ISA.Trading.Communicator
{
    public partial class frmKoreksiPembelianDownload : ISA.Trading.BaseForm
    {
        string fileZipName = GlobalVar.DbfDownload + "\\dbfmatch.zip";
        DataTable tblHeader = new DataTable();
        static string  _fileName = GlobalVar.DbfDownload+"\\KorTmp" + GlobalVar.CabangID + ".DBF";
        int jumlahTable = 1;
        int ctr = 0;
#region "Var n Function"
        private void ExtractFile(string fileName)
        {
            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }
            else
            {
                MessageBox.Show("File dbfmatch.zip tidak ada!");
                return;
            }

            string fileNameH = "Kpj11Tmp.dbf";/// +GlobalVar.CabangID + ".dbf";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;

            if (File.Exists(fileNameH))
            {
                try
                {
                    DataTable dtt = new DataTable();
                   
                    dtt = Foxpro.ReadFile(fileNameH);
                    // dtt.DefaultView.RowFilter = "Sumber='NPB'";
                    //  DataView dv = dtt.DefaultView;
                    tblHeader = dtt;//dv.ToTable();
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHeader;
                    lblDownloadStatus1.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    this.Title = fileNameH;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

           
            else
            {
                MessageBox.Show("File " + fileNameH +  " tidak ada");
            }
        }
#endregion

        
        public frmKoreksiPembelianDownload()
        {
            InitializeComponent();
        }

        private void frmKoreksiPembelianDownload_Load(object sender, EventArgs e)
        {  
            dataGridView1.AutoGenerateColumns = true;
            ExtractData();
            
        }

        private void TableDeleteKor(string fileName, string isaColName, string foxproColName)
        {
            string tableName = "";
            DataTable dt = Foxpro.ReadDeletedFile(_fileName);
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("psp_POS_DELETE_TABLE"));
                foreach (DataRow dr in dt.Rows)
                {
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NPJ")
                        tableName = "KoreksiPenjualan";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NRJ")
                        tableName = "KoreksiReturPenjualan";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NPB")
                        tableName = "KoreksiPembelian";
                    if (Tools.isNull(dr["Sumber"], "").ToString().Trim() == "NRB")
                        tableName = "KoreksiReturPembelian";

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, tableName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyName", SqlDbType.VarChar, isaColName));
                    db.Commands[0].Parameters.Add(new Parameter("@columnKeyValue", SqlDbType.VarChar, Tools.isNull(dr[foxproColName], "").ToString().Trim()));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
        }

        public void DownloadKoreksiPembelian()
        {
            
           
            DataTable result = tblHeader;
            //DataRow[] results = result.Rows;
            //if (result == null)
            //{
            //    MessageBox.Show("No Data");
            //    return;
            //}
               
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_KoreksiPembelian_DOWNLOAD"));
                        foreach (DataRow dr in result.Rows)
                        {

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["id_koreksi"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@NotaBeliDetailRecID", SqlDbType.VarChar, Tools.isNull(dr["id_detail"], "").ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, Tools.isNull(dr["tglkoreksi"], DBNull.Value)));
                            db.Commands[0].Parameters.Add(new Parameter("@NoKoreksi", SqlDbType.VarChar, (Tools.isNull(dr["No_koreksi"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, (Tools.isNull(dr["Kode_brg"], "").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, int.Parse(Tools.isNull(dr["j_nota"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@HrgBeliBaru", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_jual"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, Tools.isNull(dr["catatan"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Pemasok", SqlDbType.VarChar, Tools.isNull(dr["kd_toko"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@Sumber", SqlDbType.VarChar, "NPB" ));//(Tools.isNull(dr["sumber"], "NPB").ToString().Trim())    ));
                            db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, ""));//Tools.isNull(dr["dt_link"], "").ToString().Trim()));
                            db.Commands[0].Parameters.Add(new Parameter("@HrgBeliKoreksi", SqlDbType.Money, double.Parse(Tools.isNull(dr["h_koreksi"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, 0 ));//int.Parse(Tools.isNull(dr["n_koreksi"], "0").ToString().Trim())));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, int.Parse(Tools.isNull(dr["id_match"], "0").ToString())));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            dr["cUploaded"] = true;
                            progressBar1.Increment(1);
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        }

                    }

                   
              
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount==0)
            {
                MessageBox.Show("No Data !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DownloadKoreksiPembelian();
   //             TableDeleteKor("", "RecordID", "id_koreksi");
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                MessageBox.Show("Dwonload Selesai");
            }
            
        }
    }
}
