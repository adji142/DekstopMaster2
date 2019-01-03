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

namespace ISA.Finance.Piutang
{
    public partial class frmGiroTolakDetailUpdate : ISA.Finance.BaseForm
    {
#region Variable
        Guid _HeaderID = Guid.Empty; //rowid giro tolak 
        Guid _RowID = Guid.Empty; //rowid giro tolak detail
        string _HrecID = string.Empty;//RecordID giro tolak 
        string _KodeToko = string.Empty;//KodeToko
        Guid _IDTrans = Guid.Empty;//rowid   trans
        String _IDrecTrans = string.Empty;//RecordID giro tolak  trans
        Guid _RowIDtrans = Guid.Empty; //rowid  detail rans
        Double _RpSisa = 0;
        double _RpSaldo = 0;
        string _Keterangan = string.Empty;
        string _NoTransaksi = string.Empty;
#endregion

#region Procedure
        private bool IsRetur(Guid _NotaID, string _LinkID)
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
                    db.Commands[0].Parameters.Add(new Parameter("@Tipe", SqlDbType.VarChar, "GIT"));
                    v = Convert.ToInt32(db.Commands[0].ExecuteScalar());
                }
                valid = (v > 0 ? true : false);
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
            //dt.Rows.Add("KPJ");
            dt.Rows.Add("KRJ");
            dt.Rows.Add("ADJ");
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
            dt.DefaultView.Sort = "TR ASC";

            cboTrans.DataSource = dt;
            cboTrans.DisplayMember = "TR";
            cboTrans.ValueMember = "TR";
            cboTrans.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboTrans.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void ResetData()
        {
            cboTrans.Enabled = true;
            cboTrans.SelectedValue = "";
            txtKredit.ReadOnly = false;
            txtUraian.ReadOnly = false;
            
        }

