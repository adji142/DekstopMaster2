using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Toko.Ekspedisi
{
    public partial class frmEkspedisiPengirimanUpdate : ISA.Toko.BaseForm
    {
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid  _rowID;
        string docNoPengiriman = "NOMOR_PENGIRIMAN";
        DataTable dt;

        public frmEkspedisiPengirimanUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmEkspedisiPengirimanUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmEkspedisiPengirimanUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    //display Sopir List
                    db.Commands.Add(db.CreateCommand("usp_Sopir_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@sk", SqlDbType.VarChar, "Sopir"));
                        
                    dt = db.Commands[0].ExecuteDataTable();
                    cboSopir.DataSource = dt;
                    cboSopir.DisplayMember = "Nama";
                    cboSopir.ValueMember = "Nama";

                    //Display Kernet List
                    db.Commands.Add(db.CreateCommand("usp_Sopir_LIST"));
                    db.Commands[1].Parameters.Add(new Parameter("@sk", SqlDbType.VarChar, "Kenek"));

                    dt = db.Commands[1].ExecuteDataTable();
                    cboKernet.DataSource = dt;
                    cboKernet.DisplayMember = "Nama";
                    cboKernet.ValueMember = "Nama";

                    //Display Tujuan List
                    db.Commands.Add(db.CreateCommand("usp_TujuanExpedisi_LIST"));
                    dt = db.Commands[2].ExecuteDataTable();
                    cboTujuan.DataSource = dt;
                    cboTujuan.DisplayMember = "Tujuan";
                    cboTujuan.ValueMember = "Tujuan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (formMode == enumFormMode.New)
            {
                txtTglKirim.Text = DateTime.Today.ToString("dd/MM/yyyy");
                cboSopir.SelectedIndex = -1;
                cboKernet.SelectedIndex = -1;
                cboTujuan.SelectedIndex = -1;
                txtTglKirim.Focus();
            }
            else
            {
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                txtNoPengiriman.Text = Tools.isNull(dt.Rows[0]["NoKirim"], "").ToString();
                txtTglKirim.DateValue = (DateTime?)dt.Rows[0]["TglKirim"];
                txtJamKirim.Text = Tools.isNull(dt.Rows[0]["JamKirim"], "").ToString();
                txtKMBerangkat.Text = Tools.isNull(dt.Rows[0]["KMBerangkat"], "").ToString();
                cboSopir.SelectedValue = Tools.isNull(dt.Rows[0]["Sopir"], "").ToString();
                cboKernet.SelectedValue = Tools.isNull(dt.Rows[0]["Kernet"], "").ToString();
                cboTujuan.SelectedValue = Tools.isNull(dt.Rows[0]["Tujuan"], "").ToString();
                txtNoPolisis.Text = Tools.isNull(dt.Rows[0]["NoPolisi"], "").ToString();
            }

        }
        public bool IsValid()
        {
            bool valid = true;
            if (txtJamKirim.Text == "")
            {
                errorProvider1.SetError(txtJamKirim, Messages.Error.InputRequired);
                txtJamKirim.Focus();
                valid = false;
            }

            //if (txtKMBerangkat.Text == "")
            //{
            //    errorProvider1.SetError(txtKMBerangkat, Messages.Error.InputRequired);
            //    txtKMBerangkat.Focus();
            //    valid = false;
            //}
            if (cboSopir.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboSopir, Messages.Error.InputRequired);
                cboSopir.Focus();
                valid = false;
            }

            if (cboKernet.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboKernet, Messages.Error.InputRequired);
                cboKernet.Focus();
                valid = false;
            }

            if (cboTujuan.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboTujuan, Messages.Error.InputRequired);
                cboTujuan.Focus();
                valid = false;
            }
                       
            return valid;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    GlobalVar.LastClosingDate = (DateTime)txtTglKirim.DateValue;
                    if ((DateTime)txtTglKirim.DateValue <= GlobalVar.LastClosingDate)
                    {
                        throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                    }
                    switch (formMode)
                    {
                        case enumFormMode.New:
                            //GENERATE Nomor Numerator
                            DataTable dtNum = Tools.GetGeneralNumerator(docNoPengiriman);
                            int lebar = 3;
                            int iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                            string depan = Tools.GeneralInitial();
                            string belakang = dtNum.Rows[0]["Belakang"].ToString();
                            iNomor++;
                            string strNumerator = Tools.FormatNumerator(iNomor, lebar, depan, belakang);


                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                _rowID = Guid.NewGuid();
                                db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_INSERT"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@noKirim", SqlDbType.VarChar, strNumerator));
                                db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@tglKembali", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, cboTujuan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, cboSopir.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@kernet", SqlDbType.VarChar, cboKernet.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@noPolisi", SqlDbType.VarChar, txtNoPolisis.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kasBon", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@bbmltr", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@bbmRp", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@umSopir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@umKernet", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@parkir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@tol", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@kuli", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lain", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@ketLain", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@tarikan", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@jamKirim", SqlDbType.VarChar, txtJamKirim.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@jamKembali", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kmBerangkat", SqlDbType.Int, (string.IsNullOrEmpty(txtKMBerangkat.Text) == true ? 0 : int.Parse(txtKMBerangkat.Text))));
                                db.Commands[0].Parameters.Add(new Parameter("@kmKirim", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@izinMasuk", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@timbangan", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@inTepatWaktu", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@inPengiriman", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                                db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoPengiriman));
                                db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                                db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                                db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                                db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                                db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                db.BeginTransaction();
                                db.Commands[0].ExecuteNonQuery();
                                db.Commands[1].ExecuteNonQuery();
                                db.CommitTransaction();
                            }
                            MessageBox.Show(Messages.Confirm.UpdateSuccess + "\nNo Pengiriman " + strNumerator);
                            break;

                        case enumFormMode.Update:
                            using (Database db = new Database())
                            {
                                DataTable dt = new DataTable();
                                db.Commands.Add(db.CreateCommand("usp_PengirimanEkspedisi_UPDATE"));
                                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                db.Commands[0].Parameters.Add(new Parameter("@trID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                                db.Commands[0].Parameters.Add(new Parameter("@noKirim", SqlDbType.VarChar, txtNoPengiriman.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@tglKirim", SqlDbType.DateTime, txtTglKirim.DateValue));
                                db.Commands[0].Parameters.Add(new Parameter("@tglKembali", SqlDbType.DateTime, SqlDateTime.Null));
                                db.Commands[0].Parameters.Add(new Parameter("@tujuan", SqlDbType.VarChar, cboTujuan.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@sopir", SqlDbType.VarChar, cboSopir.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@kernet", SqlDbType.VarChar, cboKernet.SelectedValue));
                                db.Commands[0].Parameters.Add(new Parameter("@noPolisi", SqlDbType.VarChar, txtNoPolisis.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@kasBon", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@bbmltr", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@bbmRp", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@umSopir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@umKernet", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@parkir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@tol", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@kuli", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@lain", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@ketLain", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@nPrint", SqlDbType.Int, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@tarikan", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@jamKirim", SqlDbType.VarChar, txtJamKirim.Text));
                                db.Commands[0].Parameters.Add(new Parameter("@jamKembali", SqlDbType.VarChar, ""));
                                db.Commands[0].Parameters.Add(new Parameter("@kmBerangkat", SqlDbType.Int, (string.IsNullOrEmpty(txtKMBerangkat.Text) == true ? 0 : int.Parse(txtKMBerangkat.Text))));
                                db.Commands[0].Parameters.Add(new Parameter("@kmKirim", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@izinMasuk", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@timbangan", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@inTepatWaktu", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@inPengiriman", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                                db.Commands[0].ExecuteNonQuery();

                            }
                            MessageBox.Show(Messages.Confirm.UpdateSuccess);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
                
                this.DialogResult = DialogResult.OK;
                frmEkspedisiPengirimanBrowse  frmCaller = (frmEkspedisiPengirimanBrowse)this.Caller;
                frmCaller.RefreshDataHeader();
                frmCaller.FindHeader("RowID", _rowID.ToString());
                this.Close();
                frmCaller.Show();
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
