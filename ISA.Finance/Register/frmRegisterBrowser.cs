using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Utility;


namespace ISA.Finance.Register
{
    public partial class frmRegisterBrowser : ISA.Finance.BaseForm
    {
        string KodeToko = string.Empty;
        int NoBpp = 0;
        int PanjangNo = 0;
        DataTable dtNota14Hari, dtRegBlmSelese, dtNotakurang14Hari, dtNotaDlmRegister14HariBlmCekFisik, dtNotaBlmCekFisik, dtNotaBlmRegister, dtPin, dtCekNotaFisik, dtUpdateCounter, dtCekCounter, dtLastUpdate = new DataTable();
        string Kode = string.Empty;
        int flagpin = 0;
        string No, BPPNo = string.Empty;
        string _NamaToko = string.Empty;
        string _WilID = string.Empty;
        string PrnAktif;

#region "Procedure"
        #region "Variable"
            DataTable dtHeader = new DataTable("Tagihan");
            DataTable dtDetail = new DataTable("TagihanDetail");
            DataTable dtSubDetail = new DataTable("KunjunganDetail");
             
            enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
            enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
            int _PrevGrid1 = -1;
            int _PrevGrid2 = -1;
           public  bool _lcabang;

           Guid headerselect;
           string hh, dd;
           int h, d;
           string NoRegister = string.Empty;
        #endregion

        #region "RefreshData"
            public void FindGridHeader(string ColoumName_, string Value_)
            {
                dataGridHeader.FindRow(ColoumName_, Value_);
            }

            public void FindGridDetail(string ColoumName_, string Value_)
            {
                dataGridDetail.FindRow(ColoumName_, Value_);
            }
            
            public void FindGridSubDetail(string ColoumName_, string Value_)
            {
                dataGridSubDetail.FindRow(ColoumName_, Value_);
            }

            public void RefreshRowDataSubDetail(string CoulumName_, string Value_, DataTable dtRefresh_)
            {
                if (dtRefresh_.Rows.Count > 0)
                {
                    dataGridSubDetail.RefreshDataRow(dtRefresh_.Rows[0], CoulumName_, Value_);
                }
            }

            public void RefreshRowDataHeader(Guid RowID_)
            {
                DataTable dtRefresh;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tagihan_List"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    dtRefresh = db.Commands[0].ExecuteDataTable();
                }
                if (dtRefresh.Rows.Count > 0)
                {
                    dataGridHeader.RefreshDataRow(dtRefresh.Rows[0], "RowID", RowID_.ToString());
                }
            }

