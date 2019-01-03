using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.DKNForm
{
    public partial class frmDebetKreditNotaCabangUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _kodeCabang;

        DataTable dt;

        public frmDebetKreditNotaCabangUpdate(Form Caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = Caller;
        }

        public frmDebetKreditNotaCabangUpdate(Form Caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _kodeCabang = rowID;
            this.Caller = Caller;
        }

        public frmDebetKreditNotaCabangUpdate()
        {
            InitializeComponent();
        }



        private void frmDebetKreditNotaCabangUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_DKNCabang_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, _kodeCabang));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtKode.Text = Tools.isNull(dt.Rows[0]["KodeCabang"], "").ToString();
                    txtNama.Text = Tools.isNull(dt.Rows[0]["NamaCabang"], "").ToString();
                    txtPerk1.Text = Tools.isNull(dt.Rows[0]["KodePerkiraan1"], "").ToString();
                    txtPerk2.Text = Tools.isNull(dt.Rows[0]["KodePerkiraan2"], "").ToString();
                    
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

        private bool validate()
        {
            bool valid = true;
            errorProvider1.Clear();
            if (txtKode.Text == "")
            {
                errorProvider1.SetError(txtKode, "Kode harus diisi");
                valid = false;
            }

            if (txtNama.Text == "")
            {
                errorProvider1.SetError(txtNama, "Nama harus diisi");
                valid = false;
            }

            if (txtPerk1.Text == "")
            {
                errorProvider1.SetError(txtPerk1, "Perkiraan 1 harus diisi");
                valid = false;
            }

            if (txtPerk2.Text == "")
            {
                errorProvider1.SetError(txtPerk2, "Perkiraan 2 harus diisi");
                valid = false;
            }
            return valid;
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!validate())
            {
                return;
            }
            
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database(GlobalVar.DBName))
                            {

                                db.Commands.Add(db.CreateCommand("usp_DKNCabang_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, txtKode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaCabang", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KodePerkiraan1", SqlDbType.VarChar, txtPerk1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KodePerkiraan2", SqlDbType.VarChar, txtPerk2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                                this._kodeCabang = txtKode.Text;
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_DKNCabang_UPDATE"));
                                
                                db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, txtKode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@NamaCabang", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KodePerkiraan1", SqlDbType.VarChar, txtPerk1.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@KodePerkiraan2", SqlDbType.VarChar, txtPerk2.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            break;
                    }
                    MessageBox.Show(Messages.Confirm.UpdateSuccess);
                    this.DialogResult = DialogResult.OK;
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



        private void frmDebetKreditNotaCabangUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is DKNForm.frmDebetKreditNotaCabangBrowse)
                {
                    DKNForm.frmDebetKreditNotaCabangBrowse frmCaller = (DKNForm.frmDebetKreditNotaCabangBrowse)this.Caller;
                    frmCaller.RefreshRowData(_kodeCabang.ToString());
                    if (this.formMode == enumFormMode.New)
                    {
                        frmCaller.FindRow("ID", _kodeCabang);
                    }
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


       
    }
}
