using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Fixrute
{
    public partial class frmKunjunganSalesmanUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        string _sales;
        DataTable dtNew, dtUpdate;
        public frmKunjunganSalesmanUpdate()
        {
            this.DialogResult = DialogResult.Cancel;

            InitializeComponent();
        }

        public frmKunjunganSalesmanUpdate(Form caller, Guid RowID)
        {
            this.Caller = caller;
            _RowID = RowID;
            //_sales = sales;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }

        public frmKunjunganSalesmanUpdate(Form caller)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();
        }

        private void frmKunjunganSalesmanUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    txtAlamat.Enabled = false;
                    txtIdwil.Enabled = false;
                    txtNoTelp.Enabled = false;
                    txtPemilik.Enabled = false;
                    txtPenanggungJawab.Enabled = false;
                    txtAlamat1.Enabled = false;
                    txtNoTelp1.Enabled = false;
                    txtCabang.Enabled = false;
                    txtCatatan.Enabled = false;
                    txtNamaToko.Visible = false;
                    cmdLookup.Visible = false;


                    break;

                case enumFormMode.Update:
                    try
                    {
                        DataTable dtLoadUpdate = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("[usp_fixKunjunganSales_Update]"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _RowID));
                            dtLoadUpdate = db.Commands[0].ExecuteDataTable();
                        }

                        dtTanggal.Text = Tools.isNull(dtLoadUpdate.Rows[0]["tgl_kunj"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dtLoadUpdate.Rows[0]["alamat"], "").ToString();
                        lookupToko1.NamaToko = Tools.isNull(dtLoadUpdate.Rows[0]["namatoko"], "").ToString();
                        lookupToko1.KodeToko = Tools.isNull(dtLoadUpdate.Rows[0]["kd_toko"], "").ToString();
                        lookupToko1.Enabled = false;
                        lookupSales1.SalesID = Tools.isNull(dtLoadUpdate.Rows[0]["kd_sales"], "").ToString();
                        lookupSales1.Enabled = false;
                        txtKota.Text = Tools.isNull(dtLoadUpdate.Rows[0]["kota"], "").ToString();
                        txtDaerah.Text = Tools.isNull(dtLoadUpdate.Rows[0]["daerah"], "").ToString();
                        txtKecamatan.Text = Tools.isNull(dtLoadUpdate.Rows[0]["kecamatan"], "").ToString();
                        txtPropinsi.Text = Tools.isNull(dtLoadUpdate.Rows[0]["propinsi"], "").ToString();

                        txtRpSo.Text = Tools.isNull(dtLoadUpdate.Rows[0]["rp_so"], "").ToString();
                        txtSku.Text = Tools.isNull(dtLoadUpdate.Rows[0]["sku"], "").ToString();
                        txtCatatanKunjungan.Text = Tools.isNull(dtLoadUpdate.Rows[0]["catkunj"], "").ToString();
                        txtKendala.Text = Tools.isNull(dtLoadUpdate.Rows[0]["kendala"], "").ToString();
                        txtAlamat.Enabled = false;
                        txtIdwil.Enabled = false;
                        txtNoTelp.Enabled = false;
                        txtPemilik.Enabled = false;
                        txtPenanggungJawab.Enabled = false;
                        txtAlamat1.Enabled = false;
                        txtNoTelp1.Enabled = false;
                        txtCabang.Enabled = false;
                        txtCatatan.Enabled = false;
                        txtNamaToko.Visible = false;
                        cmdLookup.Visible = false;
                        cbTokoBaru.Enabled = false;
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }


                    break;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTokoBaru_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTokoBaru.Checked == true)
            {
                txtAlamat.Enabled = true;
                txtIdwil.Enabled = true;
                txtNoTelp.Enabled = true;
                txtPemilik.Enabled = true;
                txtPenanggungJawab.Enabled = true;
                txtAlamat1.Enabled = true;
                txtNoTelp1.Enabled = true;
                txtCabang.Enabled = true;
                txtCatatan.Enabled = true;
                lookupToko1.Visible = false;
                txtNamaToko.Visible = true;
                cmdLookup.Visible = true;
            }
            else
            {
                txtAlamat.Enabled = false;
                txtIdwil.Enabled = false;
                txtNoTelp.Enabled = false;
                txtPemilik.Enabled = false;
                txtPenanggungJawab.Enabled = false;
                txtAlamat1.Enabled = false;
                txtNoTelp1.Enabled = false;
                txtCabang.Enabled = false;
                txtCatatan.Enabled = false;
                lookupToko1.Visible = true;
                txtNamaToko.Visible = false;
                cmdLookup.Visible = false;
                txtAlamat.Text = "";
                txtIdwil.Text = "";
                txtNoTelp.Text = "";
                txtPemilik.Text = "";
                txtPenanggungJawab.Text = "";
                txtAlamat1.Text = "";
                txtNoTelp1.Text = "";
                txtCabang.Text = "";
                txtCatatan.Text = "";

                txtKota.Text = string.Empty;
                txtDaerah.Text = string.Empty;
                txtKecamatan.Text = string.Empty;
                txtPropinsi.Text = string.Empty;
            }
        }
        

        private void simpan()
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        _RowID = Guid.NewGuid();
                        DateTime tanggal =Convert.ToDateTime(dtTanggal.Value.ToShortDateString());
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_SalesOrder_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_kunj", SqlDbType.DateTime, tanggal));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_sales", SqlDbType.VarChar, lookupSales1.SalesID.ToString()));
                            if (cbTokoBaru.Checked == true)
                            {
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko1.KodeToko.ToString()));
                            }
                            if (cbTokoBaru.Checked == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.Text));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, lookupToko1.NamaToko.ToString()));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@areacode", SqlDbType.VarChar, ));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_so", SqlDbType.NChar, txtRpSo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@sku", SqlDbType.NChar, txtSku.Text));
                            //db.Commands[0].Parameters.Add(new Parameter("@ltokoob", SqlDbType.Bit, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catkunj", SqlDbType.VarChar, txtCatatanKunjungan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kendala", SqlDbType.VarChar, txtKendala.Text));
                            if (cbTokoBaru.Checked == true)
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@ltokoob", SqlDbType.Bit, true));
                            }
                            else
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@ltokoob", SqlDbType.Bit, false));
                            }
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                            dtNew = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                        MessageBox.Show("Gagal Menyimpan Data");
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    break;

                case enumFormMode.Update:
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_SalesOrder_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_so", SqlDbType.NChar, txtRpSo.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@sku", SqlDbType.NChar, txtSku.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catkunj", SqlDbType.VarChar, txtCatatanKunjungan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kendala", SqlDbType.VarChar, txtKendala.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dtUpdate = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                        MessageBox.Show("Gagal Menyimpan Data");
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                    break;
            }
            
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            if (cbTokoBaru.Checked == true)
            {
                //panggil sp buat nyimpen toko baru
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_fixNewOutlet_Insert"));
                    db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, txtKecamatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelp", SqlDbType.VarChar, txtNoTelp.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIdwil.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@pemilik", SqlDbType.VarChar, txtPemilik.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@pngjwb", SqlDbType.VarChar, txtPenanggungJawab.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@notelp1", SqlDbType.VarChar, txtNoTelp1.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, txtCabang.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                }
            }
            if (txtAlamat.Text == "")
            {
                MessageBox.Show("Nama Alamat diisi lengkap");
                txtAlamat.Enabled = true;
                txtAlamat.Focus();
                return;
            }
            if (txtKota.Text == "")
            {
                MessageBox.Show("Nama Kota tidak lengkap");
                txtKota.Focus();
                return;
            }

            if (txtDaerah.Text == "")
            {
                MessageBox.Show("Nama Daerah masih kosong");
                txtDaerah.Focus();
                return;
            }
            if (txtKecamatan.Text == "")
            {
                if (MessageBox.Show("Nama Kecamatan masih kosong..,apakah mau dilanjutkan..?", "SIMPAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                }
                txtKecamatan.Focus();
            }

            string _NamaSales = lookupSales1.NamaSales.ToString();
            if (MessageBox.Show("Simpan Data : " + _NamaSales + " ?", "SIMPAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                simpan();
                frmKunjunganSalesman frmCaller = (frmKunjunganSalesman)this.Caller;
                frmCaller.RefreshData();
                frmCaller.FindHeader("RowID", _RowID.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtKota_Enter(object sender, EventArgs e)
        {
            //using (Database db = new Database())
            //{
            //    db.Commands.Add(db.CreateCommand("usp_FixNamaKota_List"));
            //    dtKota = db.Commands[0].ExecuteDataTable();
            //    txtKota.Text = Tools.isNull(dtLoadUpdate.Rows[0]["kota"], "").ToString();
            //}
        }

        private void lookupToko1_Validating(object sender, CancelEventArgs e)
        {
            if (lookupToko1.NamaToko.ToString() != string.Empty)
            {
                string _alamat = lookupToko1.Alamat;
                txtAlamat.Text = _alamat;
                txtKota.Text = lookupToko1.Kota;
                txtDaerah.Text = lookupToko1.Daerah;
                txtPropinsi.Text = lookupToko1.Propinsi;

                if (lookupToko1.NamaToko == "")
                {
                    txtAlamat.Text = "";
                    txtKota.Text = "";
                    txtDaerah.Text = "";
                    txtKecamatan.Text = "";
                    txtPropinsi.Text = "";
                }

                bool isCekArea = LookupInfoValue.CekFixAreaEnable(GlobalVar.Gudang);

                txtAlamat.Enabled = isCekArea;
                txtKota.Enabled = isCekArea;
                txtDaerah.Enabled = isCekArea;
                txtKecamatan.Enabled = isCekArea;
                txtPropinsi.Enabled = isCekArea;
                
            }
        }

        private void frmKunjunganSalesmanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
