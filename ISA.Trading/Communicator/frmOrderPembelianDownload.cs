using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ISA.Trading.Communicator
{
    public partial class frmOrderPembelianDownload : ISA.Trading.BaseForm
    {

#region "Function & Variable"
        DataTable tblHeader;
        DataTable tblDetail;
      
        DataTable dtSdhDownload;
        DataTable dtHeaderFilter;
        DataTable dtDetailFilter;

        Guid _RowIDHeader;
        String _RecordIDHeader;

        private void ExtractFile(string fileName)
        {

            ISA.Trading.Class.Zip.UnZipFiles(fileName, GlobalVar.DbfDownload, false);
        }

        private void Download()
        {
            int counter = 0;
            DataTable dtResult = new DataTable();

            //dtProcess = dtHeaderFilter.Clone();
            //dtNothing = dtHeaderFilter.Clone();
            dtSdhDownload = dtHeaderFilter.Clone();


            int result = 0;
            using (Database db = new Database())
            {
                // HEADERS
                db.Commands.Add(db.CreateCommand("[usp_OrderPembelian_Download]"));
                foreach (DataRow dr in dtHeaderFilter.Rows)
                {
                    //add parameters
                    _RowIDHeader = Guid.NewGuid();
                    _RecordIDHeader = Tools.isNull(dr["Idtr"], "").ToString().Trim();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _RecordIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, Tools.isNull(dr["No_rq"], "").ToString().Trim()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, dr["Tgl_info"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, "KP-SOLO"));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, GlobalVar.CabangID));
                    db.Commands[0].Parameters.Add(new Parameter("@estHrgJual", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@estHPP", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar,GlobalVar.PerusahaanID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].Parameters.Add(new Parameter("@Date", SqlDbType.DateTime, dateTextBox1.DateValue));

                    db.BeginTransaction();

                    result = db.Commands[0].ExecuteNonQuery();



                    //grid and form status
                    dr["cUploaded"] = true;
                    counter++;
                    progressBar1.Increment(1);
                    lblDownloadStatus1.Text = counter.ToString("#,##0") + "/" + tblHeader.Rows.Count.ToString("#,##0");
                    this.Refresh();
                    this.Invalidate();
                    Application.DoEvents();

                    if (result == 1)
                    {

                     


                        //DO DETAILS

                        DataRow[] orderDetails = dtDetailFilter.Select("Idtr='" + _RecordIDHeader + "'");

                        if (orderDetails.Length == 0)
                        {
                            MessageBox.Show(String.Format(Messages.Confirm.NoDetailData));
                        }

                        db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_Download"));
                        foreach (DataRow drd in orderDetails)
                        {
                            //add parameters
                            db.Commands[1].Parameters.Clear();
                            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                            db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.isNull(drd["Idrec"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, Tools.isNull(drd["Idtr"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, Tools.isNull(drd["Id_brg"], "").ToString().Trim()));
                            db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[1].Parameters.Add(new Parameter("@initPers", SqlDbType.VarChar, GlobalVar.PerusahaanID));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[1].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@qtyBO", SqlDbType.Int, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@qtyJual", SqlDbType.Int, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@qtyAkhir", SqlDbType.Int, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@QtyTambahan", SqlDbType.Int, 0));
                            db.Commands[1].Parameters.Add(new Parameter("@Keterangan",SqlDbType.VarChar, ""));
                            db.Commands[1].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                            

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

                    }

                    else
                    {
                        dtSdhDownload.ImportRow(dr);
                    }
                    db.CommitTransaction();
                    // 
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
                MessageBox.Show("File dbfmatch.zip tidak ada");
                this.Close();
                return;
            }

            string fileNameH = "Hostmp.dbf";
            string fileNameD = "Dostmp.dbf";


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

                    //dataGridView1.DataSource = tblHeader;
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

                    //dataGridView3.DataSource = tblDetail;
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
                MessageBox.Show("File " + fileNameH + " atau " + fileNameD + " Tidak ada");
                return;
            }

            dtHeaderFilter = tblHeader.Clone();
            dtDetailFilter = tblDetail.Clone();
        }

        public void DisplayReport(DataTable dt)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
               
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No Data");
                        return;
                    }

                    string periode;
                    periode = String.Format("Tanggal :{0}", ((DateTime)dateTextBox1.DateValue).ToString("dd/MM/yyyy"));
                    //construct parameter
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("Periode", periode));

                    //call report viewer
                    frmReportViewer ifrmReport = new frmReportViewer("Communicator.rptOrderPembelianDownload.rdlc", rptParams, dt, "dsOrderPembelian_Data");
                    ifrmReport.Show();
                
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

        public void Reports()
        {
            DataSet ds = new dsOrderPembelian();;
            DataTable dt = ds.Tables[0];

            string NoRequest = "";
            string Pemasok="KP-SOLO";
            string NamaStok = "";
            string Satuan = "";
            DateTime RequestDate;
            foreach (DataRow dr in dtHeaderFilter.Rows)
            {
                NoRequest = Tools.isNull(dr["No_rq"], "").ToString().Trim();
                RequestDate = (DateTime)dr["Tgl_Info"];
                _RecordIDHeader = Tools.isNull(dr["Idtr"], "").ToString().Trim();
             
                    
                    DataRow[] orderDetails = tblDetail.Select("Idtr='" + _RecordIDHeader + "'");
                    foreach (DataRow drd in orderDetails)
                    {
                        Satuan = Tools.isNull(drd["satuan"], "").ToString().Trim();
                        NamaStok = Tools.isNull(drd["nama_stok"], "").ToString().Trim();

                        DataRow drw = dt.NewRow();
                        drw["NamaStok"] = NamaStok;
                        drw["TglRequest"] = RequestDate;
                        drw["Pemasok"] = Pemasok;
                        dt.Rows.Add(drw);
                    }
                
            }
            DisplayReport(dt);
        }

        private void FilterData()
        {
           
            int SyncFlag=0;
            DateTime RequestDate;
            string _RecordIDHeader = "";
            dtHeaderFilter.Rows.Clear(); 
            dtDetailFilter.Rows.Clear();

            //tblDetail.DefaultView.RowFilter = "";
            //foreach (DataRow dr in tblDetail.DefaultView)
            //{
            //    tblDetail.DefaultView.Count
            //}

            foreach (DataRow dr in tblHeader.Rows)
            {
                SyncFlag = Convert.ToInt32(Tools.isNull(dr["id_match"],"0").ToString());
                RequestDate = (DateTime)dr["Tgl_Info"];
                _RecordIDHeader = Tools.isNull(dr["Idtr"], "").ToString().Trim();
               if (SyncFlag == 0 && RequestDate==dateTextBox1.DateValue)
               {
                   dtHeaderFilter.ImportRow(dr);
                   DataRow[] orderDetails = tblDetail.Select("Idtr='" + _RecordIDHeader + "'");
                   foreach (DataRow drd in orderDetails)
                   {
                       dtDetailFilter.ImportRow(drd);
                   }
               }
            }
            
        }
