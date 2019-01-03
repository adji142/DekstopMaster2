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
using System.Data.SqlTypes;
using ISA.Finance.Class;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace ISA.Finance.Piutang
{
    public partial class frmKartuPiutangDetailUpdate : ISA.Finance.BaseForm
    {
        #region "Var"
        string _KodeToko = string.Empty;
        string _KPID = string.Empty; //KPID Dpiutang
        string _NoTransaksi =string.Empty;
        Guid _HeaderID = Guid.Empty; //RowID KPiutang
        string _RecordID = string.Empty;  // KPID TUJUAN mutasi
        string _Keterangan = string.Empty;
        Guid _RowID = Guid.Empty; //RowID Transaksi yg akan di link
        Guid NewID_ = Guid.Empty; //RowID DPiutang
        Double _RpSisa = 0;
        //Double _RpKredit = 0;
        //Double _RpDebet = 0;
        DataTable dtPiutang;

#endregion

#region "Procedure"
        private bool IsRetur(Guid _NotaID ,string _LinkID )
        {
            bool valid = false;
            try
            {
                int v = 0;
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[usp_KartuPiutangDetail_Validasi_KoreksiReturJual]"));
                    db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, _NotaID));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, _LinkID));
                    db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, "KPIUTANG"));
                    v = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                }
                valid = (v>0 ? true : false);
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
           
            return valid;
        }

        private void AddTipeTransaksi()
        {
            cboTrans.DropDownStyle = ComboBoxStyle.DropDown;

            DataTable dt = new DataTable("Tr");
            DataColumn dc = new DataColumn("TR");
            dt.Columns.Add(dc);
            dt.Rows.Add("");
            dt.Rows.Add("RET");
            dt.Rows.Add("KPJ");
            dt.Rows.Add("KRJ");
            if (SecurityManager.IsAdministrator() || SecurityManager.IsAuditor() || SecurityManager.IsManager())
            {
                dt.Rows.Add("ADJ");
            }
            if (SecurityManager.IsManager() && _RpSisa < 0)
            {
                dt.Rows.Add("MUT");
            }
            if (_RpSisa > (-1001) && _RpSisa < 0)
            {
                dt.Rows.Add("PLL");
            }

            if (_RpSisa > (0) && _RpSisa <= 1000)
            {
                dt.Rows.Add("POT");
            }
            dt.Rows.Add("DIL");
            dt.DefaultView.Sort = "TR ASC";

            cboTrans.DataSource = dt;
            cboTrans.DisplayMember = "TR";
            cboTrans.ValueMember = "TR";
            cboTrans.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTrans.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void GetRetur(string KodeToko_)
        {
            try
            {
                DataRow dr=null;
                DataTable dt = new DataTable("Retur");
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_GetRetur"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("Tidak Ada Retur Untuk Toko Ini ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ResetData();
                    return;
                }

                frmVwRetur ifrmDialog = new frmVwRetur(dt);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    dr = ifrmDialog.SelecetedRow;
                }

                if (dr!=null)
                {
                    txtKredit.Text = Tools.isNull(dr["NilaiRetur"], "").ToString();
                    _RecordID = Tools.isNull(dr["RecordID"], "").ToString();
                    _RowID = (Guid)dr["RowID"];
                    txtDebet.ReadOnly = true;
                    txtKredit.ReadOnly = true;
                    string date_ = string.Empty;
                    date_ = Tools.isNull(dr["TglNotaRetur"], "").ToString()=="" ? "" : ((DateTime)dr["TglNotaRetur"]).ToString("dd-MMM-yyyy");


                    txtUraian.Text =    "NOTA RETUR NO.: " + 
                                        Tools.isNull(dr["NoNotaRetur"], "").ToString() +
                                        "TGL." + date_;
                    txtUraian.ReadOnly = true;
                    cboTrans.Enabled = false;
                }
                else
                {
                    ResetData();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void GetDIL(string KodeToko_,string NoTransaksi_)
        {
            try
            {
                DataRow dr = null;
                DataTable dt = new DataTable("DIL");
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_GetDIL"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    db.Commands[0].Parameters.Add(new Parameter("@NoTransaksi", SqlDbType.VarChar, NoTransaksi_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Potongan Penjualan atau Potongan Penjualan belum diacc untuk Toko dan Nota Ini ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetData();
                    return;
                }

                frmViewDIL ifrmDialog = new frmViewDIL(dt);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    dr = ifrmDialog.SelecetedRow;
                }

                if (dr != null)
                {
                    txtKredit.Text = Tools.isNull(dr["Dil"], "").ToString();
                    _RecordID = Tools.isNull(dr["PotID"], "").ToString();
                    _RowID = (Guid)dr["RowID"];
                    txtDebet.ReadOnly = true;
                    txtKredit.ReadOnly = true;
                    string date_ = string.Empty;
                    date_ = Tools.isNull(dr["TglPot"], "").ToString() == "" ? "" : ((DateTime)dr["TglPot"]).ToString("dd-MMM-yyyy");
                    txtUraian.Text = "NOTA POT(DIL) NO.: " + Tools.isNull(dr["NoPot"], "").ToString() + "TGL." + date_;
                    txtUraian.ReadOnly = true;
                    cboTrans.Enabled = false;
                }
                else
                {
                    ResetData();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        
        
        private void GetKoreksi(string KodeToko_, string Trans_)
        {
            try
            {
                DataRow dr = null;
                DataTable dt = new DataTable(Trans_);
                 string SPName = (Trans_.Equals("KPJ") ? "usp_KartuPiutangDetail_GetKoreksiPenjualan" : "usp_KartuPiutangDetail_GetKoreksiRetur");
                using (Database db = new Database(GlobalVar.DBName))
                {
                   

                    db.Commands.Add(db.CreateCommand(SPName));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    //if (SPName=="usp_KartuPiutangDetail_GetKoreksiPenjualan")
                    //{
                    //    db.Commands[0].Parameters.Add(new Parameter("@NotaID", SqlDbType.UniqueIdentifier, _HeaderID));
                    //}
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak Ada Koreksi Untuk Toko Ini ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetData();

                    return;
                }

                frmVwKoreksi ifrmDialog = new frmVwKoreksi(dt);
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    dr = ifrmDialog.SelecetedRow;
                }

                
                if (dr == null)
                {
                    ResetData();
                    return;
                }

                if (SPName == "usp_KartuPiutangDetail_GetKoreksiPenjualan")
                {
                    if ((Guid)dr["NotaID"] != _HeaderID)
                    {
                        MessageBox.Show("KPJ bukan Untuk Nota ini", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetData();
                        return;
                    }
                }
                if (SPName == "usp_KartuPiutangDetail_GetKoreksiRetur")
                {
                    if (!IsRetur(_HeaderID,Tools.isNull(dr["LinkID"],"").ToString()))
                    {
                        MessageBox.Show("Tidak Ada Retur di Nota ini", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetData();
                        return;
                    }
                }



                double RpKoreksi_ = Convert.ToDouble(Tools.isNull(dr["NilaiKoreksi"], "0").ToString());

                if (RpKoreksi_ < 0)
                {
                    RpKoreksi_ = Math.Abs(RpKoreksi_);
                    if (Trans_.Equals("KPJ"))
                        txtKredit.Text = RpKoreksi_.ToString();
                    else
                        txtDebet.Text = RpKoreksi_.ToString();
                }
                else
                {
                    if (Trans_.Equals("KPJ"))
                        txtDebet.Text = RpKoreksi_.ToString("#,##0");
                    else
                        txtKredit.Text = RpKoreksi_.ToString("#,##0");
                }

                


                _RecordID = Tools.isNull(dr["RecordID"], "").ToString();
                _RowID = (Guid)dr["RowID"];

                txtUraian.Text = "Koreksi Nota " +
                                 (Trans_.Equals("KPJ") ? "" : "RETUR ") +
                                 "No: " +
                                    Tools.isNull(dr["NoKoreksi"], "").ToString();
                txtUraian.ReadOnly = true;
                txtDebet.ReadOnly = true;
                txtKredit.ReadOnly = true;
                cboTrans.Enabled = false;
                cmdSave.Focus();
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetNota(string KodeToko_)
        {
            try
            {
                DataRow dr = null;
                DataTable dt = new DataTable("Kpiutang");
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_GiroTolak_SisaBgTlk"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Seluruh Nota Sudah Lunas Untuk Toko Ini ", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ResetData();
                    return;
                }

                frmVwKPiutang ifrmDialog = new frmVwKPiutang(dt);
                ifrmDialog.WindowState = FormWindowState.Normal;
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    dr = ifrmDialog.SelecetedRow;
                }

                if (dr != null)
                {
                   // _RpSisa = Convert.ToDouble(Tools.isNull(dr["RpSisa"], "0").ToString());
                    _RecordID = Tools.isNull(dr["KPID"], "").ToString();
                    _RowID = (Guid)dr["RowID"];
                    txtDebet.Text = Math.Abs(_RpSisa).ToString("#,##0");
                    txtDebet.ReadOnly = true;
                    txtKredit.ReadOnly = true;
                    _Keterangan = Tools.isNull(dr["Keterangan"], "").ToString();
                    txtUraian.Text = "MUTASI DARI " + _NoTransaksi + " KE " +
                                        Tools.isNull(dr["NoTransaksi"], "").ToString();
                    txtUraian.ReadOnly = true;
                    cboTrans.Enabled = false;

                }
                else
                {
                    ResetData();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetPLL()
        {
            txtDebet.Text = _RpSisa.ToString("#,##0");
            txtDebet.ReadOnly = true;
            txtKredit.ReadOnly = true;
            cboTrans.Enabled = false;
            
        }

        private void GetPOT()
        {
            txtKredit.Text = _RpSisa.ToString("#,##0");
            txtDebet.ReadOnly = true;
            txtKredit.ReadOnly = true;
            cboTrans.Enabled = false;

        }

        private void ResetData()
        {
            cboTrans.SelectedValue = "";
            _RecordID = string.Empty;
            _RowID = Guid.Empty;
            txtDebet.Text = "0";
            txtKredit.Text = "0";
            txtNamaBank.Text = string.Empty;
            txtNoACC.Text = "";
            txtNoBGC.Text = "";
            txtNoBKM.Text = "";
            txtTglBGC.Text = "";
            txtUraian.Text = "";
            NewID_ = Guid.Empty;
            cboTrans.Enabled = true;
            txtUraian.ReadOnly = false;
            txtDebet.ReadOnly = false;
            txtKredit.ReadOnly = false;
        }

        private void SetData()
        {
             
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                    NewID_ = Guid.NewGuid();
                    string Rec1 = Tools.CreateFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial);
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, NewID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar,Rec1 ));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, txtDebet.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _KPID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Update_Trans"));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Rec1));
                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[1].Parameters.Add(new Parameter("@RowIDTrans", SqlDbType.UniqueIdentifier, _RowID));

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                }
                
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                
            }
        }

        private void SetDataAdj()
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                    NewID_ = Guid.NewGuid();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, NewID_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial)));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, txtDebet.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _KPID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void SetDataMut()
        {
            //Database db = new Database(GlobalVar.DBName);
            Guid Guid1_ = Guid.NewGuid();
            Guid Guid2_ = Guid.NewGuid();
            try
            {
               
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                   
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid1_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ISA.Common.Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, txtDebet.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _KPID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid2_));
                    db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ISA.Common.Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 2)));
                    db.Commands[1].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[1].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtDebet.GetDoubleValue));
                    db.Commands[1].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[1].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _RecordID));
                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();

                }

             

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                
            }
            finally
            {
                RefreshData(_HeaderID, Guid1_);
                RefreshRow(_RowID);
                
            }
        }

        private void SetDataMutCross()
        {
            Guid Guid1_ = Guid.NewGuid();
            Guid Guid2_ = Guid.NewGuid();
            try
            {

                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));

                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid1_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, Math.Abs(txtDebet.GetDoubleValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _KPID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid2_));
                    db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortRecordID(SecurityManager.UserInitial)));
                    db.Commands[1].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _RecordID));
                    db.Commands[1].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[1].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date, SqlDateTime.Null));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money,   Math.Abs(txtDebet.GetDoubleValue)));
                    db.Commands[1].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.BeginTransaction();
                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
                    db.CommitTransaction();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);

            }
            finally
            {
               

            }
        }
        
        private void RefreshData()
        {
            
                if (this.Caller is frmKartuPiutangBrowse)
                {
                    frmKartuPiutangBrowse frmCaller = (frmKartuPiutangBrowse)this.Caller;
                    //frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                    //frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                    frmCaller.RefreshKPiutangDetail("",_HeaderID);
                    frmCaller.RefreshGridHeader();
                    frmCaller.FindGridDetail("RowIDDetail", NewID_.ToString());

                }
        }

        private void RefreshRow(Guid RowID_)
        {
            if (this.Caller is frmKartuPiutangBrowse)
            {
                frmKartuPiutangBrowse frmCaller = (frmKartuPiutangBrowse)this.Caller;
                frmCaller.RefreshRowData(RowID_);


            }
        }

        private void RefreshData(Guid HeaderID_, Guid RowID_)
        {

            if (this.Caller is frmKartuPiutangBrowse)
            {
                frmKartuPiutangBrowse frmCaller = (frmKartuPiutangBrowse)this.Caller;
                //frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                //frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                frmCaller.RefreshKPiutangDetail("", HeaderID_);
                frmCaller.RefreshGridHeader();
                frmCaller.FindGridDetail("RowIDDetail", RowID_.ToString());
                

            }
        }


