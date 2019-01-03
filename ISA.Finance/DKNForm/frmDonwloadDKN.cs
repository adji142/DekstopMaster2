using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.IO;

namespace ISA.Finance.DKNForm
{
    public partial class frmDonwloadDKN : ISA.Finance.BaseForm
    {
        DataTable tblHeader;
        DataTable dtSdhDownload;

        public frmDonwloadDKN()
        {
            InitializeComponent();
        }

        private void ExtractData()
        {
            string fileNameH = "datahi.dbf";

            fileNameH = GlobalVar.DbfDownload + "\\" + fileNameH;
            if (File.Exists(fileNameH))
            {
                try
                {
                    tblHeader = Foxpro.ReadFile(fileNameH);
                    DataColumn newcol = new DataColumn("cUploaded");
                    newcol.DataType = Type.GetType("System.Boolean");
                    tblHeader.Columns.Add(newcol);

                    dataGridView1.DataSource = tblHeader;
                    label3.Text = "0/" + tblHeader.Rows.Count.ToString("#,##0");
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = tblHeader.Rows.Count;
                    //this.Title = fileNameH;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
        }


        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();


            dtSdhDownload = tblHeader.Clone();

            DataTable dt = new DataTable();
            int result = 0;
            using (Database db = new Database(GlobalVar.DBName))
            {
                // HEADERS
                db.Commands.Add(db.CreateCommand("usp_DKN_Download"));
                db.BeginTransaction();
                foreach (DataRow dr in tblHeader.Rows)
                {
                    //add parameters

                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, Tools.isNull(dr["idhead"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(dr["iddetail"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.DateTime, dr["tanggal"]));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDKN", SqlDbType.VarChar, Tools.isNull(dr["no_dkn"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@DK", SqlDbType.VarChar, Tools.isNull(dr["dk"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, Tools.isNull(dr["cabang"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@CD", SqlDbType.VarChar, Tools.isNull(dr["cd"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Src", SqlDbType.VarChar, Tools.isNull(dr["src"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, Tools.isNull(dr["no_perk"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, Tools.isNull(dr["uraian"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Jumlah", SqlDbType.Money, (dr["jumlah"])));
                    db.Commands[0].Parameters.Add(new Parameter("@Dari", SqlDbType.VarChar, Tools.isNull(dr["dari"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Tolak", SqlDbType.Bit, (dr["ltolak"])));
                    db.Commands[0].Parameters.Add(new Parameter("@Alasan", SqlDbType.VarChar, Tools.isNull(dr["alasan"], "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                   

                    result = db.Commands[0].ExecuteNonQuery();
                    //grid and form status
                    if (result != 0)
                    {
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        label3.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }                   
                    // 
                }
                db.CommitTransaction();
            }
        }        

        private void frmDonwloadDKN_Load(object sender, EventArgs e)
        {
            ExtractData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDwnld_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download DKN ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
    }
}
