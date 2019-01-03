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
using ISA.Toko.Class;
using ISA.Toko;

namespace ISA.Toko.Pembelian
{
    public partial class frmDOBeliBrowser : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        string _format;
        string _headerRec;
        bool _acak;
        DataTable dtHeader, dtDetail, dtGetHeader;
        
        public frmDOBeliBrowser()
        {
            InitializeComponent();
        }  

        private void frmDOBeliBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Order Pembelian";
            this.Text = "Pembelian";
            lblNamaBarang.Text = "";
            _acak = true;
            DateFromExpedisi.Enabled = false;
            DateToExpedisi.Enabled = false;
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglRQ.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglRQ.ToDate = DateTime.Now;
            rgbTglRQ.Focus();    
            
            this.cmdADDfromBO.Enabled = false;
            
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataOrderPembelian();
        }

        private void rgbTglRQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataOrderPembelian()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglRQ.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglRQ.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    dataGridDetail.DataSource = null;
                    lblNamaBarang.Text = "";
                }
                else
                {
                    RefreshDataOrderPembelianDetail();
                    dataGridHeader.Focus();
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

        public void RefreshDataOrderPembelianDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            //DateTime tgldo11 = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglDO11"].Value;
            string tgldo11 = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString();
            _headerRec = dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRecID"].Value.ToString();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    db.Commands[0].Parameters.Add(new Parameter("@tgldo11", SqlDbType.DateTime, Convert.ToDateTime(tgldo11)));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dtDetail;

                if (dtDetail.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    this.cmdADDfromBO.Enabled = true;
                }
                else
                {
                    lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                    this.cmdADDfromBO.Enabled = false;
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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    Pembelian.frmDOBeliUpdate ifrmChild = new Pembelian.frmDOBeliUpdate(this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                case enumSelectedGrid.DetailSelected:
                    if (!CekAddEditDel())
                    {
                        return;
                    } 
                        //GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
                        //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value <= GlobalVar.LastClosingDate)
                        //{
                        //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        //}

                    opendetail();
                    
                    break;
            }
        }

        public void opendetail()
        {
            if (dataGridDetail.RowCount <= 17)
            {
                try
                {
                    Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                    Pembelian.frmDOBeliDetailUpdate ifrmChild2 = new Pembelian.frmDOBeliDetailUpdate(this, headerID, frmDOBeliDetailUpdate.enumFormMode.New);
                    ifrmChild2.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild2);
                    ifrmChild2.Show();
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }

            }
            else { MessageBox.Show("Order Pembelian Detail mencapai batas maksimum"); }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (!CekAddEditDel())
            {
                return;
            }
            Guid rowID;
            bool Closing_ = false;
            Closing_ = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value < GlobalVar.LastClosingDate? true : false;
            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;

           
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                    Pembelian.frmDOBeliUpdate ifrmChild = new Pembelian.frmDOBeliUpdate(this, rowID,Closing_);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                case enumSelectedGrid.DetailSelected:
                    if (dataGridDetail.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    //if (Closing_)
                    //{
                    //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    //}
                    try
                    {
                       
                        rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        Pembelian.frmDOBeliDetailUpdate ifrmChild2 = new Pembelian.frmDOBeliDetailUpdate(this, rowID, frmDOBeliDetailUpdate.enumFormMode.Update);
                        ifrmChild2.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.Show();
                        
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (!Del())
            {
                return;
            }
            Guid rowID;
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
                            if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }

                            this.Cursor = Cursors.WaitCursor;
                            rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands.Add(db.CreateCommand("usp_OrderPembelian_DELETE"));
                                db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                                db.BeginTransaction();
                                db.Commands[0].ExecuteNonQuery();
                                db.Commands[1].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                            MessageBox.Show("Record telah dihapus");
                            RefreshDataOrderPembelian();
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
                    if (dataGridDetail.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { 
                        try
                        {
                            //GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
                            //if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value <= GlobalVar.LastClosingDate)
                            //{
                            //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            //}
                            this.Cursor = Cursors.WaitCursor;
                            rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                            using (Database db = new Database())
                            {
                                db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                                db.Commands[0].ExecuteNonQuery();
                            } 
                            MessageBox.Show("Record telah dihapus");

                            //Refresh Data
                            int i = 0;
                            int n = 0;
                            i = dataGridDetail.SelectedCells[0].RowIndex;
                            n = dataGridDetail.SelectedCells[0].ColumnIndex;
                            DataRowView dv = (DataRowView)dataGridDetail.SelectedCells[0].OwningRow.DataBoundItem;

                            DataRow dr = dv.Row;

                            dr.Delete();
                            dtDetail.AcceptChanges();
                            dataGridDetail.Focus();
                            dataGridDetail.RefreshEdit();
                            if (dataGridDetail.RowCount > 0)
                            {
                                if (i == 0)
                                {
                                    dataGridDetail.CurrentCell = dataGridDetail.Rows[0].Cells[n];
                                    //dataGridDetail.RefreshEdit();
                                }
                                else
                                {
                                    dataGridDetail.CurrentCell = dataGridDetail.Rows[i - 1].Cells[n];
                                    //dataGridDetail.RefreshEdit();
                                }

                            }


                           // RefreshDataOrderPembelianDetail();
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

        private bool CekAddEditDel()
        {
            bool cek = true;

            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                cek = false;
                goto SelesaiCek;
            }
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (dataGridDetail.RowCount > 0)
                {
                    MessageBox.Show("Order Pembelian Detail Sudah Terisi");
                    cek = false;
                    goto SelesaiCek;
                }
            }
            else
            {
                if (Tools.cekDataOnDatabase("NotaPembelian", "NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()))
                {
                    MessageBox.Show("Tanggal terima barang sudah terisi");
                    cek = false;
                    goto SelesaiCek; 
                }

                if (Convert.ToDateTime(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()) != GlobalVar.DateOfServer)
                {
                    MessageBox.Show("Date Time server Tidak Sama dengan Tgl. Order");
                    cek = false;
                    goto SelesaiCek;
                }
            }

            /*if (syncFlag == 1)
            {
                Show password manager
                cek = false; // is pwd false
                goto SelesaiCek;
            }*/

            SelesaiCek:
            return cek;
        }

        private bool Del()
        {
            bool cek = true;

            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                cek = false;
                goto SelesaiCek;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                cek = false;
                goto SelesaiCek;
            }
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (dataGridDetail.RowCount > 0)
                {
                    MessageBox.Show("Order Pembelian Detail Sudah Terisi");
                    cek = false;
                    goto SelesaiCek;
                }
            }
            else
            {
                //if (Tools.cekDataOnDatabase("NotaPembelian", "NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()))
                //{
                //    MessageBox.Show("Tanggal terima barang sudah terisi");
                //    cek = false;
                //    goto SelesaiCek;
                //} matiin sementara

                if (Convert.ToDateTime(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()) != GlobalVar.DateOfServer)
                {
                    MessageBox.Show("Date Time server Tidak Sama dengan Tgl. Order");
                    cek = false;
                    goto SelesaiCek;
                }
            }

            /*if (syncFlag == 1)
            {
                Show password manager
                cek = false; // is pwd false
                goto SelesaiCek;
            }*/

            SelesaiCek:
            return cek;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F3:
                    if (dataGridHeader.SelectedCells.Count == 0)
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                        return;
                    }
                    LaporanOrderHarian();
                    break;
                case Keys.F4:
                    if (!SecurityManager.IsAuditor())
                    {
                        if (dataGridHeader.SelectedCells.Count == 0)
                        {
                            MessageBox.Show(Messages.Error.RowNotSelected);
                            return;
                        }
                        AmbilDataDariBO();
                    }
                    break;
                case Keys.F5:
                    if (!SecurityManager.IsAuditor())
                    {
                        UploadPurchasingOrder();
                    }
                    break;
                case Keys.Tab:
                    dataGridDetail.Focus();
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    break;
            }
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    dataGridHeader.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;
                case Keys.L:
                    //CTRL + Shift + L
                    if (e.Shift && e.Control)
                    {
                        GridList_DOBeliDetail();
                    }
                    break;
            }
        }

        private void GridList_DOBeliDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dtDetail.Rows.Count > 0)
                {
                    List<ReportParameter> rptParams = new List<ReportParameter>();
                    rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
                    rptParams.Add(new ReportParameter("Gudang", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NoACC", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString()));
                    rptParams.Add(new ReportParameter("Supplier", dataGridHeader.SelectedCells[0].OwningRow.Cells["Supplier"].Value.ToString()));
                    rptParams.Add(new ReportParameter("NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()));
                    rptParams.Add(new ReportParameter("TglRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString()));
                    rptParams.Add(new ReportParameter("M", dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderSyncFlag"].Value.ToString()));
                    rptParams.Add(new ReportParameter("RpEstJual", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHrgJual"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("Item", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));
                    rptParams.Add(new ReportParameter("RpEstHPP", dataGridHeader.SelectedCells[0].OwningRow.Cells["EstHPP"].Value.ToString()));
                    //rptParams.Add(new ReportParameter("RpEstTerima", dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value));

                    frmReportViewer ifrmReport = new frmReportViewer("Pembelian.gridDetailDOBeli.rdlc", rptParams, dtDetail, "dsOrderPembelian_Data");
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
        
        /* Laporan order harian */

        private void LaporanOrderHarian()
        {
            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_OrderPembelianHarian"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
                    return;
                }
                else
                {
                    DisplayReport(dt);
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
        
        private void DisplayReport(DataTable dt)
        {
            DateTime tgl = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value;
            //construct parameter
            string periode;
            periode = tgl.ToShortDateString();
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("Periode", periode));
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptOrderHarian.rdlc", rptParams, dt, "dsOrderPembelian_Data");
            ifrmReport.Show();

        } 


        /* Proses ambil data BO untuk pembuatan DO Pembelian */

        private void AmbilDataDariBO()
        {
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                return;
            }
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            DateTime tglRQ = DateTime.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString());
            string noRQ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString();
            Pembelian.frmAmbilDODariBOFilter ifrmChild = new Pembelian.frmAmbilDODariBOFilter(this, headerID, tglRQ, noRQ);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }


        /* Proses upload data Purchasing Order ke 11 */

        private void UploadPurchasingOrder()
        {

            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["NoACC"].Value.ToString() == "")
            {
                MessageBox.Show("Belum di ACC");
                return;
            }
            if (dataGridDetail.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada detail");
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                return;
            }
            Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            string noRQ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString();
            if (MessageBox.Show("Upload No.RQ " + noRQ + "?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try                
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPembelianDetail_UPLOAD_11"));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    Upload(dt);
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

        private void Upload(DataTable dt)
        {
            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("TglRequest", "tgl_rq", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoRequest", "no_rq", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("NamaStok", "nama_stok", Foxpro.enFoxproTypes.Char, 73));
            fields.Add(new Foxpro.DataStruct("BarangID", "id_brg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyRequest", "j_rq", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("C2", "c2", Foxpro.enFoxproTypes.Char, 4));
            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("QtyBO", "j_bo", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyTambahan", "j_plus", Foxpro.enFoxproTypes.Numeric, 5));
            fields.Add(new Foxpro.DataStruct("QtyAkhir", "j_akhir", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyJual", "j_jual", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyMinimum", "Stok_min", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("QtyMaximum", "Stok_max", Foxpro.enFoxproTypes.Numeric, 7));
            fields.Add(new Foxpro.DataStruct("Catatan", "catatan", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("Keterangan", "Keterangan", Foxpro.enFoxproTypes.Char, 30));
            Foxpro.WriteFile(GlobalVar.DbfUpload, "Po_tmp", fields, dt);
            ZipFile("Po_tmp");
            MessageBox.Show("File "+GlobalVar.DbfUpload+"\\dbfmatch.zip","Succes");
        }


        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _estHPP = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["EstHPP"].Value.ToString());
            double _estHrgJual = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["EstHrgJual"].Value.ToString());
            dataGridHeader.Rows[e.RowIndex].Cells["rpTotalH"].Style.Format = "#,##0";
            dataGridHeader.Rows[e.RowIndex].Cells["EstHPP"].Style.Format = "#,##0";
            dataGridHeader.Rows[e.RowIndex].Cells["EstHrgJual"].Style.Format = "#,##0";
            
            //dataGridHeader.Rows[e.RowIndex].Cells["EstHPPAck"].Value = Tools.GetAntiNumeric(_estHPP.ToString("#,##0"));
            //dataGridHeader.Rows[e.RowIndex].Cells["EstHrgJualAck"].Value = Tools.GetAntiNumeric(_estHrgJual.ToString("#,##0")); 
            dataGridHeader.Rows[e.RowIndex].Cells["EstHPPAck"].Value = _estHPP.ToString("#,##0");
            dataGridHeader.Rows[e.RowIndex].Cells["EstHrgJualAck"].Value = _estHrgJual.ToString("#,##0"); 



            dataGridHeader.Rows[e.RowIndex].Cells["EstHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["EstHrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _hppSolo = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HPPSolo"].Value.ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HPPSolo"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["rpTotal"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["harga"].Style.Format = "#,##0";

            dataGridDetail.Rows[e.RowIndex].Cells["HPPSoloAck"].Value = _hppSolo.ToString("#,##0");

            dataGridDetail.Rows[e.RowIndex].Cells["HPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dataGridDetail.Rows[e.RowIndex].Cells["JmlHPPDO"].Style.Format = _format;
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["EstHPP"].Visible = !_acak;
            dataGridHeader.Columns["EstHrgJual"].Visible = !_acak;
            dataGridDetail.Columns["HPPSolo"].Visible = !_acak;
            //dataGridDetail.Columns["JmlHPPDO"].DefaultCellStyle.Format = _format;

            dataGridHeader.Columns["EstHPPAck"].Visible = _acak;
            dataGridHeader.Columns["EstHrgJualAck"].Visible = _acak;
            dataGridDetail.Columns["HPPSoloAck"].Visible = _acak;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void ZipFile(string FileName1)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            

            string fileZipName = GlobalVar.DbfUpload + "\\dbfmatch.zip";
            files.Add(fileName1);
           

            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1))
            {
                File.Delete(fileName1);
               
            }
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count != 0)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKrmFROM"].Value.ToString() == "")
                    { DateFromExpedisi.Text = ""; }
                else
                    { DateFromExpedisi.DateValue = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKrmFROM"].Value; }

                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKrmTO"].Value.ToString() == "")
                    { DateToExpedisi.Text = ""; }
                else
                    { DateToExpedisi.DateValue = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKrmTO"].Value; }
               
                RefreshDataOrderPembelianDetail();
            }

        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count != 0)
            {
                lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblNamaBarang.Text = "";
            }
        }

        private void cmdADDfromBO_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            //AmbilDataDariBO2nd();
        }

        private void AmbilDataDariBO2nd()
        {
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
                return;
            }
            if (dataGridHeader.SelectedCells[0].OwningRow.Cells["Gudang"].Value.ToString() != GlobalVar.PerusahaanID)
            {
                MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                return;
            }
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            DateTime tglRQ = DateTime.Parse(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRequest"].Value.ToString());
            string noRQ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString();
            Pembelian.frmAmbilDODariBOFilter2nd ifrmChild = new Pembelian.frmAmbilDODariBOFilter2nd(this, headerID, _headerRec,tglRQ, noRQ);
            ifrmChild.ShowDialog();
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.Show();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Guid _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells[HeaderRowID.Name].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetDataDetailCetakPOSupp]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                DisplayReportPOSupplier(dt);
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        public void DisplayReportPOSupplier(DataTable dt)
        {
            try
            {
                //getdataheader();
                
                object sumObject;
                sumObject = dt.Compute("Sum(Total)", "");
                Double Total = Convert.ToDouble(sumObject);
                List<ReportParameter> rptParams = new List<ReportParameter>();
                rptParams.Add(new ReportParameter("NoRequest", dataGridHeader.SelectedCells[0].OwningRow.Cells[NoRequest.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("Pemasok", dataGridHeader.SelectedCells[0].OwningRow.Cells[Supplier.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("TglRequest", string.Format("{0:dd MMM yyyy}",(DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells[TglRequest.Name].Value)));
                rptParams.Add(new ReportParameter("Salesman", dataGridHeader.SelectedCells[0].OwningRow.Cells[NamaSales.Name].Value.ToString()));
                rptParams.Add(new ReportParameter("JumlahTotal", Total.ToString()));
                rptParams.Add(new ReportParameter("footer", string.Format("{0:dddd, MMMM d, yyyy HH:mm:ss}", DateTime.Now) + ", " + SecurityManager.UserName));
                rptParams.Add(new ReportParameter("NamaPerusahaan", GlobalVar.PerusahaanName.ToString()));
                rptParams.Add(new ReportParameter("AlamatPerusahaan", GlobalVar.PerusahaanAddress.ToString()));
                rptParams.Add(new ReportParameter("KotaPerusahaan", GlobalVar.PerusahaanKota.ToString()));
                rptParams.Add(new ReportParameter("TelpPerusahaan", GlobalVar.PerusahaanTelp.ToString()));
                
                frmReportViewer ifrmReport = new frmReportViewer("Pembelian.rptDOCetakPOSupplier2.rdlc", rptParams, dt, "dsOrderPembelian_CetakPOSup");
                //ifrmReport.Show();
                ifrmReport.Print();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void getdataheader()
        {
            try
            {
                String IDPemasok = dataGridHeader.SelectedCells[0].OwningRow.Cells[PemasokID.Name].Value.ToString();
                //Guid RowIDPemasok = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells[RowIDPmsk.Name].Value;
                //Guid RowIDBuyyer = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells[RowIDByyr.Name].Value;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetDataCetakPO]"));
                    db.Commands[0].Parameters.Add(new Parameter("@PemasokID", SqlDbType.VarChar, IDPemasok));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowIDSupplier", SqlDbType.UniqueIdentifier, RowIDPemasok));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowIDBuyyer", SqlDbType.UniqueIdentifier, RowIDBuyyer));
                    dtGetHeader = db.Commands[0].ExecuteDataTable();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void dataGridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
