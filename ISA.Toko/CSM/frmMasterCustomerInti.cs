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
using System.Drawing.Printing;
using ISA.Toko.Class;

namespace ISA.Toko.CSM
{
    public partial class frmMasterCustomerInti : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { CISelected, DetailCISelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.CISelected;
        DataTable dtCI, dtDetailCI;
        DataSet dsCI = new DataSet();
        DataSet dsXML = new DataSet();
        DataSet dsDownlCIH = new DataSet();
        DataSet dsDownlCID = new DataSet();
        string FlagKtg = "" ;
        string titleT = "";


        private void deleteDataHeader()
        {
            
            Guid rowID = (Guid)dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string namaToko = dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString().Trim() ;
            if (MessageBox.Show("Hapus Customer  " + namaToko + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti_Delete"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    RefreshDataCI();
                    //DataRowView dv = (DataRowView)dataGridCustomerInti.SelectedCells[0].OwningRow.DataBoundItem;
                    //DataRow dr = dv.Row;
                    //dr.Delete();
                    //dtCI.AcceptChanges();
                    //dataGridCustomerInti.Focus();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        private void searchToko()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtCI = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    dtCI = db.Commands[0].ExecuteDataTable();

                }

                dtCI.DefaultView.Sort = "namatoko";
                dataGridCustomerInti.DataSource = dtCI.DefaultView;

                if (dataGridCustomerInti.SelectedCells.Count > 0)
                {
                    RefreshDataDetailCI();
                    dataGridCustomerInti.Focus();
                }
                else
                {
                    dataGridCustomerDetail.DataSource = null;

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

        private DataSet GetSyncData()
        {

            DataSet ds = new DataSet();

            using (Database db = new Database())
            {
                db.Commands.Clear();
                db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti_Upload"));
                db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                ds = db.Commands[0].ExecuteDataSet();              
               
            }

            int counter1 = 0;

            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                counter1++;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = ds.Tables[0].Rows.Count;


                progressBar1.Increment(1);
            }
            return ds;
        }

        private Boolean SelectFile()
        {
            openFileDialog1.InitialDirectory = LookupInfo.GetValue("FTP", "FTP_DIRECTORY_DOWNLOAD");
            string pre = "";
            if (FlagKtg == "INTI")
            {
                pre = "CI-";
            }
            else if (FlagKtg == "MITRAPS")
            {
                pre = "MPS-";
            }
            else if (FlagKtg == "MITRASAS")
            {
                pre = "MSAS-";
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName.Contains(pre))
            {
               dsXML.ReadXml(openFileDialog1.FileName);
               return true;
            }
            else
            {
                MessageBox.Show("Data yang Anda Pilih Bukan Data Antar Gudang");
                return false;
            }
        }

        private void printReport()
        {
            this.Cursor = Cursors.WaitCursor;
            List<ReportParameter> rptParams = new List<ReportParameter>();
            string ttl = "" ;
            if (FlagKtg == "INTI")
            {
                ttl  = "CUSTOMER INTI";
            }
            else if (FlagKtg == "MITRAPS")
            {
                ttl = "MITRA PS";
            }
            else if (FlagKtg == "MITRASAS")
            {
                ttl = "MITRA SAS";
            }
            rptParams.Add(new ReportParameter("Title", ttl));
            //rptParams.Add(new ReportParameter("Initial", GlobalVar.PerusahaanName + "-" + GlobalVar.Gudang));
            //rptParams.Add(new ReportParameter("User", SecurityManager.UserInitial + " " + DateTime.Now.ToString("dd-MMM-yyyy")));
            //rptParams.Add(new ReportParameter("Title", "LAPORAN HARGA BELI"));

            //call report viewer
            //frmReportViewer ifrmReport = new frmReportViewer("CSM.rptCustomerInti.rdlc", rptParams, ds.Tables[0], "dsPLDetail_DataPLDetail");
            //ifrmReport.Text = "Customer Inti";
            //ifrmReport.Show();

            try
            {
              
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    dsCI = db.Commands[0].ExecuteDataSet();
                }

                if (dsCI.Tables[0].Rows.Count > 0)
                {
                    frmReportViewer ifrmReport = new frmReportViewer("CSM.rptCustomerInti.rdlc", rptParams, dsCI.Tables[0], "dsCustomerInti_CustomerInti");
                    ifrmReport.Text = "Customer Inti";
                    ifrmReport.Show();
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

        public frmMasterCustomerInti()
        {
            InitializeComponent();

        }

        public frmMasterCustomerInti( string _titleT , string _FlagKtg)
        {
            InitializeComponent();
            titleT = _titleT;
            FlagKtg = _FlagKtg;

        }

        private void frmMasterCustomerInti_Load(object sender, EventArgs e)
        {
            this.Title = "Customer Inti";
            this.Text = "CSM";
            
            dataGridCustomerInti.AutoGenerateColumns = false;
            dataGridCustomerDetail.AutoGenerateColumns = false;
           
            dataGridCustomerInti.GenerateRowNumber = true;
            dataGridCustomerDetail.GenerateRowNumber = true;
            RefreshDataCI();
        }     

        public void RefreshDataCI()
        {    

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtCI = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    if (txtSearch.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtSearch.Text));
                    }
                    dtCI = db.Commands[0].ExecuteDataTable();
                   
                }

                dtCI.DefaultView.Sort = "namatoko";
                dataGridCustomerInti.DataSource = dtCI.DefaultView;

                if (dataGridCustomerInti.SelectedCells.Count > 0)
                {
                    RefreshDataDetailCI();
                    dataGridCustomerInti.Focus();
                }
                else
                {
                    dataGridCustomerDetail.DataSource = null;
                    
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

        public void RefreshRowDataCI(string _rowID)
        {
            txtSearch.Text = "";
            RefreshDataCI();
            dataGridCustomerInti.FindRow("rowID", _rowID);
            /*
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridCustomerInti.RefreshDataRow(dtRefresh.Rows[0], "namatoko", _rowID.ToString());

                    if (dataGridCustomerInti.SelectedCells.Count > 0)
                    {
                        RefreshDataDetailCI();
                       
                        dataGridCustomerInti.Focus();
                    }
                    else
                    {
                        dataGridCustomerDetail.DataSource = null;
                        
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
             */
        }

        public void RefreshDataDetailCI()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtDetailCI = new DataTable();
                    Guid _headerID = (Guid)dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_CSM_CustomerIntiDetail_LIST_FILTER_HEADERID"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailCI = db.Commands[0].ExecuteDataTable();
                }
                dtDetailCI.DefaultView.Sort = "RowID";
                dataGridCustomerDetail.DataSource = dtDetailCI;

                if (dataGridCustomerDetail.SelectedCells.Count > 0)
                {
                   
                }
                else
                {
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

        public void RefreshRowDataDetailCI(string _rowID)
        {
            Guid rowID = new Guid(_rowID);
            DataTable dtRefresh;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtRefresh = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_CustomerInti_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }

                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridCustomerDetail.RefreshDataRow(dtRefresh.Rows[0], "RowID", _rowID.ToString());
                }

                if (dataGridCustomerDetail.SelectedCells.Count > 0)
                {
                }
                else
                {

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

        private void dataGridCustomerInti_Click(object sender, EventArgs e)
        {

            selectedGrid = enumSelectedGrid.CISelected;
        }

        private void dataGridCustomerIntiDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailCISelected;
        }

        
        private void Download(DataTable dt)
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
                            db.Commands.Add(db.CreateCommand("psp_CSM_Customer_Inti_Download"));
                            db.Commands[0].Parameters.Add(new Parameter("@tableName", SqlDbType.VarChar, dr["TableName"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@method", SqlDbType.VarChar, dr["Method"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@xmlData", SqlDbType.VarChar, dr["XmlData"].ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@userUpdate", SqlDbType.VarChar, SecurityManager.UserID ));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }


                }
            }

        }
        
        /* Modus Add, Edit dan Delete */

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.CISelected:
                    CSM.frmCustomerIntiUpdate ifrmChild = new CSM.frmCustomerIntiUpdate(this ,FlagKtg);
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                    break;
                case enumSelectedGrid.DetailCISelected:
                    if (dataGridCustomerInti.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridCustomerInti.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridCustomerDetail.FindRow(columnName, value);
        }    

        private void dataGridCI_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridCustomerInti.SelectedCells.Count > 0)
            {
                RefreshDataDetailCI();

                //lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                //    + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
            }
            else
            {
                //lblToko.Text = " ";
            }
        }

