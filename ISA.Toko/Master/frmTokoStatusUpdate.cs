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
    public partial class frmTokoStatusUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _Noid, docNo = "NUMERATOR_IDTOKO", depan, belakang;
        int iNomor, lebar;
        DataTable dt;
        String _kodetoko;

        public frmTokoStatusUpdate(Form caller, String _KodeToko)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _kodetoko = _KodeToko;
            
        }

        
        public frmTokoStatusUpdate(Form caller, String _KodeToko, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            _kodetoko = _KodeToko;
        }

        private void frmTokoStatusUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                FillCbStatusHarga();
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_StatusToko_LIST]"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    cbStatusHarga.SelectedValue = Tools.isNull(dt.Rows[0]["Status"], "").ToString();
                    txtdateStatusToko.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["TglAktif"], GlobalVar.DateOfServer));
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["keterangan"], "").ToString();
                }
                else { txtdateStatusToko.DateValue = GlobalVar.DateOfServer; }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void FillCbStatusHarga() {

            try
            {
                
                    //retrieving data
                    
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[rsp_StatusHarga_list]"));
                        db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    cbStatusHarga.DataSource = dt;
                    cbStatusHarga.DisplayMember = "Keterangan";
                    cbStatusHarga.ValueMember = "Kode";
               
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            

            try
            {
                double _plafon = 0;
                
                
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            if (txtdateStatusToko.DateValue < GlobalVar.DateOfServer)
                            {
                                MessageBox.Show("Tanggal Kurang dari Tanggal Server");
                                txtdateStatusToko.Focus();
                                return;
                            }

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_StatusToko_insert_update_delete]"));

                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, Guid.NewGuid()));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _kodetoko));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, txtdateStatusToko.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, cbStatusHarga.SelectedValue.ToString() ));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtCatatan.Text.ToString()));
                            
                           
                            dt = db.Commands[0].ExecuteDataTable();
                            

                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                
                                if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                {
                                    MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                    return;
                                }
                                else if (dt.Rows[0]["pesan"].ToString().Substring(dt.Rows[0]["pesan"].ToString().Length - 14) == " Sudah Ada !!!")
                                {
                                    MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                    return;
                                }
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_StatusToko_insert_update_delete]"));

                            db.Commands[0].Parameters.Add(new Parameter("@do", SqlDbType.Int, 1));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, _kodetoko));
                            db.Commands[0].Parameters.Add(new Parameter("@TglAktif", SqlDbType.DateTime, txtdateStatusToko.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Status", SqlDbType.VarChar, cbStatusHarga.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtCatatan.Text.ToString()));

                            dt = db.Commands[0].ExecuteDataTable();

                            db.Close();
                            db.Dispose();

                            if (dt.Rows.Count > 0)
                            {
                                
                                if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                {
                                    MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                    return;
                                }
                            }
                        }
                        break;
                }

                this.DialogResult = DialogResult.OK;
                CloseForm();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTokoStatusUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmTokoBrowse)
                {
                    frmTokoBrowse frmCaller = (frmTokoBrowse)this.Caller;
                    frmCaller.RefreshDataStatusToko();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtWilID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdateStatusToko_Validated(object sender, EventArgs e)
        {
           
        }

        private void txtdateStatusToko_Leave(object sender, EventArgs e)
        {
            if (txtdateStatusToko.DateValue < GlobalVar.DateOfServer)
            {
                MessageBox.Show("Tanggal Kurang dari Tanggal Server");
                txtdateStatusToko.DateValue = GlobalVar.DateOfServer;
                txtdateStatusToko.Focus();
            }
        }
    }
}
