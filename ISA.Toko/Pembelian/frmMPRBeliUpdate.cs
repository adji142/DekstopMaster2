using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;
using System.Globalization;
namespace ISA.Toko.Pembelian
{
    public partial class frmMPRBeliUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dtRetur, dtPengirim;
        Guid _rowID;
        String _FladEdit ="";
        bool Closing_;

        public frmMPRBeliUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMPRBeliUpdate(Form caller, Guid rowID, bool CLosing)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            Closing_ = CLosing;
            
        }

        public frmMPRBeliUpdate(Form caller, Guid rowID, bool CLosing, String Flag)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            Closing_ = CLosing;
            _FladEdit = Flag;

        }

        public void setdisableEditTglKirim() 
        {
            txtNoMPR.Enabled =
            txtPenerima.Enabled =
            txtTglKeluar.Enabled =
            txtTglKirim2.Enabled =
            cboPemasok.Enabled =
            cboPengirim.Enabled = false;
        }

        private void frmMPRBeliUpdate_Load(object sender, EventArgs e)
        {
            txtTglKeluar.DateValue = GlobalVar.DateTimeOfServer;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPemasok = new DataTable();
                dtRetur = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dtPemasok = db.Commands[0].ExecuteDataTable();

                    db.Commands.Add(db.CreateCommand("[usp_StaffPenjualan_LIST]"));
                    db.Commands[1].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dtPengirim = db.Commands[1].ExecuteDataTable();

                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                        db.Commands[2].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtRetur = db.Commands[2].ExecuteDataTable();
                    }
                }
                cboPemasok.DataSource = dtPemasok;
                cboPemasok.DisplayMember = "Nama";
                cboPemasok.ValueMember = "PemasokID";
                cboPengirim.DataSource = dtPengirim;
                cboPengirim.DisplayMember = "Nama";
                cboPengirim.ValueMember = "RowID";
                
                if (formMode == enumFormMode.Update)
                {
                    txtNoMPR.Visible = true;
                    label2.Visible = true;
                    cboPemasok.SelectedValue = dtRetur.Rows[0]["PemasokID"].ToString();
                    txtNoMPR.Text = dtRetur.Rows[0]["NoMPR"].ToString();
                    txtTglKeluar.DateValue = (DateTime)dtRetur.Rows[0]["TglKeluar"];
                    txtTglKirim.DateValue = (DateTime)dtRetur.Rows[0]["TglKeluar"]; 
                    cboPengirim.SelectedValue = dtRetur.Rows[0]["PengirimID"].ToString();
                    txtTglKirim2.DateValue = (DateTime)dtRetur.Rows[0]["TglKeluar"]; 
                    txtPenerima.Text = dtRetur.Rows[0]["Penerima"].ToString();
                    if (Closing_)
                    {
                        txtNoMPR.ReadOnly = true;
                        txtTglKeluar.ReadOnly = true;
                        txtTglKirim2.ReadOnly = true;
                    }
                    
                    if (_FladEdit != "")
                    {
                        setdisableEditTglKirim();
                    }
                }
                else
                {
                    txtTglKeluar.DateValue = GlobalVar.DateOfServer;
                   // txtTglKirim.DateValue = DateTime.Now;
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
                GlobalVar.LastClosingDate=(DateTime)txtTglKeluar.DateValue;
                if ((DateTime)txtTglKeluar.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                
                this.Cursor = Cursors.WaitCursor;

                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();

                        
                        using (Database db = new Database())
                        {
                            DataTable dtMessage = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRetur", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, ""));
                            //db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, _noMPR));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.UniqueIdentifier, (Guid)cboPengirim.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                            
                            //db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            //db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                            //db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            //db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            //db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            //db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            //db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                                        
                            //EXECUTE COMMANDS
                            dtMessage = db.Commands[0].ExecuteDataTable();

                            if (dtMessage.Rows.Count > 0)
                            {
                                if (dtMessage.Rows[0]["pesan"].ToString() == "Data Berhasil Insert")
                                {
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
                                //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                                //{
                                //    txtKode.Text = string.Empty;
                                //    txtKode.Focus();
                                //    return;
                                //}
                            }
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtRetur.Rows[0]["ReturID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, dtRetur.Rows[0]["NoRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRetur", SqlDbType.DateTime, (DateTime)dtRetur.Rows[0]["TglRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dtRetur.Rows[0]["Penerima"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dtRetur.Rows[0]["noMPR"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.UniqueIdentifier, (Guid)cboPengirim.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtRetur.Rows[0]["isClosed"]));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtRetur.Rows[0]["NPrint"]));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                            //MessageBox.Show("Data telah disimpan");
                            this.Close();
                        }
                        break;
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTglKeluar.Text == "")
            {
                errorProvider1.SetError(txtTglKeluar, "Tanggal memo retur tidak boleh kosong");
                valid = false;
            }
            //if (txtTglKirim.Text == "")
            //{
            //    errorProvider1.SetError(txtTglKirim, "Tanggal kirim 11 tidak boleh kosong");
            //    valid = false;
            //}
                //if (txtPengirim.Text == "")
                //{
                //    errorProvider1.SetError(txtPengirim, "Pengirim tidak boleh kosong");
                //    valid = false;
                //}

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMPRBeliUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMPRBeliBrowser)
                {
                    frmMPRBeliBrowser formCaller = (frmMPRBeliBrowser)this.Caller;
                    formCaller.RefreshDataReturBeli();
                    formCaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmMPRBeliUpdate_Shown(object sender, EventArgs e)
        {
           
        }

        private void frmMPRBeliUpdate_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void cboPemasok_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPemasok_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cboPemasok_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
    }
}
