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
    public partial class frmTokoPlafonUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _Noid, docNo = "NUMERATOR_IDTOKO", depan, belakang;
        int iNomor, lebar;
        DataTable dt;
        String _kodetoko;

        public frmTokoPlafonUpdate(Form caller, String _KodeToko)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
            _kodetoko = _KodeToko;
            
        }

        
        public frmTokoPlafonUpdate(Form caller, String _KodeToko, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            _kodetoko = _KodeToko;
        }

        private void frmTokoPlafonUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("[usp_TokoPlafon_LIST]"));

                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data

                    txtPlafon.Text = Tools.isNull(dt.Rows[0]["plf_fb"], "").ToString();
                    txtCatatan.Text = Tools.isNull(dt.Rows[0]["keterangan"], "").ToString();
                    txtdateplafon.DateValue = Convert.ToDateTime(Tools.isNull(dt.Rows[0]["tanggal"], GlobalVar.DateOfServer));
                }
                else { txtdateplafon.DateValue = GlobalVar.DateOfServer; }
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
                if (txtPlafon.Text != "")
                    _plafon = double.Parse(txtPlafon.Text);
                
                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_TokoPlafon_INSERT]"));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, _kodetoko));
                            db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, txtdateplafon.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Money, double.Parse(txtPlafon.Text.ToString())));
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
                                else if (Tools.Right(dt.Rows[0]["pesan"].ToString(),14) == " Sudah Ada !!!")
                                {
                                    MessageBox.Show(dt.Rows[0]["pesan"].ToString());
                                    return;
                                }
                            }
                            this.DialogResult = DialogResult.OK;
                            CloseForm();
                            this.Close();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("[usp_TokoPlafon_UPDATE]"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tanggal", SqlDbType.DateTime, txtdateplafon.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@plf_fb", SqlDbType.Money, txtPlafon.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtCatatan.Text.ToString()));
                            db.Commands[0].ExecuteNonQuery();
                            dt = db.Commands[0].ExecuteDataTable();


                            db.Close();
                            db.Dispose();
                            if (dt.Rows.Count > 0)
                            { 
                                MessageBox.Show("Plafon toko pada tanggal " +  txtdateplafon.DateValue.ToString() + " Sudah Ada !!!");
                                txtdateplafon.Text = String.Empty;
                                txtdateplafon.Focus();
                                return;
                            }
                            this.DialogResult = DialogResult.OK;
                            CloseForm();
                            this.Close();
                        }
                        break;
                }
                
                
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

        private void frmTokoPlafonUpdate_FormClosed(object sender, FormClosedEventArgs e)
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
                    frmCaller.RefreshPlafon();
                    
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtWilID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
