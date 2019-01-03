using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel;
using ISA.Bengkel.Helper;
using System.Data.SqlTypes;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Master
{
    public partial class FrmInstansiEdit : ISA.Bengkel.BaseForm
    {
        public event EventHandler SelectData;
        Guid RowIDCust,_RowIDInstansi;
        string _NamaInstansi,_KodeToko;
        public FrmInstansiEdit()
        {
            InitializeComponent();
        }
        public FrmInstansiEdit(Guid RowIDInstansi,string namainstansi,string kodetoko)
        {
            InitializeComponent();
            _RowIDInstansi = RowIDInstansi;
            _NamaInstansi = namainstansi;
            _KodeToko = kodetoko;
        }
        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void commonTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtnopo.Text != "")
                {
                    SearchNoPol();
                }
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
                    db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtnopo.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    if (dt.Rows.Count == 1)
                    {
                        //txtNoPol.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                        //lookupCustomerBengkel1.NamaCust = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        //lookupCustomerBengkel1.KodeCust = Tools.isNull(dt.Rows[0]["kd_cust"], "").ToString();
                        //lookupSepedaMotor1.NamaSepedaMotor = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                        //lookupSepedaMotor1.KodeSepedaMotor = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                        //txtSPMType.Text = Tools.isNull(dt.Rows[0]["jns_spm"], "").ToString();
                        //txtSPMTypeDesc.Text = Tools.isNull(dt.Rows[0]["spm"], "").ToString();
                        //txtWarna.Text = Tools.isNull(dt.Rows[0]["warna"], "").ToString();
                        //txtTahun.Text = Tools.isNull(dt.Rows[0]["tahun"], "").ToString();
                        //txtAlamat.Text = Tools.isNull(dt.Rows[0]["alamat"], "").ToString();
                        //txtPemilik.Text = Tools.isNull(dt.Rows[0]["nama_cust"], "").ToString();
                        //txtTelp.Text = Tools.isNull(dt.Rows[0]["no_telp"], "").ToString();
                        //RowIDCust
                        RowIDCust = (Guid)Tools.isNull(dt.Rows[0]["RowIDCust"], Guid.Empty);
                        txtnopo.Text = Tools.isNull(dt.Rows[0]["no_pol"], "").ToString();
                        //txtService.Text = Tools.isNull(_ServiceKe, "1").ToString();

                        if (this.SelectData != null)
                        {
                            this.SelectData(this, new EventArgs());
                        }
                    }
                    else
                    {
                        ShowDialogForm(txtnopo.Text, dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

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
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        private void ShowDialogForm(string searchArg, DataTable dt)
        {
            Transaksi.frmLookupSPM ifrmDialog = new Transaksi.frmLookupSPM(searchArg, dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
            else
            {
                txtnopo.Focus();
            }
        }
        private void GetDialogResult(Transaksi.frmLookupSPM dialogForm)
        {
            //lookupCustomerBengkel1.NamaCust = dialogForm.namacust;
            //lookupCustomerBengkel1.KodeCust = dialogForm.kodecust;
            //txtNamaCust.Text = dialogForm.namacust;
            //txtNoPol.Text = dialogForm.nopol;
            //lookupSepedaMotor1.NamaSepedaMotor = dialogForm.Spm;
            //lookupSepedaMotor1.KodeSepedaMotor = dialogForm.Kd_spm;
            //txtSPMType.Text = dialogForm.Jns_spm;
            //txtSPMTypeDesc.Text = dialogForm.Spm;
            //txtWarna.Text = dialogForm.Warna;
            //txtTahun.Text = dialogForm.Tahun;
            //txtPemilik.Text = dialogForm.namacust;
            //txtAlamat.Text = dialogForm.Alamat;
            //txtNoKTP_SIM.Text = dialogForm.Ktp;
            //txtTelp.Text = dialogForm.telpon;
            RowIDCust = dialogForm.RowIDCustGet;
            txtnopo.Text = dialogForm.nopol;
            //txtService.Text = Tools.isNull(_ServiceKe, "1").ToString();


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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (txtnopo.Text == "") {
                MessageBox.Show("Nomer Polisi Tidak Bisa Kosong");
                return;
            }
            //if (lookupToko1.KodeToko == "" || lookupToko1.KodeToko == "[CODE]") {
            //    MessageBox.Show("Silahkan Isi Toko sesuai dengan nama instansi");
            //    return;
            //}
            try
            {
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("Usp_BengkelInsertInstansi"));
                    db.Commands[0].Parameters.Add(new Parameter("@Headerid", SqlDbType.UniqueIdentifier, _RowIDInstansi));
                    db.Commands[0].Parameters.Add(new Parameter("@KDToko", SqlDbType.VarChar, _KodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@IDCust", SqlDbType.UniqueIdentifier, RowIDCust));
                    db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                MessageBox.Show("Suksess");
                this.Close();
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }

        private void FrmInstansiEdit_Load(object sender, EventArgs e)
        {
            txinstansi.Text = _NamaInstansi;
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
