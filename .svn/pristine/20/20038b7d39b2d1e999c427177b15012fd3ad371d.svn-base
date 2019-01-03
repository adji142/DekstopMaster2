using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using ISA.Controls;

namespace ISA.Finance.Kasir
{
    public partial class frmBudgetDownload : ISA.Finance.BaseForm
    {
        int counter = 0;
        string _Data = "BudgetRencana";

        public frmBudgetDownload()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBudgetDownload_Load(object sender, EventArgs e)
        {

        }

        private DataSet ReadData(string fullFilePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(fullFilePath);
            return ds;
        }


        private void refreshForm()
        {
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }



        private void ProcessTable(DataSet ds)
        {
            pbDownload.Maximum = ds.Tables.Count * 2;
            counter = 0;
            pbDownload.Value = 0;
            lblProgress.Text = "DELETING DATA ...";
            for (int i = ds.Tables.Count - 1; i >= 0; i--)
            {
                counter++;
                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                ds.Tables[i].DefaultView.RowFilter = "METHOD='DELETE'";
                ImportData(ds.Tables[i]);
                pbDownload.Value = counter;
                //lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }

            lblProgress.Text = "UPDATING DATA ...";
            foreach (DataTable dt in ds.Tables)
            {
                counter++;
                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                dt.DefaultView.RowFilter = "METHOD='UPDATE'";
                ImportData(dt);
                pbDownload.Value = counter;
                //lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
            pbDownload.Value = pbDownload.Maximum;
        }


        private void ImportData(DataTable dt)
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_DOWNLOAD_DIRECTOR_KASIR_ISA"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));

                            lblDownload.Text = dr["TableName"].ToString();
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }

            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            string _paths = string.Empty;
            string PilData = _Data;

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\TEMP\\FTP\\DOWNLOAD";   //GlobalVar.DbfDownload;
            openFileDialog1.Filter = "xml files (*.xml)|*" + PilData + "*.xml";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _paths = openFileDialog1.FileName;

                    if (MessageBox.Show("Download Data ini " + openFileDialog1.FileNames[0].ToString() + " ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        //lblStatus.Text = "Download file from FTP ...";                                                
                        DataSet ds = ReadData(_paths);

                        //lblStatus.Text = "Upload data to ISA ....";
                        refreshForm();
                        ProcessTable(ds);

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
}
