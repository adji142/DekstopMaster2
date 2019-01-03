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
    public partial class frmCheckerUpdate : ISA.Toko.BaseForm
    {
            enum enumFormMode { New, Update };
            enumFormMode formMode;
            string _rowID;
            string checkerID;

            DataTable dt;

            public frmCheckerUpdate(Form caller)
            {
                InitializeComponent();
                formMode = enumFormMode.New;
                this.Caller = caller;
            }

            public frmCheckerUpdate(Form caller, string rowID)
            {
                InitializeComponent();
                formMode = enumFormMode.Update;
                _rowID = rowID;
                this.Caller = caller;
            }
            
            private void frmCheckerUpdate_Load(object sender, EventArgs e)
            {
                if (formMode == enumFormMode.Update)
                {
                    //retrieving data
                    try
                    {

                        dt = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_Checker_LIST"));

                            db.Commands[0].Parameters.Add(new Parameter("@checkerID", SqlDbType.VarChar, _rowID));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        checkerID = _rowID;
                        //display data
                        txtFirstName.Text = Tools.isNull(dt.Rows[0]["FirstName"], "").ToString();
                        txtLastName.Text = Tools.isNull(dt.Rows[0]["LastName"], "").ToString();
                        txtAlamat.Text = Tools.isNull(dt.Rows[0]["Alamat"], "").ToString();
                        txtKota.Text = Tools.isNull(dt.Rows[0]["Kota"], "").ToString();
                        txtMasuk.DateValue = (DateTime?)dt.Rows[0]["Masuk"];
                        
                        if(string.IsNullOrEmpty(dt.Rows[0]["Keluar"].ToString()))
                        {
                            txtKeluar.Text = string.Empty;
                        }
                        else
                        {
                            txtKeluar.DateValue =  (DateTime?)dt.Rows[0]["Keluar"];
                        }

                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;
                        txtMasuk.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
                else
                {
                    this.txtMasuk.Text  = DateTime.Today.ToString("dd/MM/yyyy"); 
                    //txtKeluar.Text = " / / ";
                }
            }

           
            private void cmdSave_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtFirstName.Text))
                {
                    MessageBox.Show("Nama depan belum diisi");
                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtMasuk.Text))
                {
                    MessageBox.Show("Tanggal masuk belum diisi");
                    txtMasuk.Focus();
                    return;
                }

                if (txtKeluar.DateValue < txtMasuk.DateValue)
                {
                    MessageBox.Show("Tanggal keluar tidak boleh lebih kecil dari tanggal masuk");
                    txtKeluar.Focus();
                    return;
                }

                try
                {
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            using (Database db = new Database())
                            {
                                db.Open();

                                checkerID = Tools.CreateFingerPrint();
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Checker_INSERT"));

                                db.Commands[0].Parameters.Add(new Parameter("@checkerID", SqlDbType.VarChar, checkerID));
                                db.Commands[0].Parameters.Add(new Parameter("@FirstName", SqlDbType.VarChar, txtFirstName.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastName", SqlDbType.VarChar, txtLastName.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Masuk", SqlDbType.DateTime, txtMasuk.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@Keluar", SqlDbType.DateTime, txtKeluar.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                dt = db.Commands[0].ExecuteDataTable();

                                db.Close();
                                db.Dispose();
                            }
                            break;
                        case enumFormMode.Update:
                            using (Database db = new Database())
                            {
                                db.Open();

                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_Checker_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@checkerID", SqlDbType.VarChar, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@FirstName", SqlDbType.VarChar, txtFirstName.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@LastName", SqlDbType.VarChar, txtLastName.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Alamat", SqlDbType.VarChar, txtAlamat.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, txtKota.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@Masuk", SqlDbType.DateTime, txtMasuk.DateValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@Keluar", SqlDbType.DateTime , txtKeluar.DateValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                                db.Close();
                                db.Dispose();
                            }
                            break;
                    }
                    
                    this.DialogResult = DialogResult.OK;
                    frmCheckerBrowse frmCaller = (frmCheckerBrowse)this.Caller;
                    frmCaller.RefreshData();
                    this.Close();
                    frmCaller.Show();
               }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
             
            }

            private void cmdClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void frmCheckerUpdate_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    if (this.Caller is frmCheckerBrowse)
                    {
                        frmCheckerBrowse frmCaller = (frmCheckerBrowse)this.Caller;
                        frmCaller.RefreshData();
                        //frmCaller.FindRow("CheckerID", checkerID);
                    }
                }
            }

          
           

           

         

            
        }
    }

