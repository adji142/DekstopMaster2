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
using ISA.Toko.Class;
 
namespace ISA.Toko.Expedisi
{
    public partial class frmRekapKoliBrowse : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        int prevGrid2Row = -1;
        int _prefGrid = 0;
        enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        public frmRekapKoliBrowse()
        {
            InitializeComponent();
        }

        private void frmRekapKoliBrowse_Load(object sender, EventArgs e)
        {
            rgbTglSJ.FromDate = DateTime.Now; //new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglSJ.ToDate = DateTime.Now;
            dataGridRekapKoli.AutoGenerateColumns = false;
            dataGridRekapKoliDetail.AutoGenerateColumns = false;
            dataGridRekapKoliSubDetail.AutoGenerateColumns = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataRekapKoli();
        }

        private void rgbTglSJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataRekapKoli()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_RekapKoli_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglSJ.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglSJ.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    dataGridRekapKoli.DataSource = dtHeader;
                }

                if (dataGridRekapKoli.SelectedCells.Count > 0)
                {
                    RefreshDataRekapKoliDetail();
                }
                else
                {
                    dataGridRekapKoliDetail.DataSource = null;
                    txtJmlDetail.Text = "0";
                    txtJmlSubDetail.Text = "0";
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

        public void FindHeader(string columnName, string value)
        {
            dataGridRekapKoli.FindRow(columnName, value);
        }

        public void RefreshDataRekapKoliDetail()
        {
            try
            {
                Guid _headerID = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                DataTable dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridRekapKoliDetail.DataSource = dtDetail;
                }
                
                if (dataGridRekapKoliDetail.SelectedCells.Count > 0)
                {
                    RefreshDataRekapKoliSubDetail();
                    txtJmlDetail.Text = dtDetail.Compute("SUM(Jumlah)", string.Empty).ToString();
                }
                else
                {
                    dataGridRekapKoliSubDetail.DataSource = null;
                    txtJmlDetail.Text = "0";
                    txtJmlSubDetail.Text = "0";
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

        public void FindDetail(string columnName, string value)
        {
            dataGridRekapKoliDetail.FindRow(columnName, value);
        }

        public void RefreshDataRekapKoliSubDetail()
        {
            try
            {
                Guid _headerID = (Guid)dataGridRekapKoliDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                DataTable dtSubDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {                    
                    db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtSubDetail = db.Commands[0].ExecuteDataTable();
                    dataGridRekapKoliSubDetail.DataSource = dtSubDetail;
                }
                if (dataGridRekapKoliSubDetail.SelectedCells.Count > 0)
                {
                    txtJmlSubDetail.Text = dtSubDetail.Compute("SUM(Jumlah)", string.Empty).ToString();
                }
                else
                {
                    txtJmlSubDetail.Text = "0";
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

        public void FindSubDetail(string columnName, string value)
        {
            dataGridRekapKoliSubDetail.FindRow(columnName, value);
        }

        private void dataGridRekapKoli_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridRekapKoliDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridRekapKoliSubDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.SubDetailSelected;
            _prefGrid = 3;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            try
            {
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        Expedisi.frmRekapKoliHeaderUpdate ifrmChildHeader = new Expedisi.frmRekapKoliHeaderUpdate(this);
                        ifrmChildHeader.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildHeader);
                        ifrmChildHeader.Show();
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridRekapKoli.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        GlobalVar.LastClosingDate = (DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                        //if ((DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}
                        string _kodeToko = dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        Guid _headerID = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        string _headerHtrID = dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRecordID"].Value.ToString();
                        Expedisi.frmRekapKoliDetailUpdate ifrmChildDetail = new Expedisi.frmRekapKoliDetailUpdate(this, _headerID, _headerHtrID, _kodeToko);
                        ifrmChildDetail.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildDetail);
                        ifrmChildDetail.Show();
                        break;
                    case enumSelectedGrid.SubDetailSelected:
                        if (dataGridRekapKoliDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        GlobalVar.LastClosingDate = (DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                        //if ((DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}
                        Guid _detailID = (Guid)dataGridRekapKoliDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Expedisi.frmRekapKoliSubDetailUpdate ifrmChildSubDetail = new Expedisi.frmRekapKoliSubDetailUpdate(this, _detailID);
                        ifrmChildSubDetail.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildSubDetail);
                        ifrmChildSubDetail.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            Guid _headerID; // Rekap koli header RowID
            Guid _detailID; // Rekap koli detail RowID
            Guid _subDetailID; // Rekap koli sub detail RowID
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                if ((DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridRekapKoli.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        _headerID = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        Expedisi.frmRekapKoliHeaderUpdate ifrmChildHeader = new Expedisi.frmRekapKoliHeaderUpdate(this, _headerID);
                        ifrmChildHeader.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildHeader);
                        ifrmChildHeader.Show();
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridRekapKoliDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        string _kodeToko = dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                        _headerID = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        _detailID = (Guid)dataGridRekapKoliDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Expedisi.frmRekapKoliDetailUpdate ifrmChildDetail = new Expedisi.frmRekapKoliDetailUpdate(this, _detailID, _headerID, _kodeToko);
                        ifrmChildDetail.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildDetail);
                        ifrmChildDetail.Show();
                        break;
                    case enumSelectedGrid.SubDetailSelected:
                        if (dataGridRekapKoliSubDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        _detailID = (Guid)dataGridRekapKoliDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        _subDetailID = (Guid)dataGridRekapKoliSubDetail.SelectedCells[0].OwningRow.Cells["SubDetailRowID"].Value;
                        Expedisi.frmRekapKoliSubDetailUpdate ifrmChildSubDetail = new Expedisi.frmRekapKoliSubDetailUpdate(this, _subDetailID, _detailID);
                        ifrmChildSubDetail.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChildSubDetail);
                        ifrmChildSubDetail.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            Guid _headerRowID, _detailRowID, _subDetailRowID;
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value;
                if ((DateTime)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["TglSuratJalan"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridRekapKoli.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        if (MessageBox.Show("Hapus record header ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                _headerRowID = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerRowID));
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_DELETE"));
                                    db.Commands[1].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerRowID));
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoli_DELETE"));
                                    db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerRowID));

                                    db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.Commands[1].ExecuteNonQuery();
                                    db.Commands[2].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataRekapKoli();
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
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridRekapKoliDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        if (MessageBox.Show("Hapus record detail ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                _detailRowID = (Guid)dataGridRekapKoliDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@detailID", SqlDbType.UniqueIdentifier, _detailRowID));
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_DELETE"));
                                    db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _detailRowID));

                                    db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.Commands[1].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }

                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataRekapKoliDetail();
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
                        break;
                    case enumSelectedGrid.SubDetailSelected:
                        if (dataGridRekapKoliSubDetail.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        /* Minta pwd mngr */
                        //if ()
                        //{}
                        if (MessageBox.Show("Hapus record sub detail ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                _subDetailRowID = (Guid)dataGridRekapKoliSubDetail.SelectedCells[0].OwningRow.Cells["SubDetailRowID"].Value;
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_RekapKoliSubDetail_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _subDetailRowID));
                                    db.BeginTransaction();
                                    db.Commands[0].ExecuteNonQuery();
                                    db.CommitTransaction();
                                }
                                MessageBox.Show("Record telah dihapus");
                                this.RefreshDataRekapKoliSubDetail();
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
                        break;
                }
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

        private void frmRekapKoliBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!SecurityManager.IsAuditor())
                {
                    if (dataGridRekapKoli.SelectedCells.Count == 0 && dataGridRekapKoliDetail.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    if (dataGridRekapKoli.SelectedCells.Count > 0 && dataGridRekapKoliDetail.SelectedCells.Count > 0)
                    {
                        Guid rowIDRekapKoli = (Guid)dataGridRekapKoli.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataTable dt = new DataTable();
                            using (Database db = new Database())
                            {

                                db.Commands.Add(db.CreateCommand("rsp_CetakSuratJalan"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIDRekapKoli));
                                dt = db.Commands[0].ExecuteDataTable();

                            }
                            if (dt.Rows.Count > 0)
                            {
                                //DisplayReport(dt);
                                PrintRawSuratJalan(dt);
                            }
                            else
                            {
                                MessageBox.Show("Data tidak ada");
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
                    //MessageBox.Show("Input password user");
                }
            }
        }

        private void DisplayReport(DataTable dt)
        {
            //construct parameter            
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Expedisi.rptRekapKoliSuratJalan.rdlc", rptParams, dt, "dsRekapKoli_Data");
            ifrmReport.Show();
        }

        private void PrintRawSuratJalan(DataTable dt)
        {
            BuildString suratJalan = new BuildString();
            int jumlahkoli = 0;

            #region Header

            string nosj = dt.Rows[0]["NoSuratJalan"].ToString();
            string namatoko = dt.Rows[0]["NamaToko"].ToString();
            string alamat = dt.Rows[0]["Alamat"].ToString();
            string tmp = string.Empty;

            if (alamat.Length > 28)
            {
                tmp = alamat.Substring(0, 28);
            }
            else
            {
                tmp = alamat + " ";
            }

            int pos = tmp.LastIndexOf(' ');
            string alamat1 = tmp.Substring(0,pos);
            string alamat3 = dt.Rows[0]["Alamat3"].ToString();
            string alamat2 = alamat.Substring(pos).Trim() + alamat3;
            string kota = dt.Rows[0]["Kota"].ToString();
            string kodeexpedisi = dt.Rows[0]["KodeExp1"].ToString(); 

            string[] namaexpedisi = new string[4];
            namaexpedisi[1] = dt.Rows[0]["NamaExpedisi1"].ToString();
            namaexpedisi[2] = dt.Rows[0]["NamaExpedisi2"].ToString();
            namaexpedisi[3] = dt.Rows[0]["NamaExpedisi3"].ToString();

            string idwil = dt.Rows[0]["WilID"].ToString();
            string tlp = dt.Rows[0]["Telp"].ToString();
            DateTime tglsuratjalan = DateTime.Parse(dt.Rows[0]["TglSuratJalan"].ToString());
            

            suratJalan.Initialize();
            suratJalan.Append((char)27 + "@" + (char)27 + "C" + (char)33 + (char)27 + "M");
            suratJalan.Append(Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1));
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, suratJalan.PadCenter(80, "SURAT JALAN"));
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "NO.         : " + nosj.PadRight(14) + suratJalan.SPACE(20) + "KEPADA YTH :");
            suratJalan.PROW(true, 1, "KENDARAAN   : .............." + suratJalan.SPACE(20) + namatoko);
            suratJalan.PROW(true, 1, "NO. POLISI  : .............."+ suratJalan.SPACE(20) + alamat1);

            if (kodeexpedisi == "SAS")
            {
                //kodeexpedisi = suratJalan.SPACE(3);
                suratJalan.PROW(true, 1, "EXPEDISI    : " + kodeexpedisi.PadRight(34) + (string.IsNullOrEmpty(alamat2) == true ? kota : alamat2));
                if(!string.IsNullOrEmpty(alamat2))
                {
                    suratJalan.PROW(true, 1, "TANGGAL     : "+ tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20)+ kota);
                    suratJalan.PROW(true, 1, suratJalan.SPACE(48) + "WIL : " + idwil + (string.IsNullOrEmpty(tlp) == true ? tlp : ",TELP : " + tlp));
                }
                else
                {
                    suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20) + "WIL : "+ idwil + (string.IsNullOrEmpty(tlp) == true ? tlp : ",TELP : " + tlp));
                }
            }
            else
            {
                suratJalan.PROW(true, 1, "EXPEDISI    : " + namaexpedisi[1].PadRight(34) + (string.IsNullOrEmpty(alamat2) == false ? alamat2 : kota));
	            if(!string.IsNullOrEmpty(namaexpedisi[2]) && !string.IsNullOrEmpty(namaexpedisi[3]))
                {
                    //suratJalan.PROW(true, 1, suratJalan.SPACE(14) + namaexpedisi[2].PadRight(34) + (string.IsNullOrEmpty(alamat2) == false ? kota : "WIL : " + idwil) + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
                    //suratJalan.PROW(true, 1, suratJalan.SPACE(14) + namaexpedisi[3].PadRight(34) + (string.IsNullOrEmpty(alamat2) == false ? "WIL : " + idwil : "") + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
	                suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14));
                }
                else if(!string.IsNullOrEmpty(namaexpedisi[2]) && string.IsNullOrEmpty(namaexpedisi[3]))
	            {   
                   //suratJalan.PROW(true, 1, suratJalan.SPACE(14) + namaexpedisi[2].PadRight(34) + (string.IsNullOrEmpty(alamat2) == false ? kota : "WIL : " + idwil) + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
	               suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20) + (string.IsNullOrEmpty(alamat2) == false ? "WIL : " + idwil : "") + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
	            }
                else if (string.IsNullOrEmpty(namaexpedisi[2]) && string.IsNullOrEmpty(namaexpedisi[3]))
                {
	                suratJalan.PROW(true, 1, "TANGGAL     : " + tglsuratjalan.ToString("dd-MMM-yyyy").PadRight(14) + suratJalan.SPACE(20) + (string.IsNullOrEmpty(alamat2) == false ? kota : "WIL : " + idwil) + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
	                if(!string.IsNullOrEmpty(alamat2))
                    {
	                  suratJalan.PROW(true, 1, suratJalan.SPACE(58) + "WIL : " + idwil + (string.IsNullOrEmpty(tlp) == true ? tlp : ", TELP : "+ tlp));
                    }
	            }
            }
            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(88));
            suratJalan.PROW(true, 1, "  NO.DO  NO.NOTA    SALES       URAIAN    JUMLAH  SATUAN           KETERANGAN           ");
            suratJalan.PROW(true, 1, suratJalan.Replicate(".", 88));

            #endregion

            #region Detail

            string nonota = string.Empty;
            string nodo = string.Empty;
            string sales = string.Empty;
            string lastNoNota = string.Empty;
            string uraian = string.Empty;
            string ket = string.Empty;
            string satuan = string.Empty;
            int jumlah = 0;

            foreach (DataRow dr in dt.Rows)
            {
                nonota = dr["NoNota"].ToString();
                nodo = dr["NoDO"].ToString();
                sales = dr["Sales"].ToString();
                uraian = dr["Uraian"].ToString();
                ket = dr["Keterangan"].ToString();
                satuan = dr["Satuan"].ToString();
                jumlah = int.Parse(dr["Jumlah"].ToString());

                jumlahkoli += jumlah;

                if (lastNoNota.Equals(nonota))
                {
                    sales = suratJalan.SPACE(11);
                    nodo = suratJalan.SPACE(7);
                    nonota = suratJalan.SPACE(7);
                }
                else
                {
                    lastNoNota = nonota;
                }

                suratJalan.PROW(true, 1, " " + nodo +
                    " " + nonota +
                    " " + sales +
	                " " + uraian.PadRight(12) +
	                " " + jumlah.ToString("#,###;(#,###);#").PadLeft(7) +
	                " " + suratJalan.PadCenter(6, satuan) +
	                " " + ket.PadRight(30));
            }

            #endregion

            #region Footer
            string namacabang = dt.Rows[0]["NamaCabang"].ToString();
            string alamatexpedisi = dt.Rows[0]["AlamatExpedisi"].ToString();
            string tlpexpedisi = dt.Rows[0]["TlpExpedisi"].ToString();

            suratJalan.PROW(true, 1, suratJalan.PrintEqualSymbol(88));

            if (dt.Rows[0]["KodeExp1"].ToString() != "SAS")
            {
                //suratJalan.PROW(true, 1, "KEMBALI KE SAS " + namacabang +" ***"+ suratJalan.SPACE(4) + jumlahkoli.ToString("#,##0").PadLeft(6));
                suratJalan.PROW(true, 1, suratJalan.SPACE(41) + jumlahkoli.ToString("#,##0").PadLeft(6) + suratJalan.SPACE(11) + (char)27 + (char)33 + (char)24 + "FRANGKO" + (char)27 + (char)33 + (char)1);
            }
            else
            {
                suratJalan.PROW(true, 1, suratJalan.SPACE(41) + jumlahkoli.ToString("#,##0").PadLeft(6) + suratJalan.SPACE(11) + (char)27 + (char)33 + (char)24 + "FRANGKO" + (char)27 + (char)33 + (char)1);
            }
            
            suratJalan.PROW(true, 1, "");

            if (dt.Rows[0]["KodeExp1"].ToString() != "SAS")
            {
                suratJalan.PROW(true, 1, "ALAMAT Expedisi : " + alamatexpedisi + " " + tlpexpedisi);
                suratJalan.PROW(true, 1, "");
            }
            
            suratJalan.PROW(true, 1, "           PENERIMA                     PENGIRIMAN                    SOPIR");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "");
            suratJalan.PROW(true, 1, "         (..........)                  (...........)               (............)");
            suratJalan.PROW(true, 1,  SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyyy") + " Jam " + DateTime.Now.ToShortTimeString());
            suratJalan.Eject();

            #endregion

            suratJalan.SendToPrinter("RekapKoli.txt");
        }

        private void dataGridRekapKoliSubDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData==Keys.Tab)
            //{
            //    dataGridRekapKoli.Focus();
            //    selectedGrid = enumSelectedGrid.HeaderSelected;
            //}
        }

        private void dataGridRekapKoli_Validated(object sender, EventArgs e)
        {
            if (dataGridRekapKoli.Focused==true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
        }

        private void dataGridRekapKoliDetail_Validated(object sender, EventArgs e)
        {
            if (dataGridRekapKoliDetail.Focused == true)
            {
                selectedGrid = enumSelectedGrid.DetailSelected;
                _prefGrid = 2;
            }
        }

        private void dataGridRekapKoliSubDetail_Validated(object sender, EventArgs e)
        {
           
        }

       

        private void dataGridRekapKoliSubDetail_Leave(object sender, EventArgs e)
        {
            if (_prefGrid==2 && selectedGrid != enumSelectedGrid.HeaderSelected)
            {
                dataGridRekapKoli.Focus();
                selectedGrid = enumSelectedGrid.HeaderSelected;
            }
        }

        private void dataGridRekapKoliSubDetail_Validating(object sender, CancelEventArgs e)
        {
            if (dataGridRekapKoliSubDetail.Focused == true)
            {
                selectedGrid = enumSelectedGrid.SubDetailSelected;
                _prefGrid = 3;
            }
        }

        private void dataGridRekapKoli_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridRekapKoli.SelectedCells.Count > 0)
            {
                    RefreshDataRekapKoliDetail();
            }
            else
            {
                dataGridRekapKoliDetail.DataSource = null;
            }
        }

        private void dataGridRekapKoliDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridRekapKoliDetail.SelectedCells.Count > 0)
            {
                    RefreshDataRekapKoliSubDetail();
            }
            else
            {
                dataGridRekapKoliSubDetail.DataSource = null;
            }
        }
        //private void dataGridRekapKoliSubDetail_Leave(object sender, EventArgs e)
        //{
        //    dataGridRekapKoli.Focus();
        //    selectedGrid = enumSelectedGrid.HeaderSelected;
        
        //}
    }
}
