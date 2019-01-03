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
    public partial class frmPotonganDownload : ISA.Toko.BaseForm
    {

#region "Function & Variable"
        DataTable tblHeader;
        DataTable dtSdhDownload;
        private void ExtractFile(string fileName)
        {

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }

            string fileNameH = "POT"+GlobalVar.Gudang+".dbf";

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

        }

        public void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();


            dtSdhDownload = tblHeader.Clone();

            DataTable dt = new DataTable();
            int result = 0;
            using (Database db = new Database())
            {
                // HEADERS
                db.Commands.Add(db.CreateCommand("[usp_PenjualanPotongan_Download]"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    //add parameters
                  
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, Tools.isNull(dr["Idtr"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@catACC", SqlDbType.VarChar, Tools.isNull(dr["Cat_acc"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@discACC", SqlDbType.Decimal, Convert.ToDecimal(Tools.isNull(dr["Disc_acc"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@tglACC", SqlDbType.DateTime, dr["Tgl_acc"]));
                    db.Commands[0].Parameters.Add(new Parameter("@dilACC", SqlDbType.Money, Convert.ToInt32(Tools.isNull(dr["Dil_acc"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@Dibacc", SqlDbType.VarChar,Convert.ToInt32(Tools.isNull(dr["Dib_acc"], "0").ToString().Trim())));
                    db.Commands[0].Parameters.Add(new Parameter("@statusACC", SqlDbType.Bit, Convert.ToInt32(dr["Acc"])));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();
                    //grid and form status
                    if (result!=0)
                    {
                        dr["cUploaded"] = true;
                        counter++;
                        progressBar1.Increment(1);
                        lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                        this.Refresh();
                        this.Invalidate();
                        Application.DoEvents();
                    }
                   
                    db.CommitTransaction();
                    // 
                }
            }
        }
#endregion


        public frmPotonganDownload()
        {
            InitializeComponent();
        }

        private void cmdCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
           if (dataGridView1.Rows.Count==0)
           {
               return;
           }

           if (MessageBox.Show(Messages.Question.AskDownload, "Download Potongan Penjualan ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void frmPotonganDownload_Load(object sender, EventArgs e)
        {
            ExtractData();
        }


    }
}
