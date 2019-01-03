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
    public partial class frmMasterOutletBaruUpdate : ISA.Toko.BaseForm
    {
        DataTable dtKota, dtKecamatan, dtPropinsi, dtDaerah, dtIdwil, dtLoadUpdate;
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _RowID;
        public frmMasterOutletBaruUpdate()
        {
            InitializeComponent();
        }

        public frmMasterOutletBaruUpdate(Form caller)
        {
            this.Caller = caller;
            formMode = enumFormMode.New;
            InitializeComponent();
        }

        public frmMasterOutletBaruUpdate(Form caller, Guid RowID)
        {
            this.Caller = caller;
            _RowID = RowID;
            formMode = enumFormMode.Update;
            InitializeComponent();
        }
        private void frmMasterOutletBaruUpdate_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        //combobox kota
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixNamaKota_List"));
                            dtKota = db.Commands[0].ExecuteDataTable();
                            cmbKota.DataSource = dtKota;
                            cmbKota.ValueMember = "kabupaten";
                            cmbKota.DisplayMember = "kabupaten";
                        }
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

                case enumFormMode.Update:
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixNewOutletList_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _RowID));
                            dtLoadUpdate = db.Commands[0].ExecuteDataTable();
                            cmbKota.DataSource = dtLoadUpdate;
                            cmbKecamatan.DataSource = dtLoadUpdate;
                            cmbDaerah.DataSource = dtLoadUpdate;
                            cmbPropinsi.DataSource = dtLoadUpdate;
                        }

                        txtNamaToko.Text = Tools.isNull(dtLoadUpdate.Rows[0]["namatoko"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dtLoadUpdate.Rows[0]["alamat"], "").ToString();
                        txtIdwil.Text = Tools.isNull(dtLoadUpdate.Rows[0]["idwil"], "").ToString();
                        txtNoTelp.Text = Tools.isNull(dtLoadUpdate.Rows[0]["notelp"], "").ToString();
                        txtPemilik.Text = Tools.isNull(dtLoadUpdate.Rows[0]["pemilik"], "").ToString();
                        txtPenanggungJawab.Text = Tools.isNull(dtLoadUpdate.Rows[0]["pngjwb"], "").ToString();
                        txtAlamat1.Text = Tools.isNull(dtLoadUpdate.Rows[0]["alamat1"], "").ToString();
                        txtNoTelp1.Text = Tools.isNull(dtLoadUpdate.Rows[0]["notelp1"], "").ToString();
                        txtCabang.Text = Tools.isNull(dtLoadUpdate.Rows[0]["cabang"], "").ToString();
                        txtCatatan.Text = Tools.isNull(dtLoadUpdate.Rows[0]["catatan"], "").ToString();
                        cmbKota.ValueMember = "kota";
                        cmbKota.DisplayMember = "kota";
                        cmbKecamatan.ValueMember = "kecamatan";
                        cmbKecamatan.DisplayMember = "kecamatan";
                        cmbDaerah.ValueMember = "daerah";
                        cmbDaerah.DisplayMember = "dareah";
                        cmbPropinsi.ValueMember = "propinsi";
                        cmbPropinsi.DisplayMember = "propinsi";
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

        private void cmbKota_Leave(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixKecamatan_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@kabupaten", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            dtKecamatan = db.Commands[0].ExecuteDataTable();
                            cmbKecamatan.DataSource = dtKecamatan;
                            cmbKecamatan.ValueMember = "wilayah";
                            cmbKecamatan.DisplayMember = "wilayah";
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixPropinsi_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@kabupaten", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            dtPropinsi = db.Commands[0].ExecuteDataTable();
                            cmbPropinsi.DataSource = dtPropinsi;
                            cmbPropinsi.ValueMember = "propinsi";
                            cmbPropinsi.DisplayMember = "propinsi";
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixDaerah_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@kabupaten", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            dtDaerah = db.Commands[0].ExecuteDataTable();
                            cmbDaerah.DataSource = dtDaerah;
                            cmbDaerah.ValueMember = "kabupaten";
                            cmbDaerah.DisplayMember = "kabupaten";
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_FixIdWil_List"));
                            db.Commands[0].Parameters.Add(new Parameter("@kabupaten", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            dtIdwil = db.Commands[0].ExecuteDataTable();
                            txtIdwil.Text = dtIdwil.Rows[0]["codewil"].ToString();

                        }
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

                case enumFormMode.Update:
                    try
                    {

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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpan()
        {
            switch (formMode)
            {
                case enumFormMode.New:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixNewOutlet_Insert"));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, cmbDaerah.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, cmbKecamatan.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, cmbPropinsi.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@notelp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIdwil.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pemilik", SqlDbType.VarChar, txtPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pngjwb", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@notelp1", SqlDbType.VarChar,txtNoTelp1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, txtCabang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            dt = db.Commands[0].ExecuteDataTable();
                            MessageBox.Show("Data Berhasil Di simpan");
                        }
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

                case enumFormMode.Update:
                    try
                    {
                        DataTable dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_fixNewOutlet_Update"));
                            db.Commands[0].Parameters.Add(new Parameter("@row", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@namatoko", SqlDbType.VarChar, txtNamaToko.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat", SqlDbType.VarChar, txtAlamat.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@kota", SqlDbType.VarChar, cmbKota.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@daerah", SqlDbType.VarChar, cmbDaerah.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@kecamatan", SqlDbType.VarChar, cmbKecamatan.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@propinsi", SqlDbType.VarChar, cmbPropinsi.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@notelp", SqlDbType.VarChar, txtNoTelp.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@idwil", SqlDbType.VarChar, txtIdwil.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pemilik", SqlDbType.VarChar, txtPemilik.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@pngjwb", SqlDbType.VarChar, txtPenanggungJawab.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@alamat1", SqlDbType.VarChar, txtAlamat1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@notelp1", SqlDbType.VarChar, txtNoTelp1.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, txtCabang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
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
            string _namaToko = txtNamaToko.Text.ToString();
            if (MessageBox.Show("Simpan Data : " + _namaToko + " ?", "SIMPAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                simpan();
                frmMasterOutletBaru frmCaller = (frmMasterOutletBaru)this.Caller;
                frmCaller.Refreshdata();
                this.Close();
            }
        }

    }
}
