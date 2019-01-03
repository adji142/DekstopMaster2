using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;
using System.Collections;


namespace ISA.Bengkel.Master
{
    public partial class frmMasterStokBengkelUpdate : ISA.Controls.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DataTable dt;
       
        public frmMasterStokBengkelUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMasterStokBengkelUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmMasterStokBengkelUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_StokBengkel_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    txtBarangID.Text = Tools.isNull(dt.Rows[0]["id_brg"],"").ToString();
                    txtBarangID.Enabled = false;
                    txtNamaStok.Text = Tools.isNull(dt.Rows[0]["Nama_Stok"], "").ToString();
                    txtNamaStok.Enabled = true;
                    txtSatJual.Text = Tools.isNull(dt.Rows[0]["Sat_Jual"], "").ToString();
                    txtSatJual.Enabled = true;

                    if (Tools.isNull(dt.Rows[0]["StatusPasif"], "").ToString() == "1")
                        chkStatusAktif.Checked = true;
                    else
                        chkStatusAktif.Checked = false;
                }
                else
                {
                    chkStatusAktif.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarangID.Text))
            {
                MessageBox.Show("Barang ID belum diisi");
                txtBarangID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNamaStok.Text))
            {
                MessageBox.Show("Nama stok belum diisi");
                txtNamaStok.Focus();
                return;
            }

            int lenIdbrg = 0;
            lenIdbrg = txtBarangID.Text.ToString().Trim().Length;
            if (lenIdbrg < 12)
            {
                MessageBox.Show("Kode Barang kurang dari 12 character");
                return;
            }
            else if (lenIdbrg > 12)
            {
                MessageBox.Show("Kode Barang lebih dari 12 character");
                return;
            }

            string barangIDSubString = txtBarangID.Text.Substring(0, 3).ToUpper();
            try
            {
                int _prediksiLamaKirim = 0;
                int _hariRataRata = 0;

                switch (formMode)
                {
                    case enumFormMode.New:
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dtc = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_StokBengkelCekIdbrg_LIST"));
                                db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, txtBarangID.Text));
                                dtc = db.Commands[0].ExecuteDataTable();
                                if (dtc.Rows.Count > 0)
                                {
                                    MessageBox.Show("Kode Barang sudah ada");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }

                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StokBengkel_INSERT"));
                            _rowID = Guid.NewGuid();
                            string RecID_ = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmss}", GlobalVar.DateTimeOfServer) + SecurityManager.UserInitial + " ";
                            //string RecID_ = GlobalVar.PerusahaanID + String.Format("{0:yyyyMMddHHmmssff}", GlobalVar.DateTimeOfServer) + SecurityManager.UserInitial + " ";
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, RecID_));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, txtBarangID.Text.ToUpper()));
                            db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtNamaStok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, txtSatJual.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, !chkStatusAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;

                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_StokBengkel_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, txtBarangID.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@namaStok", SqlDbType.VarChar, txtNamaStok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@satJual", SqlDbType.VarChar, txtSatJual.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@statusPasif", SqlDbType.Bit, !chkStatusAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                if (this.Caller is frmMasterStokBengkelBrowse)
                {
                    frmMasterStokBengkelBrowse frmCaller = (frmMasterStokBengkelBrowse)this.Caller;
                    frmCaller.RefreshRowDataStok(txtBarangID.Text);
                    frmCaller.FindRow("id_brg", txtBarangID.Text);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }


        private void frmMasterStokBengkelUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMasterStokBengkelBrowse)
                {
                    frmMasterStokBengkelBrowse frmCaller = (frmMasterStokBengkelBrowse)this.Caller;
                    frmCaller.RefreshRowDataStok(txtBarangID.Text);
                    frmCaller.FindRow("id_brg", txtBarangID.Text);
                }
            }
        }

    }
}
