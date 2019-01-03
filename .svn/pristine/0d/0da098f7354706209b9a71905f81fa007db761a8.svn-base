using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;

namespace ISA.Finance.Communicator
{
    public partial class FrmSaldoPiutangDownload : ISA.Finance.BaseForm
    {
        DataTable dtSalPiut, dtListSaldoPiut;
        public FrmSaldoPiutangDownload()
        {
            InitializeComponent();
        }

        private void ExtractFile(string fileName)
        {

            Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }


        private void FrmSaldoPiutangDownload_Load(object sender, EventArgs e)
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

            string fileName = "Sotmp.dbf";


            fileName = GlobalVar.DbfDownload + "\\" + fileName;


            if (File.Exists(fileName))
            {
                try
                {
                    dtSalPiut = Foxpro.ReadFile(fileName);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    dtSalPiut.Columns.Add(newcol);

                    dataGridView2.DataSource = dtSalPiut;
                    lblDownloadInfo.Text = "0/" + dtSalPiut.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dtSalPiut.Rows.Count;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                MessageBox.Show("File " + fileName + " tidak ada");
                return;
            } 
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //public void cekData()
        //{
        //    if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
        //    {
        //        ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
        //    }
        //    else
        //    {
        //        MessageBox.Show("File " + GlobalVar.DbfDownload + "\\dbfmatch.zip tidak ada");
        //        return;
        //    }

        //    string fileName = "Sotmp.dbf";


        //    fileName = GlobalVar.DbfDownload + "\\" + fileName;


        //    if (File.Exists(fileName))
        //    {
        //        try
        //        {
        //            dtSalPiut = Foxpro.ReadFile(fileName);
        //            DataColumn newcol = new DataColumn("cUploaded");
        //            newcol.DataType = Type.GetType("System.Boolean");
        //            dtSalPiut.Columns.Add(newcol);

        //            customGridView1.DataSource = dtSalPiut;
        //            lblDownloadInfo.Text = "0/" + dtSalPiut.Rows.Count.ToString("#,##0");
        //            progressBar1.Minimum = 0;
        //            progressBar1.Maximum = dtSalPiut.Rows.Count;
        //            this.DialogResult = DialogResult.OK;
        //        }
        //        catch (Exception ex)
        //        {
        //            Error.LogError(ex);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("File " + fileName + " tidak ada");
        //        return;
        //    }
        //}

        private void commandButton2_Click(object sender, EventArgs e)
        {
           if (dataGridView2.RowCount == 0)
            {
                MessageBox.Show("Tidak ada data yang didownload");
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download Saldo Piutang ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                //this.Enabled = false;

                try
                {
                    SaldoPiut();
                    if (dtListSaldoPiut.Rows.Count > 0)
                    {
                        deleteSaldoPiut();
                    }

                    Download();

                    MessageBox.Show(Messages.Confirm.DownloadSuccess);

                    //this.Close();
                    if (this.Caller is Piutang.FrmSaldoPiutangBrowse)
                    {
                        Piutang.FrmSaldoPiutangBrowse frmCaller = (Piutang.FrmSaldoPiutangBrowse)this.Caller;
                        frmCaller.Refresh();
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


        public void SaldoPiut()
        {
            try
            {
                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SaldoPiutang_List"));
                    dtListSaldoPiut = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtListSaldoPiut;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteSaldoPiut()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SaldoPiutang_Delete"));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Download()
        {
            int counter = 0;
	        DataTable dtResult = new DataTable();

	        int result = 0;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_SaldoPiut_Download"));
                foreach (DataRow dr in dtSalPiut.Rows)
                {
                    //add parameters
                    
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@Kd_toko", SqlDbType.VarChar, Tools.isNull(dr["Kd_toko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Namatoko", SqlDbType.VarChar, Tools.isNull(dr["Namatoko"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Idwil", SqlDbType.VarChar, dr["Idwil"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Kd_gdg", SqlDbType.VarChar, Tools.isNull(dr["Kd_gdg"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Init_prs", SqlDbType.VarChar, Tools.isNull(dr["Init_prs"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Piutang", SqlDbType.NChar, Tools.isNull(dr["Piutang"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Piutang_be", SqlDbType.NChar, Tools.isNull(dr["Piutang_be"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Piutang_nb", SqlDbType.NChar, Tools.isNull(dr["Piutang_nb"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro", SqlDbType.NChar, Tools.isNull(dr["Giro"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro_be", SqlDbType.NChar, dr["Giro_be"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro_nb", SqlDbType.NChar, Tools.isNull(dr["Giro_nb"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Giro_tolak", SqlDbType.NChar, Tools.isNull(dr["Giro_tolak"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, Tools.isNull(dr["Tanggal"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Overdue", SqlDbType.NChar, Tools.isNull(dr["Overdue"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@Upl", SqlDbType.VarChar, Tools.isNull(dr["Upl"], "").ToString().Trim()));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();


                    if (result == 1 || result == 0)
                    {

                        //grid and form status
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadInfo.Text = counter.ToString("#,##0") + "/" + dtSalPiut.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                    db.CommitTransaction();
                }
            }
        }

    }
}
