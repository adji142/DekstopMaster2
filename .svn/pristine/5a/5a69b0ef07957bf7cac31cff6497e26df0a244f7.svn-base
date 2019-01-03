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

namespace ISA.Toko.ArusStock
{
    public partial class frmBarangKembaliKePenjualan : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        
    #region "Var & Procedure"
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        //for Header
        Guid _RowID;
        string _RecordID,_KodeSales;
        
        //for Detail
        Guid _RowIDD,_HeaderIDD;
        #region "Function"

        public void FillHeader()
        {
            _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["rowid"].Value;
            _RecordID = dataGridHeader.SelectedCells[0].OwningRow.Cells["recordid"].Value.ToString();
            _KodeSales = dataGridHeader.SelectedCells[0].OwningRow.Cells["kodesales"].Value.ToString();
        }

        public void FillDetail()
        {
            _HeaderIDD = _RowID;
            _RowIDD = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["rowidD"].Value;
        }

        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pengembalian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridHeader.DataSource = dt;

                }

                if (dataGridDetail.SelectedCells.Count > 0)
                {
                    RefreshDetail();
                }
                else
                {
                    dataGridDetail.DataSource = null;
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

        public void RefreshDetail()
        {
            try
            {

                _HeaderIDD = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["rowid"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PengembalianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridDetail.DataSource = dt;
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

            //construct parameter
          //  string periode;
            List<ReportParameter> rptParams = new List<ReportParameter>();
            
            //Add parameter
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("ArusStock.rptBuktiPengembalianPinjaman.rdlc", rptParams, dt, "dsPinjam_Data");
            ifrmReport.Show();

        }

        private void PrintOut()
        {
            try
            {
               _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["rowid"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtPD = new DataTable();
                    db.Commands.Add(db.CreateCommand("rsp_Pengembalian"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtPD = db.Commands[0].ExecuteDataTable();
                    dtPD.Dispose();
                    db.Dispose();

                    //DisplayReport(dtPD);
                    PrintRawBarangKembali(dtPD);

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

        private void PrintRawBarangKembali(DataTable dt)
        {
            BuildString barangKembali = new BuildString();

            string sales = dt.Rows[0]["Sales"].ToString().PadRight(23);
            string tglKembali = DateTime.Parse(dt.Rows[0]["TglKembaliPj"].ToString()).ToString("dd-MMM-yyyy");
            string noKembali = dt.Rows[0]["NoKembali"].ToString();
            string catatan = dt.Rows[0]["Catatan"].ToString();
            int No = 0;

            barangKembali.Initialize();
            barangKembali.PageLLine(33);
            barangKembali.FontCPI(12);
            barangKembali.Append(Convert.ToString((char)27) + Convert.ToString((char)33) + Convert.ToString((char)1));
            barangKembali.PROW(true, 1, barangKembali.PadCenter(88, "BUKTI PENGEMBALIAN PINJAMAN"));
            barangKembali.PROW(true, 1, "");
            barangKembali.PROW(true, 1, "Nama salesman   : " + sales);
            barangKembali.PROW(true, 1, "No.Pengembalian : " + noKembali + barangKembali.SPACE(28) + "Tgl.Pengembalian : " + tglKembali);
            barangKembali.PROW(true, 1, barangKembali.PrintEqualSymbol(88));
            barangKembali.PROW(true, 1, "No                                   Nama Barang                           No.Pinj   Qty");
            barangKembali.PROW(true, 1, barangKembali.PrintMinusSymbol(88));

            string namaStok = string.Empty;
            string noPinjam = string.Empty;
            int qtyKembali = 0;
            
            foreach (DataRow dr in dt.Rows)
            {
                No++;
                namaStok = dr["NamaStok"].ToString().PadRight(70);
                noPinjam = dr["NoPinjam"].ToString().PadRight(10);
                qtyKembali = int.Parse(dr["QtyKembali"].ToString());
                
                barangKembali.PROW(true, 1, No.ToString().PadLeft(2) + " " + namaStok + " " + noPinjam  + " " + qtyKembali.ToString().PadLeft(3));
            }
            barangKembali.PROW(true, 1, barangKembali.PrintEqualSymbol(88));
            barangKembali.PROW(true, 1, "Catatan : " + catatan);
            barangKembali.PROW(true, 1, "");
            barangKembali.PROW(true, 1, "");
            barangKembali.PROW(true, 1, "      Penjualan                Pengembali            Ka.Gudang              Gudang");
            barangKembali.Eject();

            barangKembali.SendToPrinter("BarangKembali.txt");
        }

        #endregion

    #endregion

        public frmBarangKembaliKePenjualan()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:
                    if (dataGridHeader.SelectedCells.Count > 0 ||dataGridHeader.SelectedCells.Count==0)
                    {
                        ArusStock.frmBarangKembaliKePenjualanUpdate ifrmChild = new ArusStock.frmBarangKembaliKePenjualanUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
                case enumSelectedGrid.DetailSelected:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value;
                            if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            if ((dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1") || (Convert.ToInt32(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0))
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }

                            ArusStock.frmBarangKembaliKePenjualanDetailUpdate ifrmChild = new ArusStock.frmBarangKembaliKePenjualanDetailUpdate(this, _RowID, _RecordID, _KodeSales);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }

                    break;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBarangKembaliKePenjualan_Load(object sender, EventArgs e)
        {
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            selectedGrid = enumSelectedGrid.HeaderSelected;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
            txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
            }
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                FillDetail();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
            case enumSelectedGrid.HeaderSelected:

            if(dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString()=="1")
                {
                if(!SecurityManager.AskPasswordManager())
                    {
                    return;
                    }
                }
                    int rc = 0;
                    rc = dataGridDetail.Rows.Count;


                    if (rc!=0)
                    {
                        MessageBox.Show("Hapus Detail Terlebih Dahulu!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        this.DialogResult=DialogResult.OK;
                        return;
                    }

                  if (dataGridHeader.SelectedCells.Count>0)
                  {

                  if((dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString()=="1")||(Convert.ToInt32(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString())>0))
                      {
                      if(!SecurityManager.AskPasswordManager())
                          {
                          return;
                          }
                      }


                      if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                      {
                          try
                          {
                              GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value;
                              if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value <= GlobalVar.LastClosingDate)
                              {
                                  throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                              }
                              this.Cursor = Cursors.WaitCursor;
                              using (Database db = new Database())
                              {
                                  DataTable dt = new DataTable();
                                  db.Commands.Add(db.CreateCommand("usp_Pengembalian_Delete"));
                                  db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                  dt = db.Commands[0].ExecuteDataTable();
                              }
                              this.RefreshHeader();
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
                  


            break;
            case enumSelectedGrid.DetailSelected:
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PengembalianDetail_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowIDD));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                        this.RefreshDetail();
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
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }

            break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value;
                if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliPj"].Value <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                switch (selectedGrid)
                {
                    case enumSelectedGrid.HeaderSelected:
                        if (dataGridHeader.SelectedCells.Count > 0)
                        {
                            if ((dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "1") || (Convert.ToInt32(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString()) > 0))
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }

                            ArusStock.frmBarangKembaliKePenjualanUpdate ifrmChild = new ArusStock.frmBarangKembaliKePenjualanUpdate(this, _RowID);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        break;
                    case enumSelectedGrid.DetailSelected:
                        if (dataGridDetail.SelectedCells.Count > 0)
                        {
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

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
           if (dataGridHeader.SelectedCells.Count>0)
           {
               if (e.KeyCode==Keys.F3)
               {
                   if (!SecurityManager.IsAuditor())
                   {
                       PrintOut();
                       RefreshHeader();
                   }
               }
               if (e.KeyCode == Keys.Delete)
               {
                   cmdDelete.PerformClick();
               }
           }
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDetail();
            }
        }
    }
}
