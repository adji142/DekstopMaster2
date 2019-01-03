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
    public partial class frmTokoUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;

        DataTable dt;

        public frmTokoUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmTokoUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmTokoUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtNamaToko.Text = Tools.isNull(dt.Rows[0]["NamaToko"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                    txtDaerah.Text = Tools.isNull(dt.Rows[0]["Daerah"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtPenanggungJawab.Text = Tools.isNull(dt.Rows[0]["PenanggungJawab"], "").ToString();
                    txtPlafon.Text = Tools.isNull(dt.Rows[0]["Plafon"], "").ToString();
                    txtWilID.Text = Tools.isNull(dt.Rows[0]["WilID"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                double _plafon = 0;
                if (txtPlafon.Text != "")
                    _plafon = double.Parse(txtPlafon.Text);
                
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Toko_INSERT"));
                            _rowID = Guid.NewGuid();
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNamaToko.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@penanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, _plafon));
                            db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Toko_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaToko", SqlDbType.VarChar, txtNamaToko.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, txtDaerah.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@penanggungJawab", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@plafon", SqlDbType.Money, _plafon));
                            db.Commands[0].Parameters.Add(new Parameter("@wilID", SqlDbType.VarChar, txtWilID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                CloseForm();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (txtNamaToko.Text == "")

            {
                errorProvider1.SetError(txtNamaToko, Messages.Error.InputRequired);
                valid = false;
            }
            if (txtAlamat.Text == "")
            {
                errorProvider1.SetError(txtAlamat, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtDaerah.Text == "")
            {
                errorProvider1.SetError(txtDaerah, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtKota.Text == "")
            {
                errorProvider1.SetError(txtKota, Messages.Error.InputRequired);
                valid = false;
            }

            if (txtPenanggungJawab.Text == "")
            {
                errorProvider1.SetError(txtPenanggungJawab, Messages.Error.InputRequired);
                valid = false;
            }

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTokoUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmTokoBrowse)
                {
                    frmTokoBrowse frmCaller = (frmTokoBrowse)this.Caller;
                    frmCaller.RefreshDataToko();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }
    }
}