#endregion
        

        public frmKartuPiutangDetailUpdate()
        {
            InitializeComponent();
        }

        public frmKartuPiutangDetailUpdate(Form caller_,string KPID_,string KodeToko_, double RpSisa_, Guid RowID_, string NoTrasnsaksi_)
        {
            _KPID = KPID_;
            _KodeToko = KodeToko_;
            _RpSisa = RpSisa_;
            _HeaderID = RowID_;
            _NoTransaksi = NoTrasnsaksi_;
            this.Caller = caller_;
            InitializeComponent();
        }
       
        private void frmKartuPiutangDetailUpdate_Load(object sender, EventArgs e)
        {
            tglTrans.DateValue = DateTime.Now;
            AddTipeTransaksi();

        }

        private void cmdCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTrans_SelectedValueChanged(object sender, EventArgs e)
        {
            
            string val_ = Tools.isNull(cboTrans.SelectedValue, "").ToString();

                switch (val_)
                {
                case "":
                    {
                        ResetData();
                    }
                    break;
                case "RET":
                    {
                        GetRetur(_KodeToko);
                    }
                	break;
                case "KPJ":
                    {
                        GetKoreksi(_KodeToko, "KPJ");
                    }
                    break;
                case "KRJ":
                    {
                        GetKoreksi(_KodeToko, "KRJ");
                    }
                    break;
                case "MUT":
                    {
                        GetNota(_KodeToko);
                    }
                    break;
                case "PLL":
                    {
                        GetPLL();
                    }
                    break;
                case "POT":
                    {
                        GetPOT();
                    }
                    break;
                case "ADJ":
                    {
                        txtDebet.Text = "0";
                        txtKredit.Text = "0";
                        txtDebet.ReadOnly = false;
                        txtKredit.ReadOnly = false;
                        txtNoACC.ReadOnly = false;
                        txtNoACC.TabStop = true;
                        txtUraian.Clear();

                        if (GlobalVar.Gudang != "2803" && GlobalVar.Gudang != "2808")
                        {
                            string _pinKey = GetKey(_HeaderID.ToString(), GlobalVar.Gudang, 29);

                            MessageBox.Show("Input Transaksi ADJ harus menggunakan Pin." + "\n" +
                                            "Silahkan Pengajuan PIN ke HO.");
                            PengajuanPinAdj(_HeaderID, _pinKey);

                            pin.frmPinMd5 ifrmpin = new pin.frmPinMd5(this, _HeaderID, GlobalVar.Gudang, 29, "ADJ Piutang.");
                            ifrmpin.ShowDialog();
                            if (ifrmpin.DialogResult != DialogResult.OK)
                            {
                                this.DialogResult = DialogResult.No;
                                this.Close();
                                return;
                            }
                        }
                    }
                    break;
                case "DIL":
                    {
                        //GetDIL(_KodeToko,_NoTransaksi);
                        Guid RowIDNota;
                        Guid RowIDPotongan;
                        double Saldo;
                        Piutang.frmPotonganPenjualanBelumIden ifrmChild = new Piutang.frmPotonganPenjualanBelumIden(_KodeToko);
                        ifrmChild.WindowState = FormWindowState.Normal;
                        ifrmChild.ShowDialog();
                        if (ifrmChild.DialogResult == DialogResult.OK)
                        {
                            RowIDNota = ifrmChild.RowIDNota;
                            RowIDPotongan = ifrmChild.RowIDPotongan;
                            Saldo = ifrmChild.Saldo;
                            Piutang.frmpotonganpenjualanidentifikasi frm = new Piutang.frmpotonganpenjualanidentifikasi(RowIDPotongan, Saldo);
                            frm.WindowState = FormWindowState.Normal;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                            {
                                try
                                {
                                    DataTable dtLinkPot = new DataTable();
                                    using (Database db = new Database())
                                    {
                                        db.Commands.Add(db.CreateCommand("[psp_Potongan_LinkToPiutang_ISA]"));
                                        db.Commands[0].Parameters.Add(new Parameter("@potID", SqlDbType.UniqueIdentifier, RowIDPotongan));
                                        db.Commands[0].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, _HeaderID));
                                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                        db.Commands[0].Parameters.Add(new Parameter("@NominalIden", SqlDbType.Money, frm.NomIden));
                                        dtLinkPot = db.Commands[0].ExecuteDataTable();
                                    }
                                    if (dtLinkPot.Rows[0]["cekNota"].ToString() == "0")
                                        MessageBox.Show("Nota tidak ada", "Perhatian");
                                    else MessageBox.Show("Potongan Berhasil Teridentifikasi", "Sukses");
                                }
                                catch (Exception ex)
                                {
                                    Error.LogError(ex);
                                }
                                finally
                                {
                                    if (this.Caller is Piutang.frmKartuPiutangBrowse)
                                    {
                                        Piutang.frmKartuPiutangBrowse frmkp = new Piutang.frmKartuPiutangBrowse();
                                        frmkp = (Piutang.frmKartuPiutangBrowse)this.Caller;
                                        frmkp.RefreshKPiutangDetail("",_HeaderID);
                                    }
                                    //Piutang.frmKartuPiutangBrowse frmkp = new Piutang.frmKartuPiutangBrowse();
                                    //frmkp.search_kp(_HeaderID.ToString(),_KodeToko);
                                    this.Close();
                                }
                            }
                        }
                    }
                    break;

                }
        }

        private string GetKey(string rowID, string kodeGudang, int noAjuan)
        {
            string x = kodeGudang.ToString().Trim().Substring(2, 2) + noAjuan.ToString().Trim().PadLeft(2, '0') +
                       rowID.Replace("-", string.Empty).ToUpper();
            return x;
        }

        private void PengajuanPinAdj(Guid rowid, string pinKey)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_Pengajuan_ADJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowid));
                    dtPiutang = db.Commands[0].ExecuteDataTable();
                    if (dtPiutang.Rows.Count > 0)
                    {
                        DisplayReportToExcell(dtPiutang, pinKey);
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
        }

        private void DisplayReportToExcell(DataTable dtPtg, string pinkey)
        {
            List<ExcelPackage> exs = new List<ExcelPackage>();
            exs.Add(PengajuanPinADJ(dtPtg, pinkey));

            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "C:\\Temp\\";
            sf.Filter = "xlsx files (*.xlsx)|*.xlsx";
            sf.FileName = "PengajuanPinADJ";

            sf.OverwritePrompt = true;
            if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK && sf.FileName.Length > 0)
            {
                string file = sf.FileName.ToString();
                Byte[] bin1 = exs[0].GetAsByteArray();
                File.WriteAllBytes(file, bin1);
                MessageBox.Show("Laporan Selesai. " + Environment.NewLine + file);
                Process.Start(sf.FileName.ToString());
            }

        }

        private ExcelPackage PengajuanPinADJ(DataTable dtPtg, string pinkey)
        {
            ExcelPackage ex = new ExcelPackage();
            ex.Workbook.Properties.Author = "PS";
            ex.Workbook.Properties.Title = "Pengajuan Pin ADJ";
            ex.Workbook.Properties.SetCustomPropertyValue("PIN ADJ", "1147");

            ex.Workbook.Worksheets.Add("PIN ADJ "+GlobalVar.Gudang);
            ExcelWorksheet ws = ex.Workbook.Worksheets[1];

            //#region header
            ws.View.ShowGridLines = false;
            ws.Cells[1, 1].Worksheet.Column(1).Width = 2;       //kosong
            ws.Cells[1, 2].Worksheet.Column(2).Width = 5;       //no
            ws.Cells[1, 3].Worksheet.Column(3).Width = 10;      //nosuratjalan
            ws.Cells[1, 4].Worksheet.Column(4).Width = 13;      //tglsuratjalan
            ws.Cells[1, 5].Worksheet.Column(5).Width = 13;      //kodesales
            ws.Cells[1, 6].Worksheet.Column(6).Width = 30;      //namatoko
            ws.Cells[1, 7].Worksheet.Column(7).Width = 20;      //daerah
            ws.Cells[1, 8].Worksheet.Column(8).Width = 10;      //idwil
            ws.Cells[1, 9].Worksheet.Column(9).Width = 17;      //rpbayar
            ws.Cells[1, 10].Worksheet.Column(10).Width = 40;    //publickey
            ws.Cells[1, 11].Worksheet.Column(11).Width = 40;    //pin
            ws.Cells[1, 12].Worksheet.Column(12).Width = 40;    //keterangan
            ws.Cells[1, 13].Worksheet.Column(13).Width = 10;    //no acc

            int nRow = 0, nHeader = 1, Rowx = 0;
            nRow = nHeader + 4;
            Rowx = nRow;

            ws.Cells[nHeader, 2].Style.Font.Bold.ToString();
            ws.Cells[nHeader, 2].Value = "Pengajuan Pin ADJ";
            ws.Cells[nHeader, 2].Style.Font.Size = 14;
            ws.Cells[nHeader, 2].Style.Font.Bold = true;
            ws.Cells[nHeader + 1, 2].Value = "Tanggal : " + string.Format("{0:dd-MMM-yyyy}", GlobalVar.DateTimeOfServer);
            ws.Cells[nHeader + 1, 2].Style.Font.Bold = false;
            ws.Cells[nHeader + 2, 2].Value = "Depo : "+GlobalVar.Gudang;

            int MaxCol = 13;

            ws.Cells[Rowx, 2].Value = " No ";
            ws.Cells[Rowx, 3].Value = " No Nota ";
            ws.Cells[Rowx, 4].Value = " Tgl Nota ";
            ws.Cells[Rowx, 5].Value = " Kode Sales ";
            ws.Cells[Rowx, 6].Value = " Nama Toko ";
            ws.Cells[Rowx, 7].Value = " Daerah ";
            ws.Cells[Rowx, 8].Value = " Idwil ";
            ws.Cells[Rowx, 9].Value = " Rp Sisa Piutang ";
            ws.Cells[Rowx, 10].Value = " Public Key ";
            ws.Cells[Rowx, 11].Value = " Pin ";
            ws.Cells[Rowx, 12].Value = " Keterangan ";
            ws.Cells[Rowx, 13].Value = " No Acc ";

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Fill.BackgroundColor.SetColor(Color.LightSkyBlue);
            Rowx++;

            int no = 0;
            double nSaldo = 0, nQty = 0;

            if (dtPtg.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtPtg.Rows)
                {
                    no++;
                    ws.Cells[Rowx, 2].Value = no.ToString();
                    ws.Cells[Rowx, 3].Value = dr1["NoTransaksi"].ToString();
                    ws.Cells[Rowx, 4].Value = string.Format("{0:dd-MMM-yyyy}", dr1["TglTransaksi"]);
                    ws.Cells[Rowx, 5].Value = dr1["KodeSales"].ToString();
                    ws.Cells[Rowx, 6].Value = dr1["NamaToko"].ToString();
                    ws.Cells[Rowx, 7].Value = dr1["Daerah"].ToString();
                    ws.Cells[Rowx, 8].Value = dr1["WilID"].ToString();
                    ws.Cells[Rowx, 9].Value = Convert.ToDouble(dr1["Sisa"].ToString());
                    ws.Cells[Rowx, 9].Style.Numberformat.Format = "#,##;(#,##);0";
                    ws.Cells[Rowx, 10].Value = pinkey;
                    ws.Cells[Rowx, 11].Value = "";
                    ws.Cells[Rowx, 12].Value = "";
                    ws.Cells[Rowx, 13].Value = "";
                    Rowx++;
                }

                Rowx++;
                //ws.Cells[Rowx, 9].Value = "Jumlah".ToString();
                ws.Cells[Rowx, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //ws.Cells[Rowx, 10].Value = Tools.isNull(nQty, 0);
                //ws.Cells[Rowx, 10].Style.Numberformat.Format = "#,##;(#,##);0";
                //ws.Cells[Rowx, 10].Style.Font.Bold = true;

                //ws.Cells[Rowx, 12].Value = Tools.isNull(nSaldo, 0);
                //ws.Cells[Rowx, 12].Style.Numberformat.Format = "#,##;(#,##);0";
                //ws.Cells[Rowx, 12].Style.Font.Bold = true;

                var border = ws.Cells[nRow, 2, nRow, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[nRow + 1, 2, Rowx - 1, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.None;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                border = ws.Cells[Rowx, 2, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style = ExcelBorderStyle.Thin;
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[Rowx, 2, Rowx, 2].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style = ExcelBorderStyle.Thin;
                border.Right.Style = ExcelBorderStyle.None;

                border = ws.Cells[Rowx, 10, Rowx, MaxCol].Style.Border;
                border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = ExcelBorderStyle.Thin;

                nHeader = Rowx;
                Rowx += 1;

                ws.Cells[Rowx, 2].Value = "Printed by " + SecurityManager.UserName + ", " + DateTime.Now;
                ws.Cells[Rowx, 2].Style.Font.Size = 8;
                ws.Cells[Rowx, 2].Style.Font.Italic = true;
            }
            return ex;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            string val_ = Tools.isNull(cboTrans.SelectedValue,"").ToString();
            if ( val_ == "" || _HeaderID == Guid.Empty)
            {
                cboTrans.Select();
                return;
            }

            if (val_.Equals("ADJ"))
            {
                txtNoACC.ReadOnly = false;
                txtNoACC.TabStop = true;
                if (txtNoACC.Text.Trim().Equals(string.Empty))
                {
                    errorProvider1.SetError(txtNoACC, "Belum ada No Acc, Proses ADJ dibatalkan.");
                    txtNoACC.Focus();
                    return;
                }
                if (txtUraian.Text.Trim().Equals(string.Empty))
                {
                    errorProvider1.SetError(txtUraian, "Kolom Uraian Harus di isi untuk Transaski ADJ");
                    txtUraian.Focus();
                    return;
                }
            }
            else
            {
                txtNoACC.ReadOnly = true;
                txtNoACC.TabStop = false;
            }

            if (GlobalVar.Gudang != "2808")
            {
                if (PeriodeClosing.IsPJTClosed(tglTrans.DateValue.Value))
                {
                    errorProvider1.SetError(tglTrans, "Tgl Berada dalam periode closing, Link akan di lakukan pada bulan berikutnya");
                    tglTrans.DateValue = PeriodeClosing.LastClosingPJT.AddDays(+1);
                    tglTrans.SelectAll();
                    return;
                }
            }

            if (txtKredit.GetDoubleValue==0 && txtDebet.GetDoubleValue==0)
            {
                errorProvider1.SetError(txtDebet, "Debet & Kredit Tidak Boleh kosong");
                errorProvider1.SetError(txtKredit, "Debet & Kredit Tidak Boleh kosong");
                return;
            }

            if (txtKredit.GetDoubleValue < 0)
                txtKredit.Text = (txtKredit.GetDoubleValue * -1).ToString();

            if (txtDebet.GetDoubleValue < 0)
                txtDebet.Text = (txtDebet.GetDoubleValue * -1).ToString();

            switch (val_)
            {
                case "RET":
                    {
                        SetData();
                        RefreshData();
                    }
                    break;
                case "KPJ":
                    {
                        SetData();
                        RefreshData();
                    }
                    break;
                case "KRJ":
                    {
                        SetData();
                        RefreshData();
                    }
                    break;
                case "MUT":
                    {
                        switch (_Keterangan)
                        {
                            case "GiroTolak":
                                SetDataMutCross();
                                break;
                            case "KartuPiutang":
                                SetDataMut(); 
                                break;
                        }
                    }
                    break;
                case "PLL":
                    {
                        SetDataAdj();
                        RefreshData();
                    }
                    break;
                case "POT":
                    {
                        SetDataAdj();
                        RefreshData();
                    }
                    break;
                case "ADJ":
                    {
                        SetDataAdj();
                        RefreshData();
                    }
                    break;
                case "DIL":
                    {
                        SetData();
                        RefreshData();
                    }
                    break;
            }

           
            this.Close();

        }

        private void txtKredit_Validating(object sender, CancelEventArgs e)
        {

           
            string val_ =Tools.isNull(cboTrans.SelectedValue, "").ToString();
            txtKredit.Text = Math.Abs(txtKredit.GetDoubleValue).ToString("#,##0");
            if (val_.Equals("POT") && (txtKredit.GetDoubleValue < 1 || txtKredit.GetDoubleValue >1000))
            {
                errorProvider1.SetError(txtKredit, "Nilai POT harus > 0 dan <= 1000");
                ResetData();
            }

            if (val_.Equals("ADJ") ||val_ =="")
            {
                if (txtKredit.GetDoubleValue != 0)
                {
                    txtDebet.ReadOnly = true;
                }
                else
                {
                    txtDebet.ReadOnly = false;

                }
            }
           
           
        }

        private void txtDebet_Validating(object sender, CancelEventArgs e)
        {
            string val_ = Tools.isNull(cboTrans.SelectedValue, "").ToString();
            txtDebet.Text = Math.Abs(txtDebet.GetDoubleValue).ToString("#,##0");
            if (val_.Equals("ADJ") || val_ == "")
            {
                if (txtDebet.GetDoubleValue != 0)
                {
                    txtKredit.ReadOnly = true;
                }
                else
                {
                    txtKredit.ReadOnly = false;

                }
            }

         

            if (val_.Equals("MUT") && (txtDebet.GetDoubleValue == 0 || txtDebet.GetDoubleValue > Math.Abs(_RpSisa) )  )
            {
                errorProvider1.SetError(txtDebet, "Nilai Debet Tidak Boleh Lebih dari "+_RpSisa.ToString("#,##0"));
                txtDebet.Focus();
            }


        }

    }
}
