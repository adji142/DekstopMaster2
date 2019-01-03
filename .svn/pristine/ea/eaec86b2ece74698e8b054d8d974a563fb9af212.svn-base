using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Expedisi
{
    public partial class frmRekapKoliDetailUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowID, _headerID;
        DataTable dtRekapKoliDetail, dtNota;
        string _htrID;
        string _kodeToko;

        Guid _notaID;
        string _notaRecID, _noNota = "";

        public frmRekapKoliDetailUpdate(Form caller, Guid headerID, string htrID, string kodeToko)
        {
            InitializeComponent();
            _headerID = headerID;
            _htrID = htrID;
            _kodeToko = kodeToko;
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmRekapKoliDetailUpdate(Form caller, Guid rowID, Guid headerID, string kodeToko)
        {
            InitializeComponent();
            _rowID = rowID;
            _headerID = headerID;
            _kodeToko = kodeToko;
            formMode = enumFormMode.Update;
            this.Caller = caller;
        }

        private void frmRekapKoliDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                txtNoDO.Focus();
                if (formMode == enumFormMode.Update)
                {
                    txtNoDO.ReadOnly = true;
                    cmdSearch.Enabled = false;
                    dtRekapKoliDetail = new DataTable();
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtRekapKoliDetail = db.Commands[0].ExecuteDataTable();
                    }
                    _notaRecID = Tools.isNull(dtRekapKoliDetail.Rows[0]["NotaJualRecID"], "").ToString();
                    _noNota = Tools.isNull(dtRekapKoliDetail.Rows[0]["NoNota"], "").ToString();
                    _notaID = (Guid)dtRekapKoliDetail.Rows[0]["NotaJualID"];
                    txtNoDO.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["NoDO"], "").ToString();
                    txtNoNota.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["NoNota"], "").ToString();
                    txtSales.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["NamaSales"], "").ToString();
                    cboTunaiKredit.SelectedItem = Tools.isNull(dtRekapKoliDetail.Rows[0]["TunaiKredit"], "").ToString();
                    txtNominal.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["Nominal"], "").ToString();
                    txtKeterangan.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["Keterangan"], "").ToString();
                    txtNoResi.Text = Tools.isNull(dtRekapKoliDetail.Rows[0]["NoResi"], "").ToString();                 
                }
                else
                {
                    cboTunaiKredit.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
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
                switch (formMode)
                {
                    case enumFormMode.New:
                        string _recordID = Tools.CreateFingerPrint();
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, _htrID));      
                            db.Commands[0].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, _notaID));
                            db.Commands[0].Parameters.Add(new Parameter("@notaJualRecID", SqlDbType.VarChar, _notaRecID));                             
                            db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, _noNota)); 
                            db.Commands[0].Parameters.Add(new Parameter("@tunaiKredit", SqlDbType.VarChar, cboTunaiKredit.SelectedItem.ToString())); 
                            db.Commands[0].Parameters.Add(new Parameter("@nominal", SqlDbType.Money, double.Parse(txtNominal.Text))); 
                            db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, "")); 
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text)); 
                            db.Commands[0].Parameters.Add(new Parameter("@noResi", SqlDbType.VarChar, txtNoResi.Text)); 
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_RekapKoliDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtRekapKoliDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtRekapKoliDetail.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtRekapKoliDetail.Rows[0]["HtrID"]));      
                            db.Commands[0].Parameters.Add(new Parameter("@notaJualID", SqlDbType.UniqueIdentifier, _notaID));
                            db.Commands[0].Parameters.Add(new Parameter("@notaJualRecID", SqlDbType.VarChar, _notaRecID));                             
                            db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, _noNota)); 
                            db.Commands[0].Parameters.Add(new Parameter("@tunaiKredit", SqlDbType.VarChar, cboTunaiKredit.SelectedItem.ToString())); 
                            db.Commands[0].Parameters.Add(new Parameter("@nominal", SqlDbType.Money, double.Parse(txtNominal.Text))); 
                            db.Commands[0].Parameters.Add(new Parameter("@uraian", SqlDbType.VarChar, dtRekapKoliDetail.Rows[0]["Uraian"])); 
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text)); 
                            db.Commands[0].Parameters.Add(new Parameter("@noResi", SqlDbType.VarChar, txtNoResi.Text)); 
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void Clear()
        {
            txtNoDO.Text = "";
            txtNoNota.Text = "";
            txtSales.Text = "";
            cboTunaiKredit.SelectedIndex = 0;
            txtNominal.Text = "";
            txtKeterangan.Text = "";
            txtNoResi.Text = "";
        }

        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();
            
            if (string.IsNullOrEmpty(txtNoDO.Text))
            {
                errorProvider1.SetError(txtNoDO, "No DO tidak boleh kosong");
                valid = false;
            }

            if (string.IsNullOrEmpty(txtNoNota.Text))
            {
                errorProvider1.SetError(txtNoDO, "No Nota tidak boleh kosong");
                valid = false;
            }
            
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRekapKoliDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmRekapKoliBrowse frmCaller = (frmRekapKoliBrowse)this.Caller;
                frmCaller.RefreshDataRekapKoliDetail();
                frmCaller.FindHeader("HeaderRowID", _headerID.ToString());
                frmCaller.FindDetail("DetailRowID", _rowID.ToString());
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            CheckNota();
        }

        private void txtNoDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void CheckNota()
         {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNotaJualForRekapKoli"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    if (txtNoDO.Text != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtNoDO.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nota tidak ada");
                }
                //else if (dt.Rows.Count==1)
                //{
                //}
                else
                {
                    ShowDialogForm(dt);
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowDialogForm(DataTable dt)
        {
            frmNotaLookupForRekapKoli ifrmDialog = new frmNotaLookupForRekapKoli(dt);
            ifrmDialog.ShowDialog();
            if (ifrmDialog.DialogResult == DialogResult.OK)
            {
                GetDialogResult(ifrmDialog);
            }
        }

        private void GetDialogResult(frmNotaLookupForRekapKoli dialogForm)
        {
            _notaID = dialogForm.NotaJualID;
            GetDataNota();
        }

        private void GetDataNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNotaJualForRekapKoli"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _kodeToko));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaID));
                    dtNota = db.Commands[0].ExecuteDataTable();
                }
                _notaRecID = Tools.isNull(dtNota.Rows[0]["NotaRecID"], "").ToString();
                _noNota = Tools.isNull(dtNota.Rows[0]["NoNota"], "").ToString();
                txtNoNota.Text = _noNota;
                txtNoDO.Text = Tools.isNull(dtNota.Rows[0]["NoDo"], "").ToString();
                txtSales.Text = Tools.isNull(dtNota.Rows[0]["NamaSales"], "").ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.WaitCursor;
            }
        }
        
    }
}
