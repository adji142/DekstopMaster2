﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using Microsoft.Reporting.WinForms;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmPiutangKaryawan : ISA.Toko.BaseForm
    {
        string _nip,_nama,_tanggal,_reff,_jenisUtang,_nomor,_uraian,_debet,_kredit;

        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtDetail = new DataTable();
        DataTable dtHeader = new DataTable();
        public frmPiutangKaryawan()
        {
            InitializeComponent();
        }

        private void frmPiutangKaryawan_Load(object sender, EventArgs e)
        {
            RefreshPegawai();
        }

        public void RefreshPegawai()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StaffPiutang_LIST"));                   
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    gridKaryawan.DataSource = dtHeader;

                    
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

        public void RefreshPegawai(String NIP)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_StaffPiutang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, NIP));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            gridKaryawan.RefreshDataRow(dtRefresh.Rows[0], "NIP", NIP);
        }

        public void FindRowPegawsai(string column, string value)
        {
            gridKaryawan.FindRow(column, value);
        }

        public void RefreshPiutang()
        {
            EnabledBehind();
            try
            {
                string nip = gridKaryawan.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();
                dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, nip));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dtDetail.DefaultView.Sort = "TglPinjam Desc, RecordID Desc";
                    gridPiutang.DataSource = dtDetail.DefaultView;
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

        public void RefreshPiutang(Guid rowID)
        {
            EnabledBehind();
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Commands.Add(db.CreateCommand("usp_PinjamanPegawai_LIST_ByRowID"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }

            gridPiutang.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
        }

        public void FindRowPiutang(string column, string value)
        {
            gridPiutang.FindRow(column, value);
        }

        private void gridKaryawan_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKaryawan.SelectedCells.Count > 0)
            {
                if (gridKaryawan.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshPiutang();
                }
                prevGrid1Row = gridKaryawan.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                dtDetail.Clear();
                gridPiutang.DataSource = dtDetail.DefaultView;
            }
        }

        private void DisabledBehind()
        {
            gridKaryawan.Enabled = false;
            gridPiutang.Enabled = false;
            cmdPrint.Enabled = false;
            cmdKartuPiutang.Enabled = false;
            cmdAdd.Enabled = false;
            cmdEdit.Enabled = false;
            cmdDelete.Enabled = false;
            cmdClose.Enabled = false;
        }


        private void EnabledBehind()
        {
            gridKaryawan.Enabled = true;
            gridPiutang.Enabled = true;
            cmdPrint.Enabled = true;
            cmdKartuPiutang.Enabled = true;
            cmdAdd.Enabled = true;
            cmdEdit.Enabled = true;
            cmdDelete.Enabled = true;
            cmdClose.Enabled = true;
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
                        
            label2.Text = "TAMBAH DATA TRANSAKSI";
            
            


            switch (selectedGrid)
            {

              case enumSelectedGrid.HeaderSelected:


                    Kasir.frmPiutangKaryawanHeader_Update ifrmChild1 = new Kasir.frmPiutangKaryawanHeader_Update(this);
                    Program.MainForm.RegisterChild(ifrmChild1);
                    ifrmChild1.ShowDialog();
              break;
              case enumSelectedGrid.DetailSelected:

                    if (gridKaryawan.SelectedCells.Count > 0)
                    {
                        _nama = gridKaryawan.SelectedCells[0].OwningRow.Cells["namapegawai"].Value.ToString();
                        txtTanggal.Text = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();

                        formMode = enumFormMode.New;
                        cbJenisUtang.Text = string.Empty;
                        cbRef.Text = string.Empty;
                        txtDebet.Text = "0";
                        txtKredit.Text = "0";
                        txtNomor.Text = string.Empty;
                        txtUraian.Text = string.Empty;
                        cbRef.Enabled = true;
                        DisabledBehind();
                        groupTambahTransaksi.Top = 100;
                        groupTambahTransaksi.Left = 200;
                        groupTambahTransaksi.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("BELUM ADA DATA");
                    }
                    
                   
                    break;
            }


        }

        

        

        private void cmdNo_Click(object sender, EventArgs e)
        {
            groupTambahTransaksi.Visible = false;
            EnabledBehind();
           
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {            
            string nip = gridKaryawan.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();            
            string JU = string.Empty;           
            string reff = cbRef.Text;
            string cmbJU = cbJenisUtang.Text;

            switch (cmbJU)
            {
            case "PKM":
                    JU = "1";
            	break;
            case "PKN":
                JU = "2";
                break;
            case "PKI":
                JU = "3";
                break;
            case "PKB":
                JU = "4";
                break;
            }
            


            if (formMode == enumFormMode.New)
            {
                switch (reff)
                {
                    case "BKK":

                        Kasir.frmBKKUpdate ifrmChild1 = new Kasir.frmBKKUpdate(this, true, _nama, nip, JU);
                        Program.MainForm.RegisterChild(ifrmChild1);
                        ifrmChild1.ShowDialog();

                        break;
                    case "BKM":
                        Kasir.frmBKMUpdate ifrmChild2 = new Kasir.frmBKMUpdate(this, true, _nama, nip, JU);
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.ShowDialog();
                        break;

                    case "TRK":
                        Kasir.frmBuktiTransferKeluarUpdate ifrmChild3 = new Kasir.frmBuktiTransferKeluarUpdate(this,_nama,true,nip,JU,reff);
                        Program.MainForm.RegisterChild(ifrmChild3);
                        ifrmChild3.ShowDialog();
                        break;
                    case "TRM":
                        Kasir.frmBuktiTransferKeluarUpdate ifrmChild4 = new Kasir.frmBuktiTransferKeluarUpdate(this, _nama, true, nip, JU, reff);
                        Program.MainForm.RegisterChild(ifrmChild4);
                        ifrmChild4.ShowDialog();
                        break;
                }
            }
            else if (formMode == enumFormMode.Update)
            {
                string recordID = gridPiutang.SelectedCells[0].OwningRow.Cells["recordID"].Value.ToString();
                Guid rowID = (Guid)gridPiutang.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DateTime tanggal = (DateTime)gridPiutang.SelectedCells[0].OwningRow.Cells["tanggal"].Value;

                switch (reff)
                {
                    case "BKK":

                        Kasir.frmBKKUpdate ifrmChild1 = new Kasir.frmBKKUpdate(this,rowID,recordID,_nama,txtNomor.Text,tanggal,string.Empty,JU,true,nip);
                        Program.MainForm.RegisterChild(ifrmChild1);
                        ifrmChild1.ShowDialog();
                        break;
                    case "BKM":
                        Kasir.frmBKMUpdate ifrmChild2 = new Kasir.frmBKMUpdate(this, rowID, recordID, _nama, txtNomor.Text, tanggal, string.Empty,JU,true,nip);
                        Program.MainForm.RegisterChild(ifrmChild2);
                        ifrmChild2.ShowDialog();
                        break;
                    case "TRK":
                        Kasir.frmBuktiTransferKeluarUpdate ifrmChild3 = new Kasir.frmBuktiTransferKeluarUpdate(this,rowID,true,JU,reff,txtNomor.Text,nip);
                        Program.MainForm.RegisterChild(ifrmChild3);
                        ifrmChild3.ShowDialog();
                        break;
                    case "TRM":
                        Kasir.frmBuktiTransferKeluarUpdate ifrmChild4 = new Kasir.frmBuktiTransferKeluarUpdate(this, rowID, true, JU, reff, txtNomor.Text,nip);
                        Program.MainForm.RegisterChild(ifrmChild4);
                        ifrmChild4.ShowDialog();
                        break;


                }
            }
            



            groupTambahTransaksi.Visible = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            label2.Text = "EDIT DATA TRANSAKSI";                

            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected:

                    _nip = gridKaryawan.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();
                    Kasir.frmPiutangKaryawanHeader_Update ifrmChild1 = new Kasir.frmPiutangKaryawanHeader_Update(this,_nip);
                    Program.MainForm.RegisterChild(ifrmChild1);
                    ifrmChild1.ShowDialog();

                    break;

            case enumSelectedGrid.DetailSelected:

                    if (gridPiutang.SelectedCells.Count > 0 && gridKaryawan.SelectedCells.Count > 0)
                    {
                        DateTime _Tanggal = (DateTime)gridPiutang.SelectedCells[0].OwningRow.Cells["tanggal"].Value;
                        if (PeriodeClosing.IsKasirClosed(_Tanggal))
                        {
                            MessageBox.Show("Sudah Closing!");
                            return;
                        }
                        _nama = gridKaryawan.SelectedCells[0].OwningRow.Cells["namapegawai"].Value.ToString();
                        _tanggal = ((DateTime)gridPiutang.SelectedCells[0].OwningRow.Cells["tanggal"].Value).ToString("dd-MM-yyyy");
                        _reff = gridPiutang.SelectedCells[0].OwningRow.Cells["reff"].Value.ToString();
                        _jenisUtang = gridPiutang.SelectedCells[0].OwningRow.Cells["jenis"].Value.ToString();
                        _nomor = gridPiutang.SelectedCells[0].OwningRow.Cells["noref"].Value.ToString();
                        _uraian = gridPiutang.SelectedCells[0].OwningRow.Cells["uraian"].Value.ToString();
                        _debet = gridPiutang.SelectedCells[0].OwningRow.Cells["debet"].Value.ToString();
                        _kredit = gridPiutang.SelectedCells[0].OwningRow.Cells["kredit"].Value.ToString();

                        txtTanggal.Text = _tanggal;
                        cbRef.Text = _reff;
                        cbRef.Enabled = false;
                        cbJenisUtang.Text = _jenisUtang;
                        txtNomor.Text = _nomor;
                        txtUraian.Text = _uraian;
                        txtDebet.Text = _debet;
                        txtKredit.Text = _kredit;
                        formMode = enumFormMode.Update;
                        groupTambahTransaksi.Visible = true;

                    }
                    else
                    {
                        MessageBox.Show("Belum Ada Data");
                    }
                    
            	break;
            }         
      
            }
                         
        private void DeletePiutang()
        {
            //if (gridPiutang.SelectedCells.Count > 0)
            //{
            //    srowID = (Guid)dgDetailBKK.SelectedCells[0].OwningRow.Cells["rowID"].Value;
            //    try
            //    {
            //        using (Database db = new Database(GlobalVar.DBFinance))
            //        {
            //            db.Commands.Add(db.CreateCommand("usp_BuktiDetail_DELETE"));
            //            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDDetail));
            //            db.Commands[0].ExecuteNonQuery();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Error.LogError(ex);
            //    }
            //    finally
            //    {
            //        DetailRefresh();
            //        refreshTerbilang();
            //        frmBKMBrowse frm = new frmBKMBrowse();
            //        frm = (frmBKMBrowse)this.Caller;
            //        frm.HeaderRefresh();
            //        frm.FindRowHeader("RowID", _rowID.ToString());
            //        frm.DetailRefresh();
            //    }

            //}
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.DetailSelected)
            {
                if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                

                    if (gridPiutang.SelectedCells.Count > 0)
                    {

                        Guid rowID = (Guid)gridPiutang.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        string nip = gridKaryawan.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();
                        string Ref = gridPiutang.SelectedCells[0].OwningRow.Cells["reff"].Value.ToString();
                        DateTime tglPinjam = Convert.ToDateTime(gridPiutang.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                        if (PeriodeClosing.IsKasirClosed(tglPinjam))
                        {
                            MessageBox.Show("Tidak bisa delete, data sudah di closing");
                            return;
                        }
                        try
                        {
                            if(Ref == "BKK" || Ref == "BKM")
                            {
                                using (Database db = new Database(GlobalVar.DBFinance))
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PinjamanPegawaiBukti_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                            }
                            else if (Ref == "TRK" || Ref == "TRM")
                            {
                                using (Database db = new Database(GlobalVar.DBFinance))
                                {
                                    db.Commands.Add(db.CreateCommand("usp_PinjamanPegawaiTransfer_DELETE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                    db.Commands[0].ExecuteNonQuery();
                                }
                            }
                            

                            
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        finally
                        {

                            RefreshPegawai(nip);
                            FindRowPegawsai("NIP", nip);
                            #region "Tambahan"
                            int i = 0;
                            int n = 0;
                            i = gridPiutang.SelectedCells[0].RowIndex;
                            n = gridPiutang.SelectedCells[0].ColumnIndex;
                            DataRowView dv = (DataRowView)gridPiutang.SelectedCells[0].OwningRow.DataBoundItem;

                            DataRow dr = dv.Row;

                            dr.Delete();
                            dtDetail.AcceptChanges();
                            gridPiutang.Focus();
                            gridPiutang.RefreshEdit();
                            if (gridPiutang.RowCount > 0)
                            {
                                if (i == 0)
                                {
                                    gridPiutang.CurrentCell = gridPiutang.Rows[0].Cells[n];
                                    gridPiutang.RefreshEdit();
                                }
                                else
                                {
                                    gridPiutang.CurrentCell = gridPiutang.Rows[i - 1].Cells[n];
                                    gridPiutang.RefreshEdit();
                                }

                            }
                            #endregion
                        }
                    }
                }
            }
        }



        

        private void cmdKartuPiutang_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nip = gridKaryawan.SelectedCells[0].OwningRow.Cells["NIP"].Value.ToString();

                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("rsp_PinjamanPegawai_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@NIP", SqlDbType.VarChar, nip));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ada.....");
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
            string nama = gridKaryawan.SelectedCells[0].OwningRow.Cells["namapegawai"].Value.ToString().Trim();
            string jabatan = gridKaryawan.SelectedCells[0].OwningRow.Cells["jabatan"].Value.ToString().Trim();
            string unit = gridKaryawan.SelectedCells[0].OwningRow.Cells["unitkerja"].Value.ToString().Trim();
            string tanggalCetak = String.Format("{0}", ((DateTime)DateTime.Now).ToString("yyyyMMdd hh:mm:ss"));
            string pencetak = SecurityManager.UserName;
            string tanggal;
            tanggal = String.Format("{0}", ((DateTime)DateTime.Now.Date).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();

            rptParams.Add(new ReportParameter("tanggal", tanggal));
            rptParams.Add(new ReportParameter("Nama", nama));
            rptParams.Add(new ReportParameter("Jabatan", jabatan));
            rptParams.Add(new ReportParameter("Unit", unit));
            rptParams.Add(new ReportParameter("tanggalCetak", tanggalCetak));
            rptParams.Add(new ReportParameter("pencetak", pencetak));



            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Kasir.Report.rptPinjamanPegawai.rdlc", rptParams, dt, "dsPinjamanPegawai_Data");
            ifrmReport.Show();

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.DetailSelected)
            {
                Guid _RowID = (Guid)gridPiutang.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string _reff = gridPiutang.SelectedCells[0].OwningRow.Cells["Reff"].Value.ToString();
                string MK = "";
                DataTable dt=new DataTable();
                try
                {
                    using (Database db = new Database(GlobalVar.DBFinance))
                    {
                        db.Commands.Add(db.CreateCommand("rsp_CetakPiutangKaryawan"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@Ref", SqlDbType.VarChar, _reff));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    if (_reff == "BKK" || _reff == "BKM")
                    {
                        if (_reff == "BKK")
                            MK = "K";
                        else
                            MK = "M";
                        if ((int)dt.Rows[0]["NPrint"] > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
                            return;

                        BKM.cetakBukti(dt, MK);
                    }
                    else if (_reff == "TRK" || _reff == "TRM" || _reff == "TRN")
                    {
                        if (_reff == "TRK")
                            MK = "K";
                        else
                            MK = "M";
                        if ((int)dt.Rows[0]["NPrint"] > 0 && (!SecurityManager.IsManager() && SecurityManager.AskPasswordManager() == false))
                            return;

                        TransferBank.cetakTransfer(dt, MK);
                    }

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                
            }
        }

        private void gridKaryawan_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            gridKaryawan_SelectionChanged(sender, e);
        }

        private void gridPiutang_Enter(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }                      

        
    }
}