        private void GetRetur(string KodeToko_)
        {
            try
            {
                DataRow dr = null;
                DataTable dt = new DataTable("Retur");
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_GetRetur"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, KodeToko_));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
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

                if (dr != null)
                {
                    txtKredit.Text = Tools.isNull(dr["NilaiRetur"], "").ToString();
                    _RowIDtrans = (Guid)dr["RowID"];
                
                    string date_ = string.Empty;
                    date_ = Tools.isNull(dr["TglNotaRetur"], "").ToString() == "" ? "" : ((DateTime)dr["TglNotaRetur"]).ToString("dd-MMM-yyyy");


                    txtUraian.Text = "NOTA RETUR NO.: " +
                                        Tools.isNull(dr["NoNotaRetur"], "").ToString() +
                                        "TGL." + date_;
                    txtKredit.ReadOnly = true;
                    txtUraian.ReadOnly = true;
                    cboTrans.Enabled = false;
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
                if (SPName == "usp_KartuPiutangDetail_GetKoreksiRetur")
                {
                    if (!IsRetur(_HeaderID, Tools.isNull(dr["LinkID"], "").ToString()))
                    {
                        MessageBox.Show("Tidak Ada Retur di Nota ini", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetData();
                        return;
                    }
                }
                double RpKoreksi_ = Convert.ToDouble(Tools.isNull(dr["NilaiKoreksi"], "0").ToString());

                if (RpKoreksi_ < 0)
                {
                   
                    if (Trans_.Equals("KPJ"))
                        txtKredit.Text = Math.Abs(RpKoreksi_).ToString("#,##0");
                    else
                        txtKredit.Text = RpKoreksi_.ToString("#,##0");

                    txtKredit.ReadOnly = true;
                }
                else
                {
                    if (Trans_.Equals("KPJ"))
                        txtKredit.Text = (-1*RpKoreksi_).ToString("#,##0");
                    else
                        txtKredit.Text = Math.Abs(RpKoreksi_).ToString("#,##0");
                }

              
                txtKredit.ReadOnly = true;

                _RowIDtrans = (Guid)dr["RowID"];

                txtUraian.Text = "Koreksi Nota " +
                                 (Trans_.Equals("KPJ") ? "" : "RETUR ") +
                                 "No: " +
                                    Tools.isNull(dr["NoKoreksi"], "").ToString();

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void GetMutasi (string KodeToko_)
        {
            try
            {
                DataTable dt = new DataTable("BelomLunas");
                DataRow dr = null;
               
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("[usp_GiroTolak_SisaBgTlk]"));
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
                    _RpSaldo = Convert.ToDouble(Tools.isNull(dr["RpSisa"], "0").ToString());
                    _IDrecTrans = Tools.isNull(dr["KPID"], "").ToString();
                    _Keterangan =  Tools.isNull(dr["Keterangan"], "").ToString();
                    _IDTrans = (Guid)dr["RowID"];
                    txtKredit.Text = Math.Abs(_RpSisa).ToString("#,##0");

                    txtUraian.Text = "MUTASI DARI GIRO " + _NoTransaksi + " KE " +
                                        Tools.isNull(dr["NoTransaksi"], "").ToString();
                    cboTrans.Enabled = false;
                    txtKredit.ReadOnly = true;
                    txtUraian.ReadOnly = true;
                }
                else
                {
                    ResetData();
                    return;
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
        
        private void GetPLL()
        {
            txtKredit.Text = _RpSisa.ToString("#,##0");
            txtKredit.ReadOnly = true;
            cboTrans.Enabled = false;

        }

        private void GetPOT()
        {
            txtKredit.Text = _RpSisa.ToString("#,##0");
            txtKredit.ReadOnly = true;
            cboTrans.Enabled = false;

        }

        private void SetGTD()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    _RowID = Guid.NewGuid();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ISA.Common.Tools.CreateShortRecordID(SecurityManager.UserInitial)));
                    db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HrecID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date,SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));

                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                RefreshGrid(_HeaderID, _RowID);
                this.Cursor = Cursors.Default;
            }
        }

        private void SetGTDLink()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    string ass = Tools.CreateShortRecordID(SecurityManager.UserInitial);
                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    _RowID = Guid.NewGuid();
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ass));
                    db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HrecID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, txtKredit.GetDoubleValue));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));


                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Update_Trans"));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, ass));
                    db.Commands[1].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[1].Parameters.Add(new Parameter("@RowIDTrans", SqlDbType.UniqueIdentifier, _RowIDtrans));


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
                RefeshDetail(_RowID);
                this.Cursor = Cursors.Default;
            }
        }

        private void SetCrossMutasi()
        {
            Guid Guid1_ = Guid.NewGuid();
            Guid Guid2_ = Guid.NewGuid();
            _RowID = Guid1_;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderID));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortRecordID(SecurityManager.UserInitial)));
                    db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HrecID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, (-1)*Math.Abs(txtKredit.GetDoubleValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands.Add(db.CreateCommand("usp_KartuPiutangDetail_Insert"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid2_));
                    db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _IDTrans));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateShortFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial, 2)));
                    db.Commands[1].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@Debet", SqlDbType.Money, 0));
                    db.Commands[1].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Math.Abs(txtKredit.GetDoubleValue)));
                    db.Commands[1].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[1].Parameters.Add(new Parameter("@KPID", SqlDbType.VarChar, _IDrecTrans));
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
                //RefreshData(_HeaderID, Guid1_);
                //RefreshRow(_RowID);
                RefreshGrid(_HeaderID, _RowID);
                RefreshData();
                this.Cursor = Cursors.Default;
            }
        }

        private void SetMutasi()
        {
            Guid Guid1_ = Guid.NewGuid();
            Guid Guid2_ = Guid.NewGuid();
            _RowID = Guid1_;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (Database db = new Database(GlobalVar.DBName))
                {

                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid1_));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier,_HeaderID ));
                    db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateSortRecordID(SecurityManager.UserInitial, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _HrecID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date, SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, (-1) * Math.Abs(txtKredit.GetDoubleValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@Uraian", SqlDbType.VarChar, txtUraian.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));

                    db.Commands.Add(db.CreateCommand("usp_GiroTolakDetail_Insert"));
                    db.Commands[1].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid2_));
                    db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier,_IDTrans ));
                    db.Commands[1].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, Tools.CreateSortRecordID(SecurityManager.UserInitial, 2)));
                    db.Commands[1].Parameters.Add(new Parameter("@HRecordID", SqlDbType.VarChar, _IDrecTrans));
                    db.Commands[1].Parameters.Add(new Parameter("@TglBayar", SqlDbType.Date, tglTrans.DateValue));
                    db.Commands[1].Parameters.Add(new Parameter("@tglJthGiro", SqlDbType.Date, SqlDateTime.Null));
                    db.Commands[1].Parameters.Add(new Parameter("@KodeBayar", SqlDbType.VarChar, cboTrans.SelectedValue.ToString()));
                    db.Commands[1].Parameters.Add(new Parameter("@Kredit", SqlDbType.Money, Math.Abs(txtKredit.GetDoubleValue)));
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
                RefreshGrid(_HeaderID,Guid1_ );
                RefreshGrid(_IDTrans,Guid2_ );
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshData()
        {
            if (this.Caller is frmGiroTolak)
            {
                frmGiroTolak frmCaller = (frmGiroTolak)this.Caller;
                frmCaller.RefreshLabel();
            }
        }

        private void RefreshGrid(Guid Header_,Guid Detail_)
        {
            if (this.Caller is frmGiroTolak)
            {
                frmGiroTolak frmCaller = (frmGiroTolak)this.Caller;
                frmCaller.RefreshRowDataGridHeader(Header_);
                frmCaller.RefreshRowDataGridDetail(Detail_);
                frmCaller.FindGridDetail("RowIDDetail", Detail_.ToString());
                frmCaller.RefreshLabel();
            }
        }

        private void RefeshDetail(Guid RowID_)
        {
             if (this.Caller is frmGiroTolak)
            {
                frmGiroTolak frmCaller = (frmGiroTolak)this.Caller;
                frmCaller.RefreshRowDataGridDetail(RowID_);
                frmCaller.FindGridDetail("RowIDDetail", RowID_.ToString());
                frmCaller.RefreshLabel();
            }
        }
