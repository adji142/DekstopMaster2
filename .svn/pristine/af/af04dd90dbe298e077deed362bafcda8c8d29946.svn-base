using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel;
using ISA.Bengkel.Helper;
using System.Data.SqlTypes;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmPembelianUpdate : ISA.Bengkel.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dtPembelian;
        Guid _rowID, _RowIDPemasok;
        public event EventHandler SelectData;
        string _NoPB = "";

        public frmPembelianUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmPembelianUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmPembelianUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtPembelian = new DataTable();
                if (formMode == enumFormMode.Update)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeli_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtPembelian = db.Commands[0].ExecuteDataTable();                  
                    }
                    dtpTglNota.Value = (DateTime)dtPembelian.Rows[0]["tgl_nota"];
                    txtNoNota.Text = dtPembelian.Rows[0]["no_nota"].ToString();
                    dtpTglTerima.Value = (DateTime)dtPembelian.Rows[0]["tgl_trm"];
                    txtJWKredit.Text = dtPembelian.Rows[0]["hr_krdt"].ToString();
                    txtPemasok.Text = dtPembelian.Rows[0]["pemasok"].ToString();
                    txtPemasokID.Text = dtPembelian.Rows[0]["PemasokID"].ToString();
                    _RowIDPemasok = new Guid(Tools.isNull(dtPembelian.Rows[0]["PemasokRowID"], Guid.Empty).ToString());

                    //txtExpedisi.Text = dtPembelian.Rows[0]["expedisi"].ToString();
                    txtJmlBeli.Text = dtPembelian.Rows[0]["rp_beli"].ToString();
                    txtDisc1.Text = dtPembelian.Rows[0]["disc_1"].ToString();
                    txtDisc2.Text = dtPembelian.Rows[0]["disc_2"].ToString();
                    txtDisc3.Text = dtPembelian.Rows[0]["disc_3"].ToString();
                    txtPPn.Text = dtPembelian.Rows[0]["ppn"].ToString();
                    txtJmlNetto.Text = dtPembelian.Rows[0]["rp_net"].ToString();
                    txtCatatan.Text = dtPembelian.Rows[0]["catatan1"].ToString();        
                }
                else
                {
                    dtpTglNota.Value = DateTime.Now;
                    dtpTglTerima.Value = DateTime.Now;
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
                this.Cursor = Cursors.WaitCursor;
                //if (txtTglRequest.DateValue <= GlobalVar.LastClosingDate)
                //{
                //    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                //}
                switch (formMode)
                {
                    case enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        // Generate No Request
                        string _noPembelian, numeratorDoc = "NOMOR NOTA PB BKL", depan = "", belakang = "";
                        int iNomor, lebar;

                        DataTable dtNum = Tools.GetGeneralNumerator(numeratorDoc, Tools.GeneralInitial());
                        if (dtNum.Rows.Count > 0)
                        {
                            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                            depan = Tools.GeneralInitial();
                            belakang = dtNum.Rows[0]["Belakang"].ToString();
                            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                            iNomor++;
                            _noPembelian = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                        }
                        else
                        {
                            lebar = 4;
                            depan = Tools.GeneralInitial();
                            belakang = "";
                            iNomor = 0;
                            iNomor++;
                            _noPembelian = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
                        }

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeli_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_nota", SqlDbType.DateTime, dtpTglNota.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@no_nota", SqlDbType.VarChar, _noPembelian));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_trm", SqlDbType.DateTime, dtpTglTerima.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@hr_krdt", SqlDbType.Decimal, txtJWKredit.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, txtPemasok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_beli", SqlDbType.Decimal, txtJmlBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc1.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_2", SqlDbType.Decimal, txtDisc2.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_3", SqlDbType.Decimal, txtDisc3.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Decimal, txtPPn.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_net", SqlDbType.Decimal, txtJmlNetto.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));                           
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDPemasok", SqlDbType.UniqueIdentifier, _RowIDPemasok));
                            
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_BengkelBeli_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_nota", SqlDbType.DateTime, dtpTglNota.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@no_nota", SqlDbType.VarChar, txtNoNota.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tgl_trm", SqlDbType.DateTime, dtpTglTerima.Value));
                            db.Commands[0].Parameters.Add(new Parameter("@hr_krdt", SqlDbType.Decimal, txtJWKredit.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, txtPemasok.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_beli", SqlDbType.Decimal, txtJmlBeli.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc1.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_2", SqlDbType.Decimal, txtDisc2.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_3", SqlDbType.Decimal, txtDisc3.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Decimal, txtPPn.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@rp_net", SqlDbType.Decimal, txtJmlNetto.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@RowIDPemasok", SqlDbType.UniqueIdentifier, _RowIDPemasok));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
                this.DialogResult = DialogResult.OK;
                closeForm();
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

            if (txtPemasok.Text == "")
            {
                MessageBox.Show("Pemasok belum diisi");
                txtPemasok.Focus();
                valid = false;
            }

            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPembelianUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }

        private void closeForm()
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmPembelianBengkel)
                {
                    frmPembelianBengkel formCaller = (frmPembelianBengkel)this.Caller;
                    formCaller.RefreshDataPembelian();
                    formCaller.FindRow(FormTools.detailIndex.header, "RowID", _rowID.ToString());
                }
            }
        }


        private void txtPemasok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ShowDialogForm();
            }
        }

        private void ShowDialogForm()
        {
            bool l = false;

            DataTable dtg = new DataTable();

            dtg = GetData(txtPemasok.Text.Trim(), l);
            if (dtg.Rows.Count == 0)
            {
                txtPemasok.Text = string.Empty;
                txtPemasokID.Text = string.Empty;
                _RowIDPemasok = System.Guid.Empty;
                txtPemasok.Focus();
                return;
            }

            if (dtg.Rows.Count == 1)
            {
                GetResult(dtg.Rows[0]);
            }
            else
            {

                Transaksi.frmLookupPemasok ifrmDialog = new Transaksi.frmLookupPemasok(dtg,txtPemasok.Text.Trim());
                ifrmDialog.ShowDialog();
                if (ifrmDialog.DialogResult == DialogResult.OK)
                {
                    GetDialogResult(ifrmDialog);
                }
            }
        }

        private DataTable GetData(string SearchArg, bool lokal)
        {
            DataTable d = new DataTable();
            DataTable dtv = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("[usp_bkl_pemasok_LIST]"));
                db.Commands[0].Parameters.Add(new Parameter("@nama", SqlDbType.VarChar, SearchArg.Trim()));
                d = db.Commands[0].ExecuteDataTable();
            }

            dtv = d.Copy();
            return dtv;
        }

        private void GetResult(DataRow dialogForm)
        {
            txtPemasok.Text = dialogForm["Nama"].ToString();
            txtPemasokID.Text = dialogForm["PemasokID"].ToString();
            _RowIDPemasok = (Guid)dialogForm["RowID"];

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }

        private void GetDialogResult(Transaksi.frmLookupPemasok dialogForm)
        {
            txtPemasok.Text = dialogForm.GetVendor["Nama"].ToString();
            txtPemasokID.Text = dialogForm.GetVendor["PemasokID"].ToString();
            _RowIDPemasok = (Guid)dialogForm.GetVendor["RowID"];

            if (this.SelectData != null)
            {
                this.SelectData(this, new EventArgs());
            }
        }


    }
}
