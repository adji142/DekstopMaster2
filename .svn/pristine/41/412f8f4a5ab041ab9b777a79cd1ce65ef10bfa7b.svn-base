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
using ISA.Toko.Class;


namespace ISA.Toko.Piutang
{
    public partial class frmKartuPiutangDetailUpdate : ISA.Toko.BaseForm
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

#endregion

#region "Procedure"
        private bool IsRetur(Guid _NotaID ,string _LinkID )
        {
            bool valid = false;
            try
            {
                int v = 0;
                using (Database db = new Database(GlobalVar.DBFinance))
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
            dt.Rows.Add("RET");
            //dt.Rows.Add("KPJ");
            //dt.Rows.Add("KRJ");
            dt.Rows.Add("ADJ");
            //if (SecurityManager.IsManager() && _RpSisa < 0)
            //{
            //    dt.Rows.Add("MUT");
            //}
            //if (_RpSisa > (-1001) && _RpSisa < 0)
            //{
            //    dt.Rows.Add("PLL");
            //}
            //if (_RpSisa > (0) && _RpSisa <= 1000)
            //{
            //    dt.Rows.Add("POT");
            //}
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
                using (Database db = new Database(GlobalVar.DBFinance))
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

        private void GetKoreksi(string KodeToko_, string Trans_)
        {
            try
            {
                DataRow dr = null;
                DataTable dt = new DataTable(Trans_);
                 string SPName = (Trans_.Equals("KPJ") ? "usp_KartuPiutangDetail_GetKoreksiPenjualan" : "usp_KartuPiutangDetail_GetKoreksiRetur");
                using (Database db = new Database(GlobalVar.DBFinance))
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
                using (Database db = new Database(GlobalVar.DBFinance))
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
            cboTrans.SelectedIndex = 0;
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
                using (Database db = new Database(GlobalVar.DBFinance))
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
                using (Database db = new Database(GlobalVar.DBFinance))
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
            //Database db = new Database(GlobalVar.DBFinance);
            Guid Guid1_ = Guid.NewGuid();
            Guid Guid2_ = Guid.NewGuid();
            try
            {
               
                using (Database db = new Database(GlobalVar.DBFinance))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                   
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid1_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial, 1)));
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
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 2)));
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

                using (Database db = new Database(GlobalVar.DBFinance))
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
            tglTrans.DateValue = GlobalVar.DateOfServer;
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
                //case "":
                //    {
                //        ResetData();
                //    }
                //    break;
                case "RET":
                    {
                        GetRetur(_KodeToko);
                    }
                	break;
                //case "KPJ":
                //    {
                //        GetKoreksi(_KodeToko, "KPJ");
                //    }
                //    break;
                //case "KRJ":
                //    {
                //        GetKoreksi(_KodeToko, "KRJ");
                //    }
                //    break;
                //case "MUT":
                //    {
                //        GetNota(_KodeToko);
                //    }
                //    break;
                //case "PLL":
                //    {
                //        GetPLL();
                //    }
                //    break;
                //case "POT":
                //    {
                //        GetPOT();
                //    }
                //    break;
                case "ADJ":
                    {
                        txtDebet.Text = "0";
                        txtKredit.Text = "0";
                        txtDebet.ReadOnly = false;
                        txtKredit.ReadOnly = false;
                        txtUraian.Clear();
                    }
                    break;

                }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            string val_ = Tools.isNull(cboTrans.SelectedValue,"").ToString();
            if ( val_ == "" || _HeaderID == Guid.Empty)
            {
                cboTrans.Select();
                return;
            }

            if (val_.Equals("ADJ") && txtUraian.Text.Trim().Equals(string.Empty)) 
            {
                errorProvider1.SetError(txtUraian, "Kolom Uraian Harus di isi untuk Transaski ADJ");
                txtUraian.Focus();
                return;
            }

            if (PeriodeClosing.IsPJTClosed(tglTrans.DateValue.Value))
            {
                errorProvider1.SetError(tglTrans, "Tgl Berada dalam periode closing, Link akan di lakukan pada bulan berikutnya");
                tglTrans.DateValue = PeriodeClosing.LastClosingPJT.AddDays(+1);
                tglTrans.SelectAll();
                return;
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
