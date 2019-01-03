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
    public partial class frmSopirUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { NEW, UPDATE };
        enumFormMode formMode;
        string _rowID;
        string tampNama;
        DataTable dt;

        public frmSopirUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.NEW;
            this.Caller = caller;
        }

        public frmSopirUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.UPDATE;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmSopirUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.UPDATE ) 
            { 
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("usp_Sopir_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar , _rowID ));
                    dt = db.Commands[0].ExecuteDataTable();
                    db.Close();
                    db.Dispose();
                }

                txtNama.Text = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                tampNama = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                //if (Tools.isNull(dt.Rows[0]["Sp"], "").ToString() == "s")
                //{
                //    cboSp.SelectedIndex = 0;  
                //}
                //else if (Tools.isNull(dt.Rows[0]["Sp"], "").ToString() == "p")
                //{
                //    cboSp.SelectedIndex = 1;  
                //}
                cboSp.SelectedItem = Tools.isNull(dt.Rows[0]["Sk"], "").ToString();

                txtNama.Enabled = false;
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
                MessageBox.Show("Nama sopir belum diisi");
                txtNama.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboSp.Text))
            {
                MessageBox.Show("Sopir/Kernet belum diisi");
                cboSp.Focus();
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
                            db.Commands.Add(db.CreateCommand("usp_Sopir_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@sk", SqlDbType.VarChar, cboSp.SelectedItem));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Sopir: " + txtNama.Text + " sudah terdaftar");
                                txtNama.Text = string.Empty;
                                txtNama.Focus();
                                return;
                            }
                        }
                        break;
                    case enumFormMode.UPDATE:
                        using (Database db = new Database())
                        {
                            db.Open();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Sopir_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@tampNama", SqlDbType.VarChar, tampNama));
                            db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, txtNama.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@sk", SqlDbType.VarChar, cboSp.SelectedItem));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            db.Close();
                            db.Dispose();
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                frmSopirBrowse frmcaller = (frmSopirBrowse)this.Caller;
                frmcaller.RefreshData();
                this.Close();
                frmcaller.Show();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void frmSopirUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmSopirBrowse)
                {
                    frmSopirBrowse frmCaller = (frmSopirBrowse)this.Caller;                
                    frmCaller.RefreshData();
                    frmCaller.FindRow("Nama",txtNama.Text);                
                }
            }
        }

      
      
      

    }
}
