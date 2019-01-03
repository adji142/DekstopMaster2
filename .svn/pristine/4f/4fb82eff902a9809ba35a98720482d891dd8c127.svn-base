using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Data.SqlTypes;

using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Trading.Communicator
{
    public partial class frmNotaPembelianDownloadAntarCabang : ISA.Trading.BaseForm
    {

    #region "Function & Variable"
        #region "Variable"
        DataTable tblHeader;
        DataTable tblDetail;
        DataTable dtProcess;
        DataTable dtNothing;


        Guid _RowIDHeader;
        String _RecordIDHeader;

     #endregion

        private void LoadPemasok()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();

                    cboPemasok.ValueMember = "PemasokID";
                    cboPemasok.DisplayMember = "Nama";
                    cboPemasok.DataSource = dt;
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
        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            dtProcess = tblHeader.Clone();
            dtNothing = tblHeader.Clone();
          

            int result = 0;
            using (Database db = new Database())
            {

                // Headernya
                db.Commands.Add(new Command("[usp_NotaPembelian_AntarCabang_Download]"));
                foreach (DataRow dr in tblHeader.Rows)
                {
#region " Header Parameter"

                    _RowIDHeader = Guid.NewGuid();
                    _RecordIDHeader = Tools.isNull(dr["idtr"], "").ToString().Trim();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, dr["tgl_rq"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noDO", SqlDbType.VarChar, Tools.isNull(dr["No_do"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTransaksi", SqlDbType.DateTime, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dr["Tgl_sj"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, Tools.isNull(dr["no_sj"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dr["tgl_sj"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));// dr["tgl_trm"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, 0));// dr["disc_1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, 0));//dr["disc_2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, 0));// dr["disc_3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));//Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();
#endregion
                    result = db.Commands[0].ExecuteNonQuery();

                    if (result==1)
                    {
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }

#region "Detail"
                    dtProcess.ImportRow(dr);


                    //DO DETAILS

                    DataRow[] orderDetails = tblDetail.Select("Idtr='" + _RecordIDHeader + "'");

                    if (orderDetails.Length == 0)
                    {
                        MessageBox.Show(String.Format(Messages.Confirm.NoDetailData));
                    }

                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_Download"));
                    foreach (DataRow drd in orderDetails)
                    {
                        //dtReport1.ImportRow(drd);
                        //add parameters
                        db.Commands[1].Parameters.Clear();
                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                        db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                        db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Idrec"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, _RecordIDHeader));
                        db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_rq"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_do"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_sj"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_nota"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                        db.Commands[1].Parameters.Add(new Parameter("@KoreksiID", SqlDbType.VarChar, ""));
                        db.Commands[1].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[1].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, Convert.ToInt32(Tools.isNull(drd["Hpp_solo"], "0").ToString().Trim())));
                        db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                        db.Commands[1].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(drd["Kd_gdg"], "").ToString().Trim()));
                        db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0)); ;
                        db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                        db.Commands[1].ExecuteNonQuery();
                        //grid and form status
                        drd["cUploaded"] = true;
                        counter++;
                        progressBar2.Increment(1);
                        lblDownloadStatus2.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
#endregion
                  
                    db.CommitTransaction(); 


                }

            }

           
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }

            string fileNameH = "Htjactmp.dbf";
            string fileNameD = "Dtjactmp.dbf";


            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            fileNameD = GlobalVar.DbfDownload + "\\" + fileNameD;
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
                    this.Title = this.Title + " " + fileNameD;
                    this.DialogResult = DialogResult.OK;
                }

                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }

#endregion
        public frmNotaPembelianDownloadAntarCabang()
        {
            InitializeComponent();
        }

        private void frmNotaPembelianDownloadAntarCabang_Load(object sender, EventArgs e)
        {
           LoadPemasok();
           cboPemasok.Focus();
           ExtractData();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount==0)
            {
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download Pemebelian Antar Cabang ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

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
