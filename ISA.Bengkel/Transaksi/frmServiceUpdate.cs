using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel;
using ISA.Bengkel.Helper;
using System.Data.SqlTypes;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmServiceUpdate : ISA.Bengkel.BaseForm
    {
        public event EventHandler SelectData;
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dtService;
        Guid _rowID;
        Guid _rowIDNota;
        string BarcodeNota;
        string NoServis;
        Int32 _ServiceKe;
        Guid _RowIDCust;
        public frmServiceUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmServiceUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmServiceUpdate_Load(object sender, EventArgs e)
        {
            txtKM.Text = "0";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                dtService = new DataTable();
                if (formMode == enumFormMode.Update)
                {
                    using (Database db = new Database())
                    {                   
                        db.Commands.Add(db.CreateCommand("usp_bkl_service_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtService = db.Commands[0].ExecuteDataTable();                  
                    }               
                    txtTglService.DateValue = (DateTime)dtService.Rows[0]["tgl_srv"];
                    txtNoDoc.Text = dtService.Rows[0]["nomor"].ToString();
                    txtNoUrut.Text = dtService.Rows[0]["no_antri"].ToString();

                    //if(dtService.Rows[0]["perbaikan"].ToString() == "YA")
                    //    cbxPerbaikan.Checked = true;
                    //else
                    //    cbxPerbaikan.Checked = false;


                    txtShift.Text = dtService.Rows[0]["shift"].ToString();
                    lookupCustomerBengkel1.KodeCust = dtService.Rows[0]["kd_cust"].ToString();
                    lookupCustomerBengkel1.NamaCust = dtService.Rows[0]["nama_cust"].ToString();
                    txtNamaCust.Text = dtService.Rows[0]["nama_cust"].ToString();
                    txtNoPol.Text = dtService.Rows[0]["no_pol"].ToString();
                    lookupSepedaMotor1.KodeSepedaMotor = dtService.Rows[0]["kd_spm"].ToString();
                    lookupSepedaMotor1.NamaSepedaMotor = dtService.Rows[0]["jns_spm"].ToString();
                    // = dtService.Rows[0]["spm"].ToString();

                    txtWarna.Text = dtService.Rows[0]["warna"].ToString();
                    txtTahun.Text = dtService.Rows[0]["tahun"].ToString();
                    txtSPMType.Text = dtService.Rows[0]["jns_spm"].ToString();
                    txtSPMTypeDesc.Text = dtService.Rows[0]["spm"].ToString();
                    txtKM.Text = dtService.Rows[0]["km"].ToString();
                    txtKeluhan.Text = dtService.Rows[0]["keluhan"].ToString();

                    txtPemilik.Text = dtService.Rows[0]["nama_cust"].ToString();
                    txtAlamat.Text = dtService.Rows[0]["alamat"].ToString();
                    txtNoKTP_SIM.Text = dtService.Rows[0]["no_id"].ToString();
                    txtIDMember.Text = dtService.Rows[0]["id_member"].ToString();
                    txtTelp.Text = dtService.Rows[0]["no_telp"].ToString();

                    lkpMekanik.KodeMekanik = dtService.Rows[0]["kd_mk"].ToString();
                    lkpMekanik.NamaMekanik = dtService.Rows[0]["mekanik"].ToString();
                    txtMekanik.Text = dtService.Rows[0]["mekanik"].ToString();
                    txtSaran1.Text = dtService.Rows[0]["saran1"].ToString();
                    txtSaran2.Text = dtService.Rows[0]["saran2"].ToString();
                    txtService.Text = dtService.Rows[0]["servis"].ToString();

                    lookupSales1.NamaSales = dtService.Rows[0]["NamaSales"].ToString();
                    lookupSales1.KodeSales = dtService.Rows[0]["kd_sales"].ToString();

                }
                else
                {
                    txtTglService.DateValue = DateTime.Now;
                }

                if (GlobalVar.CabangID != "28")
                {
                    label19.Visible = false;
                    txtIDMember.Visible = false;
                }
                txtNoPol.Focus();
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

        private string GetInitialPT()
        {
            string code1;
            string code2;
            string code3;

            DataTable dtGudang;
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, GlobalVar.Gudang));
                dtGudang = db.Commands[0].ExecuteDataTable();
            }
            code1 = dtGudang.Rows[0]["Fax"].ToString();
            code2 = Tools.ToCode("NOTA_PT_M");
            code3 = Tools.ToCode("NOTA_PT_Y");

            return code1 + code2 + code3;
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            string valcust = ValidateCust(_RowIDCust);
            if (cboService.SelectedIndex != 1 && valcust == "") {
                MessageBox.Show("Customer Belum terdaftar di Tabel Instansi, Silahkan di daftarkan terlebih dahulu di \n"+
                    "Master -> Master Instansi -> Add Grid ke 2");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (txtTglService.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        string _noService, numeratorDoc = "NOMOR_SERVICE", depan = "", belakang = "";
                        int iNomor, lebar;
                        
                        depan = GetInitialPT();
                        DataTable dtNum = Tools.GetGeneralNumerator(numeratorDoc);
                        lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                        belakang = dtNum.Rows[0]["Belakang"].ToString();
                        if (Tools.isNull(dtNum.Rows[0]["Depan"], "").ToString() != depan)
                            iNomor = 1;
                        else
                        {
                            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                            iNomor++;
                        }
                        _noService = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

                        string HtrId = GlobalVar.PerusahaanID + Tools.CreateFingerPrint().Substring(0, 16) + SecurityManager.UserInitial;
                        
                        //BarcodeNota  = _noService.Trim() + "S" + GlobalVar.DateTimeOfServer.ToString("yyyy").Substring(2, 2) +
                        //               GlobalVar.DateTimeOfServer.ToString("MM");
                        //BarcodeNota = txtNoDoc.Text.Trim() + "S" + GlobalVar.DateTimeOfServer.ToString("yyyy").Substring(2, 2) +
                        //               GlobalVar.DateTimeOfServer.ToString("MM");
                        
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_service_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_srv", SqlDbType.DateTime, txtTglService.DateValue));

                            //db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.VarChar, txtNoDoc.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@no_antri", SqlDbType.VarChar, txtNoDoc.Text));
                            //if (cbxPerbaikan.Checked)
                            //    db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "Y"));
                            //else
                            //    db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "N"));

                            if (cboService.Text.Trim() == "Umum")
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "N"));
                            else if (cboService.Text.Trim() == "Perbaikan Inventaris")
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "Y"));
                            else if (cboService.Text.Trim() == "Instansi")
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "I"));
                            else if (cboService.Text.Trim() == "Sekolah")
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "S"));
                            else if (cboService.Text.Trim() == "Perbaikan Karyawan")
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "K"));

                            db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.VarChar, _noService));
                            db.Commands[0].Parameters.Add(new Parameter("@no_antri", SqlDbType.VarChar, txtNoUrut.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, txtShift.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idcust", SqlDbType.VarChar, "BENGKEL"));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_cust", SqlDbType.VarChar, lookupCustomerBengkel1.KodeCust));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lookupSepedaMotor1.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@km", SqlDbType.Int, Convert.ToInt32(txtKM.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@keluhan", SqlDbType.VarChar, txtKeluhan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoKTP_SIM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtIDMember.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_mk", SqlDbType.VarChar, lkpMekanik.KodeMekanik));
                            db.Commands[0].Parameters.Add(new Parameter("@mekanik", SqlDbType.VarChar, lkpMekanik.NamaMekanik));
                            db.Commands[0].Parameters.Add(new Parameter("@saran1", SqlDbType.VarChar, txtSaran1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@saran2", SqlDbType.VarChar, txtSaran2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@saran3", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, lookupSales1.KodeSales));
                            db.Commands[0].Parameters.Add(new Parameter("@Idtr", SqlDbType.VarChar, HtrId));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@JmlService", SqlDbType.Int, Convert.ToInt32(Tools.isNull(txtService.Text,"0").ToString())));

                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                                        
                            //EXECUTE COMMANDS
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();   
                        }
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DateTime tglService = (DateTime)dtService.Rows[0]["tgl_srv"];
                            NoServis = Tools.isNull(dtService.Rows[0]["nomor"],"").ToString();
                            //BarcodeNota = NoServis.Trim() + "S" + tglService.ToString("yyyy").Substring(2, 2) + tglService.ToString("MM");
                            _rowID = (Guid)dtService.Rows[0]["RowID"];
                            _rowIDNota = (Guid)Tools.isNull(dtService.Rows[0]["RowIDNota"],Guid.Empty);

                            db.Commands.Add(db.CreateCommand("usp_bkl_service_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDNota", SqlDbType.UniqueIdentifier, _rowIDNota));
                            db.Commands[0].Parameters.Add(new Parameter("@shift", SqlDbType.VarChar, txtShift.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idcust", SqlDbType.VarChar, "BENGKEL"));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_cust", SqlDbType.VarChar, lookupCustomerBengkel1.KodeCust));
                            db.Commands[0].Parameters.Add(new Parameter("@no_pol", SqlDbType.VarChar, txtNoPol.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@spm", SqlDbType.VarChar, txtSPMTypeDesc.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@warna", SqlDbType.VarChar, txtWarna.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tahun", SqlDbType.VarChar, txtTahun.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_spm", SqlDbType.VarChar, lookupSepedaMotor1.KodeSepedaMotor));
                            db.Commands[0].Parameters.Add(new Parameter("@jns_spm", SqlDbType.VarChar, txtSPMType.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@km", SqlDbType.VarChar, txtKM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@keluhan", SqlDbType.VarChar, txtKeluhan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_cust", SqlDbType.VarChar, txtPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_id", SqlDbType.VarChar, txtNoKTP_SIM.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@id_member", SqlDbType.VarChar, txtIDMember.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@no_telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_mk", SqlDbType.VarChar, lkpMekanik.KodeMekanik));
                            db.Commands[0].Parameters.Add(new Parameter("@mekanik", SqlDbType.VarChar, lkpMekanik.NamaMekanik));
                            db.Commands[0].Parameters.Add(new Parameter("@saran1", SqlDbType.VarChar, txtSaran1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@saran2", SqlDbType.VarChar, txtSaran2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@saran3", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, lookupSales1.KodeSales));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@JmlService", SqlDbType.Int, Convert.ToInt32(txtService.Text)));

                            if (cbxPerbaikan.Checked)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "Y"));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@perbaikan", SqlDbType.VarChar, "N"));
                            };

                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                if (this.Caller is frmServiceBrowser)
                {
                    frmServiceBrowser frmCaller = (frmServiceBrowser)this.Caller;
                    frmCaller.RefreshDataService();
                    frmCaller.FindRowBkl("RowID", _rowID.ToString());
                }
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

        private string ValidateCust(Guid RowIDCust) {
            string cust = "";
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("usp_CekCustInstansiBengkel"));
                    db.Commands[0].Parameters.Add(new Parameter("@IDCust", SqlDbType.UniqueIdentifier, _RowIDCust));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count > 0)
                {
                    cust = "ada";
                }
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
            return cust;
        }
        private bool ValidateInput()
        {
            bool valid = true;

            if (Tools.isNull(txtTglService.Text.ToString(), "") == "")
            {
                MessageBox.Show("Tanggal Service masih kosong..");
                txtTglService.Focus();
                valid = false;
            }
            if (Tools.isNull(txtNoPol.Text.ToString(), "") == "")
            {
                MessageBox.Show("No Polisi masih kosong..");
                txtNoPol.Focus();
                valid = false;
            }
            if (Tools.isNull(txtMekanik.Text.ToString(), "") == "")
            {
                MessageBox.Show("Mekanik masih kosong..");
                txtMekanik.Focus();
                valid = false;
            }
            if (Tools.isNull(lookupSales1.NamaSales, "").ToString() == "")
            {
                MessageBox.Show("Customer Service masih kosong.");
                lookupSales1.Focus();
                valid = false;
            }
            if (Tools.isNull(cboService.Text, "").ToString() == "")
            {
                MessageBox.Show("Kategori Service masih kosong.");
                cboService.Focus();
                valid = false;
            }
            return valid;
        }
            //|| Tools.isNull(txtTglService.Text.ToString(), "") == "" ||
                //txtNoPol.Text=="")

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmServiceUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.DialogResult == DialogResult.OK)
            //{
            //    if (this.Caller is frmServiceBrowser)
            //    {
            //        frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
            //        //formCaller.RefreshDataService();
            //        formCaller.FindRow(FormTools.detailIndex.header, "RowID", _rowID.ToString());
            //    }
            //}
        }

        private void lookupSepedaMotor1_SelectData(object sender, EventArgs e)
        {
            try
            {
                //txtSPMType.Text = lookupSepedaMotor1.;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void lkpMekanik_SelectData(object sender, EventArgs e)
        {
            try
            {
                txtMekanik.Text = lkpMekanik.NamaMekanik;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        public void SearchNoPol()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bklCust_Search"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNoPol.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        txtNoPol.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                        lookupCustomerBengkel1.NamaCust = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        lookupCustomerBengkel1.KodeCust = Tools.isNull(dt.Rows[0]["kd_cust"], "").ToString();
                        lookupSepedaMotor1.NamaSepedaMotor = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                        lookupSepedaMotor1.KodeSepedaMotor = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                        txtSPMType.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                        txtSPMTypeDesc.Text = Tools.isNull(dt.Rows[0]["spm"], "").ToString();
                        txtWarna.Text = Tools.isNull(dt.Rows[0]["warna"], "").ToString();
                        txtTahun.Text = Tools.isNull(dt.Rows[0]["tahun"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                        txtPemilik.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        txtTelp.Text = Tools.isNull(dt.Rows[0]["no_telp"], "").ToString();

                        GetDataService(txtNoPol.Text);

                        txtService.Text = Tools.isNull(_ServiceKe,"1").ToString();

                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtNoPol.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void GetDialogResult(frmLookupSPM dialogForm)
        {
            lookupCustomerBengkel1.NamaCust = dialogForm.namacust;
            lookupCustomerBengkel1.KodeCust = dialogForm.kodecust;
            txtNamaCust.Text = dialogForm.namacust;
            txtNoPol.Text = dialogForm.nopol;
            lookupSepedaMotor1.NamaSepedaMotor = dialogForm.Spm;
            lookupSepedaMotor1.KodeSepedaMotor = dialogForm.Kd_spm;
            txtSPMType.Text = dialogForm.Jns_spm;
            txtSPMTypeDesc.Text = dialogForm.Spm;
            txtWarna.Text = dialogForm.Warna;
            txtTahun.Text = dialogForm.Tahun;
            txtPemilik.Text = dialogForm.namacust;
            txtAlamat.Text = dialogForm.Alamat;
            txtNoKTP_SIM.Text = dialogForm.Ktp;
            txtTelp.Text = dialogForm.telpon;
            _RowIDCust = dialogForm.RowIDCustGet;
            GetDataService(txtNoPol.Text);
            txtService.Text = Tools.isNull(_ServiceKe, "1").ToString();


            //txtKM.Text = dialogForm.Km;
            //txtKeluhan.Text = dialogForm.Keluhan;
            //txtAlamat.Text = dialogForm.Alamat;
            //txtPemilik.Text =dialogForm.namacust;
            //txtNoKTP_SIM.Text = dialogForm.Noid;
            //txtTelp.Text = dialogForm.telpon;
            //txtIDMember.Text = dialogForm.idmember;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            frmLookupSPM ifrmDialog = new frmLookupSPM(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtNoPol.Focus();
            }
        }

  
        private void Clear()
        {
            txtNoPol.Text = string.Empty;
            lookupCustomerBengkel1.NamaCust = string.Empty;
            lookupCustomerBengkel1.KodeCust = string.Empty;
            lookupSepedaMotor1.NamaSepedaMotor = string.Empty;
            lookupSepedaMotor1.KodeSepedaMotor = string.Empty;
            txtSPMType.Text = string.Empty;
            txtSPMTypeDesc.Text = string.Empty;
            txtWarna.Text = string.Empty;
            txtTahun.Text = string.Empty;
            txtKM.Text = string.Empty;
            txtKeluhan.Text = string.Empty;
            txtAlamat.Text = string.Empty;
            txtPemilik.Text = string.Empty;
            txtNoKTP_SIM.Text = string.Empty;
            txtTelp.Text = string.Empty;
            txtIDMember.Text = string.Empty;
            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void lookupCustomerBengkel1_SelectData(object sender, EventArgs e)
        {
            try
            {
                txtNamaCust.Text = lookupCustomerBengkel1.NamaCust;
                txtNoPol.Text = lookupCustomerBengkel1.NoPol;
                lookupSepedaMotor1.NamaSepedaMotor = lookupCustomerBengkel1.JnsSpm;
                lookupSepedaMotor1.KodeSepedaMotor = lookupCustomerBengkel1.KodeSpm;
                txtSPMType.Text = lookupCustomerBengkel1.JnsSpm;
                txtSPMTypeDesc.Text = lookupCustomerBengkel1.Spm;
                txtWarna.Text = lookupCustomerBengkel1.Warna;
                txtTahun.Text = lookupCustomerBengkel1.Tahun;
                txtAlamat.Text = lookupCustomerBengkel1.Alamat;
                txtPemilik.Text = lookupCustomerBengkel1.Pemilik;
                txtNoKTP_SIM.Text = lookupCustomerBengkel1.NoID;
                txtTelp.Text = lookupCustomerBengkel1.NoTelp;
                txtIDMember.Text = lookupCustomerBengkel1.IdMember;

                /*input manual user*/
                //DataTable dth = new DataTable();
                //using (Database db = new Database())
                //{
                //    db.Commands.Add(db.CreateCommand("usp_bkl_mCustomerService_COUNT"));
                //    db.Commands[0].Parameters.Add(new Parameter("@NoPol", SqlDbType.VarChar, lookupCustomerBengkel1.NoPol));
                //    db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, lookupCustomerBengkel1.NamaCust));
                //    dth = db.Commands[0].ExecuteDataTable();
                //    if (dth.Rows.Count > 0)
                //    {
                //        txtService.Text = (Convert.ToInt32(dth.Rows[0]["JmlService"].ToString()) + 1).ToString();
                //    }
                //    else
                //    {
                //        txtService.Text = "1";
                //    }
                //}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void txtNoPol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNoPol.Text != "")
                {
                    SearchNoPol();
                }
                else
                {
                    Clear();
                }
            }
        }

        private void txtNoPol_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtNoPol_Leave(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bklServiceKe_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNoPol.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        _ServiceKe = dt.Rows.Count;
                    else
                        _ServiceKe = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            MessageBox.Show(_ServiceKe.ToString());

        }

        private void GetDataService(string NoPol)
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bklServiceKe_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, NoPol));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count > 0)
                        _ServiceKe = dt.Rows.Count;
                    else
                        _ServiceKe = 0;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

    }
}
