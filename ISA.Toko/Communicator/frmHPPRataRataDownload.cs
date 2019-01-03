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
using ISA.Toko.Class;

namespace ISA.Toko.Communicator
{
    public partial class frmHPPRataRataDownload : ISA.Toko.BaseForm
    {
        DataTable dtHPPHistory = new DataTable();
        DataTable dtBarangID = new DataTable();
        
        public frmHPPRataRataDownload()
        {
            InitializeComponent();
        }

        private bool UnzipFile(string sourceZIPFileName, string FileName)
        {
            bool retVal = false;
            string extractFileLocation = GlobalVar.DbfDownload + "\\hppatmp";

            if(File.Exists(sourceZIPFileName))
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
                lblFileNameLocation.Text = "File " + sourceZIPFileName + " tidak ada.";
                cmdDownload.Enabled = false;
                MessageBox.Show("File: " + sourceZIPFileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retVal;
        }

        private void frmHPPRataRataDownload_Load(object sender, EventArgs e)
        {
            string fileName = "hppatmp\\hppatmp.DBF";
            string fileZIPName = "hppatmp.zip";

            fileName = GlobalVar.DbfDownload + "\\" + fileName;
            fileZIPName = GlobalVar.DbfDownload + "\\" + fileZIPName;

            if (UnzipFile(fileZIPName, fileName))
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        dtHPPHistory = Foxpro.ReadFile(fileName);
                        DataColumn newcol = new DataColumn("cUploaded");
                        newcol.DataType = Type.GetType("System.Boolean");
                        dtHPPHistory.Columns.Add(newcol);

                        gvHPP.DataSource = dtHPPHistory;
                        lblInfoRecordCount.Text = "0/" + dtHPPHistory.Rows.Count.ToString("#,##0");
                        pbHPPDownload.Minimum = 0;
                        pbHPPDownload.Maximum = dtHPPHistory.Rows.Count;
                        lblFileNameLocation.Text = fileName;
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    lblFileNameLocation.Text = "File " + fileName + " tidak ada.";
                    cmdDownload.Enabled = false;
                    MessageBox.Show("File: " + fileName + " tidak ada. Mohon cek kembali file tersebut apakah sudah ada dilokasi file yang sudah ditentukan.", "Download HPP rata-rata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ValidateBarangID(string barangID)
        {
            int retVal = 0;
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HPPRataRataCekBarangID_DOWNLOAD"));
                db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, barangID));
                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 1)
            {
                retVal = int.Parse(dt.Rows[0]["Result"].ToString());
            }

            return retVal;
        }

        public void DownloadData()
        {
            int counter = 0;

            dtBarangID = dtHPPHistory.Clone();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_HPPRataRata_DOWNLOAD"));
                foreach (DataRow dr in dtHPPHistory.Rows)
                {
                    //grid and form status
                    counter++;
                    pbHPPDownload.Increment(1);
                    lblInfoRecordCount.Text = counter.ToString("#,##0") + "/" + dtHPPHistory.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();

                    if (ValidateBarangID(Tools.isNull(dr["id_brg"], "").ToString().Trim()) == 0)
                    {
                        dtBarangID.ImportRow(dr);
                    }
                    else
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@historyID", SqlDbType.VarChar, Tools.isNull(dr["id_hist"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, Tools.isNull(dr["id_brg"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglAktif", SqlDbType.VarChar, DateTime.Parse(Tools.isNull(dr["tmt"], "").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@hpp", SqlDbType.Money, double.Parse(Tools.isNull(dr["hpp"], "").ToString().Trim())));
                        db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, Tools.isNull(dr["keterangan"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@updateBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.BeginTransaction();
                        db.Commands[0].ExecuteNonQuery();
                        db.CommitTransaction();

                        dr["cUploaded"] = true;
                    }
                }
            }
        }

        private void DisplayReport(DataTable dt)
        {
            dt.Columns["satuan"].ColumnName = "Satuan";
            dt.Columns["hpp"].ColumnName = "HPP";
            
            //construct parameter
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptHPPRataRataDownload.rdlc", rptParams, dt, "AntarGudang_Data");
            ifrmReport.Show();
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
                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    cmdDownload.Enabled = false;
                    if (dtBarangID.Rows.Count > 0)
                    {
                        DisplayReport(dtBarangID);
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
    }
}
