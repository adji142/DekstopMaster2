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
    public partial class frmStafPenjualanUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _Noid, docNo = "NOMOR_STAFFPENJUALAN", depan, belakang;
        int iNomor, lebar;
        Guid  _rowID;
        string tampNama;
        DataTable dt, dtUnitkerja;



        private void fillComboboxUnitKerja() { 
            try
            {
                    //retrieving data
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_UnitKerja_LIST]"));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                        dtUnitkerja = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    CbUnitKerja.DataSource = dtUnitkerja;
                    CbUnitKerja.DisplayMember = "Nama";
                    CbUnitKerja.ValueMember = "Kode";
               
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        
        }

        public void generateNumerator()
        {

            DataTable dtNum = Tools.GetGeneralNumerator(docNo);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;

            _Noid = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
           TxtKode.Text = _Noid;
        }

        public frmStafPenjualanUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
         //   generateNumerator();
        }

        public frmStafPenjualanUpdate(Form caller, Guid  rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmStafPenjualanUpdate_Load(object sender, EventArgs e)
        {
            fillComboboxUnitKerja();

            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }
                    Kode.Visible = TxtKode.Visible = true;
                    TxtKode.Enabled = false;
                    //display data
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    TxtKode.Text = Tools.isNull(dt.Rows[0]["kode"], "").ToString();
                    RBPasif.Checked = !(bool)Tools.isNull(dt.Rows[0]["StatusAktif"], true);
                    TxtKeterangan.Text = Tools.isNull(dt.Rows[0]["keterangan"], "").ToString();
                    CbUnitKerja.SelectedValue = Tools.isNull(dt.Rows[0]["unitKerja"], "").ToString();

                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
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
                                db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@unitKerja", SqlDbType.VarChar, CbUnitKerja.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, TxtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                                dtMessage = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();

                                if (dtMessage.Rows.Count > 0)
                                {
                                    if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
                                    {
                                        this.DialogResult = DialogResult.OK;
                                        frmStafPenjualanBrowser frmCaller = (frmStafPenjualanBrowser)this.Caller;
                                        frmCaller.RefreshData();
                                        this.Close();
                                        frmCaller.Show(); this.DialogResult = DialogResult.OK;
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

                                if (Tools.cekDuplikasiDataOnDatabase("StaffPenjualan", "Nama", txtNama.Text, "kode", TxtKode.Text))
                                {
                                    MessageBox.Show("Staf Adm dan Ops Dengan Nama " + txtNama.Text + " Sudah Ada !!");
                                    txtNama.Focus();
                                    return;
                                }
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier , _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].Parameters.Add(new Parameter("@unitKerja", SqlDbType.VarChar, CbUnitKerja.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, TxtKeterangan.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, RBAktif.Checked));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                                this.DialogResult = DialogResult.OK;
                                frmStafPenjualanBrowser frmCaller = (frmStafPenjualanBrowser)this.Caller;
                                frmCaller.RefreshData();
                                this.Close();
                                frmCaller.Show();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        break;
                }
                
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmStafPenjualanUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmStafPenjualanBrowser)
                {
                    frmStafPenjualanBrowser frmCaller = (frmStafPenjualanBrowser)this.Caller;
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TxtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kode_Click(object sender, EventArgs e)
        {

        }

        private void TxtKode_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbUnitKerja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

       

       
    }
}
