using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.Master
{
    public partial class frmPerusahaan : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        DataTable dt;

        public frmPerusahaan(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPerusahaan(Form caller, Guid RowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = RowID;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerusahaan_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    txtCab.Text = Tools.isNull(dt.Rows[0]["InitCabang"], "").ToString();
                    txtGudang.Text = Tools.isNull(dt.Rows[0]["InitGudang"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtInitPrs.Text = Tools.isNull(dt.Rows[0]["InitPerusahaan"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtPropinsi.Text = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString();
                    txtNegara.Text = Tools.isNull(dt.Rows[0]["Negara"], "").ToString();
                    txtKodepos.Text = Tools.isNull(dt.Rows[0]["KodePos"], "").ToString();
                    txtTelepon.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtEmail.Text = Tools.isNull(dt.Rows[0]["Email"], "").ToString();
                    txtFax.Text = Tools.isNull(dt.Rows[0]["Fax"], "").ToString();
                    txtWebsite.Text = Tools.isNull(dt.Rows[0]["Website"], "").ToString();
                    txtNpwp.Text = Tools.isNull(dt.Rows[0]["NPWP"], "").ToString();
                    dTglpkp.Text = Tools.isNull(dt.Rows[0]["Tglpkp"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCab.Text))
            {
                MessageBox.Show("Kode Cabang belum diisi");
                txtCab.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtGudang.Text))
            {
                MessageBox.Show("Kode Gudang belum diisi");
                txtGudang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInitPrs.Text))
            {
                MessageBox.Show("Initial Perusahaan belum diisi");
                txtInitPrs.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama Perusahaan belum diisi");
                txtNama.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@InitPerusahaan", SqlDbType.VarChar, txtInitPrs.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@InitCabang", SqlDbType.VarChar, txtCab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@InitGudang", SqlDbType.VarChar, txtGudang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kodepos", SqlDbType.VarChar, txtKodepos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Telp", SqlDbType.VarChar, txtTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Npwp", SqlDbType.VarChar, txtNpwp.Text));
                            if (Tools.isNull(dTglpkp.Text,"").ToString() != "")
                                db.Commands[0].Parameters.Add(new Parameter("@Tglpkp", SqlDbType.DateTime, dTglpkp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Data Perusahaan sudah ada");
                                txtCab.Focus();
                                return;
                            }
                        }
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@initCabang", SqlDbType.VarChar, txtCab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initGudang", SqlDbType.VarChar, txtGudang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPrs.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodepos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelepon.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@npwp", SqlDbType.VarChar, txtNpwp.Text));
                            if (Tools.isNull(dTglpkp.Text, "").ToString() != "")
                                db.Commands[0].Parameters.Add(new Parameter("@Tglpkp", SqlDbType.DateTime, dTglpkp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }
    }
}
