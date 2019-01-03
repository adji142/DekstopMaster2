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
    public partial class FrmStatusHargaUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID;
        string tampNama;
        DataTable dt;

        public FrmStatusHargaUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public FrmStatusHargaUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
        }

        private void FrmStatusHargaUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.UPDATE )
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("rsp_StatusHarga_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    
                    txtKode.Text = Tools.isNull(dt.Rows[0]["Kode"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    if(dt.Rows[0]["Status"].ToString()=="True"){cbaktif.Checked = true;}else {cbpasif.Checked = true;}
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
            if (string.IsNullOrEmpty(txtKode.Text))
            {
                MessageBox.Show("Anda belum mengisi Kode StatusHarga");
                txtKode.Focus();
                return;
            } if (string.IsNullOrEmpty(txtKeterangan.Text))
            {
                MessageBox.Show("Kolom Keterangan masih kosong. Mohon dilengkapi.");
                txtKeterangan.Focus();
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
                            int Status = cbaktif.Checked==false? 0:1;
                            db.Commands.Add(db.CreateCommand("usp_StatusHarga_Insert_Update_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Status));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Createdby", SqlDbType.VarChar, SecurityManager.UserName));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                //MessageBox.Show(dt.Rows[0]["pesan"].ToString() );
                                if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                {
                                    txtKode.Text = string.Empty;
                                    txtKode.Focus();
                                    return;
                                }
                                
                            }
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            int Status = cbaktif.Checked == false ? 0 : 1;
                            db.Commands.Add(db.CreateCommand("usp_StatusHarga_Insert_Update_Delete"));
                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 1));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Kode", SqlDbType.VarChar, txtKode.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, Status));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                //MessageBox.Show(dt.Rows[0]["pesan"].ToString());
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
                this.Close();
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            
        }

        private void FrmStatusHargaUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is FrmStatusHargaBrowse)
                {
                    FrmStatusHargaBrowse frmCaller = (FrmStatusHargaBrowse)this.Caller;                
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

        private void txtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {

        }

      
      
      

    }
}
