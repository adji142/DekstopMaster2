using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.VLapW
{
    public partial class frmKoliToneUpdate : ISA.Trading.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID;
        string _recID;
        public frmKoliToneUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmKoliToneUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            this.Caller = caller;
            _rowID = rowID;
        }

        private void frmKoliToneUpdate_Load(object sender, EventArgs e)
        {
            if (formMode == enumFormMode.Update)
            {
                RefreshData();
            }
         
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KoliTone_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    _recID = dt.Rows[0]["RecID"].ToString();
                    txtNamaStok.BarangID = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                    txtNamaStok.NamaStock = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                    txtJenis.Text = Tools.isNull(dt.Rows[0]["Jenis"], "").ToString();
                    txtPcs.Text = Tools.isNull(dt.Rows[0]["Pcs"], "").ToString();
                    txtKoli.Text = Tools.isNull(dt.Rows[0]["Koli"], "").ToString();
}
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                switch (formMode)
                {
                    case enumFormMode.New:
                       try
                       {
                           this.Cursor = Cursors.WaitCursor;
                           using (Database db = new Database())
                           {
                               DataTable dt = new DataTable();
                               db.Commands.Add(db.CreateCommand("usp_KoliTone_INSERT"));
                               _rowID = Guid.NewGuid();
                               db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                               db.Commands[0].Parameters.Add(new Parameter("@recID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                               db.Commands[0].Parameters.Add(new Parameter("@brgID", SqlDbType.VarChar, txtNamaStok.BarangID));
                               db.Commands[0].Parameters.Add(new Parameter("@pcs", SqlDbType.Int, txtPcs.GetIntValue));
                               db.Commands[0].Parameters.Add(new Parameter("@koli", SqlDbType.Int, txtKoli.GetIntValue));
                               db.Commands[0].Parameters.Add(new Parameter("@qPoint", SqlDbType.Int, 0));
                               db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, txtJenis.Text));
                               db.Commands[0].Parameters.Add(new Parameter("@itemCode", SqlDbType.VarChar, ""));
                               db.Commands[0].Parameters.Add(new Parameter("@nPoint", SqlDbType.Int, 0));
                               db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                               db.Commands[0].ExecuteNonQuery();

                           }
                       }
                       catch (System.Exception ex)
                       {
                           Error.LogError(ex);
                       }
                       finally
                       {
                           MessageBox.Show("Data telah tersimpan");
                           this.DialogResult = DialogResult.OK;
                           this.Cursor = Cursors.Default;
                       }
                        
                      

                        break;

                    case enumFormMode.Update:
                        try
                        {
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_KoliTone_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@brgID", SqlDbType.VarChar, txtNamaStok.BarangID));
                                db.Commands[0].Parameters.Add(new Parameter("@pcs", SqlDbType.Int,txtPcs.GetIntValue));
                                db.Commands[0].Parameters.Add(new Parameter("@koli", SqlDbType.Int, txtKoli.GetIntValue));
                                //db.Commands[0].Parameters.Add(new Parameter("@qPoint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@jenis", SqlDbType.VarChar, txtJenis.Text));
                                //db.Commands[0].Parameters.Add(new Parameter("@itemCode", SqlDbType.VarChar, ""));
                               // db.Commands[0].Parameters.Add(new Parameter("@nPoint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }
                        finally
                        {
                            MessageBox.Show("Data telah tersimpan");
                            this.DialogResult = DialogResult.OK;
                            this.Cursor = Cursors.Default;
                        }
                       
                        break;
                }
               
                frmKoliToneBrowse frmCaller = (frmKoliToneBrowse)this.Caller;
               
                frmCaller.RefreshData();
                frmCaller.FindHeader(_rowID);
                cmdClose.PerformClick();
            }

        }

        public bool IsValid()
        {
            bool valid = true;
            if (txtNamaStok.BarangID == "")
            {
                errorProvider1.SetError(txtNamaStok, Messages.Error.InputRequired);
                txtNamaStok.Focus();
                valid = false;
            }

            //if (txtJenis.Text == "")
            //{
            //    errorProvider1.SetError(txtJenis, Messages.Error.InputRequired);
            //    txtJenis.Focus();
            //    valid = false;
            //}
            if (txtPcs.Text  == "")
            {
                errorProvider1.SetError(txtPcs, Messages.Error.InputRequired);
                txtJenis.Focus();
                valid = false;
            }
            if (txtKoli.Text == "")
            {
                errorProvider1.SetError(txtKoli, Messages.Error.InputRequired);
                txtKoli.Focus();
                valid = false;
            }
            return valid;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
