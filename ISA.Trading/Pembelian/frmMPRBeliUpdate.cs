using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.Pembelian
{
    public partial class frmMPRBeliUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dtRetur;
        Guid _rowID;
        bool Closing_;

        public frmMPRBeliUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmMPRBeliUpdate(Form caller, Guid rowID, bool CLosing)
        {
         
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            Closing_ = CLosing;
            InitializeComponent();
        }

        private void frmMPRBeliUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "MPR";
            this.Text = "Retur Pembelian";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtPemasok = new DataTable();
                dtRetur = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));
                    dtPemasok = db.Commands[0].ExecuteDataTable();

                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtRetur = db.Commands[1].ExecuteDataTable();
                    }
                }
                cboPemasok.DataSource = dtPemasok;
                cboPemasok.DisplayMember = "Nama";
                cboPemasok.ValueMember = "Nama";

                if (formMode == enumFormMode.Update)
                {
                    cboPemasok.SelectedValue = dtRetur.Rows[0]["Pemasok"].ToString();
                    txtNoMPR.Text = dtRetur.Rows[0]["NoMPR"].ToString();
                    txtTglKeluar.DateValue = (DateTime)dtRetur.Rows[0]["TglKeluar"];
                    txtTglKirim.DateValue = (DateTime)dtRetur.Rows[0]["TglKirim"];
                    txtPengirim.Text = dtRetur.Rows[0]["Pengirim"].ToString();
                    txtTglKirim2.DateValue = (DateTime)dtRetur.Rows[0]["TglKirim"];
                    txtPenerima.Text = dtRetur.Rows[0]["Penerima"].ToString();
                    if (Closing_)
                    {
                        txtNoMPR.ReadOnly = true;
                        txtTglKeluar.ReadOnly = true;
                        txtTglKirim2.ReadOnly = true;

                    }
                }
                else
                {
                    txtTglKeluar.DateValue = DateTime.Now;
                    txtTglKirim.DateValue = DateTime.Now;
                    txtPengirim.Text = SecurityManager.UserID;
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
                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                
                this.Cursor = Cursors.WaitCursor;

                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();

                        // Generate No MPR Pembelian
                        string _noMPR, numeratorDoc = "NOMOR_MPR_RB", depan = "", belakang = "";
                        int iNomor, lebar;

                        DataTable dtNum = Tools.GetGeneralNumerator(numeratorDoc);
                        lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                        depan = Tools.GeneralInitial();
                        belakang = dtNum.Rows[0]["Belakang"].ToString();                        
                        iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                        iNomor++;
                        _noMPR = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRetur", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, _noMPR));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, txtPengirim.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            
                            db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                            db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, numeratorDoc));
                            db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                            db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                            db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                            db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                            db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                                        
                            //EXECUTE COMMANDS
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.Commands[1].ExecuteNonQuery();
                            db.CommitTransaction();   
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtRetur.Rows[0]["ReturID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noRetur", SqlDbType.VarChar, dtRetur.Rows[0]["NoRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRetur", SqlDbType.DateTime, dtRetur.Rows[0]["TglRetur"]));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboPemasok.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@penerima", SqlDbType.VarChar, dtRetur.Rows[0]["Penerima"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noMPR", SqlDbType.VarChar, dtRetur.Rows[0]["noMPR"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, txtTglKeluar.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@Pengirim", SqlDbType.VarChar, txtPengirim.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, dtRetur.Rows[0]["isClosed"]));
                            db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, dtRetur.Rows[0]["NPrint"]));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }                
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Data telah disimpan");
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTglKeluar.Text == "")
            {
                errorProvider1.SetError(txtTglKeluar, "Tanggal memo retur tidak boleh kosong");
                valid = false;
            }
            if (txtTglKirim.Text == "")
            {
                errorProvider1.SetError(txtTglKirim, "Tanggal kirim 11 tidak boleh kosong");
                valid = false;
            }
            if (txtPengirim.Text == "")
            {
                errorProvider1.SetError(txtPengirim, "Pengirim tidak boleh kosong");
                valid = false;
            }

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
    }
}