            private void DeleteData(Guid RowID_)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_Tagihan_Delete]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].ExecuteNonQuery();
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

            private void DeleteDataDetail(Guid RowID_)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_Delete]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                        db.Commands[0].ExecuteNonQuery();
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

            private void FreeUpFlag()
            {
               

                for (int i = 0; i < dtHeader.Rows.Count;i++ )
                {
                    dtHeader.Rows[i]["Flag"] = "0";
                }

                dtHeader.AcceptChanges();
            }
        #endregion

        #region "LoadData"

        public void RefreshHeader(DateTime d1_, DateTime d2_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Tagihan_List")); // 30042013
                    db.Commands[0].Parameters.Add(new Parameter("@FromDate", SqlDbType.DateTime,d1_));
                    db.Commands[0].Parameters.Add(new Parameter("@ToDate", SqlDbType.DateTime, d2_));

                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
               
                dataGridHeader.DataSource = dtHeader;

                if (dataGridHeader.SelectedCells.Count > 0)
                {
                    RefreshDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value);
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

        public void RefreshDetail(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TagihanDetail_List]")); // cek table HR 30042013
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));

                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dtDetail.DefaultView.Sort = "NamaToko";
                dataGridDetail.DataSource = dtDetail.DefaultView.ToTable();

                int jmlScan = GetJmlScan();
                lblJmlTagihan.Text = dtDetail.Rows.Count.ToString();
                lblJmlScan.Text = jmlScan.ToString();
                lblJmlBlmScan.Text = (dtDetail.Rows.Count - jmlScan).ToString();

                if (dataGridDetail.SelectedCells.Count > 0)
                {
                    RefreshSubDetail((Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value);
                }
                else
                {
                    dataGridSubDetail.DataSource = null;
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

        public void RefreshSubDetail(Guid HeaderID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TagihanSubDetail_List]")); //	cek table HR 30042013
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));

                    dtSubDetail = db.Commands[0].ExecuteDataTable();
                }

                dataGridSubDetail.DataSource = dtSubDetail;

               
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
        
        private bool ChekPembayaran(Guid HeaderID_)
        {
            bool valid = false;
            int n = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Tagihan_ValidasiDelete]")); //  cek table HR 30042013
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, HeaderID_));

                    n = (int)db.Commands[0].ExecuteScalar();
                }

                if (n>0)
                {
                    valid = true;
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
            return valid;
        }

        private bool ChekPembayaranDetail(Guid HeaderID_)
        {
            bool valid = false;
            int n = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Tagihan_ValidasiDelete]")); // ?? gak pakai detail?
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID_));

                    n = (int)db.Commands[0].ExecuteScalar();
                }

                if (n > 0)
                {
                    valid = true;
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
            return valid;
        }

        private void GetDataUpload(string RowID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Tagihan_Upload]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.Text, RowID_));

                    ds = db.Commands[0].ExecuteDataSet();
                }

                if (ds.Tables[0].Rows.Count==0)
                {
                    MessageBox.Show("No data");
                    return;
                }
                UploadRegister(ds);
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

        private void ZipFile(string FileName1, string FileName2)
        {
            List<string> files = new List<string>();

            string fileName1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".dbf";
            string fileIndex1 = GlobalVar.DbfUpload + "\\" + FileName1 + ".CDX";
            string fileName2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".dbf";
            string fileIndex2 = GlobalVar.DbfUpload + "\\" + FileName2 + ".CDX";

            string fileZipName = GlobalVar.DbfUpload + "\\DBFTAGIH.zip";
            files.Add(fileName1);
            files.Add(fileName2);
            files.Add(fileIndex1);
            files.Add(fileIndex2);
            //Delete File Yg lama jika Ada
            if (File.Exists(fileZipName))
            {
                File.Delete(fileZipName);
            }

            Zip.ZipFiles(files, fileZipName);

            if (File.Exists(fileName1) && File.Exists(fileName2) && File.Exists(fileIndex1) && File.Exists(fileIndex2))
            {
                files.Add(fileName1);
                files.Add(fileName2);
                files.Add(fileIndex1);
                files.Add(fileIndex2);
            }


        }

        private void Upload1(String FileName, DataTable dt)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RecordID", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("NoReg", "no_reg", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglReg", "tgl_reg", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("CollectorID", "colector", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("NamaCollector", "nm_coll", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("RpNota", "n_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpBayar", "n_bayar", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpTagih", "n_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("Wilayah", "wilayah", Foxpro.enFoxproTypes.Char, 20));
            fields.Add(new Foxpro.DataStruct("Periode1", "periode_1", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Periode2", "periode_2", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("TLama", "t_lama", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("NamaKasir", "nm_kasir", Foxpro.enFoxproTypes.Char, 10));

            fields.Add(new Foxpro.DataStruct("RpGiro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpTransfer", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpTunai", "rp_tunai", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("nGiro", "lbr_giro", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("nToko", "ntoko1", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("nToko2", "ntoko2", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("nNota", "lbr_nota", Foxpro.enFoxproTypes.Numeric, 4));
            fields.Add(new Foxpro.DataStruct("RpOnly", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("TglKembali", "tgl_kbl", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NPrint", "nprint", Foxpro.enFoxproTypes.Numeric, 3));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("id_reg", "id_reg"));

            ProgressBar pb = new ProgressBar();
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], DetailprogressBar, index);
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dt,pb,index);
        }

        private void Upload2(String FileName, DataTable dt)
        {
            string Physical = GlobalVar.DbfUpload + "\\" + FileName + ".dbf";

            if (File.Exists(Physical))
            {
                File.Delete(Physical);
            }

            List<Foxpro.DataStruct> fields = new List<Foxpro.DataStruct>();

            fields.Add(new Foxpro.DataStruct("RecordID", "idrec", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("HRecordID", "id_reg", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("KPrecID", "id_kp", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("WilID", "idwil", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("KodeToko", "kd_toko", Foxpro.enFoxproTypes.Char, 19));
            fields.Add(new Foxpro.DataStruct("NamaToko", "nama_toko", Foxpro.enFoxproTypes.Char, 31));
            fields.Add(new Foxpro.DataStruct("KodeSales", "kd_sales", Foxpro.enFoxproTypes.Char, 11));

            fields.Add(new Foxpro.DataStruct("TglTransaksi", "tgl_tr", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("NoTransaksi", "no_tr", Foxpro.enFoxproTypes.Char, 7));
            fields.Add(new Foxpro.DataStruct("TglJthTempo", "tgl_jt", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("RpNota", "rp_nota", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpBayar", "rp_bayar", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpTagih", "rp_tagih", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("PLama", "p_lama", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpGiro", "rp_giro", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpKas", "rp_cash", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpTransfer", "rp_trf", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpMutasi", "rp_mutasi", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpPot", "rp_pot", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("RpPot", "rp_disc", Foxpro.enFoxproTypes.Numeric, 12));
            fields.Add(new Foxpro.DataStruct("RpRetur", "rp_retur", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("NoBP", "no_bpp", Foxpro.enFoxproTypes.Char, 10));
            fields.Add(new Foxpro.DataStruct("RpRetur", "rp_only", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("RpRetur", "rp_exp", Foxpro.enFoxproTypes.Numeric, 14));
            fields.Add(new Foxpro.DataStruct("SyncFlag", "id_match", Foxpro.enFoxproTypes.Char, 1));
            fields.Add(new Foxpro.DataStruct("TglTagih", "tgl_tagih", Foxpro.enFoxproTypes.DateTime, 8));
            fields.Add(new Foxpro.DataStruct("Flag", "Flag", Foxpro.enFoxproTypes.Logical, 1));
            fields.Add(new Foxpro.DataStruct("TagihID", "ket", Foxpro.enFoxproTypes.Char, 30));
            fields.Add(new Foxpro.DataStruct("Keterangan", "idtagih", Foxpro.enFoxproTypes.Char, 23));
            fields.Add(new Foxpro.DataStruct("NamaCollector", "nm_coll", Foxpro.enFoxproTypes.Char, 10));

            List<Foxpro.IndexStruct> index = new List<Foxpro.IndexStruct>();
            index.Add(new Foxpro.IndexStruct("id_reg", "id_reg"));

            ProgressBar pb = new ProgressBar();
            //Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dsResult.Tables[1], DetailprogressBar, index);
            Foxpro.WriteFile(GlobalVar.DbfUpload, FileName, fields, dt, pb, index);
        }

        private void UploadRegister(DataSet dsResult)
        {
            if (dsResult.Tables.Count == 0)
            {
                cmdSearch.PerformClick();
                return;
            }

            if (dsResult.Tables[0].Rows.Count == 0 || dsResult.Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("Tidak data yang diupload");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Upload1("HtghnTmp",dsResult.Tables[0]);
                Upload2("DtghnTmp", dsResult.Tables[1]);
                ZipFile("HtghnTmp", "DtghnTmp");
                this.Cursor = Cursors.Default;
                FreeUpFlag();
                MessageBox.Show(Messages.Confirm.ProcessFinished + ". Lokasi File: " + GlobalVar.DbfUpload + "\\DBFTAGIH.zip");
                //DisplayReport();
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

       
        #endregion

        #region "Print Out"
        private DataTable rpt(Guid HeaderID_)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[rsp_Tagihan_Register]"));
                    db.Commands[0].Parameters.Add(new Parameter("@HEaderID", SqlDbType.UniqueIdentifier, HeaderID_));
                    db.Commands[0].Parameters.Add(new Parameter("@LCabang", SqlDbType.Bit, _lcabang ? 1 :0));
                    dt = db.Commands[0].ExecuteDataTable();
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
            return dt;
        }


        private void PrintOutInkjet(DataTable dt)
        {
            string _NamaCollector = _lcabang ? dataGridHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString() : string.Empty;
            string _Periode1 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode1"].Value).ToString("dd-MMM-yyyy");
            string _Periode2 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode2"].Value).ToString("dd-MMM-yyyy");
            string _NoReg = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoReg"].Value.ToString();
            string _WilID = dataGridHeader.SelectedCells[0].OwningRow.Cells["Wilayah"].Value.ToString();
            string _TglReg = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglReg"].Value).ToString("dd-MMM-yyyy");

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserName", SecurityManager.UserName));
            rptParams.Add(new ReportParameter("Periode1", _Periode1));
            rptParams.Add(new ReportParameter("Periode2", _Periode2));
            rptParams.Add(new ReportParameter("NoReg", _NoReg));
            rptParams.Add(new ReportParameter("Colector", _NamaCollector));
            rptParams.Add(new ReportParameter("TglReg", _TglReg));

            frmReportViewer ifrmReport = new frmReportViewer("Piutang.rptCetakRegisterTagihan.rdlc", rptParams, dt, "dsTagihan_Data2");
            ifrmReport.Print(8.5, 12);
            //ifrmReport.Show();


            //if (PrnAktif == "2")
            //{
                ifrmReport = new frmReportViewer("Piutang.rptCetakRegisterTagihan_copy.rdlc", rptParams, dt, "dsTagihan_Data2");
                ifrmReport.Print(8.5, 12);
                //ifrmReport.Show();
            //}
        }

        
        private void PrintOut(DataTable dt)
        {
            string _NamaCollector = _lcabang ? dataGridHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString() : string.Empty;
            string _Periode1 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode1"].Value).ToString("dd-MMM-yyyy");
            string _Periode2 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode2"].Value).ToString("dd-MMM-yyyy");
            string _NoReg = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoReg"].Value.ToString();
            string _WilID = dataGridHeader.SelectedCells[0].OwningRow.Cells["Wilayah"].Value.ToString();
            string _TglReg = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglReg"].Value).ToString("dd-MMM-yyyy");

            int _pg = 1;
            int _jmlhal = 1;
            int _hal = 1;
            int _no = 0;
            int _nRec = 0;
            int _nRecCount = dt.Rows.Count;

            for (int i = 1; i <= _nRecCount; i++)
            {
                if (_jmlhal == 1)
                {
                    if (_no >= 23 && _nRecCount <= 25 && _no == (_nRecCount - 1))
                    {
                        _hal = 0;
                        _nRec = 0;
                    }
                    else
                    {
                        if (_no == 25)
                        {
                            _hal = 0;
                            _nRec = _nRec + _no;
                        }
                    }
                }
                else
                {
                    if (_no >= 26 && (_nRecCount - _nRec) <= 28 && _no == (_nRecCount - (_nRec + 1)))
                    {
                        _hal = 0;
                        _nRec = _nRec + _no;
                    }
                    else
                    {
                        if (_no == 28)
                        {
                            _hal = 0;
                            _nRec = _nRec + _no;
                        }
                    }
                }

                if (_hal == 0)
                {
                    _hal = 1;
                    _no = 0;
                    _jmlhal = _jmlhal + 1;
                }
                _no = _no + 1;
            }
            BuildString detail = new BuildString();
            detail.FontCondensed(true);

            //detail.PROW(false,1,Convert.ToString((char)27)+"!"+Convert.ToString((char)37));
            detail.PROW(true, 1, "Wil " + _WilID + " REGISTER TAGIHAN " + _NoReg + detail.SPACE(15) + "Hal. " + _pg.ToString() + "/" + _jmlhal.ToString());
            detail.PROW(true, 1, detail.SPACE(_WilID.Length + 4) + "------------------------");
            //detail.AddCR();
            //detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)1));
            detail.PROW(true, 1, "Periode      : " + _Periode1 + " sd " + _Periode2 + "                       Collector : " + _NamaCollector);
            detail.PROW(true, 1, "Tgl. Kembali : " + detail.SPACE(53) + "Tanggal : " + _TglReg);
            //detail.AddCR();
            //detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)4));
            detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBTOp() + detail.PrintHorizontalLine(8) + detail.PrintTBTOp() + detail.PrintHorizontalLine(39) + detail.PrintTBTOp() + detail.PrintHorizontalLine(3) + detail.PrintTBTOp() + detail.PrintHorizontalLine(40) + detail.PrintTopRightCorner());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(34) + detail.PrintVerticalLine() + detail.SPACE(8) + detail.PrintVerticalLine() + detail.PadCenter(39, "N O T A") + detail.PrintVerticalLine() + detail.SPACE(3) + detail.PrintVerticalLine() + detail.SPACE(40) + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(34, " NAMA TOKO") + detail.PrintVerticalLine() + detail.PadCenter(8, "IDWIL") + detail.PrintTBLeft() + (detail.PrintHorizontalLine(13) + detail.PrintTTOp() + detail.PrintHorizontalLine(9) + detail.PrintTTOp() + detail.PrintHorizontalLine(15)) + detail.PrintTRight() + "SLS" + detail.PrintVerticalLine() + detail.PadCenter(25, "K E T E R A N G A N") + detail.PrintVerticalLine() + detail.PadCenter(14, "TGL JT TEMPO") + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(34) + detail.PrintVerticalLine() + detail.SPACE(8) + detail.PrintVerticalLine() + (detail.PadCenter(13, "TANGGAL") + detail.PrintVerticalLine() + detail.PadCenter(9, "NOMOR") + detail.PrintVerticalLine() + detail.PadCenter(15, "Rp. SISA")) + detail.PrintVerticalLine() + detail.SPACE(3) + detail.PrintVerticalLine() + detail.SPACE(40) + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(30) + detail.PrintTMidlle() + detail.PrintHorizontalLine(3) + detail.PrintTMidlle() + detail.PrintHorizontalLine(8) + detail.PrintTMidlle() + (detail.PrintHorizontalLine(13) + detail.PrintTMidlle() + detail.PrintHorizontalLine(9) + detail.PrintTMidlle() + detail.PrintHorizontalLine(15)) + detail.PrintTMidlle() + detail.PrintHorizontalLine(3) + detail.PrintTMidlle() + detail.PrintHorizontalLine(40) + detail.PrintTBRight());

            _hal = 1;
            _no = 0;
            _nRec = 0;
            string cekTK = "";

            string _KodeToko = string.Empty;
            string _NamaToko = string.Empty;
            string _IDWIL = string.Empty;
            string _KodeSales = string.Empty;
            string _NoTransaksi = string.Empty;
            string _TipeTransaksi = string.Empty;
            string _TglTransaksi = string.Empty;
            string _RpTagih = string.Empty;
            string _TglJthTempo = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                if (_pg == 1)
                {
                    if (_no >= 23 && _nRecCount <= 25 && _no == (_nRecCount - 1))
                    {
                        _hal = 0;
                        _nRec = 0;
                        detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
                        detail.Eject();
                    }
                    else
                    {
                        if (_no == 25)
                        {
                            _hal = 0;
                            _nRec = _nRec + _no;
                            detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
                            detail.Eject();
                        }
                    }
                }
                else
                {
                    if (_no >= 26 && (_nRecCount - _nRec) <= 28 && _no == (_nRecCount - (_nRec + 1)))
                    {
                        _hal = 0;
                        _nRec = _nRec + _no;
                        detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
                        detail.Eject();
                    }
                    else
                    {
                        if (_no == 28)
                        {
                            _hal = 0;
                            _nRec = _nRec + _no;
                            detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
                            detail.Eject();
                        }
                    }
                }

                if (_hal == 0)
                {
                    _pg = _pg + 1;
                    detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)37));
                    detail.PROW(true, 1, detail.SPACE(27) + "REGISTER TAGIHAN " + _NoReg + detail.SPACE(17) + "Hal. " + _pg.ToString() + "/" + _jmlhal.ToString());
                    detail.PROW(true, 1, "");

                    detail.PROW(false, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)4));
                    detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBTOp() + detail.PrintHorizontalLine(8) + detail.PrintTBTOp() + detail.PrintHorizontalLine(13) + detail.PrintTBTOp() + detail.PrintHorizontalLine(9) + detail.PrintTBTOp() + detail.PrintHorizontalLine(15) + detail.PrintTBTOp() + detail.PrintHorizontalLine(3) + detail.PrintTBTOp() + detail.PrintHorizontalLine(40) + detail.PrintTopRightCorner());
                    _hal = 1;
                    _no = 0;
                }
                _KodeToko = dr["KodeToko"].ToString();
                _NamaToko = dr["NamaToko"].ToString();
                _IDWIL = dr["WilID"].ToString();
                _KodeSales = dr["KodeSales"].ToString();
                _NoTransaksi = dr["NoTransaksi"].ToString();
                _TipeTransaksi = dr["TipeTransaksi"].ToString();
                _TglTransaksi = ((DateTime)dr["TglTransaksi"]).ToString("dd-MMM-yyyy");
                _RpTagih = Convert.ToDouble(dr["RpSisa"]).ToString("#,##0");
                _TglJthTempo = ((DateTime)dr["TglJthTempo"]).ToString("dd-MMM-yyyy");

                if (_no != 0)
                {
                    detail.PROW(true, 1, (cekTK != _KodeToko ?
                                         (detail.PrintTBLeft() + detail.PrintHorizontalLine(30) + detail.PrintTBMidlle()) :
                                         (detail.PrintVerticalLine() + detail.SPACE(30) + detail.PrintTLeft())) +
                                          detail.PrintHorizontalLine(3) + detail.PrintTBMidlle() +
                                          detail.PrintHorizontalLine(8) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(13) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(9) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(15) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(3) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(25) + detail.PrintTMidlle() +
                                          detail.PrintHorizontalLine(14) + detail.PrintTBRight());
                }

                detail.PROW(true, 1, (cekTK != _KodeToko || _no == 0 ?
                                     (detail.PrintVerticalLine() + _NamaToko.PadRight(30) +
                                      detail.PrintVerticalLine() + _TipeTransaksi.PadRight(3)) :
                                     (detail.PrintVerticalLine() + detail.SPACE(30) +
                                      detail.PrintVerticalLine() + _TipeTransaksi.PadRight(3))) +
                                      detail.PrintVerticalLine() + detail.PadCenter(8, _IDWIL) +
                                      detail.PrintVerticalLine() + detail.PadCenter(13, _TglTransaksi) +
                                      detail.PrintVerticalLine() + detail.PadCenter(9, _NoTransaksi) +
                                      detail.PrintVerticalLine() + _RpTagih.PadLeft(15) +
                                      detail.PrintVerticalLine() + _KodeSales +
                                      detail.PrintVerticalLine() + detail.SPACE(25) +
                                      detail.PrintVerticalLine() + detail.PadCenter(13, _TglJthTempo) +
                                      detail.PrintVerticalLine());
                cekTK = _KodeToko;
                _no = _no + 1;
            }

            detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(63) + detail.PrintTBTOp() + detail.PrintHorizontalLine(64) + detail.PrintTopRightCorner());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(3) + "Collector, ".PadRight(60) + detail.PrintVerticalLine() + detail.SPACE(3) + "Piutang, ".PadRight(61) + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(63) + detail.PrintVerticalLine() + detail.SPACE(64) + detail.PrintVerticalLine());
            detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(63) + detail.PrintTBBottom() + detail.PrintHorizontalLine(64) + detail.PrintBottomLeftCorner());
            detail.Eject();

            if (rdb1Printer.Checked)
            {
                detail.SendToPrinter("reg_tagihPS.txt", detail.GenerateString());
            }
            else
            {
                string namaFile = (textBox1.Text.Trim() == "" ? "reg_tagihPS.txt" : textBox1.Text.Trim() + ".txt");
                detail.SendToTxt(namaFile, detail.GenerateString());
                Process.Start(Properties.Settings.Default.OutputFile + "\\" + namaFile);
            }


            //string _NamaCollector = _lcabang?  dataGridHeader.SelectedCells[0].OwningRow.Cells["Nama"].Value.ToString():string.Empty;
            //string _Periode1 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode1"].Value).ToString("dd-MMM-yyyy");
            //string _Periode2 = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["Periode2"].Value).ToString("dd-MMM-yyyy");
            //string _NoReg = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoReg"].Value.ToString();
            //string _WilID = dataGridHeader.SelectedCells[0].OwningRow.Cells["Wilayah"].Value.ToString();
            //string _TglReg = ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglReg"].Value).ToString("dd-MMM-yyyy");

            //int _pg    =1;
            //int _jmlhal=1;
            //int _hal   =1;
            //int _no    =0;
            //int _nRec  =0;
            //int _nRecCount = dt.Rows.Count;

            //for (int i = 1; i <= _nRecCount;i++)
            //{
            //   if (_jmlhal==1)
            //   {
            //       if (_no>=23 && _nRecCount<=25 && _no==(_nRecCount-1))
            //       {
            //           _hal = 0;
            //           _nRec = 0;
            //       } 
            //       else
            //       {
            //           if (_no==25)
            //           {
            //               _hal = 0;
            //               _nRec = _nRec + _no;
            //           }
            //       }
            //   }
            //   else
            //   {
            //       if (_no >= 26 && (_nRecCount-_nRec) <= 28 && _no == (_nRecCount -( _nRec+1)))
            //       {
            //           _hal = 0;
            //           _nRec = _nRec + _no;
            //       }
            //       else
            //       {
            //           if (_no == 28)
            //           {
            //               _hal = 0;
            //               _nRec = _nRec + _no;
            //           }
            //       }
            //   }

            //    if (_hal==0)
            //    {
            //        _hal = 1;
            //        _no = 0;
            //        _jmlhal = _jmlhal + 1;
            //    }
            //    _no = _no + 1;
            //}
            //BuildString detail = new BuildString();

            ////detail.PROW(false,1,Convert.ToString((char)27)+"!"+Convert.ToString((char)37));
            //detail.PROW(true, 1, "Wil " + _WilID + " REGISTER TAGIHAN "+ _NoReg + detail.SPACE(15) + "Hal. "+_pg.ToString()+"/"+_jmlhal.ToString()  );
            //detail.PROW(true, 1, detail.SPACE(_WilID.Length+4) + "------------------------");
            ////detail.AddCR();
            ////detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)1));
            //detail.PROW(true, 1, "Periode      : " + _Periode1 + " sd " + _Periode2 + "                       Collector : "+_NamaCollector);
            //detail.PROW(true, 1, "Tgl. Kembali : " + detail.SPACE(53) + "Tanggal : "+_TglReg);
            ////detail.AddCR();
            ////detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)4));
            //detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBTOp() + detail.PrintHorizontalLine(8) + detail.PrintTBTOp() + detail.PrintHorizontalLine(39) + detail.PrintTBTOp() + detail.PrintHorizontalLine(3) + detail.PrintTBTOp() + detail.PrintHorizontalLine(40)+detail.PrintTopRightCorner());
            //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(34) + detail.PrintVerticalLine() + detail.SPACE(8) + detail.PrintVerticalLine() + detail.PadCenter(39, "N O T A" )+ detail.PrintVerticalLine() + detail.SPACE(3) + detail.PrintVerticalLine() + detail.SPACE(40) + detail.PrintVerticalLine());
            //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.PadCenter(34, " NAMA TOKO") + detail.PrintVerticalLine() + detail.PadCenter(8, "IDWIL") + detail.PrintTBLeft() + (detail.PrintHorizontalLine(13) + detail.PrintTTOp() + detail.PrintHorizontalLine(9) + detail.PrintTTOp() + detail.PrintHorizontalLine(15)) + detail.PrintTRight() + "SLS" + detail.PrintVerticalLine() + detail.PadCenter(25, "K E T E R A N G A N") + detail.PrintVerticalLine() + detail.PadCenter(14, "TGL JT TEMPO") + detail.PrintVerticalLine());
            //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(34) + detail.PrintVerticalLine() + detail.SPACE(8) + detail.PrintVerticalLine() + (detail.PadCenter(13,"TANGGAL")+ detail.PrintVerticalLine() + detail.PadCenter(9,"NOMOR")+ detail.PrintVerticalLine() + detail.PadCenter(15,"Rp. SISA")) + detail.PrintVerticalLine() + detail.SPACE(3) + detail.PrintVerticalLine() + detail.SPACE(40) + detail.PrintVerticalLine());
            //detail.PROW(true, 1, detail.PrintTLeft() + detail.PrintHorizontalLine(30) + detail.PrintTMidlle() + detail.PrintHorizontalLine(3) + detail.PrintTMidlle() + detail.PrintHorizontalLine(8) + detail.PrintTMidlle() + (detail.PrintHorizontalLine(13) + detail.PrintTMidlle() + detail.PrintHorizontalLine(9) + detail.PrintTMidlle() + detail.PrintHorizontalLine(15)) + detail.PrintTMidlle() + detail.PrintHorizontalLine(3) + detail.PrintTMidlle() + detail.PrintHorizontalLine(40) + detail.PrintTBRight());
            
            //_hal  = 1;
            //_no   = 0;
            //_nRec = 0;
            //string cekTK = "";

            //string _KodeToko = string.Empty;
            //string _NamaToko = string.Empty;
            //string _IDWIL = string.Empty;
            //string _KodeSales = string.Empty;
            //string _NoTransaksi = string.Empty;
            //string _TipeTransaksi = string.Empty;
            //string _TglTransaksi = string.Empty;
            //string _RpTagih = string.Empty;
            //string _TglJthTempo = string.Empty;
            
            //foreach (DataRow dr in dt.Rows)
            //{
            //   if (_pg==1)
            //   {
            //       if (_no >= 23 && _nRecCount <= 25 && _no == (_nRecCount - 1))
            //       {
            //           _hal = 0;
            //           _nRec = 0;
            //           detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            //           detail.Eject();
            //       }
            //       else
            //       {
            //           if (_no == 25)
            //           {
            //               _hal = 0;
            //               _nRec = _nRec + _no;
            //               detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            //               detail.Eject();
            //           }
            //       }
            //   } 
            //   else
            //   {
            //       if (_no >= 26 && (_nRecCount - _nRec) <= 28 && _no == (_nRecCount - (_nRec + 1)))
            //       {
            //           _hal = 0;
            //           _nRec = _nRec + _no;
            //           detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            //           detail.Eject();
            //       }
            //       else
            //       {
            //           if (_no == 28)
            //           {
            //               _hal = 0;
            //               _nRec = _nRec + _no;
            //               detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            //               detail.Eject();
            //           }
            //       }
            //   }

            //   if (_hal == 0)
            //   {
            //       _pg = _pg + 1;
            //       detail.PROW(true, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)37));
            //       detail.PROW(true, 1, detail.SPACE(27)+ "REGISTER TAGIHAN " + _NoReg + detail.SPACE(17) + "Hal. " + _pg.ToString() + "/" + _jmlhal.ToString());
            //       detail.PROW(true, 1, "");

            //       detail.PROW(false, 1, Convert.ToString((char)27) + "!" + Convert.ToString((char)4));
            //       detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBTOp() + detail.PrintHorizontalLine(8) + detail.PrintTBTOp() + detail.PrintHorizontalLine(13) + detail.PrintTBTOp() + detail.PrintHorizontalLine(9) + detail.PrintTBTOp() + detail.PrintHorizontalLine(15) + detail.PrintTBTOp() + detail.PrintHorizontalLine(3) + detail.PrintTBTOp() + detail.PrintHorizontalLine(40) + detail.PrintTopRightCorner());
            //       _hal = 1;
            //       _no = 0;
            //   }
            //   _KodeToko = dr["KodeToko"].ToString();
            //   _NamaToko = dr["NamaToko"].ToString();
            //   _IDWIL = dr["WilID"].ToString();
            //   _KodeSales = dr["KodeSales"].ToString();
            //   _NoTransaksi = dr["NoTransaksi"].ToString();
            //   _TipeTransaksi = dr["TipeTransaksi"].ToString();
            //   _TglTransaksi = ((DateTime)dr["TglTransaksi"]).ToString("dd-MMM-yyyy");
            //   _RpTagih = Convert.ToDouble(dr["RpSisa"]).ToString("#,##0");
            //   _TglJthTempo = ((DateTime)dr["TglJthTempo"]).ToString("dd-MMM-yyyy");

            //    if (_no!=0)
            //    {
            //        detail.PROW(true, 1, (cekTK != _KodeToko ? 
            //                             (detail.PrintTBLeft() + detail.PrintHorizontalLine(30) + detail.PrintTBMidlle()) : 
            //                             (detail.PrintVerticalLine() + detail.SPACE(30) + detail.PrintTLeft())) +
            //                              detail.PrintHorizontalLine(3) + detail.PrintTBMidlle() + 
            //                              detail.PrintHorizontalLine(8) + detail.PrintTMidlle() + 
            //                              detail.PrintHorizontalLine(13) + detail.PrintTMidlle() + 
            //                              detail.PrintHorizontalLine(9) + detail.PrintTMidlle() + 
            //                              detail.PrintHorizontalLine(15) + detail.PrintTMidlle() + 
            //                              detail.PrintHorizontalLine(3) + detail.PrintTMidlle() +
            //                              detail.PrintHorizontalLine(25) + detail.PrintTMidlle() +
            //                              detail.PrintHorizontalLine(14) + detail.PrintTBRight());
            //    }

            //    detail.PROW(true, 1, (cekTK != _KodeToko || _no==0 ?
            //                         (detail.PrintVerticalLine() + _NamaToko.PadRight(30) + 
            //                          detail.PrintVerticalLine() + _TipeTransaksi.PadRight(3)) :
            //                         (detail.PrintVerticalLine() + detail.SPACE(30) + 
            //                          detail.PrintVerticalLine() + _TipeTransaksi.PadRight(3))) +
            //                          detail.PrintVerticalLine() + detail.PadCenter(8,_IDWIL) + 
            //                          detail.PrintVerticalLine() + detail.PadCenter(13,_TglTransaksi) +
            //                          detail.PrintVerticalLine() + detail.PadCenter(9,_NoTransaksi)  +
            //                          detail.PrintVerticalLine() + _RpTagih.PadLeft(15) +
            //                          detail.PrintVerticalLine() + _KodeSales +
            //                          detail.PrintVerticalLine() + detail.SPACE(25) +
            //                          detail.PrintVerticalLine() + detail.PadCenter(13, _TglJthTempo) + 
            //                          detail.PrintVerticalLine());
            //    cekTK = _KodeToko;
            //    _no = _no + 1;
            //}
            
            //detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(34) + detail.PrintTBBottom() + detail.PrintHorizontalLine(8) + detail.PrintTBBottom() + (detail.PrintHorizontalLine(13) + detail.PrintTBBottom() + detail.PrintHorizontalLine(9) + detail.PrintTBBottom() + detail.PrintHorizontalLine(15)) + detail.PrintTBBottom() + detail.PrintHorizontalLine(3) + detail.PrintTBBottom() + detail.PrintHorizontalLine(40) + detail.PrintBottomRightCorner());
            //detail.PROW(true, 1, detail.PrintTopLeftCorner() + detail.PrintHorizontalLine(63) + detail.PrintTBTOp() + detail.PrintHorizontalLine(64) + detail.PrintTopRightCorner());
            //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(3) + "Collector, ".PadRight(60) + detail.PrintVerticalLine() + detail.SPACE(3) +"Piutang, ".PadRight(61) + detail.PrintVerticalLine());
            //detail.PROW(true, 1, detail.PrintVerticalLine() + detail.SPACE(63) + detail.PrintVerticalLine() + detail.SPACE(64) + detail.PrintVerticalLine());
            //detail.PROW(true, 1, detail.PrintBottomLeftCorner() + detail.PrintHorizontalLine(63) + detail.PrintTBBottom() + detail.PrintHorizontalLine(64) + detail.PrintBottomLeftCorner());
            //detail.Eject();

            //if (rdb1Printer.Checked)
            //{
            //    detail.SendToPrinter("reg_tagihPS.txt", detail.GenerateString());
            //} 
            //else
            //{
            //    string namaFile =(textBox1.Text.Trim() == "" ? "reg_tagihPS.txt" : textBox1.Text.Trim() + ".txt");
            //    detail.SendToTxt(namaFile, detail.GenerateString());
            //    Process.Start(Properties.Settings.Default.OutputFile + "\\" + namaFile);
            //}
        
        }
        #endregion
#endregion
        public frmRegisterBrowser()
        {
            InitializeComponent();
        }

        private void frmRegisterBrowser_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;

            string id_ = Tools.Right(GlobalVar.PerusahaanID, 2);
            bool aaaa_ = false;
            int a_ = 0;
            aaaa_ = int.TryParse(id_, out a_);

            if (aaaa_)
            {
                if (a_>0)
                {
                    _lcabang = true;
                }
                
            }else
            {
                _lcabang=false;
            }


            _lcabang = true;

            if (_lcabang)
            {

                cmdRiwayat.Visible = false;
                cmdKunjung.Visible = false;
            }
            else
            {
                cmdRiwayat.Visible = true;
                cmdKunjung.Visible = true;
            }

            if (GlobalVar.Gudang == "2808")
            {
                dataGridSubDetail.ReadOnly = true;
                //dataGridSubDetail.Columns[0].ReadOnly = true;
                //dataGridSubDetail.Columns[1].ReadOnly = false;
                //dataGridSubDetail.Columns[2].ReadOnly = true;
                //dataGridSubDetail.Columns[3].ReadOnly = true;
                //dataGridSubDetail.Columns[4].ReadOnly = true;
                //dataGridSubDetail.Columns[5].ReadOnly = true;
                //dataGridSubDetail.Columns[6].ReadOnly = true;
                //dataGridSubDetail.Columns[7].ReadOnly = true;
            }
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {

            try
            {
                int i = 0;
                i = Convert.ToInt32(dtHeader.Compute("COUNT(Flag)", "Flag=1"));
                if (i == 0)
                {
                    MessageBox.Show("Browsing ke 1 belum ada yg di flag !!!");
                    return;
                }


                string RowID_ = string.Empty;
                DataTable dt = new DataTable();
                dt = dtHeader.Copy();
                dt.DefaultView.RowFilter = "Flag=1";
                DataTable dtT = new DataTable();
               // dtT.Columns.Add("RowID");

                foreach (DataRow dr in dt.DefaultView.ToTable().Rows)
                {
                  //  dtT.ImportRow(dr);
                    RowID_ = RowID_ + dr["RowID"].ToString() + "|";
                }
                //string path = GlobalVar.DbfUpload+"\\Register01.xml";
                //if (File.Exists(path))
                //{
                //    File.Delete(path);
                //}
                //dtT.WriteXml(path);
                GetDataUpload(RowID_);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                
                if (MessageBox.Show("Data Sudah Benar ? ", "Cetak Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                        db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "Registertagihan"));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (dt.Rows.Count == 0)
                        PrnAktif = "0";
                    else
                        PrnAktif = dt.Rows[0]["Value"].ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                string Flag_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();

                if (Flag_ == "Ctk")
                {
                    MessageBox.Show("Data Sudah Pernah Tercetak");
                    return;
                }
                
                if (PrnAktif != "0")
                    PrintOutInkjet(rpt(RowID_));
                else
                    PrintOut(rpt(RowID_));

                int index = -1;
                index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr["NPrint"] = "Ctk";
                dtHeader.AcceptChanges();
                dataGridHeader.RefreshEdit();

                #region pin register
                /*PIN Register ditutup, Permintaan Mei Piutang*/
                //if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                //{
                //    //Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                //    //string Flag_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
                //    if (Flag_ == "Ctk")
                //    {
                //        MessageBox.Show("Data Sudah Pernah Tercetak");
                //        return;
                //    }

                //    //TUTUP SEMENTARA UJICOBA CETAK REGISTER
                //    bool isHasPin = LookupInfoValue.CekPinCetakRegister();
                //    if (!isHasPin)
                //    {
                //        if (PrnAktif != "0")
                //            PrintOutInkjet(rpt(RowID_));
                //        else
                //            PrintOut(rpt(RowID_));

                //        int index = -1;
                //        index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                //        DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                //        DataRow dr = dv.Row;
                //        dr["NPrint"] = "Ctk";
                //        dtHeader.AcceptChanges();
                //        dataGridHeader.RefreshEdit();
                //    }
                //    else
                //    {
                //        //nota14hari();
                //        //notakurang14hari();

                //        RegBlmSelesai();
                //        notaCekFisik();
                //        NotaBelumBerregister();
                //        NotaDlmRegister14HariBlmCekFisik();
                //        PinRegister();

                //        if (dtRegBlmSelese.Rows.Count > 0 || dtNotaBlmCekFisik.Rows.Count > 0 || dtNotaBlmRegister.Rows.Count > 0 || dtNotaDlmRegister14HariBlmCekFisik.Rows.Count > 0)
                //        {
                //            if (dtPin.Rows.Count == 0)
                //            {
                //                //if (dtNota14Hari.Rows.Count > 0)
                //                //{
                //                //    Administrasi.frmPasswordSpv ifrmChild = new Administrasi.frmPasswordSpv();
                //                //    ifrmChild.WindowState = FormWindowState.Normal;
                //                //    ifrmChild.ShowDialog();
                //                //}
                //                //DisplayReportNota14Hari(dtNota14Hari);
                //                //DisplayReportNotaKurang14Hari(dtNotakurang14Hari);

                //                DisplayReportNotaBlmAdaReg(dtNotaBlmRegister);
                //                DisplayReportNotaCekFisik(dtNotaBlmCekFisik);
                //                DisplayReportNotaDLmReg14HariBlmCekFisik(dtNotaDlmRegister14HariBlmCekFisik);

                //                //panggil form pin
                //                //pin.frmPinFinance ifrmpin = new pin.frmPinFinance(this, 0, 11, 10, RowID_, DateTime.Today); //pin ke 1
                //                //ifrmpin.MdiParent = Program.MainForm;
                //                //Program.MainForm.RegisterChild(ifrmpin);
                //                //ifrmpin.Show();

                //                Kode = "CTKREG";
                //                CekCounter();
                //                flagpin = Convert.ToInt32(dtCekCounter.Rows[0]["FLAGPIN"]);
                //                CekLastUpdateflag();

                //                if (Convert.ToDateTime(dtLastUpdate.Rows[0]["LastUpdatedTime"]) != GlobalVar.DateOfServer)
                //                {
                //                    flagpin = flagpin + 1;
                //                    if (flagpin > 2)
                //                    {
                //                        flagpin = 0;
                //                    }
                //                    //MessageBox.Show(flagpin.ToString());

                //                    if (flagpin == 0)
                //                    {
                //                        pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this, RowID_, Class.IdPIN.Bagian.CetakRegisterSPV, DateTime.Today, "Pin SPV");
                //                        ifrmpin.MdiParent = Program.MainForm;
                //                        Program.MainForm.RegisterChild(ifrmpin);
                //                        ifrmpin.Show();
                //                    }
                //                    else if (flagpin == 1)
                //                    {
                //                        pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this, RowID_, Class.IdPIN.Bagian.CetakRegisterSupport, DateTime.Today, "Pin Support(YYK)");
                //                        ifrmpin.MdiParent = Program.MainForm;
                //                        Program.MainForm.RegisterChild(ifrmpin);
                //                        ifrmpin.Show();
                //                    }
                //                    else if (flagpin == 2)
                //                    {
                //                        pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this, RowID_, Class.IdPIN.Bagian.CetakRegisterPKP, DateTime.Today, "Pin CTR/PKP");
                //                        ifrmpin.MdiParent = Program.MainForm;
                //                        Program.MainForm.RegisterChild(ifrmpin);
                //                        ifrmpin.Show();
                //                    }

                //                    //pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this,RowID_, Class.IdPIN.Bagian.CetakRegister, DateTime.Today, "Pin Cetak Register ");
                //                    //ifrmpin.MdiParent = Program.MainForm;
                //                    //Program.MainForm.RegisterChild(ifrmpin);
                //                    //ifrmpin.ShowDialog();
                //                }
                //                else
                //                {
                //                    if (PrnAktif != "0")
                //                        PrintOutInkjet(rpt(RowID_));
                //                    else
                //                        PrintOut(rpt(RowID_));

                //                    int index = -1;
                //                    index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                //                    DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                //                    DataRow dr = dv.Row;
                //                    dr["NPrint"] = "Ctk";
                //                    dtHeader.AcceptChanges();
                //                    dataGridHeader.RefreshEdit();
                //                }
                //            }
                //            else
                //            {
                //                if (PrnAktif != "0")
                //                    PrintOutInkjet(rpt(RowID_));
                //                else
                //                    PrintOut(rpt(RowID_));

                //                int index = -1;
                //                index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                //                DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                //                DataRow dr = dv.Row;
                //                dr["NPrint"] = "Ctk";
                //                dtHeader.AcceptChanges();
                //                dataGridHeader.RefreshEdit();
                //            }
                //        }
                //        else
                //        {
                //            if (PrnAktif == "0")
                //                PrintOut(rpt(RowID_));
                //            else
                //                PrintOutInkjet(rpt(RowID_));

                //            int index = -1;
                //            index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                //            DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                //            DataRow dr = dv.Row;
                //            dr["NPrint"] = "Ctk";
                //            dtHeader.AcceptChanges();
                //            dataGridHeader.RefreshEdit();
                //        }
                //    }
                //}
                //else
                //{
                //    Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                //    string Flag_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();

                //    //sementara ujicoba cetak
                //    //PrintOut(rpt(RowID_));
                //    //return;

                    
                //    if (Flag_ == "Ctk")
                //    {
                //        MessageBox.Show("Data Sudah Pernah Tercetak");
                //        return;
                //    }

                //    if (PrnAktif != "0")
                //        PrintOutInkjet(rpt(RowID_));
                //    else
                //        PrintOut(rpt(RowID_));

                //    int index = -1;
                //    index = dataGridHeader.SelectedCells[0].OwningRow.Index;

                //    DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                //    DataRow dr = dv.Row;
                //    dr["NPrint"] = "Ctk";
                //    dtHeader.AcceptChanges();
                //    dataGridHeader.RefreshEdit();
                //}
                #endregion

            }
        }


        private void CekCounter()
        {
            #region cek counter
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetPinCounter]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
                    dtCekCounter = db.Commands[0].ExecuteDataTable();
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
            #endregion
        }

        public void UpdateCounter()
        {
            #region Update counter
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetPinCounter]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
                    dtLastUpdate = db.Commands[0].ExecuteDataTable();
                }
                if (dtLastUpdate.Rows.Count > 0)
                {
                    DateTime asd = Convert.ToDateTime(dtLastUpdate.Rows[0]["LastUpdatedTime"]);
                    if (asd != DateTime.Today)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_UpdateFlagCetakReg"));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
                            dtUpdateCounter = db.Commands[0].ExecuteDataTable();
                        }
                        if (dtUpdateCounter.Rows.Count > 0)
                        {
                            flagpin = Convert.ToInt32(dtUpdateCounter.Rows[0]["FLAGPIN"]);
                        }
                    }
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
            #endregion
        }

        public void CekLastUpdateflag()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetPinCounter]"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, Kode));
                    dtLastUpdate = db.Commands[0].ExecuteDataTable();
                }
                //if (dtLastUpdate.Rows.Count > 0)
                //{
                //    DateTime asd = Convert.ToDateTime(dtLastUpdate.Rows[0]["LastUpdatedTime"]);
                //    if (asd != DateTime.Today)
                //    {
                //        UpdateCounter();
                //    }
                //}
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

        //private void DisplayReportNota14Hari(DataTable dt)
        //{

        //    //construct parameter
        //    string periode,Collector;
        //    periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate.Value).ToString("dd/MM/yyyy"));
        //    Collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
        //    List<ReportParameter> rptParams = new List<ReportParameter>();
        //    rptParams.Add(new ReportParameter("periode", periode));
        //    rptParams.Add(new ReportParameter("Collector", Collector));
        //    //List<ReportParameter> rptParams1 = new List<ReportParameter>();
        //    //rptParams1.Add(new ReportParameter("Periode", periode));

        //    //call report viewer
        //    frmReportViewer ifrmReport = new frmReportViewer("Register.NotaDlmRegBlmLunas.rdlc", rptParams, dt, "dsNotaBelumLunas14hari_Data");
        //    ifrmReport.Show();

        //    //frmReportViewer ifrmReport1 = new frmReportViewer("Register.rptNotaPiutangBlmAdaReg.rdlc", rptParams1, dt2, "dsNotaBelumAdaRegister_Data");
        //    //ifrmReport.Show();

        //    //frmReportViewer ifrmReport2 = new frmReportViewer("Register.rptNotaBlmCekFisik.rdlc", rptParams1, dt3, "dsNotaBlmCekFisik_Data");
        //    //ifrmReport.Show();
        //}


        private void DisplayReportNotaKurang14Hari(DataTable dt)
        {

            //construct parameter
            string periode, Collector;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate.Value).ToString("dd/MM/yyyy"));
            Collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("periode", periode));
            rptParams.Add(new ReportParameter("Collector", Collector));
            //List<ReportParameter> rptParams1 = new List<ReportParameter>();
            //rptParams1.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Register.NotaDlmRegBlmLunas.rdlc", rptParams, dt, "dsNotaBelumLunas14hari_Data");
            ifrmReport.Show();

            //frmReportViewer ifrmReport1 = new frmReportViewer("Register.rptNotaPiutangBlmAdaReg.rdlc", rptParams1, dt2, "dsNotaBelumAdaRegister_Data");
            //ifrmReport.Show();

            //frmReportViewer ifrmReport2 = new frmReportViewer("Register.rptNotaBlmCekFisik.rdlc", rptParams1, dt3, "dsNotaBlmCekFisik_Data");
            //ifrmReport.Show();
        }


        private void DisplayReportNotaBlmAdaReg(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate.Value).ToString("dd/MM/yyyy"));
            //collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("Collector", collector));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Register.rptNotaPiutangBlmAdaReg.rdlc", rptParams, dt, "dsNotaBelumAdaRegister_Data");
            ifrmReport.Show();
        }


        private void DisplayReportNotaDLmReg14HariBlmCekFisik(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate.Value).ToString("dd/MM/yyyy"));
            //collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));
            //rptParams.Add(new ReportParameter("Collector", collector));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Register.rptNotaDalamRegister14HariBelumCekFisik.rdlc", rptParams, dt, "dsNotaDlmReg14HariBlmCekFisik_Data");
            ifrmReport.Show();
        }


        private void DisplayReportNotaCekFisik(DataTable dt)
        {

            //construct parameter
            string periode;
            periode = String.Format("{0} s/d {1}", ((DateTime)rangeDateBox1.FromDate.Value).ToString("dd/MM/yyyy"), ((DateTime)rangeDateBox1.ToDate.Value).ToString("dd/MM/yyyy"));
            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("Periode", periode));

            //call report viewer
            frmReportViewer ifrmReport = new frmReportViewer("Register.rptNotaBlmCekFisik.rdlc", rptParams, dt, "dsNotaBlmCekFisik_Data");
            ifrmReport.Show();
        }

        public void RegBlmSelesai()
        {
            //Register yang belum diselesaikan
            //dalam 1 wilayah terdapat collector yang sama
            //tanggal kembali fisik kosong
           
            try
            {
                //cari jangka waktu 35 hari kebelakang
                Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                string collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_TagihanRegBlmSelesai]"));
                    db.Commands[0].Parameters.Add(new Parameter("@collector", SqlDbType.VarChar, collector));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtRegBlmSelese = db.Commands[0].ExecuteDataTable();
                }

                if (dtRegBlmSelese.Rows.Count > 0)
                {
                    MessageBox.Show("Ada Register yang belum terselesaikan");
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

        public void notakurang14hari()
        {
            //nama collector,wilayah sama dan tagihan belum lunas
            //minta pin spv + keluar laporan nota dalam register yang belum lunas 14 hari
            //panggil form pin spv, administrator,-->frmpasswordSpv
            try
            {
                //cari jangka waktu 14 hari kebelakang
                Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                string collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaBlmLunasKurang14Hari]"));
                    db.Commands[0].Parameters.Add(new Parameter("@collector", SqlDbType.VarChar, collector));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtNotakurang14Hari = db.Commands[0].ExecuteDataTable();
                }

                if (dtNotakurang14Hari.Rows.Count > 0)
                {
                    //Administrasi.frmPasswordSpv ifrmChild = new Administrasi.frmPasswordSpv();
                    //ifrmChild.WindowState = FormWindowState.Normal;
                    //ifrmChild.ShowDialog();
                    //DisplayReportNotaBlmLunas14hari(dtNota14Hari);
                }
                else
                {
                    return;
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

        public void nota14hari()
        {
            //nama collector,wilayah sama dan tagihan belum lunas
            //minta pin spv + keluar laporan nota dalam register yang belum lunas 14 hari
            //panggil form pin spv, administrator,-->frmpasswordSpv
            try
            {
                //cari jangka waktu 14 hari kebelakang
                Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                string collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaBlmLunas14Hari]"));
                    db.Commands[0].Parameters.Add(new Parameter("@collector", SqlDbType.VarChar, collector));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtNota14Hari = db.Commands[0].ExecuteDataTable();
                }

                if (dtNota14Hari.Rows.Count > 0)
                {
                    //Administrasi.frmPasswordSpv ifrmChild = new Administrasi.frmPasswordSpv();
                    //ifrmChild.WindowState = FormWindowState.Normal;
                    //ifrmChild.ShowDialog();
                    //DisplayReportNotaBlmLunas14hari(dtNota14Hari);
                }
                else
                {
                    return;
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

        public void notaCekFisik()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaBelumCekFisik2]"));
                    //db.Commands[0].Parameters.Add(new Parameter("@collector", SqlDbType.VarChar, collector));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtNotaBlmCekFisik = db.Commands[0].ExecuteDataTable();
                }

                if (dtNotaBlmCekFisik.Rows.Count > 0)
                {
                    MessageBox.Show("Ada Nota yang belum Cek Fisik");
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

        public void NotaBelumBerregister()
        {
            try
            {
                //cari jangka waktu 35 hari kebelakang
                //Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                //string collector = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value);
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaBelumAdaReg2]"));
                    //db.Commands[0].Parameters.Add(new Parameter("@collector", SqlDbType.VarChar, collector));
                    //db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtNotaBlmRegister = db.Commands[0].ExecuteDataTable();
                }

                if (dtNotaBlmRegister.Rows.Count > 0)
                {
                    MessageBox.Show("Ada Nota yang Belum Mempunyai register");
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


        public void NotaDlmRegister14HariBlmCekFisik()
        {
            try
            {
                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_NotaBlmCekfisikKurang14hari]"));
                    dtNotaDlmRegister14HariBlmCekFisik = db.Commands[0].ExecuteDataTable();
                }

                if (dtNotaDlmRegister14HariBlmCekFisik.Rows.Count > 0)
                {
                    MessageBox.Show("Ada Nota Dalam Register 14 Hari yang belum di cek fisik");
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


        public void PinRegister()
        {
            try
            {
                //cek pernah masukin pin apa engga
                Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_CekPinReg]"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, rowid));
                    dtPin = db.Commands[0].ExecuteDataTable();
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.HasValue && rangeDateBox1.ToDate.HasValue)
            {
                RefreshHeader(rangeDateBox1.FromDate.Value, rangeDateBox1.ToDate.Value);
            }
        }
               
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void tglKmbaliFisik()
        {
            Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("[usp_RegisterUpdateTglKembaliFisik]"));
                db.Commands[0].Parameters.Add(new Parameter("@rowid", SqlDbType.UniqueIdentifier, rowid));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
         if (dataGridDetail.RowCount>0 && dataGridHeader.SelectedCells.Count>0)
         {
             if (e.Control == true &&  e.KeyCode == Keys.P)
             {
                 cmdPrint.PerformClick();
             }
         }

            switch (e.KeyCode)
            {
                case Keys.Insert:
                    {
                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                        {
                            bool isValidated = LookupInfoValue.CekValidasiRegister();
                            if (isValidated)
                            {
                                DataTable dtHeader1 = new DataTable();
                                using (Database db = new Database(GlobalVar.DBName))
                                {
                                    db.Commands.Add(db.CreateCommand("[usp_Cegatan_TagihH_Insert]"));
                                    dtHeader1 = db.Commands[0].ExecuteDataTable();
                                }

                                if (dtHeader1.Rows.Count > 0)
                                {
                                    MessageBox.Show("Ada Register yang belum tercetak, Cetak Register terlebih dahulu untuk membuat register selanjutnya");
                                    return;
                                }
                            }
                        }

                        Register.frmRegisterUpdate ifrmChild = new Register.frmRegisterUpdate(this, _lcabang);
                        ifrmChild.ShowDialog();
                    }
                    break;

                case Keys.Space:
                    {
                        string tglkembalifisik = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliFisik"].Value.ToString());
                        if (tglkembalifisik != "")
                        {
                            MessageBox.Show("Tidak Bisa merubah data ini");
                            
                            return;
                        }
                        else
                        {
                            if (dataGridHeader.SelectedCells.Count > 0)
                            {
                                Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                                string CollectorID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["CollectorID"].Value.ToString();
                                Register.frmRegisterCollectorUpdate ifrmChild = new Register.frmRegisterCollectorUpdate(this, RowID_, CollectorID_);
                                ifrmChild.ShowDialog();
                            }
                        }
                    }
                    break;

                case Keys.F8:
                    string KembaliFisik = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliFisik"].Value.ToString();
                    if (KembaliFisik != "")
                    {
                        MessageBox.Show("Register Sudah di closing");
                    }
                    else
                    {
                    
                        DialogResult jawab = MessageBox.Show("Register ini mau di Closing ?","Konfirmasi", MessageBoxButtons.YesNo);
                        if (jawab == DialogResult.Yes)
                        {
                            //masukin pin dari ho 

                            //kalo pin nya udah bener baru ngisi tanggal kembali nya tanggal sekarang
                            //Guid regIDDetail = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                            Guid regID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;

                            //pin.frmPinFinance ifrmpin = new pin.frmPinFinance(this, 0, 9, 10, regID, DateTime.Today); //pin ke 1
                            //ifrmpin.MdiParent = Program.MainForm;
                            //Program.MainForm.RegisterChild(ifrmpin);
                            //ifrmpin.Show();

                            pin.frmPinHarian ifrmpin = new pin.frmPinHarian(this, regID, Class.IdPIN.Bagian.ClosingRegister, DateTime.Today, "Pin Closing Register ");  //pin ke 1
                            ifrmpin.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmpin);
                            ifrmpin.Show();
                            return;
                        }
                    }
                    break;


                case Keys.Delete:
                    if (dataGridHeader.SelectedCells.Count > 0)
                    {
                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                        {
                            Guid RowidHeader = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                            DataTable dtDeleteHeader = new DataTable();
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("[usp_Cegatan_TagihH_Delete]"));
                                db.Commands[0].Parameters.Add(new Parameter("@Rowid", SqlDbType.UniqueIdentifier, RowidHeader));
                                dtDeleteHeader = db.Commands[0].ExecuteDataTable();
                            }
                            if (dtDeleteHeader.Rows.Count > 0)
                            {
                                MessageBox.Show("Tidak bisa hapus data, hapus data detail terlebih dahulu");
                                return;
                            }
                            else
                            {

                                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return;
                                }

                                string NPrint_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
                                if (NPrint_ != "0")
                                {
                                    if (!SecurityManager.IsManager())
                                    {
                                        if (!SecurityManager.AskPasswordManager())
                                        {
                                            return;
                                        }
                                    }
                                }
                                Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                                if (ChekPembayaran(RowID_))
                                {
                                    MessageBox.Show("Sudah ada Pemabayaran");
                                    return;
                                }
                                try
                                {
                                    int i = 0;
                                    int n = 0;
                                    i = dataGridHeader.SelectedCells[0].RowIndex;
                                    n = dataGridHeader.SelectedCells[0].ColumnIndex;
                                    DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                                    DataRow dr = dv.Row;
                                    DeleteData(RowID_);

                                    //Refresh Data

                                    dr.Delete();
                                    dtHeader.AcceptChanges();
                                    dataGridHeader.Focus();
                                    if (dataGridHeader.RowCount > 0)
                                    {
                                        if (i == 0)
                                        {
                                            dataGridHeader.CurrentCell = dataGridHeader.Rows[0].Cells[n];
                                            dataGridHeader.RefreshEdit();
                                        }
                                        else
                                        {
                                            dataGridHeader.CurrentCell = dataGridHeader.Rows[i - 1].Cells[n];
                                            dataGridHeader.RefreshEdit();
                                        }



                                    }
                                }

                                catch (System.Exception ex)
                                {
                                    Error.LogError(ex);
                                }


                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }

                            string NPrint_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
                            //if (NPrint_ != "0")
                            //{
                            //    if (!SecurityManager.IsManager())
                            //    {
                            //        if (!SecurityManager.AskPasswordManager())
                            //        {
                            //            return;
                            //        }
                            //    }
                            //}
                            Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                            if (ChekPembayaran(RowID_))
                            {
                                MessageBox.Show("Sudah ada Pemabayaran");
                                return;
                            }
                            try
                            {
                                int i = 0;
                                int n = 0;
                                i = dataGridHeader.SelectedCells[0].RowIndex;
                                n = dataGridHeader.SelectedCells[0].ColumnIndex;
                                DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                                DataRow dr = dv.Row;
                                DeleteData(RowID_);

                                //Refresh Data

                                dr.Delete();
                                dtHeader.AcceptChanges();
                                dataGridHeader.Focus();
                                if (dataGridHeader.RowCount > 0)
                                {
                                    if (i == 0)
                                    {
                                        dataGridHeader.CurrentCell = dataGridHeader.Rows[0].Cells[n];
                                        dataGridHeader.RefreshEdit();
                                    }
                                    else
                                    {
                                        dataGridHeader.CurrentCell = dataGridHeader.Rows[i - 1].Cells[n];
                                        dataGridHeader.RefreshEdit();
                                    }
                                }
                            }

                            catch (System.Exception ex)
                            {
                                Error.LogError(ex);
                            }

                        }
                    }
        
                    break;

                case Keys.F2:
                    {
                        if (dataGridHeader.SelectedCells.Count == 0)
                        {
                            return;
                        }
                        int index = -1;
                        index = dataGridHeader.SelectedCells[0].OwningRow.Index;
                        bool Flag_ = Convert.ToBoolean(dataGridHeader.SelectedCells[0].OwningRow.Cells["Flag"].Value);

                        DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                        DataRow dr = dv.Row;
                        dr["Flag"] = !Flag_;
                        dtHeader.AcceptChanges();
                        dataGridHeader.RefreshEdit();
                    }
                    break;

                //case Keys.F8:
                //    {
                //        if (dataGridHeader.SelectedCells.Count > 0)
                //        {
                //            Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;

                //            string CollectorID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembali"].Value.ToString().Trim();
                //            DateTime tgl_ = DateTime.Now;
                //            if(CollectorID_!="")
                //            {
                //                tgl_ = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembali"].Value;
                //            }
                //            Register.frmRegisterTglKembaliUpdate ifrmChild = new Register.frmRegisterTglKembaliUpdate(this, RowID_, CollectorID_,tgl_);
                //            ifrmChild.ShowDialog();
                //        }

                //    }
                //    break;
            }
        }

        private void dataGridHeader_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].RowIndex != _PrevGrid1)
                {
                    RefreshDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value);
                }
                _PrevGrid1 = dataGridHeader.SelectedCells[0].RowIndex;
                selectedGrid = enumSelectedGrid.HeaderSelected;
            }
            else
            {
                _PrevGrid1 = -1;
            }

            //groupBox1.Visible = true;
            //groupBox2.Visible = true;
            //lblInfo.Visible = true;
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            //groupBox1.Visible = true;
            //groupBox2.Visible = true;
            //lblInfo.Visible = true;
        }

        private void dataGridHeader_DoubleClick(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            if (dataGridHeader.SelectedCells.Count == 0)
            {
                return;
            }
            int index = -1;
            index = dataGridHeader.SelectedCells[0].OwningRow.Index;
            bool Flag_ =  Convert.ToBoolean(dataGridHeader.SelectedCells[0].OwningRow.Cells["Flag"].Value);

            DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
            DataRow dr = dv.Row;
            dr["Flag"] = !Flag_;
            dtHeader.AcceptChanges();
            dataGridHeader.RefreshEdit();
//                         dr[]
//             dataGridHeader
            //dataGridHeader.Rows[index]["Flag"] = !Flag_;
            //--UpdateHeader(index, noDOBO, dtDO.Rows[index]["StatusBO"]);

        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    string tglkembalifisik = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliFisik"].Value.ToString());
                    if (tglkembalifisik != "")
                    {
                        MessageBox.Show("Tidak Bisa merubah data ini");
                        return;
                    }

                    break;
                case Keys.Insert:
                    if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                    {
                        if (dataGridHeader.SelectedCells[0].OwningRow.Cells["tglkembaliFisik"].Value.ToString() != "" || dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString() != "0")
                        {
                            MessageBox.Show("tidak dapat Menginput data register ini");
                            return;
                        }

                        else
                        {
                            ////panggil form pin untuk menambah
                            //Register.frmPinRegister ifrmChild = new Register.frmPinRegister();
                            //ifrmChild.MdiParent = Program.MainForm;
                            //Program.MainForm.RegisterChild(ifrmChild);
                            //ifrmChild.Show();
                            if (dataGridHeader.SelectedCells.Count > 0)
                            {
                                Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                                string RecordID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordIDHeader"].Value.ToString();
                                frmRegisterDetailUpdate ifrmChild = new frmRegisterDetailUpdate(this, RowID_, RecordID_);
                                ifrmChild.WindowState = FormWindowState.Normal;
                                ifrmChild.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        if (dataGridHeader.SelectedCells.Count > 0)
                        {
                            Guid RowID_ = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
                            string RecordID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["RecordIDHeader"].Value.ToString();
                            frmRegisterDetailUpdate ifrmChild = new frmRegisterDetailUpdate(this, RowID_, RecordID_);
                            ifrmChild.WindowState = FormWindowState.Normal;
                            ifrmChild.ShowDialog();
                        }
                    }
                    break;

                case Keys.Delete:

                    if (dataGridDetail.SelectedCells.Count > 0)
                    {
                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                        {
                            //kalo dia nprint nya 0 brti di minta pin
                            string ctk = Convert.ToString(dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value);
                            if (ctk == "0")
                            {
                                Guid regIDDetail = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                                //Guid regID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;

                                //panggil formpin kalo pin nya bener brti bisa dihapus
                                pin.frmPinFinance ifrmpin = new pin.frmPinFinance(this, 0, 10, 10, regIDDetail, DateTime.Today); //pin ke 2
                                ifrmpin.MdiParent = Program.MainForm;
                                Program.MainForm.RegisterChild(ifrmpin);
                                ifrmpin.Show();

                                return;
                            }

                            if (ctk == "Ctk")
                            {
                                MessageBox.Show("Data Tidak Dapat dihapus");
                                return;
                            }
                        }

                        #region ijo

                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                        {
                            if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            string NPrint_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString();
                            if (NPrint_ != "0")
                            {
                                if (!SecurityManager.AskPasswordManager())
                                {
                                    return;
                                }
                            }
                        }

                        Guid RowID_ = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                        Guid HeaderID_ = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["HeaderIDDetail"].Value;

                        if (GlobalVar.Gudang != "2808" && GlobalVar.Gudang != "2803")
                        {
                            if (ChekPembayaranDetail(RowID_))
                            {
                                MessageBox.Show("Sudah ada Pemabayaran");
                                return;
                            }
                        }


                        int i = 0;
                        int n = 0;
                        i = dataGridDetail.SelectedCells[0].RowIndex;
                        n = dataGridDetail.SelectedCells[0].ColumnIndex;
                        DataRowView dv = (DataRowView)dataGridDetail.SelectedCells[0].OwningRow.DataBoundItem;

                        DataRow dr = dv.Row;

                        
                        DeleteDataDetail(RowID_);
                        RefreshDetail((Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value);

                        //dr.Delete();
                        dtDetail.AcceptChanges();
                        dataGridDetail.Focus();
                        dataGridDetail.RefreshEdit();
                        if (dataGridDetail.RowCount > 0)
                        {
                            if (i == 0)
                            {
                                dataGridDetail.CurrentCell = dataGridDetail.Rows[0].Cells[n];
                                dataGridDetail.RefreshEdit();
                            }
                            else
                            {
                                dataGridDetail.CurrentCell = dataGridDetail.Rows[i - 1].Cells[n];
                                dataGridDetail.RefreshEdit();
                            }

                        }

                        RefreshRowDataHeader(HeaderID_);

                        break;
                        #endregion

                    }
                    break;
            }
        }

        private void dataGridDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                if (dataGridDetail.SelectedCells[0].RowIndex != _PrevGrid2)
                {
                    RefreshSubDetail((Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value);
                }
                _PrevGrid2 = dataGridDetail.SelectedCells[0].RowIndex;
                selectedGrid = enumSelectedGrid.DetailSelected;
            }
            else
            {
                _PrevGrid2 = -1;
            }
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            //groupBox1.Visible = true;
            //groupBox2.Visible = false;
            //lblInfo.Visible = false;
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridHeader.Rows[e.RowIndex].Cells["Flag"].Value.ToString() != "0")
                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.OrangeRed;
            else
                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridDetail.Rows[e.RowIndex].Cells["CekFisik"].Value.ToString() == "False" || dataGridDetail.Rows[e.RowIndex].Cells["CekFisik"].Value.ToString() == "")
            {
              dataGridDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                dataGridDetail.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            }          

        }

        private void dataGridSubDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.SubDetailSelected;
            lblInfo.Visible = false;
        }

        private void dataGridSubDetail_SelectionChanged(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.SubDetailSelected;
            //groupBox1.Visible = false;
            //groupBox2.Visible = false;
        }

        private void dataGridSubDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.Insert:
                    if (dataGridDetail.SelectedCells.Count>0)
                    {
                       Guid RowID_ = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["RowIDDetail"].Value;
                       string RecordID_ = dataGridDetail.SelectedCells[0].OwningRow.Cells["RecordIDDetail"].Value.ToString();
                       frmRegisterSubDetailUpdate ifrmChild = new frmRegisterSubDetailUpdate(this,_lcabang, RowID_, RecordID_);
                       ifrmChild.WindowState = FormWindowState.Normal;
                       ifrmChild.ShowDialog();
                            
                    }
            	break;
            case Keys.Space:
                if (dataGridSubDetail.SelectedCells.Count > 0)
                {
                    Guid RowID_ = (Guid)dataGridSubDetail.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    frmRegisterSubDetailUpdate ifrmChild = new frmRegisterSubDetailUpdate(this, _lcabang, RowID_);
                    ifrmChild.WindowState = FormWindowState.Normal;
                    ifrmChild.ShowDialog();

                }
                break;
            }
        }

        private void cmdRiwayat_Click(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                Guid KPID_ = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["KPID"].Value;
                DateTime TglReg_ = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglReg"].Value;
                Register.frmRegisterHistory ifrmChild = new frmRegisterHistory(this,KPID_,TglReg_);
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();
            }
        }

        private void cmdKunjung_Click(object sender, EventArgs e)
        {
            Register.frmRptRegisterKunjungan ifrmChild = new frmRptRegisterKunjungan();
            ifrmChild.WindowState = FormWindowState.Normal;
            ifrmChild.ShowDialog();
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
        {
        }

        private void cmdCekNotaLunas_Click(object sender, EventArgs e)
        {
            CekNotaLunas();

            cekNotaFisik();
            if (dtCekNotaFisik.Rows.Count == 0)
            {
                CekKembaliFisik();
            }
            else
            {
                return;
            }
        }

        public void CekNotaLunas()
        {
            Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
            DataTable dtlunas;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("fsp_ceknotalunas"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                dtlunas = db.Commands[0].ExecuteDataTable();
            }
        }

        private void cekNotaFisik()
        {
            NoRegister = dataGridHeader.SelectedCells[0].OwningRow.Cells["NoReg"].Value.ToString();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_CekNotaFisik"));
                db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, NoRegister));
                dtCekNotaFisik = db.Commands[0].ExecuteDataTable();
            }
        }

        public void CekKembaliFisik()
        {
            Guid rowid = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;
            DataTable dtFISIK;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("fsp_ceknotakembalifisik"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                dtFISIK = db.Commands[0].ExecuteDataTable();
            }
        }

        private int GetJmlScan()
        {
            int jmlScan = 0;

            if (dataGridDetail.DataSource != null)
            {
                try
                {
                    DataTable dt = (DataTable)dataGridDetail.DataSource;
                    DataRow[] rows = dt.Select("Barcode <> ''");
                    jmlScan = rows.Length;
                }
                catch { }
            }

            return jmlScan;
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (barcode == string.Empty)
                {
                    txtBarcode.Focus();
                    return;
                }

                if (barcode.Length > 12)
                    barcode = barcode.Substring(0, 12);

                if (dataGridHeader.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Silahkan pilih register-nya terlebih dahulu.");
                    return;
                }

                if (int.Parse(lblJmlScan.Text) == dataGridDetail.Rows.Count)
                {
                    MessageBox.Show("Semua nota dalam register ini sudah di-scan.");
                    return;
                }

                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliFisik"].Value != null)
                {
                    string tglFisik = dataGridHeader.SelectedCells[0].OwningRow.Cells["TglKembaliFisik"].Value.ToString();
                    if (tglFisik != string.Empty)
                    {
                        MessageBox.Show("Tanggal Kembali Fisik sudah terisi. Silahkan lanjut ke Register yang lain.");
                        txtBarcode.SelectAll();
                        txtBarcode.Focus();
                        return;
                    }
                }

                Guid headerId = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDHeader"].Value;

                if (GlobalVar.Gudang.Substring(0, 1) != "9")
                {
                    bool hasExpedition = LookupInfoValue.CekEkspedisi();
                    string cekEkspedisi = "1";
                    if (!hasExpedition)
                        cekEkspedisi = "0";

                    DataTable dt = new DataTable();

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetail_LIST_ByRecID"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                        db.Commands[0].Parameters.Add(new Parameter("@CekEkspedisi", SqlDbType.VarChar, cekEkspedisi));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    string kpRecId = string.Empty;

                    if (dt.Rows.Count == 0 && hasExpedition)
                    {
                        frmRegisterUpdateBarcode dialog = new frmRegisterUpdateBarcode(headerId, barcode);
                        dialog.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK && dialog.KpRecId != string.Empty)
                            kpRecId = dialog.KpRecId;
                        else
                            return;
                    }
                    else if (dt.Rows.Count == 0 && !hasExpedition)
                    {
                        MessageBox.Show("Barcode tidak ditemukan di nota penjualan.");
                        return;
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        frmRegisterBarcodeDouble dialog = new frmRegisterBarcodeDouble(dt);
                        dialog.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK && dialog.KpRecId != string.Empty)
                            kpRecId = dialog.KpRecId;
                        else
                            return;
                    }
                    else
                        kpRecId = dt.Rows[0]["KPRecID"].ToString();



                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetail_UPDATE_Barcode"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                        db.Commands[0].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, kpRecId));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    RefreshDetail(headerId);

                    int jmlScan = GetJmlScan();

                    lblJmlScan.Text = jmlScan.ToString();

                    if (jmlScan == dataGridDetail.Rows.Count)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tagihan_Barcode_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
                else
                {

                    bool hasExpedition = false;
                    string cekEkspedisi= "0";

                    DataTable dt = new DataTable();

                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetail_LIST_ByRecID_9x"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                        db.Commands[0].Parameters.Add(new Parameter("@CekEkspedisi", SqlDbType.VarChar, cekEkspedisi));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    string kpRecId = string.Empty;

                    if (dt.Rows.Count == 0 && hasExpedition)
                    {
                        frmRegisterUpdateBarcode dialog = new frmRegisterUpdateBarcode(headerId, barcode);
                        dialog.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK && dialog.KpRecId != string.Empty)
                            kpRecId = dialog.KpRecId;
                        else
                            return;
                    }
                    else if (dt.Rows.Count == 0 && !hasExpedition)
                    {
                        MessageBox.Show("Barcode tidak ditemukan.");
                        //MessageBox.Show("Barcode tidak ditemukan di nota penjualan.");
                        return;
                    }
                    else if (dt.Rows.Count > 1)
                    {
                        frmRegisterBarcodeDouble dialog = new frmRegisterBarcodeDouble(dt);
                        dialog.ShowDialog();
                        if (dialog.DialogResult == DialogResult.OK && dialog.KpRecId != string.Empty)
                            kpRecId = dialog.KpRecId;
                        else
                            return;
                    }
                    else
                        kpRecId = dt.Rows[0]["KPRecID"].ToString();



                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_TagihanDetail_UPDATE_Barcode"));
                        db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                        db.Commands[0].Parameters.Add(new Parameter("@KPRecID", SqlDbType.VarChar, kpRecId));
                        db.Commands[0].Parameters.Add(new Parameter("@Barcode", SqlDbType.VarChar, barcode));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    RefreshDetail(headerId);

                    int jmlScan = GetJmlScan();

                    lblJmlScan.Text = jmlScan.ToString();

                    if (jmlScan == dataGridDetail.Rows.Count)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Tagihan_Barcode_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, headerId));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
                txtBarcode.SelectAll();
                txtBarcode.Focus();
            }
        }

        private void cmdPrintBPP_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.Rows.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells[NPrint.Name].Value.ToString() != "Ctk")
                {
                    MessageBox.Show("Register Belum di cetak, cetak register terlebih dahulu");
                    return;
                }
                else
                {
                    DataTable dtNoBPP = new DataTable();
                    DataTable dtData = new DataTable();
                    //cari apakah noreg tersebut sudah ada di tabel bpp, kalo udah ada di hapus dulu, bppheader dan detailnya
                    //menjaga printer mati tengah jalan
                    string _NoReg = dataGridHeader.SelectedCells[0].OwningRow.Cells[NoReg.Name].Value.ToString();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_BPP_FilterNoReg"));
                        db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, _NoReg));
                        dtData = db.Commands[0].ExecuteDataTable();
                    }
                    if (dtData.Rows.Count > 0)
                    {
                        Guid _Row = (Guid) dtData.Rows[0]["RowID"];
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_Bpp_Clear"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _Row));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }

                    //end of cek noreq

                    //cari nobpp terakhir itu nomer berapa (udah di bikin sp)
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_BPPGetLastBPP"));
                        //db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
                        dtNoBPP = db.Commands[0].ExecuteDataTable();
                    }
                    NoBpp = Convert.ToInt32(dtNoBPP.Rows[0]["NoBPP"].ToString());
                    //end
                    NoBpp = NoBpp + 1;
                    GetNo(NoBpp);
                    string NoBPPAwal = BPPNo;
                    Guid _RowIDHeader = Guid.NewGuid();
                    UpdateBPP(NoBPPAwal, _RowIDHeader, _NoReg);
                    int lembar = 0;
                    // cari ada berapa banyak toko yang ada di detail
                    DataTable dtToko = dtDetail.DefaultView.ToTable(true, "KodeToko").Copy();
                    for (int i = 0; i < dtToko.Rows.Count; i++)
                    {
                        
                        KodeToko = dtToko.Rows[i]["KodeToko"].ToString();
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataSet ds = new DataSet();
                            DataTable dt = new DataTable();

                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("rsp_KartuPiutang_RekapPembayaran"));
                                db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko));
                                ds = db.Commands[0].ExecuteDataSet();
                            }

                            if (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0)
                            {
                                NoBpp = NoBpp + lembar;
                                GetNo(NoBpp);
                                CetakBPP(ds, BPPNo);
                                lembar = lembar + 1;
                                //update di table bpp nya, 
                                UpdateBPPDetail(KodeToko, _RowIDHeader);
                            }

                            
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                        }

                        //update lembar bppHeader
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            // HEADERS
                            db.Commands.Add(db.CreateCommand("usp_BPPUpdate"));
                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                            db.Commands[0].Parameters.Add(new Parameter("@Lembar", SqlDbType.Int, lembar));
                            db.Commands[0].ExecuteNonQuery();

                        }
                    }
                }
            }

        }

        private void UpdateBPP(string NoAwalBPP, Guid _RowIDHeader, string _NoReg)
        {
            
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    // HEADERS
                    db.Commands.Add(db.CreateCommand("usp_BPP_Insert"));
                    DataTable dtToko = dtDetail.DefaultView.ToTable(true, "KodeToko").Copy();

                    string _KodeKolektor = dataGridHeader.SelectedCells[0].OwningRow.Cells[CollectorID.Name].Value.ToString();
                    db.Commands[0].Parameters.Clear();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBPPAwal", SqlDbType.VarChar, NoAwalBPP));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, _KodeKolektor));
                    db.Commands[0].Parameters.Add(new Parameter("@GudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                    //db.Commands[0].Parameters.Add(new Parameter("@Lembar", SqlDbType.Int, Lembar));
                    db.Commands[0].Parameters.Add(new Parameter("@NoReg", SqlDbType.VarChar, _NoReg));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    //db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void UpdateBPPDetail(string _KodeToko, Guid _RowIDHeader)
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_BPPDetail_Insert"));
                    //for (int y = 0; y < dtToko.Rows.Count; y++)
                    //{
                    DateTime TglBPP = DateTime.Today;
                    //GetNo(NoBpp + 1);
                    GetDataToko(_KodeToko);

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowIDHeader));
                    db.Commands[0].Parameters.Add(new Parameter("@NoBPP", SqlDbType.VarChar, BPPNo));
                    db.Commands[0].Parameters.Add(new Parameter("@TglBPP", SqlDbType.DateTime, TglBPP));
                    db.Commands[0].Parameters.Add(new Parameter("@NamaToko", SqlDbType.VarChar, _NamaToko));
                    db.Commands[0].Parameters.Add(new Parameter("@IdWIll", SqlDbType.VarChar, _WilID));
                    db.Commands[0].Parameters.Add(new Parameter("@NoNota", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@TglNota", SqlDbType.DateTime, null));
                    db.Commands[0].Parameters.Add(new Parameter("@RpNota", SqlDbType.Money, 0));

                    db.Commands[0].Parameters.Add(new Parameter("@JenisPembayaran", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@RpBayar", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagAudit", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@KetAudit", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetDataToko(string KodeToko)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodetoko", SqlDbType.VarChar, KodeToko));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                _NamaToko = dt.Rows[0]["NamaToko"].ToString();
                _WilID = dt.Rows[0]["WilID"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetNo(int NoBPP)
        {
            
            No = NoBPP.ToString();
            PanjangNo = No.Length;

            if (PanjangNo == 1)
            {
                BPPNo = ("00000" + No);
            }
            else if (PanjangNo == 2)
            {
                BPPNo = ("0000" + No);
            }
            else if (PanjangNo == 3)
            {
                BPPNo = ("000" + No);
            }
            else if (PanjangNo == 4)
            {
                BPPNo = ("00" + No);
            }
            else if (PanjangNo == 5)
            {
                BPPNo = ("0" + No);
            }
            else if (PanjangNo == 6)
            {
                BPPNo = (No);
            }
        }


        private void CetakBPP(DataSet ds, string nBPP)
        {
            try
            {
                DataTable dt = new DataTable();
                List<ReportParameter> rptParams = new List<ReportParameter>();

                DateTime tglBPP = DateTime.Parse(DateTime.Now.ToString());

                rptParams.Add(new ReportParameter("NoBPP", nBPP));
                rptParams.Add(new ReportParameter("Tanggal", tglBPP.ToString()));
                rptParams.Add(new ReportParameter("NamaToko", ds.Tables[6].Rows[0]["NamaToko"].ToString()));
                rptParams.Add(new ReportParameter("WilID", ds.Tables[6].Rows[0]["WilID"].ToString()));
                //rptParams.Add(new ReportParameter("Alamat", ds.Tables[6].Rows[0]["Alamat"].ToString()));

                List<DataTable> pTable = new List<DataTable>();
                pTable.Add(ds.Tables[0]);
                pTable.Add(ds.Tables[3]);
                pTable.Add(ds.Tables[7]);

                List<string> pDatasetName = new List<string>();
                pDatasetName.Add("dsKpiutang_Data");
                pDatasetName.Add("dsKpiutang_Data3");
                pDatasetName.Add("dsKpiutang_DataKosong");


                frmReportViewer ifrmReport = new frmReportViewer("Register.rptCetakBPP.rdlc", rptParams, pTable, pDatasetName);
                ifrmReport.Text = "BPP";
                ifrmReport.PrintRdlc();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdFixRoute_Click(object sender, EventArgs e)
        {
            Piutang.frmFixRouteRegisterPiutang ifrmChild = new Piutang.frmFixRouteRegisterPiutang(this);
            ifrmChild.ShowDialog();
            ifrmChild.WindowState = FormWindowState.Maximized;
        }

        List<Guid> CKIDS = new List<Guid>();
        private List<Guid> getCheckedIDs()
        {
            List<Guid> r = new List<Guid>();
            if (dataGridHeader.Rows.Count > 0)
            {
                foreach (DataGridViewRow c in dataGridHeader.Rows)
                {
                    if (c.Cells["colCheck"].Value == null) c.Cells["colCheck"].Value = false;
                    if (bool.Parse(c.Cells["colCheck"].Value.ToString())) r.Add(new Guid(c.Cells["RowIDHeader"].Value.ToString()));
                }
            }
            return r;
        }

        InPopup ipExports;
        private void btnExports_Click(object sender, EventArgs e)
        {
            if (ipExports == null) ipExports = new InPopup(this, pnlExports);
            ipExports.Open((Control)sender);
        }

        private void loggingError(Exception ex)
        {
            try
            {
                using (var db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_ErrorLog_INSERT]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglError", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@Source", SqlDbType.VarChar, (ex.Source != null ? ex.Source : "ISAFinance")));
                    db.Commands[0].Parameters.Add(new Parameter("@StackTrace", SqlDbType.VarChar, (ex.StackTrace != null ? ex.StackTrace : (new System.Diagnostics.StackTrace()).ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@Message", SqlDbType.VarChar, ex.Message));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (Exception) { }
        }

        InPopup ipWiserProgress;
        FakeProgress fpWiserProgress;
        private void btnSynchWiser_Click(object sender, EventArgs e)
        {
            Form thisx = this;
            if (ipWiserProgress == null) ipWiserProgress = new InPopup(this, pnlWiserProgress);
            if (fpWiserProgress == null) fpWiserProgress = new FakeProgress(progbWiserProgress2);
            ipExports.Close(true);

            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;

            ipWiserProgress.OpenDialog(thisx);
            progbWiserProgress.Value = 0;
            fpWiserProgress.Start();

            bgw.DoWork += (a, b) =>
            {
                List<Guid> ls = getCheckedIDs();
                if (ls.Count > 0)
                {
                    using (var db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_AppSetting_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, "Wiser_Host"));
                        DataTable dtbl = db.Commands[0].ExecuteDataTable();

                        string host = "https://devwiser.sas-autoparts.com";
                        if (dtbl.Rows.Count > 0) host = dtbl.Rows[0]["Value"].ToString();
                        else
                        {
                            b.Result = "Synch wiser gagal, karena belum di setting";
                            return;
                        }
                        db.Commands.Clear();

                        db.Commands.Add(db.CreateCommand("[usp_Tagihan_WISER_GET]"));
                        db.Commands.Add(db.CreateCommand("[usp_Tagihan_WISER_MARK]"));
                        int s = 0, f = 0, k = 0, n = 0, m = ls.Count;
                        foreach (Guid cid in ls)
                        {
                            if (bgw.CancellationPending)
                            {
                                b.Cancel = true;
                                return;
                            }

                            db.Commands[0].Parameters.Clear();
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cid));
                            DataSet dts = db.Commands[0].ExecuteDataSet();
                            if (dts.Tables.Count == 5)
                            {
                                JSON sobj = new JSON(JSONType.Object);
                                sobj.ObjAdd("KodeGudang", new JSON(GlobalVar.Gudang));

                                // 0: Tagihan & TagihanDetail
                                sobj.ObjAdd("Tagihan", new JSON(JSONType.Object));
                                string[][] cols = new string[][] {
                                    new string[] {
                                        "HRowID", "HTglReg", "HNoReg", "HTglKembali", "HPeriode2", "HCollectorID", "HWilayah", "HNPrint", "HLastUpdatedBy", "HLastUpdatedTime", "HSyncFlag"
                                    },
                                    new string[] {
                                        "RowID", "KPID", "RpTagih", "Keterangan", "LastUpdatedBy", "LastUpdatedTime"
                                    }
                                };
                                foreach (DataRow cur in dts.Tables[0].Rows)
                                {
                                    string key = cur["HRowID"].ToString();
                                    string key2 = cur["RowID"].ToString();

                                    JSON cdat;
                                    if (!sobj["Tagihan"].ObjExists(key))
                                    {
                                        cdat = new JSON(JSONType.Object);
                                        foreach (string col in cols[0]) cdat.ObjAdd(col, new JSON(cur[col]));
                                        cdat.ObjAdd("Details", new JSON(JSONType.Array));
                                        cdat.ObjAdd("Total", new JSON(0));
                                        sobj["Tagihan"].ObjAdd(key, cdat);
                                    }
                                    cdat = new JSON(JSONType.Object);
                                    foreach (string col in cols[1]) cdat.ObjAdd(col, new JSON(cur[col]));
                                    sobj["Tagihan"][key]["Details"].ArrAdd(cdat);
                                    sobj["Tagihan"][key]["Total"] = new JSON(sobj["Tagihan"][key]["Total"].NumberValue + double.Parse(cur["RpTagih"].ToString()));
                                }

                                // 1: KartuPiutang & KartuPiutangDetail
                                sobj.ObjAdd("KartuPiutang", new JSON(JSONType.Object));
                                cols = new string[][] {
                                    new string[] { 
                                        "HRowID", "HTagihanDetailID", "HTokoID", "HKodeToko", "HKodeSales", "HTglTransaksi", "HTglLink", "HNoTransaksi", "HTglJatuhTempo", "HJangkaWaktu", "HHariKirim", "HHariSales", "HUraian", "HTransactionType", "HTglKomitmuenKaAdm", "HKeteranganKomitmenKaAdm", "HTglKomitmenPKP", "HKeteranganKomitmenPKP", "HLastUpdatedBy", "HLastUpdatedTime"
                                    },
                                    new string[] {
                                        "RowID", "TglTransaksi", "KodeTransaksi", "Debet", "Uraian", "LastUpdatedBy", "LastUpdatedTime"
                                    }
                                };
                                foreach (DataRow cur in dts.Tables[1].Rows)
                                {
                                    string key = cur["HRowID"].ToString();
                                    string key2 = cur["RowID"].ToString();

                                    JSON cdat;
                                    if (!sobj["KartuPiutang"].ObjExists(key))
                                    {
                                        cdat = new JSON(JSONType.Object);
                                        foreach (string col in cols[0]) cdat.ObjAdd(col, new JSON(cur[col]));
                                        cdat.ObjAdd("Details", new JSON(JSONType.Array));
                                        sobj["KartuPiutang"].ObjAdd(key, cdat);
                                    }
                                    cdat = new JSON(JSONType.Object);
                                    foreach (string col in cols[1]) cdat.ObjAdd(col, new JSON(cur[col]));
                                    sobj["KartuPiutang"][key]["Details"].ArrAdd(cdat);
                                }

                                // 2: Toko
                                sobj.ObjAdd("Toko", new JSON(JSONType.Object));
                                cols = new string[][] {
                                    new string[] {
                                        "RowID", "TokoID", "TokoIDLama", "KodeToko", "NamaToko", "Alamat", "Propinsi", "Kota", "WillID", "Telp", "Fax", "PenanggungJawab", "Tgl1st", "Catatan", "nama_pemilik", "jenis_kelamin", "tempat_lhr", "TglLahir", "email", "no_rekening", "nama_bank", "np_npwp", "TipeBisnis", "HP", "LastUpdatedBy", "LastUpdatedTime"
                                    }
                                };
                                foreach (DataRow cur in dts.Tables[2].Rows)
                                {
                                    string key = cur["KodeToko"].ToString();
                                    JSON cdat = new JSON(JSONType.Object);
                                    foreach (string col in cols[0]) cdat.ObjAdd(col, new JSON(cur[col]));
                                    sobj["Toko"].ObjAdd(key, cdat);
                                }

                                // 3: Collector / Karyawan
                                sobj.ObjAdd("Collector", new JSON(JSONType.Object));
                                cols = new string[][] {
                                    new string[] {
                                        "Nama", "TglMasuk", "TglKeluar", "Kode", "LastUpdatedBy", "LastUpdatedTime"
                                    }
                                };
                                foreach (DataRow cur in dts.Tables[3].Rows)
                                {
                                    string key = cur["Kode"].ToString();
                                    JSON cdat = new JSON(JSONType.Object);
                                    foreach (string col in cols[0]) cdat.ObjAdd(col, new JSON(cur[col]));
                                    sobj["Collector"].ObjAdd(key, cdat);
                                }

                                // 4: Sales / Karyawan
                                sobj.ObjAdd("Sales", new JSON(JSONType.Object));
                                cols = new string[][] {
                                    new string[] {
                                        "NamaSales", "TglMasuk", "TglKeluar", "SalesID", "LastUpdatedBy", "LastUpdatedTime"
                                    }
                                };
                                foreach (DataRow cur in dts.Tables[4].Rows)
                                {
                                    string key = cur["SalesID"].ToString();
                                    JSON cdat = new JSON(JSONType.Object);
                                    foreach (string col in cols[0]) cdat.ObjAdd(col, new JSON(cur[col]));
                                    sobj["Sales"].ObjAdd(key, cdat);
                                }

                                // HttpWebResponse res = null;
                                try
                                {
                                    string url = host + "/api/tagihan/synch";
                                    // byte[] bdata = Encoding.UTF8.GetBytes("{\"data\":" + sobj.ToString() + "}");
                                    JSON fdata = new JSON(JSONType.Object);
                                    fdata.ObjAdd("data", sobj);

                                    XNet xn = new XNet(url, XNetMethod.POST, XNetMode.Synchronous);
                                    XNetThread xt = xn.Send(fdata, r =>
                                    {
                                        try
                                        {
                                            if (r.Error != null)
                                            {
                                                k += 1;
                                                loggingError(r.Error);
                                                return;
                                            }
                                            else if (r.Message != null && r.Message.Length > 0)
                                            {
                                                k += 1;
                                                loggingError(new Exception(r.Message));
                                                return;
                                            }

                                            JSON jres = JSON.Parse(r.Output);
                                            if (jres.Type == JSONType.Object)
                                            {
                                                if (jres.ObjExists("Result") && jres["Result"].BoolValue)
                                                {
                                                    if (jres.ObjExists("List") && jres["List"].Count > 0)
                                                    {
                                                        for (int ci = 0; ci < jres["List"].Count; ci++)
                                                        {
                                                            db.Commands[1].Parameters.Clear();
                                                            db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, new Guid(jres["List"][ci].StringValue)));
                                                            db.Commands[1].ExecuteNonQuery();
                                                        }
                                                        s += 1;
                                                    }
                                                    else
                                                    {
                                                        // a mean data was exists
                                                        db.Commands[1].Parameters.Clear();
                                                        db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, cid));
                                                        db.Commands[1].ExecuteNonQuery();
                                                        n += 1;
                                                    }
                                                }
                                                else
                                                {
                                                    if (jres.ObjExists("Msg")) loggingError(new Exception(jres["Msg"].StringValue));
                                                    f += 1;
                                                }
                                            }
                                            else
                                            {
                                                loggingError(new Exception("Server output is unexpected, " + r.Output));
                                                f += 1;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            loggingError(ex);
                                            k += 1;
                                        }
                                    });
                                }
                                catch (Exception Ex)
                                {
                                    loggingError(Ex);
                                    k += 1;
                                }
                            }
                            else n += 1;

                            double cr = (((double)(s + f + n + k) / (double)m) * 100.00);
                            bgw.ReportProgress((int)cr);
                        }

                        if (s == m) b.Result = true;
                        else if (n == m) b.Result = "Synch Wiser gagal, karena telah ada data";
                        else if (k == m) b.Result = "Synch Wiser gagal, karena ditolak / kegagalan server / koneksi";
                        else if (f == m) b.Result = "Synch Wiser gagal semua";
                        else b.Result = "Synch Wiser selesai,\n - berhasil: " + s + "\n - gagal: " + f + "\n - tolak server: " + k + "\n - telah ada: " + n;
                    }
                }
                else b.Result = "Tidak ada yang di pilih. Ceklis data terlebih dahulu";
            };
            bgw.ProgressChanged += (a, b) =>
            {
                progbWiserProgress.Value = b.ProgressPercentage;
                if (fpWiserProgress.IsEnabled) fpWiserProgress.Done();
                fpWiserProgress.Start();
            };
            bgw.RunWorkerCompleted += (a, b) =>
            {
                if (fpWiserProgress.IsEnabled) fpWiserProgress.Done();

                if (b.Cancelled) MessageBox.Show(thisx, "Synch telah di gagalkan");
                if (b.Error != null) MessageBox.Show(thisx, b.Error.Message);
                else if (b.Result == null) MessageBox.Show(thisx, "Terjadi kegagalan tidak dapat di handle");
                else if (b.Result.Equals(true)) MessageBox.Show(thisx, "Synch Wiser telah berhasil");
                else MessageBox.Show(thisx, b.Result.ToString());
                ipWiserProgress.Close(true);

                if (dataGridHeader.InvokeRequired) dataGridHeader.Invoke(new Action(() => RefreshHeader(rangeDateBox1.FromDate.Value, rangeDateBox1.ToDate.Value)));
                else RefreshHeader(rangeDateBox1.FromDate.Value, rangeDateBox1.ToDate.Value);
            };
            bgw.RunWorkerAsync();
        }

        private void dataGridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (colCheck.Index == e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow cur = dataGridHeader.Rows[e.RowIndex];
                if (cur.Cells["colWiserFlag"].Value != DBNull.Value && cur.Cells["colWiserFlag"].Value != null) MessageBox.Show("Sudah di synch tidak dapat di synch kembali");
                else
                {
                    if (cur.Cells["colCheck"].Value == null) cur.Cells["colCheck"].Value = false;
                    cur.Cells["colCheck"].Value = !bool.Parse(cur.Cells["colCheck"].Value.ToString());
                }
            }
        }



    }
}
