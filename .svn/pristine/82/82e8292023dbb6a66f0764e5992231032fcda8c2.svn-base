using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ISA.DAL;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDownloadDataISA_Manual : ISA.Trading.BaseForm
    {

        int counter = 0;
        string _Data = string.Empty;

        public frmDownloadDataISA_Manual()
        {
            InitializeComponent();
        }

        private void frmDownloadDataISA_Manual_Load(object sender, EventArgs e)
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
            for(int i = ds.Tables.Count - 1;i >=0;i--)
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
            using (Database db = new Database())
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            if (dr["TableName"].ToString().ToUpper().Equals("ANTARGUDANG") || dr["TableName"].ToString().ToUpper().Equals("AntarGudangDetail"))
                            {
                                continue;
                            }
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_SYNC_DOWNLOAD_DIRECTOR"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.NText, dr["XmlData"].ToString()));

                            lblDownload.Text = dr["TableName"].ToString();
                            db.Commands[0].ExecuteNonQuery();

                        }
                    }
                }
            }
        }

        private string Data()
        {            

            switch (cboxData.Text)
            {
                
                case "Antar Gudang":
                    _Data = "AG-";

                    break;
                case "DO Antar Cabang":
                    _Data = "OPJ-";

                    break;
                case "Nota Antar Cabang":
                    _Data = "NPJ-";

                    break;
                case "POS":
                    _Data = "POS-";

                    break;
                case "Potongan":
                    _Data = "POT-";

                    break;
                case "HPPA":
                    _Data = "HPPA-";

                    break;
                case "Nota Pembelian Antar Cabang":
                    _Data = "NPB-";

                    break;

                case "RSOPAC":
                    _Data = "RSOPAC-";

                    break;
                default:
                    _Data = "";
                    break;
                

            }

            return _Data;

           
        }


        private void cmdDownload_Click(object sender, EventArgs e)
        {

            string _paths = string.Empty;
            string PilData = Data();
            if (PilData=="")
            {
                MessageBox.Show("Pilih Salah Satu Transaksi Download!!!");
                return;
            }

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory =  "C:\\TEMP\\FTP\\DOWNLOAD";   //GlobalVar.DbfDownload;
            if (PilData == "RSOPAC-")
            {

                openFileDialog1.Filter = "xml files (*.xml)|*" + PilData + "*.xml";
            } 
            else
            {
                openFileDialog1.Filter = "xml files (*.xml)|*" + PilData + "*.xml";
            }
           
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
                    if (PilData == "RSOPAC-" )
                    {
                        if (!( _paths.Contains("RSOPAC-") && _paths.Contains(GlobalVar.Gudang)))
                        {
                            MessageBox.Show("Invalid File !!!");
                            return; 
                        } 
                        
                        openFileDialog1.Filter = "xml files (*.xml)|*" + PilData + "*.xml";
                    } 
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {                        
                        //lblStatus.Text = "Download file from FTP ...";                                                
                        DataSet ds = ReadData(_paths);

                        //lblStatus.Text = "Upload data to ISA ....";
                        refreshForm();
                        ProcessTable(ds);
                        if (PilData == "RSOPAC-")
                        {
                            LinkNota(ds);
                        }


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

        

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkNota(DataSet ds)
        {
            
           

            lblProgress.Text = "Link DATA ...";
            foreach (DataTable dt in ds.Tables)
            {
               
                //lblStatus.Text = "Download " + dt.TableName;
                refreshForm();
                Linkss(dt);
            
            }
            pbDownload.Value = pbDownload.Maximum;
        }


        private void Linkss(DataTable dt)
        {
            using (Database db = new Database())
            {
                foreach (DataRowView dr in dt.DefaultView)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            if (dr["TableName"].ToString().ToUpper().Equals("NOTAPENJUALAN-RSOPAC") )
                            {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("[psp_SYNC_DOWNLOAD_NotaPenjualan_RSOPAC_LINK]"));
                            db.Commands[0].Parameters.Add(new Parameter("@Doc", SqlDbType.NText, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
