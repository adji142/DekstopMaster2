using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance.Class;
using ISA.Common;

namespace ISA.Finance.PJ3
{
    public partial class frmPJ3UpdateTglTerimaTglKirim : ISA.Finance.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        String _cabang1, _cabang2, _initCab;
        DataTable dt;

        public frmPJ3UpdateTglTerimaTglKirim()
        {
            InitializeComponent();
        }

        public frmPJ3UpdateTglTerimaTglKirim(Form caller, Guid rowID, string cabang1, string cabang2, string initGdg)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            _cabang1 = cabang1;
            _cabang2 = cabang2;
            _initCab = initGdg;
            this.Caller = caller;
        }

        private void frmPJ3UpdateTglTerimaTglKirim_Load(object sender, EventArgs e)
        {
            if (_cabang1 != _initCab)
            {
                txtTglTerimaDokumen.Enabled = false;
                txtNamaPenerima.Enabled = false;
            }
            else
            {
                txtTglKirim.Enabled = false;
                txtNamaPengirim.Enabled = false;
            }

            try
            {
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    if (_cabang1 != _initCab)
                    {
                        DateTime tglKirim = new DateTime();
                        if (!DateTime.TryParse(dt.Rows[0]["TglKirim"].ToString(), out tglKirim))
                        {
                            txtTglKirim.DateValue = GlobalVar.DateOfServer;
                        }
                        else
                        {
                            txtTglKirim.DateValue = (DateTime)dt.Rows[0]["TglKirim"];
                        }
                        txtNamaPengirim.Text = Tools.isNull(dt.Rows[0]["NamaPengirim"], "").ToString();
                    }
                    else
                    {
                        DateTime tglTerimaDokumen = new DateTime();
                        if (!DateTime.TryParse(dt.Rows[0]["TglTerimaDokumen"].ToString(), out tglTerimaDokumen))
                        {
                            txtTglTerimaDokumen.DateValue = GlobalVar.DateOfServer;
                        }
                        else
                        {
                            txtTglTerimaDokumen.DateValue = (DateTime)dt.Rows[0]["TglTerimaDokumen"];
                        }
                        txtTglKirim.DateValue = (DateTime)dt.Rows[0]["TglKirim"];
                        txtNamaPenerima.Text = Tools.isNull(dt.Rows[0]["NamaPenerima"], "").ToString();
                        txtNamaPengirim.Text = Tools.isNull(dt.Rows[0]["NamaPengirim"], "").ToString();
                    }                    
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (_cabang1 != _initCab)
            {
                if (string.IsNullOrEmpty(txtTglKirim.Text))
                {
                    MessageBox.Show("Tgl.Kirim dokumen belum diisi");
                    txtTglKirim.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNamaPengirim.Text))
                {
                    MessageBox.Show("Nama pengirim belum diisi");
                    txtNamaPengirim.Focus();
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtTglTerimaDokumen.Text))
                {
                    MessageBox.Show("Tgl.Terima dokumen belum diisi");
                    txtTglTerimaDokumen.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNamaPenerima.Text))
                {
                    MessageBox.Show("Nama penerima belum diisi");
                    txtNamaPenerima.Focus();
                    return;
                }
            }

            try
            {
                using (Database db = new Database())
                    if (formMode == enumFormMode.Update)
                    {
                        DataTable dt = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_updateTglTerimaTglKirim"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                        if (_cabang1 == _initCab)
                        {
                            db.Commands[0].Parameters.Add(new Parameter("@TglTerimaDokumen", SqlDbType.DateTime, txtTglTerimaDokumen.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@NamaPenerima", SqlDbType.VarChar, txtNamaPenerima.Text));
                        }                        
                        db.Commands[0].Parameters.Add(new Parameter("@TglTglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@NamaPengirim", SqlDbType.VarChar, txtNamaPengirim.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPJ3UpdateTglTerimaTglKirim_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is PJ3.frmPJ3Browse)
                {
                    PJ3.frmPJ3Browse frmCaller = (PJ3.frmPJ3Browse)this.Caller;
                    frmCaller.RefreshRowDataNotaJual(_rowID.ToString()); 
                   
                }
            }
        }
    }
}
