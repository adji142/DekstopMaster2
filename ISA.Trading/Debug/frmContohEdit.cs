using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Debug
{
    public partial class frmContohEdit : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmContohEdit(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }


        public frmContohEdit(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID  = rowID;
            this.Caller = caller;
        }

        private void frmContohEdit_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_Cabang_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@cabangID", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    txtKode.Enabled = false;
                    txtKode.Text = Tools.isNull(dt.Rows[0]["CabangID"], "").ToString();
                    txtCabang.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtNoTelp.Text = Tools.isNull(dt.Rows[0]["TelModem"], "").ToString();
                    txtAlamat1.Text = Tools.isNull(dt.Rows[0]["Alamat1"], "").ToString();
                    txtAlamat2.Text = Tools.isNull(dt.Rows[0]["Alamat2"], "").ToString();
                    txtKota.Text = Tools.isNull(dt.Rows[0]["kota"], "").ToString();
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtKode.Text))
            {
                MessageBox.Show("Kode Belum Diisi");
                txtKode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCabang.Text))
            {
                MessageBox.Show("Cabang Belum Diisi");
                txtCabang.Focus();
                return;
            }


            try 
            {
                this.Cursor = Cursors.WaitCursor;
                switch (formMode)
                { 
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Cabang_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama",SqlDbType.VarChar,txtCabang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TelModem",SqlDbType.VarChar,txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt=db.Commands[0].ExecuteDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Cabang ID: " + txtKode.Text + " Sudah terdaftar di database");
                                txtKode.Text = string.Empty;
                                txtKode.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            
                            db.Commands.Add(db.CreateCommand("usp_Cabang_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@CabangID", SqlDbType.VarChar, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtCabang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@TelModem", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Alamat2", SqlDbType.VarChar, txtAlamat2.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
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

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmContoh)
                {
                    frmContoh frmCaller = (frmContoh)this.Caller;
                    frmCaller.RefreshData();
                }
            }
            //this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmContohEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }





    }
}