#endregion
       

        public frmGiroTolakDetailUpdate(Form Caller_ ,Guid HeaderID_,string HrecID_,double RpSisa_, string KodeToko_,string NoTransaksi_)
        {
            this.Caller = Caller_;
            _HeaderID = HeaderID_;
            _HrecID = HrecID_;
            _RpSisa = RpSisa_;
            _KodeToko = KodeToko_;
            _NoTransaksi = NoTransaksi_;
            InitializeComponent();
        }

        public frmGiroTolakDetailUpdate()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            

            string val_ = Tools.isNull(cboTrans.SelectedValue, "").ToString();
            if (val_ == "" || _HeaderID == Guid.Empty)
            {
                return;
            }

            if (val_.Equals("ADJ") && txtUraian.Text.Trim().Equals(string.Empty))
            {
                errorProvider1.SetError(txtUraian, "Kolom Uraian Harus di isi untuk Transaski ADJ");
                txtUraian.Focus();
                return;
            }

            if (txtKredit.GetDoubleValue == 0)
            {
                errorProvider1.SetError(txtKredit, "Kredit Tidak Boleh kosong");
                return;
            }
            if (PeriodeClosing.IsPJTClosed(tglTrans.DateValue.Value))
            {
                errorProvider1.SetError(tglTrans, "Tgl Berada dalam periode closing, Link akan di lakukan pada bulan berikutnya");
                tglTrans.DateValue = PeriodeClosing.LastClosingPJT.AddDays(+1);
                tglTrans.SelectAll();
                return;
            }

            switch (val_)
            {
                case "RET":
                    {
                        SetGTDLink();
                    }
                    break;
                case "KPJ":
                    {
                        SetGTDLink();
                    }
                    break;
                case "KRJ":
                    {
                        SetGTDLink();
                    }
                    break;
                case "MUT":
                    {
                        switch (_Keterangan)
                        {
                            case "GiroTolak":
                                SetMutasi();
                                break;
                            case "KartuPiutang":
                                SetCrossMutasi();
                                break;
                        }
                    }
                    break;
                case "PLL":
                    {
                        SetGTD();
                    }
                    break;
                case "POT":
                    {
                        SetGTD();
                    }
                    break;
                case "ADJ":
                    {
                        SetGTD();
                    }
                    break;
            }


            this.Close();
        }

        private void cmdCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTrans_SelectedValueChanged(object sender, EventArgs e)
        {
           

            string val_ =Tools.isNull(cboTrans.SelectedValue, "").ToString();

            switch (val_)
            {
                case "":
                    break;
                case "RET":
                    GetRetur(_KodeToko);
                    break;
                case "KPJ":
                    GetKoreksi(_KodeToko, val_);
                    break;
                case "KRJ":
                    GetKoreksi(_KodeToko, val_);
                    break;
                case "MUT":
                    GetMutasi(_KodeToko);
                    break;
                case "PLL":
                    GetPLL();
                    break;
                case "POT":
                    GetPOT();
                    break;
                case "ADJ":
                    txtKredit.Focus();
                    txtKredit.SelectAll();
                    break;

            }
        }

        private void frmGiroTolakDetailUpdate_Load(object sender, EventArgs e)
        {
            AddTipeTransaksi();
            tglTrans.DateValue = DateTime.Now;
        }
    }
}
