using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel.Helper;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Transaksi
{
    public partial class frmServiceDetailUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode _formMode;
        DataTable dtServiceDetail, dtService;
        DataSet dtPrmService = new DataSet();
        Guid _rowID, _headerID;
        String HtrID_,_NoPol, Promo51 = "0",perbaikan_="";
        Double Potongan = 0, Biaya = 0,Net = 0;


        public frmServiceDetailUpdate(Form caller, Guid rowID, Guid HeaderID_,string HtrID, FormTools.enumFormMode formMode, string NoPol,string perbaikan)
        {
            InitializeComponent();
            _formMode = formMode;
            _NoPol = NoPol;
            if (_formMode == FormTools.enumFormMode.Update)
            {
                _rowID = rowID;
                _headerID = HeaderID_;
            }
            else
            {
                _headerID = HeaderID_;
                HtrID_ = HtrID;
                perbaikan_ = perbaikan;
            }
            this.Caller = caller;
        }

        private void frmServiceDetailUpdate_Load(object sender, EventArgs e)
        {
            if (perbaikan_ == "INV")
            {
                label6.Visible = true;
                chksasa.Visible = true;
                chkother.Visible = true;
                //chkkry.Visible = true;
            }
            else if (perbaikan_ == "KRY") {
                label6.Visible = true;
                chksasa.Visible = false;
                chkother.Visible = false;
                chkkry.Visible = true;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtService = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_bkl_hpoint_LIST"));
                    dtService = db.Commands[0].ExecuteDataTable();

                    cmbService.DataSource = dtService; 
                    cmbService.DisplayMember = "kategori";
                    cmbService.ValueMember = "kode";

                    if (_formMode == FormTools.enumFormMode.Update)
                    {
                        dtServiceDetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtServiceDetail = db.Commands[1].ExecuteDataTable();

                        cmbService.SelectedValue = dtServiceDetail.Rows[0]["kode"].ToString();
                        txtServiceDesc.Text = dtServiceDetail.Rows[0]["kategori"].ToString();
                        txtBiaya.Text = dtServiceDetail.Rows[0]["biaya"].ToString();
                        txtDisc.Text = dtServiceDetail.Rows[0]["disc_1"].ToString();
                        txtPot.Text = dtServiceDetail.Rows[0]["pot_rp"].ToString();
                        txtNetto.Text = dtServiceDetail.Rows[0]["netto"].ToString();
                        txtKeterangan.Text = dtServiceDetail.Rows[0]["Keterangan"].ToString();

                    }
                    //else
                    //{
                    //    dtService = new DataTable();
                    //    db.Commands.Add(db.CreateCommand("usp_bkl_service_LIST"));
                    //    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                    //    dtService = db.Commands[0].ExecuteDataTable();

                    //}
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
                switch(_formMode)
                {
                    case FormTools.enumFormMode.New:
                        _rowID = Guid.NewGuid();
                        
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbService.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, txtServiceDesc.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Decimal, txtBiaya.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Decimal, txtPot.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@Idtr", SqlDbType.VarChar, HtrID_));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        Clear();
                        this.Close();
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_servicedetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, cmbService.SelectedValue));
                            db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, txtServiceDesc.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@biaya", SqlDbType.Decimal, txtBiaya.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@disc_1", SqlDbType.Decimal, txtDisc.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pot_rp", SqlDbType.Decimal, txtPot.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@keterangan", SqlDbType.VarChar, txtKeterangan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();

                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        this.Close();
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
            errorProvider1.Clear();

            if (cmbService.SelectedValue == "")
            {
                errorProvider1.SetError(cmbService, "Mohon masukkan kategori servis");
                valid = false;
            }
            if (chksasa.Checked == false && chkother.Checked == false && chkkry.Checked == false && perbaikan_ == "INV") {
                errorProvider1.SetError(chksasa, "Transaksi inventaris harus pilih perusahaan");
                errorProvider1.SetError(chkkry, "Transaksi inventaris harus pilih perusahaan");
                errorProvider1.SetError(chkother, "Transaksi inventaris harus pilih perusahaan");
                valid = false;
            }
            return valid;
        }

        private void Clear()
        {
            cmbService.Text = "";
            txtServiceDesc.Text = "";
            txtBiaya.Text = "";
            txtDisc.Text = "";
            txtPot.Text = "0";
            txtNetto.Text = "0";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmServiceDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmServiceBrowser)
                {
                    frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
                    formCaller.RefreshDataServiceDetail();
                    //formCaller.FindRow(FormTools.detailIndex.detail1, "RowID", _rowID.ToString()); 
                }
            }
        }

        private void cmbService_SelectedValueChanged(object sender, EventArgs e)
        {
            string _promo1 = "";
            string _promo2 = "";
            string _kode = cmbService.SelectedValue.ToString();
            Biaya = 0;
            Potongan = 0;

            /*kategori service*/
            DataTable dtcmbService = new DataTable();
            using (Database data = new Database())
            {
                data.Commands.Add(data.CreateCommand("usp_bkl_hpoint_LIST_kode"));
                data.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, _kode));
                dtcmbService = data.Commands[0].ExecuteDataTable();
                if (dtcmbService.Rows.Count > 0)
                {
                    Biaya = Double.Parse(Tools.isNull(dtcmbService.Rows[0]["biaya"], "0").ToString());
                    txtServiceDesc.Text = dtcmbService.Rows[0]["kategori"].ToString();
                    txtBiaya.Text = Biaya.ToString();
                    txtDisc.Text = "0";
                    txtPot.Text = Potongan.ToString();
                }
            }

            /*promo bengkel*/
            using (Database data = new Database())
            {
                data.Commands.Add(data.CreateCommand("usp_bkl_PromoService_LIST"));
                data.Commands[0].Parameters.Add(new Parameter("@kode", SqlDbType.VarChar, _kode));
                data.Commands[0].Parameters.Add(new Parameter("@NoPol", SqlDbType.VarChar, _NoPol));
                dtPrmService = data.Commands[0].ExecuteDataSet();
            }

            /*potongan biaya service*/
            if (dtPrmService.Tables[0].Rows.Count > 0)
            {
                Potongan = Double.Parse(Tools.isNull(dtPrmService.Tables[0].Rows[0]["pot_rp"], "0").ToString());
                txtPot.Text = Potongan.ToString();
                txtNetto.Text = (Biaya - Potongan).ToString();
            }

            /*gratis biaya service*/
            if (dtPrmService.Tables[1].Rows.Count > 0)
            {
                //Int32 nService = 0;
                //Int32 nMin = Int32.Parse(Tools.isNull(dtPrmService.Tables[1].Rows[0]["q_min"], "0").ToString());
                //if (dtPrmService.Tables[2].Rows.Count > 0)
                //{
                //    nService = Int32.Parse(Tools.isNull(dtPrmService.Tables[2].Rows[0]["QtySrv"], "0").ToString());
                //}
                //Potongan = Biaya;
                Int32 nService = 0;
                Int32 nMin = Int32.Parse(Tools.isNull(dtPrmService.Tables[1].Rows[0]["q_min"], "0").ToString());
                if (dtPrmService.Tables[2].Rows.Count > 0)
                {
                    nService = Int32.Parse(Tools.isNull(dtPrmService.Tables[2].Rows[0]["QtySrv"], "0").ToString());
                }
                //Potongan = Biaya;
                if (nService >= nMin)
                {
                    Promo51 = "1";
                    txtPot.Text = Potongan.ToString();
                    txtNetto.Text = (Biaya - Potongan).ToString();
                }

            }
        }


        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            double biaya, dis, ndis, npot, netto;

            if (txtBiaya.Text != "")
                biaya = Convert.ToDouble(txtBiaya.Text);
            else
                biaya = 0;

            if (txtDisc.Text != "")
                ndis = Convert.ToDouble(txtDisc.Text);
            else
                ndis = 0;

            if (txtPot.Text != "")
                npot = Convert.ToDouble(txtPot.Text);
            else
                npot = 0;

            dis  = biaya * (ndis / 100);
            netto= biaya - dis - npot;

            txtNetto.Text = netto.ToString();
        }

        private void txtBiaya_Leave(object sender, EventArgs e)
        {
            if (Double.Parse(Tools.isNull(txtBiaya.Text, "0").ToString()) > 0)
                txtPot.Text = Potongan.ToString();
            else
                txtPot.Text = "0";
        }

        private void chksasa_CheckedChanged(object sender, EventArgs e)
        {
            chkkry.Checked = false;
            chkother.Checked = false;
            txtPot.Text = txtBiaya.Text;
            Net = txtBiaya.GetDoubleValue - txtPot.GetDoubleValue;
            txtNetto.Text = Net.ToString();
        }

        private void chkother_CheckedChanged(object sender, EventArgs e)
        {
            chkkry.Checked = false;
            chksasa.Checked = false;
            txtPot.Text = "0";
            Net = txtBiaya.GetDoubleValue - txtPot.GetDoubleValue;
            txtNetto.Text = Net.ToString();
        }

        private void chkkry_CheckedChanged(object sender, EventArgs e)
        {
            chksasa.Checked = false;
            chkother.Checked = false;
            txtPot.Text = "0";
            Net = txtBiaya.GetDoubleValue - txtPot.GetDoubleValue;
            txtNetto.Text = Net.ToString();
        }
    }
}


