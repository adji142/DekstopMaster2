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
using System.Data.SqlTypes;

using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Toko.Communicator
{
    public partial class frmNotaPembelianDownload : ISA.Toko.BaseForm
    {

#region "Function & Variable"
    #region "Variable"
        DataTable tblHeader;
        DataTable tblDetail;
        DataTable dtProcess;
        DataTable dtNothing;
        DataTable dtSdhDownload;

        Guid _RowIDHeader;
        String _RecordIDHeader;
        DataTable dtReport1;
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

            ISA.Toko.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            dtProcess = tblHeader.Clone();
            dtNothing = tblHeader.Clone();
            dtSdhDownload = tblHeader.Clone();
            dtReport1 = tblDetail.Clone();
            string KodeGudang = "";
            int result = 0;
            String NoSJ = "";
            using (Database db = new Database())
            {

                // Headernya
                db.Commands.Add(db.CreateCommand("[usp_NotaPembelian_Download]"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                    #region " Header Parameter"
                    KodeGudang = Tools.isNull(dr["Nm_toko"], "").ToString().Trim();
                    if (KodeGudang == GlobalVar.Gudang)
                    {
                        _RowIDHeader = Guid.NewGuid();
                        _RecordIDHeader = Tools.isNull(dr["idtr"], "").ToString();
                        NoSJ = Tools.isNull(dr["no_sj"], "").ToString().Trim() + Tools.isNull(dr["no_dobo"], "").ToString().Trim();
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDHeader));
                        db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, dr["tgl_rq"]));
                        db.Commands[0].Parameters.Add(new Parameter("@noDO", SqlDbType.VarChar, Tools.isNull(dr["No_do"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglTransaksi", SqlDbType.DateTime, SqlDateTime.Null));
                        db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, NoSJ));
                        db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, dr["Tgl_sj"]));

                        db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, NoSJ));
                        db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dr["tgl_sj"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, dr["tgl_trm"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, dr["disc_1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, dr["disc_2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, dr["disc_3"]));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, Tools.isNull(dr["id_disc"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@Cabang", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                        //db.Commands[0].Parameters.Add(new Parameter("@tgldo11", SqlDbType.DateTime, dr["tgl_do11"]));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();

                        result = db.Commands[0].ExecuteNonQuery();
                    #endregion
                      

                        //if (result == 1)
                        //{
                            dr["cUploaded"] = true;
                            counter++;
                            progressBar1.Increment(1);
                            lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                            this.Refresh();
                            this.Invalidate();
                            Application.DoEvents();
                        //}

     #region "Detail"
                        dtProcess.ImportRow(dr);


                        //DO DETAILS

                        DataRow[] orderDetails = tblDetail.Select("Idtr='" + _RecordIDHeader + "'");

                        if (orderDetails.Length == 0)
                        {
                            MessageBox.Show("Tidak ada Detail");
                        }

                        db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_Download"));
                        foreach (DataRow drd in orderDetails)
                        {
                            //dtReport1.ImportRow(drd);
                            //add parameters
                            db.Commands[1].Parameters.Clear();
                            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                            db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Idrec"], "").ToString()));
                            db.Commands[1].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, Tools.isNull(drd["idtr"], "").ToString()));
                            db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["Kode_brg"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyRequest", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_rq"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyDO", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_do"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@QtySuratJalan", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_sj"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyNota", SqlDbType.Int, Convert.ToInt32(Tools.isNull(drd["J_sj"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, Tools.isNull(drd["catatan"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@TglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[1].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["h_jual"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["h_pokok"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["h_pokok2"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@Pot", SqlDbType.Money, Convert.ToDouble(Tools.isNull(drd["pot_rp"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_1"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_2"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, Convert.ToDouble(Tools.isNull(drd["disc_3"], "0").ToString().Trim())));
                            db.Commands[1].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, Tools.isNull(drd["id_disc"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@ppn", SqlDbType.Float,0));
                            db.Commands[1].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0)); ;
                            db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[1].Parameters.Add(new Parameter("@NamaStok", SqlDbType.VarChar, Tools.isNull(drd["Nama_stok"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@Koderak", SqlDbType.VarChar, Tools.isNull(drd["kd_rak"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@KoreksiID", SqlDbType.VarChar, Tools.isNull(drd["id_koreksi"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@StokID", SqlDbType.VarChar, Tools.isNull(drd["Id_stok"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@Satuan", SqlDbType.VarChar, Tools.isNull(drd["Satuan"], "").ToString().Trim()));

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
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_NotaPembelian_Download_RefreshQtyReal"));
                foreach (DataRow dr in tblHeader.Rows)
                {
                  
                    KodeGudang = Tools.isNull(dr["Nm_toko"], "").ToString().Trim();
                    if (KodeGudang == GlobalVar.Gudang)
                    {
                        db.Commands[0].Parameters.Clear();
                        db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, Tools.isNull(dr["no_rq"], "").ToString().Trim()));
                        db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, dr["tgl_rq"]));
                        db.Commands[0].Parameters.Add(new Parameter("@tgldo11", SqlDbType.DateTime, dr["tgl_do"]));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, KodeGudang));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                        db.BeginTransaction();

                      db.Commands[0].ExecuteNonQuery();
                      db.CommitTransaction();
                    }
                }
            }
        }

        private void ExtractData()
        {
            if (File.Exists(GlobalVar.DbfDownload + "\\dbfmatch.zip"))
            {
                ExtractFile(GlobalVar.DbfDownload + "\\dbfmatch.zip");
            }
            else
            {
                MessageBox.Show("File dbfmatch.zip tidak ada!");
                return;
            }

            string fileNameH = "Hpj11Tmp.dbf";
            string fileNameD = "Dpj11Tmp.dbf";


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
            else
            {
                MessageBox.Show("File " + fileNameH + " atau " + fileNameH + " tidak ada");
            }
        }

        private int GetHargaBeli(string KodeBarang,DateTime Tgl)
        {
            int hrgBeli = 0;
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_GetHrgBeli]"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang));
                db.Commands[0].Parameters.Add(new Parameter("Tgl", SqlDbType.DateTime, Tgl));

                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 1)
            {
                hrgBeli =Convert.ToInt32(dt.Rows[0]["HrgBeli"]);
            }

            return hrgBeli;
        }

        private Boolean ChekBarang(string KodeBarang)
        {
            Boolean t=false;
            DataTable dt;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("rsp_NotaPembelian_Download"));
                db.Commands[0].Parameters.Add(new Parameter("@KodeBarang", SqlDbType.VarChar, KodeBarang));
                

                dt = db.Commands[0].ExecuteDataTable();
            }

            if (dt.Rows.Count == 1)
            {
                t = true;
            }

            return t;
        }
        private void DisplayReport1()
        {

            DataSet ds = new dsNotaPembelian();
            DataTable dt = ds.Tables[0];
        
            string idtr = "";
            string NoRq = "";
            string TglRq=string.Empty;
            string NoDO="";
            string TglDO=string.Empty;
            string NoNota = "";
            string TglNota= string.Empty;
           
            string NamaStok = "";
            int HrgJual=0;
            int QtySJ = 0;
            int _No = 0;

            foreach (DataRow dr in tblHeader.Rows)
            {
                idtr = Tools.isNull(dr["idtr"], "").ToString().Trim();
                NoRq = Tools.isNull(dr["no_rq"], "").ToString().Trim();
                TglRq = Tools.isNull(dr["tgl_rq"],"").ToString();
                NoDO = Tools.isNull(dr["No_do"], "").ToString().Trim();
                TglDO = Tools.isNull(dr["Tgl_do"], "").ToString();
                DateTime result;
                if (DateTime.TryParse(dr["Tgl_nota"].ToString(), out result))
                {
                    TglNota = result.ToString("dd/MM/yyyy");
                }else
                {
                    TglNota = "1900/1/1";
                }
                
                NoNota = Tools.isNull(dr["No_nota"], "").ToString().Trim();
                _No = _No + 1;
                DataRow[] Details = tblDetail.Select("Idtr='" + idtr + "'");

                 foreach (DataRow drd in Details)
                 {
                     NamaStok = Tools.isNull(drd["Nama_stok"], "").ToString().Trim();
                     HrgJual = Convert.ToInt32(Tools.isNull(drd["H_jual"], "0").ToString().Trim());
                     QtySJ = Convert.ToInt32(Tools.isNull(drd["J_sj"], "0").ToString().Trim());
                     
                     DataRow drw = dt.NewRow();
                     drw["NoRequest"] = NoRq;
                     drw["TglRequest"] = TglRq;
                     drw["NoNota"] = NoNota;
                     drw["TglNota"] = TglNota;
                     drw["NamaBarang"] = NamaStok;
                     drw["QtySuratJalan"] = QtySJ;
                     drw["HrgBeli"] = HrgJual;
                     drw["TglDO"] = TglDO;
                     drw["NoDO"] = NoDO;
                    drw["Nilai"]=_No;
                     dt.Rows.Add(drw);
                 }
            }


            if (dt.Rows.Count > 0)
            {
                string periode;
                periode = String.Format("Tanggal :{0}", ((DateTime)DateTime.Now).ToString("dd/MM/yyyy"));
                //construct parameter
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Periode", periode));
                rptParams.Add(new ReportParameter("Gudang", GlobalVar.Gudang));

                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptNotaPembelianDownload.rdlc", rptParams, dt, "dsNotaPembelian_Data");
                ifrmReport.Show();
            }
            


        }

        private void DisplayReport2()
        {
            DataSet ds = new dsNotaPembelian();
            DataTable dt = ds.Tables[0];

            string idtr = "";
            string TglSj=string.Empty;
            string KodeBarang;
            string NamaStok = "";
            int HrgJual = 0;
            int _No = 0;
            int hrgBeli = 0;
            foreach (DataRow dr in tblHeader.Rows)
            {
                _No = _No + 1;
                idtr = Tools.isNull(dr["idtr"], "").ToString().Trim();
                TglSj = Tools.isNull(dr["Tgl_sj"], "").ToString();
                DataRow[] Details = tblDetail.Select("Idtr='" + idtr + "'");

                foreach (DataRow drd in Details)
                {
                    NamaStok = Tools.isNull(drd["Nama_stok"], "").ToString().Trim();
                    HrgJual = Convert.ToInt32(Tools.isNull(drd["H_jual"], "0").ToString().Trim());
                    KodeBarang = Tools.isNull(drd["Kode_brg"], "").ToString().Trim();
                    TglSj = Tools.isNull(dr["Tgl_sj"], "").ToString();
                    hrgBeli = GetHargaBeli(KodeBarang, (DateTime)dr["Tgl_sj"]);
                    DataRow drw = dt.NewRow();
                    drw["Nilai"] = _No;
                    drw["NamaBarang"] = NamaStok;
                    drw["HrgJual"] = HrgJual;
                    drw["HrgBeli"] = hrgBeli;

                    if (hrgBeli!= HrgJual)
                    {
                       dt.Rows.Add(drw);
                    }
                    
                   
                }
            }


            if (dt.Rows.Count > 0)
            {
                string periode;
                periode = String.Format("Tanggal :{0}", ((DateTime)DateTime.Now).ToString("dd/MM/yyyy"));
                //construct parameter
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Periode", periode));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptNotaPembelianDownloadBedaHarga.rdlc", rptParams, dt, "dsNotaPembelian_Data");
                ifrmReport.Show();
            }
            

        }

        private void DisplayReport3()
        {
            DataSet ds = new dsNotaPembelian();
            DataTable dt = ds.Tables[0];

            string idtr = "";
            string KodeBarang;
            string NamaStok = "";
            int HrgJual = 0;
            string Satuan = "";
            foreach (DataRow dr in tblHeader.Rows)
            {
                idtr = Tools.isNull(dr["idtr"], "").ToString().Trim();
                DataRow[] Details = tblDetail.Select("Idtr='" + idtr + "'");

                foreach (DataRow drd in Details)
                {
                    NamaStok = Tools.isNull(drd["Nama_stok"], "").ToString().Trim();
                    HrgJual = Convert.ToInt32(Tools.isNull(drd["H_jual"], "0").ToString().Trim());
                    KodeBarang = Tools.isNull(drd["Kode_brg"], "").ToString().Trim();
                    Satuan = Tools.isNull(drd["Satuan"], "").ToString().Trim();
                    DataRow drw = dt.NewRow();
                    drw["NamaBarang"] = NamaStok;
                    drw["HrgJual"] = HrgJual;
                    drw["BarangID"] = KodeBarang;
                    drw["Satuan"] = Satuan;

                    if (ChekBarang(KodeBarang))
                    {
                        dt.Rows.Add(drw);
                    }


                }
            }


            if (dt.Rows.Count > 0)
            {
                string periode;
                periode = String.Format("Tanggal :{0}", ((DateTime)DateTime.Now).ToString("dd/MM/yyyy"));
                //construct parameter
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                rptParams.Add(new ReportParameter("Periode", periode));


                //call report viewer
                frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptNotaPembelianDownloadStokBaru.rdlc", rptParams, dt, "dsNotaPembelian_Data");
                ifrmReport.Show();
            }
        }
#endregion
        public frmNotaPembelianDownload()
        {
            InitializeComponent();
        }

        private void frmNotaPembelianDownload_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView3.AutoGenerateColumns = true;
            LoadPemasok();
            ExtractData();
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboPemasok.Text))
            {
                cboPemasok.Focus();
                return;
            }

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Data tidak ada!");
                return;
            }

            if (MessageBox.Show(Messages.Question.AskDownload, "Download Pemebelian ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    Download();
                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    DisplayReport1();
                    DisplayReport2();
                    DisplayReport3();
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