        private void dataGridDetailCI_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridCustomerDetail.SelectedCells.Count > 0)
            {
                //lblBarang.Text = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
            else
            {
                //lblBarang.Text = " ";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridCustomerInti.SelectedCells.Count > 0)
            {
                deleteDataHeader();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                switch (selectedGrid)
                {
                    case enumSelectedGrid.CISelected:
                        if (dataGridCustomerInti.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        Guid rowID = (Guid)dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        CSM.frmCustomerIntiUpdate ifrmChild = new CSM.frmCustomerIntiUpdate(this, rowID,FlagKtg);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                    case enumSelectedGrid.DetailCISelected:
                        if (dataGridCustomerDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmMasterCustomerInti_Load_1(object sender, EventArgs e)
        {
            this.Title = titleT ;
            this.Text = "CSM";
            

            dataGridCustomerInti.AutoGenerateColumns = false;
            dataGridCustomerDetail.AutoGenerateColumns = false;

            dataGridCustomerInti.GenerateRowNumber = true;
            dataGridCustomerDetail.GenerateRowNumber = true;
            RefreshDataCI();
        }

        private void cmdADD_Click_1(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.CISelected:
                    CSM.frmCustomerIntiUpdate ifrmChild = new CSM.frmCustomerIntiUpdate(this ,FlagKtg);
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.ShowDialog();
                    break;
                case enumSelectedGrid.DetailCISelected:
                    if (dataGridCustomerInti.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    break;
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            try
            {

                switch (selectedGrid)
                {
                    case enumSelectedGrid.CISelected:
                        if (dataGridCustomerInti.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        Guid rowID = (Guid)dataGridCustomerInti.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        CSM.frmCustomerIntiUpdate ifrmChild = new CSM.frmCustomerIntiUpdate(this, rowID,FlagKtg);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                        break;
                    case enumSelectedGrid.DetailCISelected:
                        if (dataGridCustomerDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridCustomerInti.SelectedCells.Count > 0)
            {
                deleteDataHeader();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
           if( dataGridCustomerInti.SelectedCells.Count > 0){
               printReport();
           }
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (SelectFile())
                {
                    //string XmlDataH = dsXML.Tables[0].Rows[0]["XmlData"].ToString();
                    //StringReader srH = new StringReader(XmlDataH);
                    //dsDownlCIH.ReadXml(srH);

                    Download(dsXML.Tables[0]);
                    Download(dsXML.Tables[1]);
                    MessageBox.Show("Selesai Download");
                    RefreshDataCI();
                    
                }
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = GetSyncData();

                if (ds.Tables.Count > 0)
                {

                    string pathString = @"c:\temp\upload";
                    if (!System.IO.Directory.Exists(pathString))
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }
                    string pre = "";
                    if (FlagKtg == "INTI")
                    {
                        pre = "CI-";
                    }
                    else if (FlagKtg == "MITRAPS")
                    {
                        pre = "MPS-";
                    }
                    else if (FlagKtg == "MITRASAS")
                    {
                        pre = "MSAS-";
                    }
                    string fileOuput = pathString + "\\" + pre + "" + DateTime.Now.ToString("yyyyMMdd hhmmss") + " " + Guid.NewGuid().ToString() + ".xml";
                    ds.WriteXml(fileOuput);
                    MessageBox.Show(Messages.Confirm.UploadSuccessful + "\n" + fileOuput);

                }
                else
                {
                    MessageBox.Show(Messages.Confirm.NoDataAvailable);
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            searchToko();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSearch.PerformClick();
            }
        }

       

      
    }
}
