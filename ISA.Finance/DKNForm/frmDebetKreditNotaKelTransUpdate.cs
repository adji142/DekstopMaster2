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
    public partial class frmDebetKreditNotaKelTransUpdate : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode = new enumFormMode();
        string _kodeTrans = "", _kodeCabang = "", _ket = "", _group = "", _dn = ""; 
        Guid _RowID;

        public frmDebetKreditNotaKelTransUpdate(Form caller, string kodeCabang)
        {
            this.Caller = caller;
            this._kodeCabang = kodeCabang;
            this.formMode = enumFormMode.New;
            InitializeComponent();
        }

        public frmDebetKreditNotaKelTransUpdate(Form caller, string kodeTrans, string ket, string group, string dn, Guid RowID)
        {
            this.Caller = caller;
            this._kodeTrans = kodeTrans;
            this._ket = ket;
            this._group = group;
            this._dn = dn;
            this._RowID = RowID;
            this.formMode = enumFormMode.Update;
            InitializeComponent();
        }

     

        private void tbKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==8)
            {
                e.Handled = false;
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
                tbKeterangan.Focus();
            
        }

        private void tbKode_Click(object sender, EventArgs e)
        {
            tbKode.SelectAll();
        }

        private void tbGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar != '1' && e.KeyChar != '2')
            {
                e.Handled = true;
            }
            else
                tbDN.Focus();
        }

        private void tbGroup_Click(object sender, EventArgs e)
        {
            tbGroup.SelectAll();
        }

        private void tbDN_Click(object sender, EventArgs e)
        {
            tbDN.SelectAll();
        }

        private void tbDN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar != 'D' && e.KeyChar != 'N' && e.KeyChar != 'd' && e.KeyChar != 'n')
            {
                e.Handled = true;
            }
            else
                cmdSave.Focus();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;


            if (formMode == enumFormMode.New)
            {
                try
                {
                    _RowID = Guid.NewGuid();
                    string _recordID=Tools.CreateFingerPrint(GlobalVar.PerusahaanID,SecurityManager.UserInitial);
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_DKNKodeTransaksi_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@RecordID", SqlDbType.VarChar, _recordID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, _kodeCabang));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, tbKode.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Group", SqlDbType.VarChar, tbGroup.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@DN", SqlDbType.VarChar, tbDN.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }

                    MessageBox.Show("Tambah Data Berhasil");
                    frmDebetKreditNotaKelTransBrowse frm = new frmDebetKreditNotaKelTransBrowse();
                    frm = (frmDebetKreditNotaKelTransBrowse)Caller;
                    frm.RefreshTransaksi();
                    frm.FindRowTransaksi("RowID", _RowID.ToString());
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else
            {
                try
                {
                    string _recordID = Tools.CreateFingerPrint(GlobalVar.PerusahaanID, SecurityManager.UserInitial);
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("usp_DKNKodeTransaksi_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, tbKode.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Group", SqlDbType.VarChar, tbGroup.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@DN", SqlDbType.VarChar, tbDN.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKeterangan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    MessageBox.Show("Update Data Berhasil");
                    frmDebetKreditNotaKelTransBrowse frm = new frmDebetKreditNotaKelTransBrowse();
                    frm = (frmDebetKreditNotaKelTransBrowse)Caller;
                    frm.RefreshTransaksi();
                    frm.FindRowTransaksi("RowID", _RowID.ToString());
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }

        }

        private bool validate()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (tbKode.Text == "")
            {
                errorProvider1.SetError(tbKode, "Kode harus diisi, dan harus angka");
                valid = false;
            }
            if (tbDN.Text == "")
            {
                errorProvider1.SetError(tbDN, "D/N harus diisi");
                valid = false;
            }
            if (tbGroup.Text == "")
            {
                errorProvider1.SetError(tbGroup, "Group harus diisi");
                valid = false;
            }
            if (tbKeterangan.Text == "")
            {
                errorProvider1.SetError(tbKeterangan, "Keterangan harus diisi");
                valid = false;
            }
            return valid;
        }

        private void frmDebetKreditNotaKelTransUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.New)
            {
                tbKode.Clear();
                tbKeterangan.Clear();
                tbGroup.Clear();
                tbDN.Clear();
                tbKode.Focus();
            }
            else 
            {
                tbKode.Text = _kodeTrans;
                tbKeterangan.Text = _ket;
                tbGroup.Text = _group;
                tbDN.Text = _dn;
                tbKode.Focus();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
