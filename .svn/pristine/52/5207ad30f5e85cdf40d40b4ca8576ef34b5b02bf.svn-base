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
    public partial class frmPromoAddEdit : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        DataTable dt;

        public frmPromoAddEdit(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPromoAddEdit(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmPromoAddEdit_Load(object sender, EventArgs e)            
        {
            checkBoxStatusAktif.Checked = true;

            try
            {
                if (formMode == enumFormMode.Update)
                {
                    dt = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_HistoryPromo_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dt = db.Commands[0].ExecuteDataTable();
                    }
                    TextBoxTglMulai.DateValue = (DateTime)dt.Rows[0]["TglMulai"];
                    TextBoxTglSelesai.DateValue = (DateTime)dt.Rows[0]["TglSelesai"];
                    textBoxKeterangan.Text = Tools.isNull(dt.Rows[0]["Keterangan"], "").ToString();
                    //checkBoxStatusAktif.Checked = Convert.ToBoolean(dt.Rows[0]["StatusAktif"]);
                    checkBoxStatusAktif.Checked = (bool)dt.Rows[0]["StatusAktif"];
                    TextBoxTglMulai.Enabled = false;
                    TextBoxTglSelesai.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButtonSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (TextBoxTglMulai.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                if (TextBoxTglMulai.Text == "")
                {
                    MessageBox.Show("Tanggal mulai tidak boleh kosong");
                    TextBoxTglMulai.Focus();
                    return;
                }

                if (TextBoxTglSelesai.Text == "")                
                {
                    MessageBox.Show("Tanggal selesai tidak boleh kosong");
                    TextBoxTglSelesai.Focus();
                    return;
                }

                if (textBoxKeterangan.Text == "")                {
                    MessageBox.Show("Keterangan tidak boleh kosong");
                    textBoxKeterangan.Focus();
                    return;
                }

                switch (formMode)
                {
                    case enumFormMode.New:
                        using (Database db = new Database())
                        {
                            _rowID = Guid.NewGuid();
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryPromo_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@TglMulai", SqlDbType.DateTime, TextBoxTglMulai.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@TglSelesai", SqlDbType.DateTime, TextBoxTglSelesai.DateValue.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, textBoxKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, checkBoxStatusAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Periode promo sudah sudah ada");
                                TextBoxTglMulai.Focus();
                                return;
                            }                            
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_HistoryPromo_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                             db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, textBoxKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, checkBoxStatusAktif.Checked));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            dt = db.Commands[0].ExecuteDataTable();
                            db.Close();
                            db.Dispose();
                        }
                        break;

                }
                this.DialogResult = DialogResult.OK;
                frmPromo frmCaller = (frmPromo)this.Caller;
                frmCaller.BrowsePromo();
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }     


    }
}
