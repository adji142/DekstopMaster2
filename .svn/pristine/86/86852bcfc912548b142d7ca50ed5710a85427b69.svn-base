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
    public partial class frmGudangUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmGudangUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmGudangUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmGudangUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Gudang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtGudangID.Text = Tools.isNull(dt.Rows[0]["GudangID"], "").ToString();
                    txtGudangID.Enabled = false;
                    cbCabang.SelectedValue = Tools.isNull(dt.Rows[0]["KodeCabang"], "").ToString();
                    txtNamaGudang.Text = Tools.isNull(dt.Rows[0]["NamaGudang"], "").ToString();
                    txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat1"], "").ToString();
                    txtAlamat2.Text = Tools.isNull(dt.Rows[0]["Alamat2"], "").ToString();
                    txtAlamat3.Text = Tools.isNull(dt.Rows[0]["Alamat3"], "").ToString();
                    txtTelp.Text = Tools.isNull(dt.Rows[0]["Telp"], "").ToString();
                    txtFax.Text = Tools.isNull(dt.Rows[0]["Fax"], "").ToString();
                    txtModem.Text = Tools.isNull(dt.Rows[0]["Modem"], "").ToString();

                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGudangID.Text))
            {
                MessageBox.Show("Kode belum diisi");
                txtGudangID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cbCabang.CabangID))
            {
                MessageBox.Show("Cabang belum diisi");
                cbCabang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaGudang.Text))
            {
                MessageBox.Show("Gudang belum diisi");
                txtNamaGudang.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_Gudang_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, txtGudangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, cbCabang.CabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaGudang", SqlDbType.VarChar, txtNamaGudang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat3", SqlDbType.VarChar, txtAlamat3.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@modem", SqlDbType.VarChar, txtModem.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Gudang ID: " + txtGudangID.Text + " sudah terdaftar di database");
                                txtGudangID.Text = string.Empty;
                                txtGudangID.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Gudang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@gudangID", SqlDbType.VarChar, txtGudangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeCabang", SqlDbType.VarChar, cbCabang.CabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@namaGudang", SqlDbType.VarChar, txtNamaGudang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat3", SqlDbType.VarChar, txtAlamat3.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@telp", SqlDbType.VarChar, txtTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@fax", SqlDbType.VarChar, txtFax.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@modem", SqlDbType.VarChar, txtModem.Text));
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

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGudangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmGudangBrowse)
                {
                    frmGudangBrowse frmCaller = (frmGudangBrowse)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("GudangID", txtGudangID.Text);
                }
            }
        }
    }
}
