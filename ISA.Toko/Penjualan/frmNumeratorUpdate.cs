using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Penjualan
{
    public partial class frmNumeratorUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _rowID;

        DataTable dt;

        public frmNumeratorUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmNumeratorUpdate(Form caller, string rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }
        private void frmNumeratorUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                //retrieving data
                try
                {

                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Open();
                        db.Commands.Add(db.CreateCommand("usp_Numerator_LIST"));

                        db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();

                        db.Close();
                        db.Dispose();
                    }

                    //display data
                    txtDoc.Text = Tools.isNull(dt.Rows[0]["Doc"], "").ToString();
                    txtDoc.Enabled = false;
                    txtDepan.Text  = Tools.isNull(dt.Rows[0]["Depan"], "").ToString();
                    txtBelakang.Text = Tools.isNull(dt.Rows[0]["Belakang"], "").ToString();
                    txtNomor.Text = Tools.isNull(dt.Rows[0]["Nomor"], "").ToString();
                    txtLebar.Text = Tools.isNull(dt.Rows[0]["Lebar"], "").ToString();
                  
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
           
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (formMode)
                {
                    case enumFormMode.New:

                        using (Database db = new Database())
                        {
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Numerator_INSERT"));

                            db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, txtDoc.Text ));
                            db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, txtDepan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, txtBelakang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int , txtNomor.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.Int , txtLebar.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                            db.Close();
                            db.Dispose();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Open();

                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, txtDoc.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, txtDepan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, txtBelakang.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, txtNomor.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lebar", SqlDbType.Int, txtLebar.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                            db.Close();
                            db.Dispose();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                frmNumeratorBrowse  frmCaller = (frmNumeratorBrowse )this.Caller;
                frmCaller.Refreshdata ();
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

        private void frmNumeratorUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNumeratorBrowse)
                {
                    frmNumeratorBrowse frmCaller = (frmNumeratorBrowse)this.Caller;
                    frmCaller.Refreshdata();
                    frmCaller.FindRow("Doc", txtDoc.Text);
                }
            }
        }
    }
}
