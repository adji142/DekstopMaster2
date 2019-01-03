using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;

namespace ISA.Trading.Master
{
    public partial class frmHargaPromoDownload : ISA.Trading.BaseForm
    {

        DataTable dtHPromo = new DataTable() ;

        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }


        private void loadDataGridfromDBF()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\Download\\DBFMATCH.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\Download\\DBFMATCH.zip");
            }
            else
            {
                MessageBox.Show("File " + GlobalVar.DbfDownload + "\\Download\\DBFMATCH.zip tidak ada");
                return;
            }

            string fileNameS = "hjual.dbf";
  

            fileNameS = GlobalVar.DbfDownload + "\\" + fileNameS;
 

            if (File.Exists(fileNameS))
            {
                try
                {
                    dtHPromo = Foxpro.ReadFile(fileNameS);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dtHPromo.Columns.Add(newcol);

                    dataGridView1.DataSource = dtHPromo;
                    lblDownloadStatus1.Text = "0/" + dtHPromo.Rows.Count.ToString("#,##0");
                    progressBar2.Minimum = 0;
                    progressBar2.Maximum = dtHPromo.Rows.Count;
       
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

        }


        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            int result = 0;
            int result2 = 0;
            using (Database db = new Database())
            {
                Guid _RowID; 

                db.Commands.Add(db.CreateCommand("usp_Harga_Promo_Download"));
                foreach (DataRow dr in dtHPromo.Rows)
                {
                    //add parameters
                    _RowID = Guid.NewGuid();
                    

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt1", SqlDbType.DateTime,  dr["tmt1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tmt2", SqlDbType.DateTime, dr["tmt2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@h_cash", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["h_cash"], "").ToString().Trim())));

                    db.Commands[0].Parameters.Add(new Parameter("@h_top10", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["h_top10"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@h_user", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["h_user"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@het", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["het"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Money,  Tools.getBit(dr["id_match"] ) ));
                    db.Commands[0].Parameters.Add(new Parameter("@dcash", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["dcash"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@dtop10", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["dtop10"], "").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@duser", SqlDbType.Money, Convert.ToDecimal(Tools.isNull(dr["duser"], "").ToString().Trim())));
                     db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                     
                    result = db.Commands[0].ExecuteNonQuery();

                     
                    if (result > 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar2.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + dtHPromo.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                    

                     
                    
                }

            }
        }

        public frmHargaPromoDownload()
        {
            InitializeComponent();
        }

        private void frmHargaPromoDownload_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            loadDataGridfromDBF();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
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
        }
    }
}
