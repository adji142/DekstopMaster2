using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Master
{
    public partial class frmPenanggungjawabRakUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        string _kode;
        string _nama;
        Guid _rowID;
        DataTable dt;

        public frmPenanggungjawabRakUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New ;
            
            this.Caller = caller;
        }

        public frmPenanggungjawabRakUpdate(Form caller, string kode)
        {
            InitializeComponent();
            formMode = enumFormMode.New ;
            _kode = kode;
            this.Caller = caller;
        }

        public frmPenanggungjawabRakUpdate(Form caller, string kode, Guid rowID,string nama)
        {
            InitializeComponent();
            formMode = enumFormMode.Update ;
            _kode = kode;
            _rowID = rowID;
            _nama = nama;
            this.Caller = caller;
        }

        //public frmPenanggungjawabRakUpdate(Form caller, Guid rowID)
        //{
        //    InitializeComponent();
        //    formMode = enumFormMode.Update;
        //    _rowID  = rowID;
        //    this.Caller = caller;
        //}
        
        private void frmPenanggungjawabRakUpdate_Load(object sender, EventArgs e)
        {

            //retrieve data di Nama
            //data Nama berasal dari data user
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StaffPenjualan_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    cboNama.DataSource = dt;
                    cboNama.DisplayMember = "Nama";
                    cboNama.ValueMember = "Nama";
                    cboNama.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            } 
           //Retrieve data saat proses edit
            if (formMode == enumFormMode.Update)
            {//retrieving data
                try
                {

                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_PenanggungjawabRak_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, _kode));
                        dt = db.Commands[0].ExecuteDataTable();
                    }

                    //display data
                    txtTgl.Text = Tools.isNull(dt.Rows[0]["TglTransaksi"], "").ToString();
                    cboNama.SelectedValue = Tools.isNull(dt.Rows[0]["Nama"], "").ToString();
                    
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
           
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            switch (formMode)
            {
                case enumFormMode.New:

                    try
                    {
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenanggungjawabRak_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, _kode));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, cboNama.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, txtTgl.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case enumFormMode.Update:
                    try
                    {
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_PenanggungjawabRak_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRak", SqlDbType.VarChar, _kode));
                            db.Commands[0].Parameters.Add(new Parameter("@Nama", SqlDbType.VarChar, cboNama.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@TglTransaksi", SqlDbType.DateTime, txtTgl.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    break;
            }
            MessageBox.Show("Data telah tersimpan");
            this.DialogResult = DialogResult.OK;
            frmPenanggungjawabRakBrowse frmCaller = (frmPenanggungjawabRakBrowse)this.Caller;
            frmCaller.RefreshDataPJ();
            this.Close();
            frmCaller.Show();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //Error.LogError(ex);
            //}
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPenanggungjawabRakUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPenanggungjawabRakBrowse)
                {
                    frmPenanggungjawabRakBrowse frmCaller = (frmPenanggungjawabRakBrowse)this.Caller;
                    frmCaller.RefreshDataPJ();
                    frmCaller.FindDetail("RowID", _rowID.ToString());
                }
            }
        }


       
    }
}
