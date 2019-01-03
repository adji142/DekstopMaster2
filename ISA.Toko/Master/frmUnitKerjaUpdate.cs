using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmUnitKerjaUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID, __RowID;
        string _Noid, docNo = "NOMOR_UNITKERJA", depan, belakang;
        int iNomor, lebar;
        string tampNama;
        DataTable dt;

       


        public void generateNumerator()
        {

            DataTable dtNum = Tools.GetGeneralNumerator(docNo);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;

            _Noid = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
            txtKode.Text = _Noid;
        }

        public frmUnitKerjaUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmUnitKerjaUpdate(Form caller, Guid  rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmUnitKerjaUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("[usp_UnitKerja_LIST]"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }
                    label3.Visible = txtKode.Visible = true;
                    txtKode.Enabled = false;
                    //display data
                    RBPasif.Checked = !(bool)Tools.isNull(dt.Rows[0]["StatusAktif"], true); 
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtKode.Text = Tools.isNull(dt.Rows[0]["Kode"], "").ToString();
                    txtketerangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    tampNama = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            else { //generateNumerator(); 
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNama.Text))
            {
                MessageBox.Show("Nama belum diisi");
                txtNama.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                        try
                        {
                            using (Database db = new Database())
                            {
                                db.Open();
                                _rowID = Guid.NewGuid();
                                DataTable dtMessage = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_UnitKerja_INSERTUPDATEDELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@mau", SqlDbType.Int, 1));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.VarChar, RBAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtketerangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));


                                dtMessage = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
                                    //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                    //{
                                    //    txtKode.Text = string.Empty;
                                    //    txtKode.Focus();
                                    //    return;
                                    //}
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                    case enumFormMode.Update:
                        try
                        {
                            using (Database db = new Database())
                            {
                                if (Tools.cekDuplikasiDataOnDatabase("UnitKerja", "Nama", txtNama.Text, "Kode", txtKode.Text))
                                {
                                    MessageBox.Show("Unit Kerja Dengan Nama " + txtNama.Text + " Sudah Ada !!");
                                    txtNama.Focus();
                                    return;
                                }
                                db.Open();

                                DataTable dtMessage = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_UnitKerja_INSERTUPDATEDELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@mau", SqlDbType.Int, 2));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.VarChar, RBAktif.Checked));
                                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtketerangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                dtMessage = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    if (dtMessage.Rows[0]["pesan"].ToString() == "Update Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
                                    //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                    //{
                                    //    txtKode.Text = string.Empty;
                                    //    txtKode.Focus();
                                    //    return;
                                    //}
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
                
                //this.DialogResult = DialogResult.OK;
                //frmUnitKerjaBrowser  frmCaller = (frmUnitKerjaBrowser )this.Caller;
                //frmCaller.RefreshData();
                //this.Close();
                //frmCaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmUnitKerjaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmUnitKerjaBrowser)
                {
                    frmUnitKerjaBrowser frmCaller = (frmUnitKerjaBrowser)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

       

       

       
    }
}
