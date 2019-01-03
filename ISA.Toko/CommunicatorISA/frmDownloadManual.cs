using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.FTP;
using System.Linq;
using System.Xml;
using System.IO;
using ISA.DAL;

namespace ISA.Toko.CommunicatorISA
{
    public partial class frmDownloadManual : ISA.Toko.BaseForm
    {
        int counter = 0;
        public frmDownloadManual()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {

            string _paths = string.Empty;

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = GlobalVar.DbfDownload;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _paths = openFileDialog1.FileName;
                    label1.Text = _paths;
                    if (MessageBox.Show("Download Data ini "+ openFileDialog1.FileNames[0].ToString()  +" ?", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DataSet ds = ReadData(_paths);                        

                        lblUpload.Text = "0/" + ds.Tables.Count.ToString("#,##0");

                        lblStatus.Text = "Upload data to ISA ....";
                        pbSyncUpload.Minimum = 0;
                        pbSyncUpload.Maximum = ds.Tables.Count;
                        refreshForm();
                        counter = 0;
                        if (ds.Tables.Count>0)
                        {
                            ProcessTable(ds, "HistoryHPPA");
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
                            ProcessTable(ds, "StandarStok");
                        }
                        
                        
                        

                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                }
            }
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

        private void ProcessTable(DataSet ds, string tableName)
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
    }
}
