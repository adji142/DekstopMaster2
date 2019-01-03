using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;

namespace ISA.Toko.Rekon
{
    public partial class frmDownloadOverdueFU : ISA.Toko.BaseForm
    {
        DataTable tblHeader;

        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void LoadGridFromDBF()
        {

            try
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

                string fileNameH = "overduefu.dbf";



                fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;


                if (File.Exists(fileNameH))
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    GVDownOVF.DataSource = tblHeader;
                    lblStst.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("File " + fileNameH + " tidak ada");
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        public frmDownloadOverdueFU()
        {
            InitializeComponent();
        }


        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();
            int result = 0;

            using (Database db = new Database())
            {
                // HEADERS

                foreach (DataRow dr in tblHeader.Rows)
                {
                    db.Commands.Clear();
                    db.Commands.Add(db.CreateCommand("usp_OverdueFU_Download_Data"));
                    //add parameters
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid()));
                    db.Commands[0].Parameters.Add(new Parameter("@idrec", SqlDbType.VarChar,  Tools.isNull(dr["idrec"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, Tools.isNull(dr["KodeGudang"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@IDKP", SqlDbType.VarChar, Tools.isNull(dr["IDKP"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, Tools.isNull(dr["KodeToko"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, dr["TglTrans"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, Tools.isNull(dr["NoTrans"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, Tools.isNull(dr["KodeSales"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglJatuhTempo", SqlDbType.DateTime, dr["TglJT"]));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["RpBayar"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@RpSisa", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr["RpSisa"], "0").ToString().Trim())));

                    db.Commands[0].Parameters.Add(new Parameter("@TglReg", SqlDbType.DateTime, dr["tglreg"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, Tools.isNull(dr["noreg"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglUser", SqlDbType.DateTime,  dr["tgluser"] ));
                    db.Commands[0].Parameters.Add(new Parameter("@KetUser", SqlDbType.VarChar,  Tools.isNull(dr["ketuser"], "0").ToString().Trim()));


                    db.Commands[0].Parameters.Add(new Parameter("@KetAdmin", SqlDbType.VarChar, Tools.isNull(dr["ketadmin"], "0").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglUpload ", SqlDbType.DateTime, dr["tglupload"]));
                    db.Commands[0].Parameters.Add(new Parameter("@TglDownld", SqlDbType.DateTime, dr["tgldownld"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Toleransi1", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr["toleransi1"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@TglFU", SqlDbType.DateTime, dr["tglfu"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Toleransi2", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr["toleransi2"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@TglClose", SqlDbType.DateTime, dr["TglClose"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Toleransi3", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr["toleransi3"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Lclose", SqlDbType.Bit, Tools.getBit(dr["Lclose"])));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, Tools.getBit(dr["SyncFlag"])));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();
                    if (result >= 0)
                    {
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblStst.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                    db.CommitTransaction();
                }

            }
        }


        private void btnDownld_Click(object sender, EventArgs e)
        {
            if (GVDownOVF.RowCount == 0)
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDownloadOverdueFU_Load(object sender, EventArgs e)
        {
            GVDownOVF.AutoGenerateColumns = true;
            LoadGridFromDBF();
        }
    }
}
