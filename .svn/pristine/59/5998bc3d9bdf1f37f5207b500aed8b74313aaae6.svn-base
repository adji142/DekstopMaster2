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
    public partial class frmBankKotaUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID;
        string tampNama;
        DataTable dt;

        public frmBankKotaUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmBankKotaUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
        }

        private void frmBankKotaUpdate_Load(object sender, EventArgs e)
        {
            this.Title = formMode == enumFormMode.NEW ? this.Title + " Insert" : this.Title + " Update";
            if (formMode == enumFormMode.UPDATE)
            {
                dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("[usp_BankKota_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    txtNama.Text = Tools.isNull(dt.Rows[0]["NamaBank"], "").ToString();
                    txtLokasi.Text = Tools.isNull(dt.Rows[0]["Lokasi"], "").ToString();
                    cbpasif.Checked = !(bool)dt.Rows[0]["StatusAktif"];
                    //txtKode.Enabled = false;
                }
            }           
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool dataSudahAda() 
        {
            DataTable Dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                db.Open();
                db.Commands.Add(db.CreateCommand("[usp_BankKota_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@NamaBank", SqlDbType.VarChar, txtNama.Text));
                db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, txtLokasi.Text));
                Dt = db.Commands[0].ExecuteDataTable();
            }
            return Dt.Rows.Count > 0 ? true : false;
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (dataSudahAda()) 
            {
                KotakPesan.Warning("Data Sudah Ada di database");
                txtNama.Focus();
                return;
            }
            if (string.IsNullOrEmpty( txtNama.Text))
            {
                KotakPesan.Warning("Anda belum mengisi data Nama");
                txtNama.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLokasi.Text))
            {
                KotakPesan.Warning("Anda belum mengisi data Lokasi");
                txtLokasi.Focus();
                return;
            }
            try
            {
                switch (formMode)
                {
                    case enumFormMode.NEW:
                        
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_BankKota_INSERT]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, txtLokasi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, cbaktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                            KotakPesan.Information("Insert Berhasil");
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database(GlobalVar.DBFinance))
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_BankKota_UPDATE]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Lokasi", SqlDbType.VarChar, txtLokasi.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, cbaktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                            KotakPesan.Information("Update Berhasil");
                        }
                        break;
                }
                this.DialogResult = DialogResult.OK;
                frmBankKotaBrowse frmcaller = (frmBankKotaBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmBankKotaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmBankKotaBrowse)
                {
                    frmBankKotaBrowse frmCaller = (frmBankKotaBrowse)this.Caller;                
                    frmCaller.RefreshData();
                    frmCaller.FindRow("RowID",RowID.ToString());                
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void commonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

      
      
      

    }
}
