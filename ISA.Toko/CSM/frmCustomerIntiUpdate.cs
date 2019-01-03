using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ISA.Toko;
using ISA.Controls;
using ISA.DAL;
using ISA.Toko.Controls;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace ISA.Toko.CSM
{
    public partial class frmCustomerIntiUpdate : BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;  
        string initCab = GlobalVar.CabangID;
        DataTable dtH = new DataTable();
        Guid _rowID;
        string _nameToko, _sts = "1";
        string FlagKtg = "";

        private bool validasi()
        {   
              if (txtTokoID.Text != "")
              {
                  return false ;
              }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable() ;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, txtTokoID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    dt = db.Commands[0].ExecuteDataTable();

                }

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Customer Sudah Ada");
                    return false ;
                }
               
              
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return true;
        }
        
        private void RefreshGridHeader()
        {
            if (this.Caller is frmMasterCustomerInti)
            {
                frmMasterCustomerInti frmCaller = (frmMasterCustomerInti)this.Caller;
                frmCaller.RefreshRowDataCI(_rowID.ToString());
            }
        }

        private void insertData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _rowID = Guid.NewGuid();

                if (RadioMilik.Checked == true) { _sts = "1"; }
                else if (RadioKontrak.Checked == true) { _sts = "0"; }


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagKategori", SqlDbType.VarChar, FlagKtg));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, lookupToko.NamaToko));
                    db.Commands[0].Parameters.Add(new Parameter("@idtoko", SqlDbType.VarChar, txtTokoID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamatKirim.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtProvince.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIDWil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelp", SqlDbType.VarChar, txtTelp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nofax", SqlDbType.VarChar, txtFax.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Sts", SqlDbType.VarChar, _sts.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@dbangun", SqlDbType.DateTime, txtTahunBerdiri.DateValue.HasValue ? txtTahunBerdiri.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@dkontrak1", SqlDbType.DateTime, txtMasaKontrakDari.DateValue.HasValue ? txtMasaKontrakDari.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@dkontrak2", SqlDbType.DateTime, txtMasaKontrakSampai.DateValue.HasValue ? txtMasaKontrakSampai.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@jnsjual", SqlDbType.VarChar, comboBoxJenisDag.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@segment", SqlDbType.VarChar, comboBoxJenisProd.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@namap", SqlDbType.VarChar, txtNamaPemilik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jkp", SqlDbType.VarChar, comboBoxJenisKel.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tmplahirp", SqlDbType.VarChar, txtTempatLahir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tgllahirp", SqlDbType.DateTime, txtTglLahirP.DateValue.HasValue ? txtTglLahirP.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@alamatp", SqlDbType.VarChar, txtAlamatPemilik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelpp", SqlDbType.VarChar, txtTelpRumah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nohpp", SqlDbType.VarChar, txtHPRumah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@emailp", SqlDbType.VarChar, txtEmail.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@norekp", SqlDbType.VarChar, txtNomorRek.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nmbankp", SqlDbType.VarChar, comboBoxBank.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.VarChar, comboBoxStatusToko.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastorder", SqlDbType.DateTime, SqlDateTime.Null));

                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb2rp", SqlDbType.Int, Convert.ToDouble(tg_fb2rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb4rp", SqlDbType.Int, Convert.ToDouble(tg_fb4rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe2rp", SqlDbType.Int, Convert.ToDouble(tg_fe2rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe4rp", SqlDbType.Int, Convert.ToDouble(tg_fe4rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fxrp", SqlDbType.Int, Convert.ToDouble(tg_fxrp.GetIntValue)));

                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb2sku", SqlDbType.Int, Convert.ToDouble(tg_fb2sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb4sku", SqlDbType.Int, Convert.ToDouble(tg_fb4sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe2sku", SqlDbType.Int, Convert.ToDouble(tg_fe2sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe4sku", SqlDbType.Int, Convert.ToDouble(tg_fe4sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fxsku", SqlDbType.Int, Convert.ToDouble(tg_fxsku.GetIntValue)));

                    db.Commands[0].Parameters.Add(new Parameter("SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();

                }

                RefreshGridHeader();
                this.Close();
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

        private void UpdateData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


                if (RadioMilik.Checked == true) { _sts = "1"; }
                else if (RadioKontrak.Checked == true) { _sts = "0"; }


                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti_Update"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@FlagKategori", SqlDbType.VarChar, cbSwitch.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, lookupToko.NamaToko));
                    db.Commands[0].Parameters.Add(new Parameter("@idtoko", SqlDbType.VarChar, txtTokoID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamatKirim.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtProvince.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIDWil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelp", SqlDbType.VarChar, txtTelp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nofax", SqlDbType.VarChar, txtFax.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Sts", SqlDbType.VarChar, _sts.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@dbangun", SqlDbType.DateTime, txtTahunBerdiri.DateValue.HasValue ? txtTahunBerdiri.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@dkontrak1", SqlDbType.DateTime, txtMasaKontrakDari.DateValue.HasValue ? txtMasaKontrakDari.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@dkontrak2", SqlDbType.DateTime, txtMasaKontrakSampai.DateValue.HasValue ? txtMasaKontrakSampai.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@jnsjual", SqlDbType.VarChar, comboBoxJenisDag.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@segment", SqlDbType.VarChar, comboBoxJenisProd.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@namap", SqlDbType.VarChar, txtNamaPemilik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@jkp", SqlDbType.VarChar, comboBoxJenisKel.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tmplahirp", SqlDbType.VarChar, txtTempatLahir.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@tgllahirp", SqlDbType.DateTime, txtTglLahirP.DateValue.HasValue ? txtTglLahirP.DateValue.Value : SqlDateTime.Null));
                    db.Commands[0].Parameters.Add(new Parameter("@alamatp", SqlDbType.VarChar, txtAlamatPemilik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelpp", SqlDbType.VarChar, txtTelpRumah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nohpp", SqlDbType.VarChar, txtHPRumah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@emailp", SqlDbType.VarChar, txtEmail.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@norekp", SqlDbType.VarChar, txtNomorRek.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@nmbankp", SqlDbType.VarChar, comboBoxBank.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.VarChar, comboBoxStatusToko.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, dtH.Rows[0]["kd_toko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoID.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@lastorder", SqlDbType.DateTime, SqlDateTime.Null));

                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb2rp", SqlDbType.Int, Convert.ToDouble(tg_fb2rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb4rp", SqlDbType.Int, Convert.ToDouble(tg_fb4rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe2rp", SqlDbType.Int, Convert.ToDouble(tg_fe2rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe4rp", SqlDbType.Int, Convert.ToDouble(tg_fe4rp.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fxrp", SqlDbType.Int, Convert.ToDouble(tg_fxrp.GetIntValue)));

                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb2sku", SqlDbType.Int, Convert.ToDouble(tg_fb2sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fb4sku", SqlDbType.Int, Convert.ToDouble(tg_fb4sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe2sku", SqlDbType.Int, Convert.ToDouble(tg_fe2sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fe4sku", SqlDbType.Int, Convert.ToDouble(tg_fe4sku.GetIntValue)));
                    db.Commands[0].Parameters.Add(new Parameter("@tg_fxsku", SqlDbType.Int, Convert.ToDouble(tg_fxsku.GetIntValue)));

                    db.Commands[0].Parameters.Add(new Parameter("SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }

                RefreshGridHeader();
                this.Close();
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

        private void initLoadFormInsert()
        {
            RadioMilik.Checked = true;

            lblMasaKontrak.Visible = false;
            txtMasaKontrakDari.Visible = false;
            lblSD.Visible = false;
            txtMasaKontrakSampai.Visible = false;

            lblTahunBerdiri.Visible = true;
            txtTahunBerdiri.Visible = true;

        }

        private void initLoadFormUpdate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                    dtH = db.Commands[0].ExecuteDataTable();
                }
             
                lookupToko.SetNamaToko(dtH.Rows[0]["namatoko"].ToString()) ;
                txtTokoID.Text = dtH.Rows[0]["idtoko"].ToString();
                txtAlamatKirim.Text = dtH.Rows[0]["alamat"].ToString();
                txtKota.Text = dtH.Rows[0]["kota"].ToString();
                txtTelp.Text = dtH.Rows[0]["notelp"].ToString();
                txtFax.Text = dtH.Rows[0]["nofax"].ToString();
                txtIDWil.Text = dtH.Rows[0]["idwil"].ToString();
                txtDaerah.Text = dtH.Rows[0]["daerah"].ToString();
                txtProvince.Text = dtH.Rows[0]["propinsi"].ToString();
                switch (Convert.ToInt16(dtH.Rows[0]["sts"]))
                {
                    case 1 :
                        RadioMilik.Checked = true;
                        if (!dtH.Rows[0]["dbangun"].ToString().Equals(""))
                        {
                            txtTahunBerdiri.DateValue = Convert.ToDateTime(dtH.Rows[0]["dbangun"]);
                        } 
                        
                        break;
                    case 2:
                        RadioKontrak.Checked = true;
                        if (!dtH.Rows[0]["dkontrak1"].ToString().Equals(""))
                        {
                            txtMasaKontrakDari.DateValue = Convert.ToDateTime(dtH.Rows[0]["dkontrak1"]);
                        }
                         if (!dtH.Rows[0]["dkontrak2"].ToString().Equals(""))
                        {
                            txtMasaKontrakSampai.DateValue = Convert.ToDateTime(dtH.Rows[0]["dkontrak2"]);
                        } 
                  
                        break;
                }

                comboBoxJenisDag.Text = dtH.Rows[0]["jnsjual"].ToString();
                comboBoxJenisProd.Text = dtH.Rows[0]["segment"].ToString();
                txtNamaPemilik.Text = dtH.Rows[0]["namap"].ToString();
                comboBoxJenisKel.Text = dtH.Rows[0]["jkp"].ToString();
                if (!dtH.Rows[0]["tgllahirp"].ToString().Equals(""))
                {  txtTglLahirP.DateValue =Convert.ToDateTime(dtH.Rows[0]["tgllahirp"]);
                } 
                 
                
                txtTempatLahir.Text = dtH.Rows[0]["tmplahirp"].ToString();
                txtAlamatPemilik.Text = dtH.Rows[0]["alamatp"].ToString();
                txtTelpRumah.Text = dtH.Rows[0]["notelpp"].ToString();
                txtHPRumah.Text = dtH.Rows[0]["nohpp"].ToString();
                txtEmail.Text = dtH.Rows[0]["emailp"].ToString();
                txtNomorRek.Text = dtH.Rows[0]["norekp"].ToString();
                comboBoxBank.Text = dtH.Rows[0]["nmbankp"].ToString();
                comboBoxStatusToko.Text = dtH.Rows[0]["lpasif"].ToString();
                txtNoID.Text = dtH.Rows[0]["no_id"].ToString();

                tg_fb2rp.Text = dtH.Rows[0]["tg_fb2rp"].ToString();
                tg_fb4rp.Text = dtH.Rows[0]["tg_fb4rp"].ToString();
                tg_fb2sku.Text = dtH.Rows[0]["tg_fe2rp"].ToString();
                tg_fb4sku.Text = dtH.Rows[0]["tg_fe4rp"].ToString();
                tg_fe2rp.Text = dtH.Rows[0]["tg_fb2sku"].ToString();
                tg_fe4rp.Text = dtH.Rows[0]["tg_fb4sku"].ToString();

                tg_fe2sku.Text = dtH.Rows[0]["tg_fe2sku"].ToString();
                tg_fe4sku.Text = dtH.Rows[0]["tg_fe4sku"].ToString();
                tg_fxrp.Text = dtH.Rows[0]["tg_fxrp"].ToString();
                tg_fxsku.Text = dtH.Rows[0]["tg_fxsku"].ToString();

                lblSwitch.Visible = true;
                cbSwitch.Visible = true;
                cbSwitch.Text = FlagKtg;

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

        public frmCustomerIntiUpdate()
        {
            InitializeComponent();
        }

        public frmCustomerIntiUpdate(Form caller ,string _FlagKtg)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            FlagKtg = _FlagKtg;
        }

        public frmCustomerIntiUpdate(Form caller, Guid rowID, string _FlagKtg)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            FlagKtg = _FlagKtg;
        }

        private void frmCustomerIntiUpdate_Load(object sender, EventArgs e)
        {
            switch (FlagKtg)
            {
                case "INTI" :
                    this.Title = "CUSTOMER INTI";
                    break;
                case "MITRAPS" :
                    this.Title = "MITRA PS";
                    break;
                case "MITRASAS" :
                    this.Title = "MITRA SAS";
                    break;
                case "REG":
                    this.Title = "REGULAR";
                    break;
            }
            switch (formMode)
            {
                case enumFormMode.New:
                    initLoadFormInsert();
                    break;
                case enumFormMode.Update:
                    initLoadFormUpdate();
                    break;
            }
        }

        private void lookupToko_SelectData(object sender, EventArgs e)
        {
            try
            {
                DataTable dtToko = new DataTable();
                DataTable dtStsToko = new DataTable();
                object stsToko;

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetStatusToko"));
                    db.Commands[0].Parameters.Add(new Parameter("@tglDO", SqlDbType.DateTime, DateTime.Now));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@c1", SqlDbType.VarChar, initCab));
                    stsToko = db.Commands[0].ExecuteScalar();

                    db.Commands.Add(db.CreateCommand("usp_StsToko_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, lookupToko.KodeToko));
                    dtStsToko = db.Commands[1].ExecuteDataTable();
                }
                _nameToko = lookupToko.NamaToko;

                string stsTk = stsToko.ToString();
                txtStatus.Text = stsToko.ToString();
                txtAlamatKirim.Text = lookupToko.Alamat;
                txtKota.Text = lookupToko.Kota;
                txtTokoID.Text = lookupToko.TokoID;
                txtIDWil.Text = lookupToko.WilID;
                txtDaerah.Text = lookupToko.Daerah;


            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }



        private void RadioMilik_CheckedChanged(object sender, EventArgs e)
        {
            lblMasaKontrak.Visible = false;
            txtMasaKontrakDari.Visible = false;
            lblSD.Visible = false;
            txtMasaKontrakSampai.Visible = false;

            lblTahunBerdiri.Visible = true;
            txtTahunBerdiri.Visible = true;
        }

        private void RadioKontrak_CheckedChanged(object sender, EventArgs e)
        {
            lblMasaKontrak.Visible = true;
            txtMasaKontrakDari.Visible = true;
            lblSD.Visible = true;
            txtMasaKontrakSampai.Visible = true;

            lblTahunBerdiri.Visible = false;
            txtTahunBerdiri.Visible = false;
        }


        private bool validasiData()
        {

            if (txtTokoID.Text == "")
            {
                MessageBox.Show("Toko Harus diPilih");
                return false;
            }
            
            DataTable dtCI = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_CSM_Customer_Inti"));
                switch (formMode)
                {
                    case enumFormMode.New:
                        db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, FlagKtg));
                        break;
                    case enumFormMode.Update:
                        db.Commands[0].Parameters.Add(new Parameter("@flagKtg", SqlDbType.VarChar, cbSwitch.Text));
                        break;
                }
                
                db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, txtTokoID.Text));
                dtCI = db.Commands[0].ExecuteDataTable();

            }
            if (dtCI.Rows.Count > 0)
            {
                MessageBox.Show("Data sudah ada");
                return false;
            }


            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        if (validasiData())
                        {
                            insertData();
                        }
                        break;
                    case enumFormMode.Update:
                        if (validasiData())
                        { 
                            UpdateData();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;

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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       
    }

}
