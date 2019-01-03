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
    public partial class frmKategoriReturUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID;
        string tampNama;
        DataTable dt;

        public frmKategoriReturUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmKategoriReturUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
        }

        private void frmKategoriReturUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.UPDATE )
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("[usp_Kategori_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    txtKode.Visible = true;
                    label1.Visible = true;
                    txtRetur.Text = Tools.isNull(dt.Rows[0]["Ket"], "").ToString();
                    txtKode.Text = Tools.isNull(dt.Rows[0]["Kategori"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    if(dt.Rows[0]["StatusAktif"].ToString()=="True"){cbaktif.Checked = true;}else {cbpasif.Checked = true;}
                    txtKode.Enabled = false;
                }
            }

           
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty( txtRetur.Text))
            {
                MessageBox.Show("Anda belum mengisi Nama Nama");
                txtRetur.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.NEW:
                        if(Tools.cekDataOnDatabase("Kategori","Kategori", txtKode.Text))
                        {
                            MessageBox.Show("Kategori dengan Kode "+txtKode.Text +" Sudah Ada" );
                            txtKode.Focus();
                            return;
                        } 
                        if (Tools.cekDataOnDatabase("Kategori", "Keterangan", txtKeterangan.Text))
                        {
                            MessageBox.Show("Kategori dengan Keterangan " + txtKeterangan.Text + " Sudah Ada");
                            txtKeterangan.Focus();
                            return;
                        }
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_Kategori_INSERT]"));
                            db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, txtRetur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.VarChar, cbaktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                            db.Close();
                            db.Dispose();

                            
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            if (Tools.cekDuplikasiDataOnDatabase("Kategori", "Kategori", txtKode.Text,"RowID",RowID.ToString()))
                            {
                                MessageBox.Show("Kategori dengan Kode " + txtKode.Text + " Sudah Ada");
                                txtKode.Focus();
                                return;
                            }
                            if (Tools.cekDuplikasiDataOnDatabase("Kategori", "Keterangan", txtKeterangan.Text, "RowID", RowID.ToString()))
                            {
                                MessageBox.Show("Kategori dengan Keterangan " + txtKeterangan.Text + " Sudah Ada");
                                txtKeterangan.Focus();
                                return;
                            }

                            db.Open();
                            DataTable dt = new DataTable();
                            int Status = cbaktif.Checked == true ? 0 : 1;
                            db.Commands.Add(db.CreateCommand("[usp_Kategori_UPDATE]"));
                            db.Commands[0].Parameters.Add(new Parameter("@Kategori", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Ket", SqlDbType.VarChar, txtRetur.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.VarChar, cbaktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].ExecuteNonQuery();
                            db.Close();
                            db.Dispose();

                            
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                frmKategoriReturBrowse frmcaller = (frmKategoriReturBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmKategoriReturUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKategoriReturBrowse)
                {
                    frmKategoriReturBrowse frmCaller = (frmKategoriReturBrowse)this.Caller;                
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
