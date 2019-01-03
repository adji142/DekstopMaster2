using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Master
{
    public partial class frmCustomerUpdate : ISA.Bengkel.BaseForm
    {
        public event EventHandler SelectData;
        FormTools.enumFormMode formMode;
        Guid rowID, headerID, rowIDDet;
        Guid _kecamatanID,_kerjaID,_motorID,_dealerID;

        int lebar = 4, nomor;
        string depan = "", belakang = "";

        DataTable dt;

        public frmCustomerUpdate(Form caller)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.New;
            this.Caller = caller;
        }

        public frmCustomerUpdate(Form caller, Guid _rowID, Guid _rowIDdetail)
        {
            InitializeComponent();
            formMode = FormTools.enumFormMode.Update;
            rowID  = _rowID;
            rowIDDet = _rowIDdetail;
            this.Caller = caller;            
        }

        public frmCustomerUpdate(Form caller, Guid _rowID, Guid _rowIDdetail, FormTools.enumFormMode _formMode)
        {
            InitializeComponent();
            formMode = _formMode;
            if (formMode == FormTools.enumFormMode.Update)
            {
                rowID = _rowID;
                rowIDDet = _rowIDdetail;
            }
            else
            {
                headerID = _rowID;
                MessageBox.Show("insert");
            }
            this.Caller = caller;
            return;
        }

        private void frmCustomerUpdate_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            txtNoMember.Visible = false;
            label10.Visible = false;
            txtKet1.Visible = false;
            label11.Visible = false;
            if (GlobalVar.CabangID.Contains("06")) //AHASS
            {
                //label7.Visible = false;
                //txtNoMember.Visible = false;
                //label10.Visible = false;
                //txtKet1.Visible = false;
                //label11.Visible = false;
                label24.Visible = false; //daerah
                txtDaerah.Visible = false;//daerah
                txtSPMTypeDesc.Visible = false;//jenis spm
                label25.Visible = false;//asal dealer
                txtAsalDealer.Visible = false;//asal dealer

            }
            else //depo
            {
                //label7.Visible = false;
                //txtNoMember.Visible = false;
                //label10.Visible = false;
                //txtKet1.Visible = false;
                //label11.Visible = false;
                label9.Visible = false; //cmb kecamatan
                cboKecamatan.Visible = false;//cmb kecamatan
                cboJnsMotor.Visible = false;//jenis spm
                label23.Visible = false;//jenis kerja
                cboJnsKerja.Visible = false;//jenis kerja
                label21.Visible = false;//asal dealer
                cboAsalDealer.Visible = false;//asal dealer
                txtSPMTypeDesc.Visible = true;
                txtAsalDealer.Visible = true;
                txtSPMTypeDesc.Enabled = true;
                txtAsalDealer.Enabled = true;

            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dtSPM = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_bkl_mMotor_LIST"));
                    dtSPM = db.Commands[0].ExecuteDataTable();
                }
                cmbSPMType.DisplayMember = "jns_spm";
                cmbSPMType.ValueMember = "kode";
                cmbSPMType.DataSource = dtSPM;
                if (GlobalVar.Gudang.Contains("0601"))//AHASS
                {

                    this.ListKecamatan();
                    this.ListPekerjaan();
                    this.ListAsalDealer();
                    this.ListJnsMotor();
                }
                else
                {
                }
                
                if (formMode == FormTools.enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {

                        if (formMode == FormTools.enumFormMode.Update)
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDdetail", SqlDbType.UniqueIdentifier, rowIDDet));
                            dt = db.Commands[0].ExecuteDataTable();
                        }
                    }

                    /*data customer*/
                    txtIDCust.Text = Tools.isNull(dt.Rows[0]["idcust"], "").ToString();
                    txtIDCust.Enabled = false;
                    txtCustNama.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
                    if (GlobalVar.Gudang.Contains("0601")) //AHASS
                    {
                        cboKecamatan.Text = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();
                    }
                    else
                    {
                        txtDaerah.Text = Tools.isNull(dt.Rows[0]["daerah"], "").ToString();
                    }
                    txtNoTelepon.Text = Tools.isNull(dt.Rows[0]["no_telp"], "").ToString();
                    txtKTP.Text = Tools.isNull(dt.Rows[0]["no_id"], "").ToString();
                    txtNoMember.Text = Tools.isNull(dt.Rows[0]["no_member"], "").ToString();
                    txtKet1.Text = Tools.isNull(dt.Rows[0]["ket"], "").ToString();
                    txtKet2.Text = Tools.isNull(dt.Rows[0]["instansi"], "").ToString();
                    txtAgama.Text = Tools.isNull(dt.Rows[0]["agama"], "").ToString();
                    lookupCustomerALL1.NomerMember = dt.Rows[0]["no_member"].ToString();
                    if (GlobalVar.Gudang.Contains("0601")) //AHASS
                    {
                        cboAsalDealer.Text = Tools.isNull(dt.Rows[0]["AsalDealer"], "").ToString();
                    }
                    else
                    {
                        txtAsalDealer.Text = Tools.isNull(dt.Rows[0]["AsalDealer"], "").ToString();
                    }
                    cboJnsKerja.Text = Tools.isNull(dt.Rows[0]["JenisPekerjaan"], "").ToString();

                    /*data spm*/
                    txtNoPol.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                    txtSPM.Text = Tools.isNull(dt.Rows[0]["spm"], "").ToString();
                    txtTahun.Text = Tools.isNull(dt.Rows[0]["tahun"], "").ToString();
                    txtWarna.Text = Tools.isNull(dt.Rows[0]["warna"], "").ToString();
                    txtNoMesin.Text = Tools.isNull(dt.Rows[0]["no_mesin"], "").ToString();
                    txtNoRangka.Text = Tools.isNull(dt.Rows[0]["no_rangka"], "").ToString();
                    cmbSPMType.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                    if (GlobalVar.Gudang.Contains("0601")) //AHASS
                    {
                        cboJnsMotor.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                    }
                    else
                    {
                        txtSPMTypeDesc.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                    }
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

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (formMode.ToString() == "New")
            {
                depan = Tools.GeneralInitial();
                DataTable dtNum = new DataTable();
                dtNum = Tools.GetGeneralNumerator("IDCUST_BENGKEL", depan);

                if (dtNum.Rows.Count > 0)
                {
                    lebar = int.Parse(Tools.isNull(dtNum.Rows[0]["Lebar"], "4").ToString());
                    nomor = int.Parse(Tools.isNull(dtNum.Rows[0]["Nomor"], "0").ToString());
                    belakang = Tools.isNull(dtNum.Rows[0]["Belakang"], "").ToString();
                }
                else
                {
                    nomor = 0;
                    lebar = 4;
                }
                nomor++;
                string idCust = Tools.FormatNumerator(nomor, lebar, depan, belakang);
                txtIDCust.Text = idCust;
            }

            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                {
                    case FormTools.enumFormMode.New:
                        rowID = Guid.NewGuid();
                        string kd_cust = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHH:mm:ss}", GlobalVar.DateTimeOfServer);
                        string nama = Tools.isNull(txtCustNama.Text, "").ToString();
                        string alamat = Tools.isNull(txtAlamat.Text, "").ToString();
                        string kota = Tools.isNull(txtKota.Text, "").ToString();
                        string ktp = Tools.isNull(txtKTP.Text, "").ToString();
                        Guid _rID1 = Guid.Empty;
                        Guid _rID2 = Guid.Empty;

                        DataTable dtc = new DataTable();
                        DataTable dtm = new DataTable();

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_CEK"));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            dtm = db.Commands[0].ExecuteDataTable();
                        }
                        if (dtm.Rows.Count > 0)
                        {
                            MessageBox.Show("No Polisi sudah ada !!");
                            return;
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@idcust", SqlDbType.VarChar, txtIDCust.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_cust", SqlDbType.VarChar, kd_cust));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtKTP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, nama));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, alamat));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, kota));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, cboKecamatan.SelectedValue));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtNoTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, txtNoMember.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKet1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@instansi", SqlDbType.VarChar, txtKet2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@ktp", SqlDbType.VarChar, ktp));
                            db.Commands[0].Parameters.Add(new Parameter("@agama", SqlDbType.VarChar, txtAgama.Text));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@AsalDealer", SqlDbType.VarChar, cboAsalDealer.SelectedValue));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@AsalDealer", SqlDbType.VarChar, txtAsalDealer.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@JenisPekerjaan", SqlDbType.VarChar, cboJnsKerja.SelectedValue));
                            db.Commands[0].ExecuteNonQuery();

                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_INSERT"));
                            db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[1].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPM.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@no_mesin", SqlDbType.VarChar, txtNoMesin.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@no_rangka", SqlDbType.VarChar, txtNoRangka.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbSPMType.SelectedValue));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[1].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, cboJnsMotor.SelectedValue));
                            }
                            else
                            {
                                db.Commands[1].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));
                            }
                            db.Commands[1].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[1].ExecuteNonQuery();

                            db.Commands.Add(db.CreateCommand("usp_Numerator_INSERT_UPDATE"));
                            db.Commands[2].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, "IDCUST_BENGKEL"));
                            db.Commands[2].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            db.Commands[2].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[2].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, nomor));
                            db.Commands[2].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[2].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[2].ExecuteNonQuery();
                        }
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtKTP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtCustNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, cboKecamatan.SelectedValue));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtNoTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_member", SqlDbType.VarChar, txtNoMember.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, txtKet1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@instansi", SqlDbType.VarChar, txtKet2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, false));
                            //db.Commands[0].Parameters.Add(new Parameter("@lpasif", SqlDbType.Bit, false));                            
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@agama", SqlDbType.VarChar, txtAgama.Text));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@AsalDealer", SqlDbType.VarChar, cboAsalDealer.SelectedValue));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@AsalDealer", SqlDbType.VarChar, txtAsalDealer.Text));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@JenisPekerjaan", SqlDbType.VarChar, cboJnsKerja.SelectedValue));

                            db.Commands.Add(db.CreateCommand("usp_bkl_mMotorService_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIDDet));
                            //db.Commands[1].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[1].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPM.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@no_mesin", SqlDbType.VarChar, txtNoMesin.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@no_rangka", SqlDbType.VarChar, txtNoRangka.Text));
                            db.Commands[1].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbSPMType.SelectedValue));
                            if (GlobalVar.Gudang.Contains("0601")) //AHASS
                            {
                                db.Commands[1].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, cboJnsMotor.SelectedValue));
                            }
                            else
                            {
                                db.Commands[1].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));
                            }
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                closeForm();
                this.Close();
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

        private bool ValidateInput()
        {
            bool valid = true;

            //if (FormTools.IsBlank(txtIDCust))
            //{
            //    valid = false;
            //    goto finish;
            //}

            if (FormTools.IsBlank(txtCustNama))
            {
                valid = false;
                goto finish;
            }

            if (formMode == FormTools.enumFormMode.New)
            {
                if (FormTools.IsDataExist("usp_bkl_mCustomerService_LIST", "@idcust", SqlDbType.VarChar, txtIDCust.Text))
                {
                    valid = false;
                    goto finish;
                }
            }

            finish:
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmCustomerBrowse)
                {
                    frmCustomerBrowse frmCaller = (frmCustomerBrowse)this.Caller;
                    frmCaller.RefreshData(FormTools.detailIndex.header);
                    frmCaller.FindHeader("RowID", rowID.ToString());
                    frmCaller.FindDetail("RowID2", rowIDDet.ToString());
                    //frmCaller.FindRow(FormTools.detailIndex.header, "RodID", rowID.ToString());
                }
            }
            //this.Close();
        }

        private void txtNoPol_Validating(object sender, CancelEventArgs e)
        {
            if (txtNoPol.Text.ToString().Trim().Contains(" ") == true)
            {
                MessageBox.Show("Nomor Polisi tidak boleh ada Spasi.");
                txtNoPol.Focus();
                return;
            }
        }

        private void txtMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNoMember.Text!= "")
                {
                    SearchNoMember();
                }
                else
                {
                    Clear();
                }
            }
        }
        public void SearchNoMember()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bklCustMember_Search"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNoMember.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtNoMember.Text = Tools.isNull(dt.Rows[0]["NoMember"],"").ToString();
                        txtCustNama.Text = Tools.isNull(dt.Rows[0]["Nama"],"").ToString();
                        txtAlamat.Text = Tools.isNull(dt.Rows[0]["AlamatIdt"], "").ToString();
                        txtKota.Text = Tools.isNull(dt.Rows[0]["KotaIdt"], "").ToString();
                        txtNoTelepon.Text = Tools.isNull(dt.Rows[0]["NoTelp"],"").ToString();
                        txtKTP.Text = Tools.isNull(dt.Rows[0]["NoIdentitas"],"").ToString();
                        if (GlobalVar.Gudang.Contains("0601")) //AHASS
                        {
                            txtDaerah.Text = Tools.isNull(dt.Rows[0]["KecamatanIdt"],"").ToString();
                        }
                        else
                        {
                            cboKecamatan.Text = Tools.isNull(dt.Rows[0]["KecamatanIdt"], "").ToString();
                        }
                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtNoMember.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
        private void Clear()
        {
            txtNoMember.Text = string.Empty;
            txtCustNama.Text = string.Empty;
            txtAlamat.Text = string.Empty;
            txtKota.Text = string.Empty;
            txtNoTelepon.Text = string.Empty;
            txtKTP.Text = string.Empty;
            if (GlobalVar.Gudang.Contains("0601")) //AHASS
            {
                cboKecamatan.Text = string.Empty; 
            }
            else
            {
                txtDaerah.Text = string.Empty;
            }
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            Lookup.FormData.frmCustomerALLLookup ifrmDialog = new Lookup.FormData.frmCustomerALLLookup(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtNoMember.Focus();
            }
        }
        private void GetDialogResult(Lookup.FormData.frmCustomerALLLookup dialogForm)
        {
            txtNoMember.Text = dialogForm.NomerMember;
            txtCustNama.Text = dialogForm.NamaCust;
            txtAlamat.Text = dialogForm.Alamat;
            txtKota.Text = dialogForm.Kota;
            txtKTP.Text = dialogForm.NoKTP;
            if (GlobalVar.Gudang.Contains("0601")) //AHASS
            {
                cboKecamatan.Text = dialogForm.Daerah;
            }
            else
            {
                txtDaerah.Text = dialogForm.Daerah;
            }
            txtNoTelepon.Text = dialogForm.NoTelepon;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }
        private void lookupCustomerALL1_SelectData(object sender, EventArgs e)
        {
            try
            {
                txtNoMember.Text = lookupCustomerALL1.NomerMember;
                txtCustNama.Text = lookupCustomerALL1.NamaCust;
                txtAlamat.Text = lookupCustomerALL1.Alamat;
                txtKota.Text = lookupCustomerALL1.Kota;
                txtNoTelepon.Text = lookupCustomerALL1.NoTelepon;
                txtKTP.Text = lookupCustomerALL1.NoKTP;
                if (GlobalVar.Gudang.Contains("0601")) //AHASS
                {
                    cboKecamatan.Text = lookupCustomerALL1.Daerah;
                }
                else
                {
                    txtDaerah.Text = lookupCustomerALL1.Daerah;
                }
                txtNoPol.Text = lookupCustomerALL1.NoPol;
                txtSPM.Text = lookupCustomerALL1.KdType;
                txtTahun.Text = lookupCustomerALL1.Tahun;
                txtWarna.Text = lookupCustomerALL1.Warna;
                txtNoMesin.Text = lookupCustomerALL1.NoMesin;
                txtNoRangka.Text = lookupCustomerALL1.NoRangka;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ListKecamatan()
        {
            DataTable dtkec = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Kecamatan_LIST"));//sp_kecamatan
                    dtkec = db.Commands[0].ExecuteDataTable();

                    dtkec.DefaultView.Sort = "NamaKecamatan ASC";
                    cboKecamatan.DisplayMember = "NamaKecamatan";
                    cboKecamatan.ValueMember = "NamaKecamatan";
                    cboKecamatan.DataSource = dtkec.DefaultView;
                } 
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ListPekerjaan()
        {
            DataTable dtkerja = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JnsPekerjaan_LIST"));
                    dtkerja = db.Commands[0].ExecuteDataTable();

                    dtkerja.DefaultView.Sort = "JenisKerja ASC";
                    cboJnsKerja.DisplayMember = "JenisKerja";
                    cboJnsKerja.ValueMember = "JenisKerja";
                    cboJnsKerja.DataSource = dtkerja.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ListAsalDealer()
        {
            DataTable dtdealer = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_AsalDealer_LIST"));//sp_kecamatan
                    dtdealer = db.Commands[0].ExecuteDataTable();

                    dtdealer.DefaultView.Sort = "nama_dealer ASC";
                    cboAsalDealer.DisplayMember = "nama_dealer";
                    cboAsalDealer.ValueMember = "nama_dealer";
                    cboAsalDealer.DataSource = dtdealer.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ListJnsMotor()
        {
            DataTable dtmotor = new DataTable();
            try
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_JenisMotor_LIST"));//sp_kecamatan
                    dtmotor = db.Commands[0].ExecuteDataTable();

                    dtmotor.DefaultView.Sort = "nama_type ASC";
                    cboJnsMotor.DisplayMember = "nama_type";
                    cboJnsMotor.ValueMember = "nama_type";
                    cboJnsMotor.DataSource = dtmotor.DefaultView;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void cboKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_kecamatanID = (Guid)cboKecamatan.SelectedValue;
            //ListKecamatan();
        }
        private void cboKecamatan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cboJnsKerja_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_kerjaID = (Guid)cboJnsKerja.SelectedValue;
            //ListPekerjaan();
        }
        private void cboJnsKerja_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cboJnsMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_motorID = (Guid)cboJnsMotor.SelectedValue;
            //ListJnsMotor();
        }
        private void cboJnsMotor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cboAsalDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_dealerID = (Guid)cboAsalDealer.SelectedValue;
            //ListAsalDealer();
      
        }
        private void cboAsalDealer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                SendKeys.Send("{TAB}");
            }
        }
        
    }
}
