using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;
using System.Data.SqlTypes;

namespace ISA.Toko.Pembelian
{
    public partial class frmDOBeliUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode formMode;
        DataTable dtDO, dtPemasok = new DataTable();
        Guid _rowID, _JadwalKrmID;
        bool Closing;

        public frmDOBeliUpdate(Form caller)
        {
            InitializeComponent();
            formMode = enumFormMode.New;
            this.Caller = caller;
        }

        public frmDOBeliUpdate(Form caller, Guid rowID,bool CLosing_)
        {
            InitializeComponent();
            formMode = enumFormMode.Update;
            _rowID = rowID;
            this.Caller = caller;
            Closing = CLosing_;
        }

        public String findNamaSalesman(String kode) 
        {
            String Salesman = "";
            if (Tools.Left(kode, 2)=="00")
            {
                DataRow[] dtfilter = dtPemasok.Select("PemasokID = " + kode);
                Salesman = dtfilter[0]["Salesman"].ToString();
                
            }
            return Salesman;
        }

        private void frmDOBeliUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Order Pembelian";
            this.Text = "Pembelian";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDO = new DataTable();

                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Pemasok_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusAktif", SqlDbType.Bit, true));
                    dtPemasok = db.Commands[0].ExecuteDataTable();


                    if (formMode == enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_OrderPembelian_LIST"));
                        db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtDO = db.Commands[1].ExecuteDataTable();
                    }
                }
                cboSupplier.DataSource = dtPemasok;
                cboSupplier.DisplayMember = "Nama";
                cboSupplier.ValueMember = "PemasokID";

                if (formMode == enumFormMode.Update)
                {
                    label2.Visible = true;
                    txtNoRequest.Visible = true;
                    txtTglRequest.DateValue = (DateTime)dtDO.Rows[0]["TglRequest"];
                    txtNoRequest.Text = dtDO.Rows[0]["NoRequest"].ToString();
                    try
                    {
                        cboSupplier.SelectedValue = dtDO.Rows[0]["PemasokID"].ToString();
                    }
                    catch { cboSupplier.Text = dtDO.Rows[0]["Pemasok"].ToString();
                    cboSupplier.BackColor = Color.DeepPink ;
                    }
                    txtNoACC.Text = dtDO.Rows[0]["NoACC"].ToString();
                    txtCatatan.Text = dtDO.Rows[0]["Catatan"].ToString();
                    txtSalesman.Text= dtDO.Rows[0]["NamaSales"].ToString();
                   

                    txtTglRequest.ReadOnly = true;
                    txtNoRequest.ReadOnly = true;
                    cboSupplier.Enabled = true;
                    if (Tools.isNull(dtDO.Rows[0]["JadwalKrmID"],"").ToString()=="")
                    {
                        _JadwalKrmID = Guid.Empty;
                    } 
                    else
                    {
                        _JadwalKrmID = (Guid)dtDO.Rows[0]["JadwalKrmID"];
                    }
                 
                }
                else
                {

                    txtTglRequest.DateValue = DateTime.Now;
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
                        _JadwalKrmID = lookupJadwalExpedisi1.RowID;
                        // Generate No Request
                        //string _noRQ, numeratorDoc = "NOMOR_RQ_PB0", depan = "", belakang = "";
                        //int iNomor, lebar;

                        //DataTable dtNum = Tools.GetGeneralNumerator(numeratorDoc, Tools.GeneralInitial());
                        //lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
                        //depan = Tools.GeneralInitial();
                        //belakang = dtNum.Rows[0]["Belakang"].ToString();                        
                        //iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
                        //iNomor++;
                        //_noRQ = Tools.FormatNumerator(iNomor, lebar, depan, belakang);

                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPembelian_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, txtTglRequest.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboSupplier.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, GlobalVar.CabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, GlobalVar.CabangID));
                            db.Commands[0].Parameters.Add(new Parameter("@estHrgJual", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@estHPP", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jadwalkrmID", SqlDbType.UniqueIdentifier, _JadwalKrmID));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@Salesman", SqlDbType.VarChar, txtSalesman.Text));
                            
                                                        
                            //EXECUTE COMMANDS
                            db.BeginTransaction();
                            db.Commands[0].ExecuteNonQuery();
                            db.CommitTransaction();   
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_OrderPembelian_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDO.Rows[0]["recordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, dtDO.Rows[0]["NoRequest"]));
                            db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, txtTglRequest.DateValue));
                            db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboSupplier.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang1", SqlDbType.VarChar, dtDO.Rows[0]["Cabang1"]));
                            db.Commands[0].Parameters.Add(new Parameter("@cabang2", SqlDbType.VarChar, dtDO.Rows[0]["Cabang2"]));
                            db.Commands[0].Parameters.Add(new Parameter("@estHrgJual", SqlDbType.Money, dtDO.Rows[0]["EstHrgJual"]));
                            db.Commands[0].Parameters.Add(new Parameter("@estHPP", SqlDbType.Money, dtDO.Rows[0]["EstHPP"]));
                            db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, txtNoACC.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@jadwalkrmID", SqlDbType.UniqueIdentifier, _JadwalKrmID == Guid.Empty ? SqlGuid.Null : _JadwalKrmID));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@Salesman", SqlDbType.VarChar, txtSalesman.Text));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        break;
                }
                MessageBox.Show("Data telah tersimpan");
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

        private bool ValidateInput()
        {
            bool valid = true;

            if (txtTglRequest.Text == "")
            {
                errorProvider1.SetError(txtTglRequest, "Tgl Request tidak boleh kosong");
                valid = false;
            }
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDOBeliUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmDOBeliBrowser)
                {
                    frmDOBeliBrowser formCaller = (frmDOBeliBrowser)this.Caller;
                    formCaller.RefreshDataOrderPembelian();
                    formCaller.FindHeader("HeaderRowID", _rowID.ToString());
                    formCaller.opendetail();
                }
            }
        }

        private void txtTglRequest_Validating(object sender, CancelEventArgs e)
        {
            if (txtTglRequest.DateValue != null)
            {
                lookupJadwalExpedisi1.TglRQ = (DateTime)txtTglRequest.DateValue;
                lookupJadwalExpedisi1.KdGdg = GlobalVar.Gudang;
            }
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            txtSalesman.Text = findNamaSalesman(cboSupplier.SelectedValue.ToString());
            cboSupplier.BackColor = Color.Empty;
        }

    }
}
