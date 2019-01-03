using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Administrasi
{
    public partial class frmIdentitasPerusahaan : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;

        DataTable dt;

        Guid _rowID;

        public frmIdentitasPerusahaan()
        {
            InitializeComponent();
        }

        private void frmIdentitasPerusahaan_Load(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));

                    dt = db.Commands[0].ExecuteDataTable();
                }

                if (dt.Rows.Count > 0)
                {
                    formMode = enumFormMode.Update;
                    _rowID = (Guid)(dt.Rows[0]["RowID"]);
                    txtInitPerusahaan.Text = Tools.isNull(dt.Rows[0]["InitPerusahaan"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtNegara.Text = Tools.isNull(dt.Rows[0]["Negara"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtNPWP.Text = Tools.isNull(dt.Rows[0]["NPWP"], "").ToString();
                    txtEmail.Text = Tools.isNull(dt.Rows[0]["Email"], "").ToString();
                    txtPropinsi.Text = Tools.isNull(dt.Rows[0]["Propinsi"], "").ToString();
                    txtKodePos.Text = Tools.isNull(dt.Rows[0]["KodePos"], "").ToString();
                    txtFax.Text = Tools.isNull(dt.Rows[0]["Fax"], "").ToString();
                    txtWebsite.Text = Tools.isNull(dt.Rows[0]["Website"], "").ToString();
                }
                else
                {
                    formMode = enumFormMode.New;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_INSERT"));

                            _rowID = Guid.NewGuid();

                           // db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@npwp", SqlDbType.VarChar, txtNPWP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Perusahaan_UPDATE"));

                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@initPerusahaan", SqlDbType.VarChar, txtInitPerusahaan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@negara", SqlDbType.VarChar, txtNegara.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@npwp", SqlDbType.VarChar, txtNPWP.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@email", SqlDbType.VarChar, txtEmail.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, txtPropinsi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodePos", SqlDbType.VarChar, txtKodePos.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@website", SqlDbType.VarChar, txtWebsite.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
