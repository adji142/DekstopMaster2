using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Toko.Pembelian
{
    public partial class frmNotaBeliDetailUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode _formMode;
        DataTable dtNotaDetail, dtNota;
        Guid _rowID, _headerID;

        public frmNotaBeliDetailUpdate(Form caller, Guid rowID, enumFormMode formMode)
        {
            InitializeComponent();
            _formMode = formMode;
            if (_formMode == enumFormMode.New)
            {
                _headerID = rowID;
            }
            else
            {
                _rowID = rowID;
            }
            this.Caller = caller;
        }

        private void frmNotaBeliDetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Pembelian Detail";
            this.Text = "Pembelian";

            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    if (_formMode == enumFormMode.Update)
                    {
                        dtNotaDetail = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtNotaDetail = db.Commands[0].ExecuteDataTable();
                    }
                    else
                    {
                        dtNota = new DataTable();
                        db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));                        
                        dtNota = db.Commands[0].ExecuteDataTable();
                    }
                }

                if (_formMode == enumFormMode.Update)
                {
                    lookupStock.BarangID = dtNotaDetail.Rows[0]["BarangID"].ToString();
                    lookupStock.NamaStock = dtNotaDetail.Rows[0]["NamaBarang"].ToString();
                    txtSatuan.Text = dtNotaDetail.Rows[0]["Satuan"].ToString();
                    txtQtyNota.Text = dtNotaDetail.Rows[0]["QtyNota"].ToString();
                    txtCatatan.Text = dtNotaDetail.Rows[0]["Catatan"].ToString();
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
                switch (_formMode)
                {
                    case enumFormMode.New:
                        Console.WriteLine(Guid.NewGuid());
                        _rowID = Guid.NewGuid();
                        Console.WriteLine(_rowID);
                        Console.WriteLine(Tools.CreateFingerPrint());
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, txtQtyNota.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, SqlDateTime.Null));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        Clear();
                        this.Close();
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtNotaDetail.Rows[0]["HeaderID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, dtNotaDetail.Rows[0]["HeaderRecID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyRequest"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, dtNotaDetail.Rows[0]["QtyDO"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, dtNotaDetail.Rows[0]["QtySuratJalan"]));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, txtQtyNota.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                            db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, dtNotaDetail.Rows[0]["TglTerima"]));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, dtNotaDetail.Rows[0]["HrgBeli"]));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, dtNotaDetail.Rows[0]["HrgPokok"]));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, dtNotaDetail.Rows[0]["HPPSolo"]));
                            db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtNotaDetail.Rows[0]["Pot"]));
                            db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc1"]));
                            db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc2"]));
                            db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, dtNotaDetail.Rows[0]["Disc3"]));
                            db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtNotaDetail.Rows[0]["DiscFormula"]));
                            db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, dtNotaDetail.Rows[0]["PPN"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dtNotaDetail.Rows[0]["KodeGudang"]));
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
                this.Cursor =  Cursors.Default;
            }        
        }


        private bool ValidateInput()
        {
            bool valid = true;
            errorProvider1.Clear();

            if (lookupStock.BarangID == "[Code]" || lookupStock.BarangID == "")
            {
                errorProvider1.SetError(lookupStock, "Barang tidak boleh kosong");
                valid = false;
            }
            return valid;
        }

        private void Clear()
        {
            lookupStock.BarangID = "[Code]";
            lookupStock.NamaStock = "";
            txtSatuan.Text = "";
            txtQtyNota.Text = "0";
            txtCatatan.Text = "";
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            txtSatuan.Text = lookupStock.Satuan;
        }        

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotaBeliDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaBeliBrowser)
                {
                    frmNotaBeliBrowser formCaller = (frmNotaBeliBrowser)this.Caller;
                    formCaller.RefreshDataNotaBeliDetail();
                    formCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }
    }
}
