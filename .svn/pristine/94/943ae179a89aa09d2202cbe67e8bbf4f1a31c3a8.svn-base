using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Trading.DataTemplates;

namespace ISA.Trading.VACCDO
{
    public partial class frmACCDOBrowseISA : ISA.Trading.BaseForm
    {
        string docNO = "NOMOR_ACC_DO";
        string initPerusahaan = GlobalVar.PerusahaanID;
        string host = Database.Host;

        public void RptRekapPembayaran(DataSet ds, string NamaToko_, String Alamat_, string Grade_, string Catatan_, double plafon_)
        {
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("NamaToko", ds.Tables[6].Rows[0]["NamaToko"].ToString()));
            rptParams.Add(new ReportParameter("WilID", ds.Tables[6].Rows[0]["WilID"].ToString()));
            rptParams.Add(new ReportParameter("Alamat", ds.Tables[6].Rows[0]["Alamat"].ToString()));
            rptParams.Add(new ReportParameter("Catatan", ds.Tables[6].Rows[0]["Catatan"].ToString()));
            rptParams.Add(new ReportParameter("Grade", ds.Tables[6].Rows[0]["Grade"].ToString()));
            rptParams.Add(new ReportParameter("Kota", ds.Tables[6].Rows[0]["Kota"].ToString() + ", " + ds.Tables[6].Rows[0]["Daerah"].ToString()));
            rptParams.Add(new ReportParameter("Plafon", plafon_.ToString("#,##0")));
            rptParams.Add(new ReportParameter("UserName", SecurityManager.UserName));
            rptParams.Add(new ReportParameter("JKW", ds.Tables[5].Rows[0][0].ToString()));
            rptParams.Add(new ReportParameter("NoTelp", ds.Tables[6].Rows[0]["Telp"].ToString()));
            rptParams.Add(new ReportParameter("Pemilik", ds.Tables[6].Rows[0]["PenanggungJawab"].ToString()));

            //call report viewer
            List<DataTable> pTable = new List<DataTable>();
            pTable.Add(ds.Tables[0]);
            pTable.Add(ds.Tables[1]);
            pTable.Add(ds.Tables[2]);
            pTable.Add(ds.Tables[3]);
            pTable.Add(ds.Tables[4]);


            List<string> pDatasetName = new List<string>();
            pDatasetName.Add("dsKpiutang_Data");
            pDatasetName.Add("dsKpiutang_Data1");
            pDatasetName.Add("dsKpiutang_Data2");
            pDatasetName.Add("dsKpiutang_Data3");
            pDatasetName.Add("dsKpiutang_Data4");

            frmReportViewer ifrmReport = new frmReportViewer("VACCDO.rptRekapPembayaran.rdlc", rptParams, pTable, pDatasetName);
            ifrmReport.Text = "SaldoKu";
            ifrmReport.Show();
        }

        public void F12(string KodeToko_,string NamaToko_, String Alamat_, string Grade_,string Catatan_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_RekapPembayaran")); //cek heri 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    ds = db.Commands[0].ExecuteDataSet();
                }
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("fsp_GetLastPlafon")); //cek heri 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                double plafon_ = 0;
                if (dt.Rows.Count > 0)
                {
                    double.TryParse(dt.Rows[0]["PlafonAkhir"].ToString(), out plafon_);
                }

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No Data");
                    return;
                }
                RptRekapPembayaran(ds,NamaToko_, Alamat_, Grade_,Catatan_, plafon_);

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
    
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public frmACCDOBrowseISA()
        {
            InitializeComponent();
        }

        private void frmACCDOBrowseISA_Load(object sender, EventArgs e)
        {
            chBoFilter.Checked = true;
            chBoFilter.Text = "Tampilkan seluruhnya";
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.GenerateRowNumber = true;
            Catatan.Visible = true;
        }

        private void chBoFilter_Click(object sender, EventArgs e)
        {
            if (chBoFilter.Checked == false)
            {
                chBoFilter.Text = "Tampilkan yang belum ACC saja.";
                RefreshDataBelum();
            }
            else
            {
                chBoFilter.Text = "Tampilkan seluruhnya";
                RefreshDataSeluruhnya();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataSeluruhnya();
        }

        public void RefreshDataSeluruhnya()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST"));  // cek heri 13022013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort =  "TglDO, NoDo";
                dataGridView1.DataSource = dt.DefaultView; 
               
             

             
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }


        public void RefreshRowDataDO(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST_FILTER_ROWID"));//cek heri 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));                    
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());                   
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

        public void RefreshDataBelum()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ACCDO_LIST")); //cek heri, 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@filter", SqlDbType.VarChar, ""));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                //Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdApprove_Click(object sender, EventArgs e)
        {
            Guid doID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            DataTable dt = new DataTable();
            try
            {
                int nota_ = 0;
                

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaPenjualan_CHEK]")); //cek heri 13032013
                    db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, doID));
                    nota_ = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                    //dt = db.Commands[0].ExecuteDataTable();
                }

                if (nota_ > 0 //dt.Rows.Count > 0 
                    && !SecurityManager.AskPasswordManager())
                {
                    MessageBox.Show("Anda tidak berwenang untuk ACC ulang");
                    return;
                }
                
                Guid headerID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string kodeToko = dataGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                DateTime tglDo = (DateTime)dataGridView1.SelectedCells[0].OwningRow.Cells["TglDO"].Value;
                string NamaToko_=dataGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                string AlamatToko_= dataGridView1.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                string CatatanTOko_ = dataGridView1.SelectedCells[0].OwningRow.Cells["CatatanToko"].Value.ToString();
                string Grade_ =dataGridView1.SelectedCells[0].OwningRow.Cells["Grade"].Value.ToString();
              F12(kodeToko,NamaToko_,AlamatToko_,Grade_,CatatanTOko_);


              VACCDO.frmPlafonISA ifrmChild = new VACCDO.frmPlafonISA(this, headerID, kodeToko, tglDo);
              ifrmChild.MdiParent = Program.MainForm;
              Program.MainForm.RegisterChild(ifrmChild);
              ifrmChild.Show();

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                cmdApprove.PerformClick();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["NoACC"].Value.ToString() == "")
            {
                
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black ;
            }
                else
            {
             dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue ;   
            }
            
       }
        
    }
}
