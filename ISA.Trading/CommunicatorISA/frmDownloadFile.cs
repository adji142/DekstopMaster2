using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using ISA.DAL;

namespace ISA.Trading.CommunicatorISA
{
    public partial class frmDownloadFile : ISA.Trading.BaseForm
    {
        DataTable fileList;
        int counter = 0;
        bool loaded = false;

        public frmDownloadFile()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    bool success = false;
                    string fileName = customGridView1.SelectedCells[0].OwningRow.Cells["FileName"].Value.ToString();
                    DataRow rowItem = fileList.Rows.Find(fileName);
                    if (rowItem != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        lblStatus.Text = "Download file from FTP ...";
                        refreshForm();

                        double downloadSize = FTP.FtpEngine.Download(FTP.FtpEngine.InboxDirectory, fileName);
                        if (downloadSize == (double)rowItem["FileSize"] && downloadSize != 0)
                        {
                            success  = FTP.FtpEngine.Delete(FTP.FtpEngine.InboxDirectory, fileName);
                            if (success)
                            {
                                rowItem.Delete();

                                DataSet ds = ReadData(FTP.FtpEngine.DownloadDirectory + "\\" + fileName);

                                lblUpload.Text = "0/" + ds.Tables.Count.ToString("#,##0");

                                lblStatus.Text = "Upload data to ISA ....";
                                pbSyncUpload.Minimum = 0;
                                pbSyncUpload.Maximum = ds.Tables.Count;
                                refreshForm();
                                counter = 0;

                                ProcessTable(ds, "Expedisi");
                                ProcessTable(ds, "Sales");
                                ProcessTable(ds, "Pemasok");
                                ProcessTable(ds, "Stok");
                                ProcessTable(ds, "Toko");
                                ProcessTable(ds, "Kompensasi");
                                ProcessTable(ds, "AntarGudang");
                                ProcessTable(ds, "AntarGudangDetail");
                                ProcessTable(ds, "Peminjaman");
                                ProcessTable(ds, "PeminjamanDetail");
                                ProcessTable(ds, "Pengembalian");
                                ProcessTable(ds, "PengembalianDetail");
                                ProcessTable(ds, "Mutasi");
                                ProcessTable(ds, "MutasiDetail");
                                ProcessTable(ds, "OpnameHistory");
                                ProcessTable(ds, "OrderPembelian");
                                ProcessTable(ds, "OrderPembelianDetail");
                                ProcessTable(ds, "NotaPembelian");
                                ProcessTable(ds, "NotaPembelianDetail");
                                ProcessTable(ds, "KoreksiPembelian");
                                ProcessTable(ds, "ReturPembelian");
                                ProcessTable(ds, "ReturPembelianDetail");
                                ProcessTable(ds, "ReturPembelianManualDetail");
                                ProcessTable(ds, "KoreksiReturPembelian");
                                ProcessTable(ds, "OrderPenjualan");
                                ProcessTable(ds, "OrderPenjualanDetail");
                                ProcessTable(ds, "NotaPenjualan");
                                ProcessTable(ds, "NotaPenjualanDetail");
                                ProcessTable(ds, "KoreksiPenjualan");
                                ProcessTable(ds, "PenjualanPotongan");
                                ProcessTable(ds, "ReturPenjualan");
                                ProcessTable(ds, "ReturPenjualanDetail");
                                ProcessTable(ds, "ReturPenjualanTarikanDetail");
                                ProcessTable(ds, "KoreksiReturPenjualan");
                                ProcessTable(ds, "Selisih");
                                ProcessTable(ds, "SelisihDetail");
                                ProcessTable(ds, "RekapKoli");
                                ProcessTable(ds, "RekapKoliDetail");
                                ProcessTable(ds, "RekapKoliSubDetail");
                                ProcessTable(ds, "ClosingStokSaldo");
                                ProcessTable(ds, "StandarStok");

                                MessageBox.Show(Messages.Confirm.DownloadSuccess);
                            }
                        }
                        else
                        {
                            MessageBox.Show(Messages.Error.FailDownload);
                        }
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
        }

        private void ReadFileList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                fileList = FTP.FtpEngine.GetFileList(FTP.FtpEngine.InboxDirectory);
                fileList.DefaultView.Sort = "FileName";
                //fileList.DefaultView.RowFilter = "FileName LIKE 'DO%'";
                customGridView1.DataSource = fileList.DefaultView;
            }
            catch (Exception ex)
            {                
                if (ex.Message.Contains ("450"))
                {
                    ex = new Exception ("No File available", ex);
                }
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmDownloadFile_Load(object sender, EventArgs e)
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

        private void ProcessTable (DataSet ds, string tableName)
        {
            if (ds.Tables.Contains(tableName))
            {
                counter++;
                lblStatus.Text = "Download " + tableName;
                ImportData(ds.Tables[tableName]);
                pbSyncUpload.Value = counter;
                lblUpload.Text = counter.ToString("#,##0") + "/" + ds.Tables.Count.ToString("#,##0");
                refreshForm();
            }
        }


        private void ImportData(DataTable dt)
        {
            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_SYNC_DOWNLOAD_DIRECTOR"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        private void frmDownloadFile_Shown(object sender, EventArgs e)
        {
            if (!loaded)
            {
                refreshForm();
                lblStatus.Text = "Get FTP Info ...";
                ReadFileList();
                loaded = true;
            }
        }
    }
}