#endregion

        public frmOrderPembelianDownload()
        {
            InitializeComponent();
        }

        private void frmOrderPembelianDownload_Load(object sender, EventArgs e)
        {
            dateTextBox1.DateValue = DateTime.Now;
            dateTextBox1.Focus();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView3.AutoGenerateColumns = true;
            ExtractData();
        }

        private void dateTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {

            //if (dtHeaderFilter.Rows.Count == 0 )
            //{
            //    MessageBox.Show("Tanggal yang akan diproses download tidak ada", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    dateTextBox1.Focus();
            //    return;
            //}
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Tidak ada Data yang akan diproses download ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dateTextBox1.Focus();
                return;
            }
            if (MessageBox.Show(Messages.Question.AskDownload, "Download Order Pemebelian ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                try
                {
                    Download();
                    MessageBox.Show(Messages.Confirm.DownloadSuccess);
                    Reports();
                 
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

        private void cmdSearch_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTextBox1.Text))
            {
                MessageBox.Show("Tanggal yang akan diproses download tidak ada", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dateTextBox1.Focus();
                return;
            }
            else
            {
                FilterData();
                if (dtHeaderFilter.Rows.Count == 0)
                {
                    MessageBox.Show("Tanggal yang akan diproses download tidak ada", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dateTextBox1.Focus();
                    dataGridView1.DataSource = null;
                    dataGridView3.DataSource = null;
                    return;
                }
                dataGridView1.DataSource = dtHeaderFilter;
                dataGridView3.DataSource = dtDetailFilter;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
