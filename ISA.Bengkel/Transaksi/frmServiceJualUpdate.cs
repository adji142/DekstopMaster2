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
    public partial class frmServiceJualUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode _formMode;
        DataTable dtServiceJual, dtService;
        Guid _rowID, _headerID, _rowStokBkl;
        string HtrID_,Perbaikan_;

        public frmServiceJualUpdate(Form caller, Guid rowID, Guid HeaderID_, string HtrID, FormTools.enumFormMode formMode,string perbaikan)
        {
            InitializeComponent();
            _formMode = formMode;
            if (_formMode == FormTools.enumFormMode.Update)
            {
                _rowID = rowID;
                _headerID = HeaderID_;
                Perbaikan_ = perbaikan;
            }
            else
            {
                _headerID = HeaderID_;
                HtrID_ = HtrID;
                Perbaikan_ = perbaikan;
            }
            this.Caller = caller;
        }

        private void frmServiceJualUpdate_Load(object sender, EventArgs e)
        {
            if (Perbaikan_ == "INV" || Perbaikan_ == "KRY" || Perbaikan_ =="SEKOLAH" || Perbaikan_ =="INSTANSI")
            {
                label6.Visible = true;
                lookupToko1.Visible = true;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == FormTools.enumFormMode.Update)
                    {
                        dtServiceJual = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_bkl_djual_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtServiceJual = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dtService = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_bkl_service_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));                  

                        dtService = db.Commands[0].ExecuteDataTable();
                    }
                }

                if (_formMode == FormTools.enumFormMode.Update)
                {
                    lkpStokBkl.KodeStokBkl = dtServiceJual.Rows[0]["id_brg"].ToString();
                    lkpStokBkl.NamaStokBkl = dtServiceJual.Rows[0]["nama_stok"].ToString();
                    _rowStokBkl = (Guid)dtServiceJual.Rows[0]["RowStokBkl"];
                    txtSatuan.Text = dtServiceJual.Rows[0]["satuan"].ToString();
                    txtQty.Text = dtServiceJual.Rows[0]["j_nota"].ToString();
                    txtHargaSat.Text = dtServiceJual.Rows[0]["h_jual"].ToString();
                    txtJumlah.Text = dtServiceJual.Rows[0]["jumlah"].ToString();

                    lkpStokBkl.Enabled = false;
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
            if (lookupToko1.KodeToko == "" || lookupToko1.KodeToko == "[CODE]" && (Perbaikan_ != "UMUM" || Perbaikan_ =="INSTANSI" || Perbaikan_ =="SEKOLAH"))
            {
                MessageBox.Show("Toko Harus di isi");
                return;
            }
            double Qty = 0,Hrg = 0;
            Qty = Convert.ToDouble(txtQty.Text);
            Hrg = Convert.ToDouble(txtHargaSat.Text);

            if (Qty == 0)
            {
                MessageBox.Show("QTY masih kosong");
                return;
            }
            if (Hrg == 0)
            {
                MessageBox.Show("Harga Jual masih kosong");
                return;
            }

            try
            {
                using (Database db = new Database())
                {
                    DataTable dtc = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_StokBengkelCekIdbrg_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                    dtc = db.Commands[0].ExecuteDataTable();
                    if (dtc.Rows.Count == 0)
                    {
                        MessageBox.Show("Barang ini tidak ada di master stok bengkel");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
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
                            db.Commands.Add(db.CreateCommand("usp_bkl_djual_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, (Guid)dtService.Rows[0]["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@Idtr", SqlDbType.VarChar, HtrID_));
                            db.Commands[0].Parameters.Add(new Parameter("@id_brg", SqlDbType.VarChar, lkpStokBkl.KodeStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@nama_stok", SqlDbType.VarChar, lkpStokBkl.NamaStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@j_nota", SqlDbType.Decimal, txtQty.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@h_jual", SqlDbType.Decimal, txtHargaSat.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@RowStokBkl", SqlDbType.UniqueIdentifier, lkpStokBkl.RowStokBkl));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].Parameters.Add(new Parameter("@Gudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@kd_toko", SqlDbType.VarChar, lookupToko1.KodeToko));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        UpdateServiceFlagStokBkl();
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        //Clear();

                        if (this.Caller is frmServiceBrowser)
                        {
                            frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
                            formCaller.RefreshDataJual();
                            formCaller.FindRow(FormTools.detailIndex.detail3, "RowID4", _rowID.ToString());
                        }
                        this.Close();
                        break;

                    case FormTools.enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_bkl_djual_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtServiceJual.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@j_nota", SqlDbType.Decimal, txtQty.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@h_jual", SqlDbType.Decimal, txtHargaSat.GetDoubleValue));
                            db.Commands[0].Parameters.Add(new Parameter("@satuan", SqlDbType.VarChar, txtSatuan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        if (this.Caller is frmServiceBrowser)
                        {
                            frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
                            formCaller.RefreshDataJual();
                            formCaller.FindRow(FormTools.detailIndex.detail3, "RowID4", _rowID.ToString());
                        }
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
            return valid;
        }

        private void Clear()
        {
            lkpStokBkl.KodeStokBkl = "";
            lkpStokBkl.NamaStokBkl = "";
            txtSatuan.Text = "";
            txtQty.Text = "0";
            txtHargaSat.Text = "0";
            txtJumlah.Text = "0";
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void frmServiceJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (this.DialogResult == DialogResult.OK)
        //    {
        //        if (this.Caller is frmServiceBrowser)
        //        {
        //            frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
        //            formCaller.RefreshDataJual();
        //            formCaller.FindRow(FormTools.detailIndex.detail3, "RowID", _rowID.ToString()); 
        //        }
        //    }
        //}

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lkpStokBkl.Satuan;         
        }

        private void UpdateServiceFlagStokBkl()
        {
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_bkl_stokbkl_UPDATE"));
                db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                db.Commands[0].Parameters.Add(new Parameter("@ServiceFlag", SqlDbType.Bit, 1));
                db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }
        }

        private void lkpStokBkl_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lkpStokBkl.Satuan;
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            double Qty = 0, Hrg = 0;
            Qty = Convert.ToDouble(txtQty.Text);
            Hrg = Convert.ToDouble(txtHargaSat.Text);
            txtJumlah.Text = (Qty * Hrg).ToString();

        }

        private void txtHargaSat_Leave(object sender, EventArgs e)
        {
            double Qty = 0, Hrg = 0;
            Qty = Convert.ToDouble(txtQty.Text);
            Hrg = Convert.ToDouble(txtHargaSat.Text);
            txtJumlah.Text = (Qty * Hrg).ToString();

        }
    }
}
