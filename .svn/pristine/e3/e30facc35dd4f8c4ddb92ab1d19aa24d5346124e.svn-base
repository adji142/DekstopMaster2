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
    public partial class frmAppSettingUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        Guid RowID;
        string tampNama;
        DataTable dt;

        public frmAppSettingUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            RowID = Guid.NewGuid();
            this.Caller = caller;
        }

        public frmAppSettingUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            RowID = rowID;
            this.Caller = caller;
        }

        private void frmAppSettingUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.UPDATE )
            {
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("usp_AppSetting_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }
                if (dt.Rows.Count > 0)
                {
                    txtKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    txtKey.Text = Tools.isNull(dt.Rows[0]["Key"], "").ToString();
                    txtValue.Text = Tools.isNull(dt.Rows[0]["Value"], "").ToString();

                }
            }

           
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                using (Database db = new Database())
                {
                    db.Open();
                    DataTable dt = new DataTable();
                    if (formMode == enumFormMode.NEW)
                    {
                        db.Commands.Add(db.CreateCommand("[USP_APPSETTING_INSERT]"));
                    }
                    else
                    {
                        db.Commands.Add(db.CreateCommand("[USP_APPSETTING_UPDATE]"));
                    }
                    db.Commands[0].Parameters.Add(new Parameter("@Key", SqlDbType.VarChar, txtKey.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Value", SqlDbType.VarChar, txtValue.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                    db.Commands[0].Parameters.Add(new Parameter("@LastUpdateBy", SqlDbType.VarChar, SecurityManager.UserName));
                    db.Commands[0].ExecuteNonQuery();
                    db.Close();
                    db.Dispose();
                }
                this.DialogResult = DialogResult.OK;
                frmAppSettingBrowse frmcaller = (frmAppSettingBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmAppSettingUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmAppSettingBrowse)
                {
                    frmAppSettingBrowse frmCaller = (frmAppSettingBrowse)this.Caller;                
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
