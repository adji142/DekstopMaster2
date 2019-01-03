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
    public partial class frmPosDownload : ISA.Trading.BaseForm
    {
        //DataSet dsXML = new DataSet();
        string _FileName;
        string _pathFTP = LookupInfo.GetValue("FTP", "FTP_COCKPIT");
        int _Count = 0;
        

        public frmPosDownload()
        {
            InitializeComponent();
        }


        private void frmPosDownload_Load(object sender, EventArgs e)
        {
            
                        
        }

        

        private DataSet ReadData(string file)
        {
            DataSet ds = new DataSet();

            ds.ReadXml(file);
            return ds;
        }

        public void RefreshStatus(string status)
        {
            LabelStatus.Text = status;
            progressBar1.Value = 0;
            this.Refresh();
            this.Invalidate();
            Application.DoEvents();
        }

        private void cdmDownload_Click(object sender, EventArgs e)
        {
            string _paths = string.Empty;

            Stream myStream = null;



            openFileDialog1.InitialDirectory = "C:\\TEMP\\FTP\\UPLOAD\\";               //_pathFTP;
            openFileDialog1.Filter = "xml files (*.xml)|*POS*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    _paths = openFileDialog1.FileName;

                    DataSet dsXML = ReadData(_paths);

                    try
                    {
                        DownloadSales(dsXML.Tables["Sales"]);

                        DownloadToko(dsXML.Tables["Toko"]);

                        DownloadStok(dsXML.Tables["Stok"]);

                        DownloadPemasok(dsXML.Tables["Pemasok"]);

                        DownloadExpedisi(dsXML.Tables["Expedisi"]);

                        DownloadKompensasi(dsXML.Tables["Kompensasi"]);

                        DownloadOpnameHistory(dsXML.Tables["OpnameHistory"]);

                        DownloadOrderPenjualan(dsXML.Tables["OrderPenjualan"]);

                        DownloadOrderPenjualanDetail(dsXML.Tables["OrderPenjualanDetail"]);

                        DownloadNotaPenjualan(dsXML.Tables["NotaPenjualan"]);

                        DownloadNotaPenjualanDetail(dsXML.Tables["NotaPenjualanDetail"]);

                        DownloadReturPenjualan(dsXML.Tables["ReturPenjualan"]);

                        DownloadReturPenjualanDetail(dsXML.Tables["ReturPenjualanDetail"]);

                        DownloadKoreksiPenjualan(dsXML.Tables["KoreksiPenjualan"]);

                        DownloadKoreksiReturPenjualan(dsXML.Tables["KoreksiReturPenjualan"]);

                        DownloadPenjualanPotongan(dsXML.Tables["PenjualanPotongan"]);

                        DownloadRekapKoli(dsXML.Tables["RekapKoli"]);

                        DownloadRekapKoliDetail(dsXML.Tables["RekapKoliDetail"]);

                        DownloadRekapKoliSubDetail(dsXML.Tables["RekapKoliSubDetail"]);

                        DownloadOrderPembelian(dsXML.Tables["OrderPembelian"]);

                        DownloadOrderPembelianDetail(dsXML.Tables["OrderPembelianDetail"]);

                        DownloadNotaPembelian(dsXML.Tables["NotaPembelian"]);

                        DownloadNotaPembelianDetail(dsXML.Tables["NotaPembelianDetail"]);

                        DownloadReturPembelian(dsXML.Tables["ReturPembelian"]);

                        DownloadReturPembelianDetail(dsXML.Tables["ReturPembelianDetail"]);

                        DownloadKoreksiPembelian(dsXML.Tables["KoreksiPembelian"]);

                        DownloadKoreksiReturPembelian(dsXML.Tables["KoreksiReturPembelian"]);

                        DownloadPeminjaman(dsXML.Tables["Peminjaman"]);

                        DownloadPeminjamanDetail(dsXML.Tables["PeminjamanDetail"]);

                        DownloadPengembalian(dsXML.Tables["Pengembalian"]);

                        DownloadMutasi(dsXML.Tables["Mutasi"]);

                        DownloadMutasiDetail(dsXML.Tables["MutasiDetail"]);

                        DownloadAntarGudang(dsXML.Tables["AntarGudang"]);

                        DownloadAntarGudangDetail(dsXML.Tables["AntarGudangDetail"]);

                        MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data yang Anda Pilih Bukan Data POS");
                    }
                }

                
            }
           
            

        }


        private void DownloadSales(DataTable dt)
        {
            RefreshStatus("Downloading Sales...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Sales"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }
            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }


        private void DownloadToko(DataTable dt)
        {
            RefreshStatus("Downloading Toko...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Toko"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";

        }

        private void DownloadStok(DataTable dt)
        {
            RefreshStatus("Downloading Stok...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Stok"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadPemasok(DataTable dt)
        {
            RefreshStatus("Downloading Pemasok...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Pemasok"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);
                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadExpedisi(DataTable dt)
        {
            RefreshStatus("Downloading Expedisi...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Expedisi"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadKompensasi(DataTable dt)
        {
            RefreshStatus("Downloading Kompensasi...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Kompensasi"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadOpnameHistory(DataTable dt)
        {
            RefreshStatus("Downloading Opname History...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_OpnameHistory"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadOrderPenjualan(DataTable dt)
        {
            RefreshStatus("Downloading Order Penjualan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_OrderPenjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadOrderPenjualanDetail(DataTable dt)
        {
            RefreshStatus("Downloading Order Penjualan Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_OrderPenjualanDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);
                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadNotaPenjualan(DataTable dt)
        {
            RefreshStatus("Downloading Nota Penjualan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_NotaPenjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadNotaPenjualanDetail(DataTable dt)
        {
            RefreshStatus("Downloading Nota Penjualan Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_NotaPenjualanDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }
            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }


        private void DownloadReturPenjualan(DataTable dt)
        {
            RefreshStatus("Downloading Retur Penjualan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_ReturPenjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadReturPenjualanDetail(DataTable dt)
        {
            RefreshStatus("Downloading Retur Penjualan Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_ReturPenjualanDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadKoreksiPenjualan(DataTable dt)
        {

            RefreshStatus("Downloading Koreksi Penjualan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_KoreksiPenjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }


        private void DownloadKoreksiReturPenjualan(DataTable dt)
        {

            RefreshStatus("Downloading Koreksi Retur Penjualan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_KoreksiReturPenjualan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadPenjualanPotongan(DataTable dt)
        {
            RefreshStatus("Downloading Penjualan Potongan...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_PenjualanPotongan"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadRekapKoli(DataTable dt)
        {
            RefreshStatus("Downloading Rekap Koli...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_RekapKoli"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadRekapKoliDetail(DataTable dt)
        {
            RefreshStatus("Downloading Rekap Koli Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_RekapKoliDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadRekapKoliSubDetail(DataTable dt)
        {

            RefreshStatus("Downloading Rekap Koli SubDetail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_RekapKoliSubDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";

        }

        private void DownloadOrderPembelian(DataTable dt)
        {

            RefreshStatus("Downloading Order Pembelian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_OrderPembelian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";

        }

        private void DownloadOrderPembelianDetail(DataTable dt)
        {
            RefreshStatus("Downloading Order Pembelian Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_OrderPembelianDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadNotaPembelian(DataTable dt)
        {
            RefreshStatus("Downloading Nota Pembelian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_NotaPembelian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadNotaPembelianDetail(DataTable dt)
        {
            RefreshStatus("Downloading Nota Pembelian Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_NotaPembelianDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadReturPembelian(DataTable dt)
        {
            RefreshStatus("Downloading Retur Pembelian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_ReturPembelian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }


        private void DownloadReturPembelianDetail(DataTable dt)
        {

            RefreshStatus("Downloading Retur Pembelian Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_ReturPembelianDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);


                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";

        }

        private void DownloadKoreksiPembelian(DataTable dt)
        {
            RefreshStatus("Downloading Koreksi Pembelian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_KoreksiPembelian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);


                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";

        }

        private void DownloadKoreksiReturPembelian(DataTable dt)
        {

            RefreshStatus("Downloading Koreksi Retur Pembelian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_KoreksiReturPembelian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadPeminjaman(DataTable dt)
        {
            RefreshStatus("Downloading Peminjaman...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Peminjaman"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadPeminjamanDetail(DataTable dt)
        {
            RefreshStatus("Downloading Peminjaman Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_PeminjamanDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadPengembalian(DataTable dt)
        {
            RefreshStatus("Downloading Pengembalian...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Pengembalian"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadMutasi(DataTable dt)
        {
            RefreshStatus("Downloading Mutasi...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_Mutasi"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadMutasiDetail(DataTable dt)
        {
            RefreshStatus("Downloading Mutasi Detail");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_MutasiDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadAntarGudang(DataTable dt)
        {
            RefreshStatus("Downloading Antar Gudang...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_AntarGudang"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void DownloadAntarGudangDetail(DataTable dt)
        {
            RefreshStatus("Downloading Antar Gudang Detail...");

            using (Database db = new Database())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Contains("XmlData"))
                    {
                        if (dr["XmlData"] != null && dr["XmlData"].ToString() != "")
                        {
                            db.Commands.Clear();
                            db.Commands.Add(db.CreateCommand("psp_POS_DOWNLOAD_ISA_AntarGudangDetail"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Increment(1);

                }
            }

            _Count++;
            lblCtr.Text = _Count.ToString() + "/34";
        }

        private void cdmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
    }
}
