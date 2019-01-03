using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.DataTemplates;
using System.IO;
using ISA.Finance.Class;


namespace ISA.Finance.VWil
{
    public partial class frmRiwayatIDWilDownload : ISA.Finance.BaseForm
    {
        DataTable dt1 = new DataTable();

        DataTable dtSudahDownload = new DataTable();
        DataTable dtProses = new DataTable();



        public frmRiwayatIDWilDownload()
        {
            InitializeComponent();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDownload, "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    DownloadData();
                    
                    if (dtProses.Rows.Count == 0 && dtSudahDownload.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada data yang didownload.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                        cmdDownload.Enabled = false;
                        //DisplayReport();
                    }
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

        private bool UnzipFile(string sourceZIPFileName, string FileName)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\hppatmp";

            if (File.Exists(sourceZIPFileName))
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }

                Zip.UnZipFiles(sourceZIPFileName, extractFileLocation, false);
                retVal = true;
            }
            else
            {
                //lblFileNameLocation.Text = "File " + sourceZIPFileName + " tidak ada.";
                cmdDownload.Enabled = false;
                MessageBox.Show("File: " + sourceZIPFileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void LoadFile()
        {
            
            string fileName1 = GlobalVar.DbfDownload + "\\wiltmp.dbf";
            
            string fileZIPName = GlobalVar.DbfDownload + "\\" + "WIL" + GlobalVar.CabangID + ".zip";


            if (UnzipFile(fileZIPName, fileName1))
            {
                if (File.Exists(fileName1))
                {
                    try
                    {
                        dt1 = Foxpro.ReadFile(fileName1);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        dt1.Columns.Add(newcol);

                        gvDownload1.DataSource = dt1;
                        lblDownloadCount1.Text = "0/" + dt1.Rows.Count.ToString("#,##0");
                        pbDownload1.Minimum = 0;
                        pbDownload1.Maximum = dt1.Rows.Count;
                        lblInfo1.Text = fileName1;

                      

                        pbDownload1.Value = 0;
                        this.DialogResult = DialogResult.OK;

                        cmdDownload.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    lblInfo1.Text = "File " + fileName1 + " tidak ada.";                    
                    cmdDownload.Enabled = false;
                    MessageBox.Show("File: " + fileName1 + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void DownloadData()
        {
            int counter1 = 0;

            string id_rec = string.Empty;
            string kd_toko = string.Empty;
            DateTime tanggal = new DateTime(); ;
            string idwil = string.Empty;
            string oldwil = string.Empty;
            string keterangan = string.Empty;
            string lrefresh = string.Empty;
            

            dtSudahDownload = dt1.Clone();
            dtProses = dt1.Clone();

            int stat = 0;
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_psp_VWIL_Download"));

                    foreach (DataRow dr in dt1.Rows)
                    {
                        id_rec = Tools.isNull(dr["id_rec"], "").ToString().Trim();
                        kd_toko = Tools.isNull(dr["kd_toko"], "").ToString().Trim();
                        tanggal = Convert.ToDateTime( dr["tanggal"].ToString());                        
                        idwil = Tools.isNull(dr["idwil"], "").ToString().Trim();
                        oldwil = Tools.isNull(dr["oldwil"], "").ToString().Trim();
                        keterangan = Tools.isNull(dr["keterangan"], "").ToString().Trim();
                        lrefresh = Tools.isNull(dr["lrefresh"], "").ToString().Trim();

                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, id_rec));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, kd_toko));
                        db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, tanggal));
                        db.Commands[0].Parameters.Add(new Parameter("@WilID", SqlDbType.VarChar, Tools.isNull(dr["idwil"], "").ToString().Trim()));                        
                        db.Commands[0].Parameters.Add(new Parameter("@WilIDOld", SqlDbType.VarChar, Tools.isNull(dr["oldwil"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, Tools.isNull(dr["Keterangan"], "").ToString().Trim()));                        
                        db.Commands[0].Parameters.Add(new Parameter("@LRefresh", SqlDbType.VarChar, Tools.isNull(dr["lrefresh"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        stat = Convert.ToInt32(db.Commands[0].ExecuteScalar());

                        dr["cUploaded"] = true;
                        dtProses.ImportRow(dr);
                                                       
                        counter1++;
                        pbDownload1.Increment(1);
                        lblDownloadCount1.Text = counter1.ToString("#,##0") + "/" + dt1.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
