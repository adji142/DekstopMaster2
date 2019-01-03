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
    public partial class frmJasaUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID;
        string tampNama;
        DataTable dt;

        public frmJasaUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmJasaUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
        }

        private void frmJasaUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.UPDATE )
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("rsp_Jasa_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    txtKode.Visible = true;
                    label1.Visible = true;
                    txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    txtKode.Text = Tools.isNull(dt.Rows[0]["Kode"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan"], "").ToString();
                    if(dt.Rows[0]["Status"].ToString()=="False"){cbaktif.Checked = true;}else {cbpasif.Checked = true;}
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
           
            if (string.IsNullOrEmpty( txtNama.Text))
            {
                MessageBox.Show("Anda belum mengisi Nama Nama");
                txtNama.Focus();
                return;
            }

            try
            {
                switch (formMode)
                {
                    case enumFormMode.NEW:
                        
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            int Status = cbaktif.Checked==true? 0:1;
                            db.Commands.Add(db.CreateCommand("usp_Jasa_Insert_Update_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Status));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Createdby", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                {
                                    txtKode.Text = string.Empty;
                                    txtKode.Focus();
                                    return;
                                }
                                else if (dt.Rows[0]["pesan"].ToString().Substring(dt.Rows[0]["pesan"].ToString().Length - 14) == " Sudah Ada !!!")
                                {
                                    txtNama.Text = string.Empty;
                                    txtNama.Focus();
                                    return;
                                }
                            }
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            if (Tools.cekDuplikasiDataOnDatabase("Jasa", "Nama", txtNama.Text, "Kode", txtKode.Text))
                            {
                                MessageBox.Show("Jasa Dengan Nama " + txtNama.Text+" Sudah Ada !!");
                                txtNama.Focus();
                                return;
                            }
                            db.Open();
                            DataTable dt = new DataTable();
                            int Status = cbaktif.Checked == true ? 0 : 1;
                            db.Commands.Add(db.CreateCommand("usp_Jasa_Insert_Update_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 1));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Status));
                            db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                {
                                    txtKode.Text = string.Empty;
                                    txtKode.Focus();
                                    return;
                                }
                                
                            }
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                frmJasaBrowse frmcaller = (frmJasaBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmJasaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmJasaBrowse)
                {
                    frmJasaBrowse frmCaller = (frmJasaBrowse)this.Caller;                
                    frmCaller.RefreshData();
                    frmCaller.FindRow("Kode",txtKode.Text);                
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
