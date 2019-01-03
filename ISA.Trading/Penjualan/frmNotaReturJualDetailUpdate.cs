using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Penjualan
{
    public partial class frmNotaReturJualDetailUpdate : ISA.Trading.BaseForm
    {
        DataTable dt;
        Guid _rowID;
        string _kodeRetur;
        

        public frmNotaReturJualDetailUpdate(Form caller, Guid rowID)
        {
            InitializeComponent();
            _rowID = rowID;
            this.Caller = caller;
        }

        private void frmNotaReturJualDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_LIST")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                _kodeRetur = Tools.isNull(dt.Rows[0]["KodeRetur"], "").ToString();
                if (_kodeRetur == "1")
                {
                    txtKodeRetur.Text = "Murni";
                }
                else
                {
                    txtKodeRetur.Text = "Tarikan";
                }
                txtKodeBarang.Text = Tools.isNull(dt.Rows[0]["BarangID"], "").ToString();
                txtNamaBarang.Text = Tools.isNull(dt.Rows[0]["NamaStok"], "").ToString();
                txtSatuan.Text = Tools.isNull(dt.Rows[0]["Satuan"], "").ToString();
                txtNoNota.Text = Tools.isNull(dt.Rows[0]["NotaAsal"], "").ToString();
                if (Tools.isNull(dt.Rows[0]["TglNota"], "").ToString() != "")
                {
                    txtTglNota.DateValue = (DateTime)dt.Rows[0]["TglNota"];
                }
                txtCabang1.Text = Tools.isNull(dt.Rows[0]["Cabang1"], "").ToString();
                txtNoACC.Text = Tools.isNull(dt.Rows[0]["NoACC"], "").ToString();
                txtKodeSales.Text = Tools.isNull(dt.Rows[0]["KodeSales"], "").ToString();
                txtExpedisi.Text = Tools.isNull(dt.Rows[0]["Expedisi"], "").ToString();
                txtQtyNota.Text = Tools.isNull(dt.Rows[0]["QtySuratJalan"], "").ToString();
                txtQtyReturSebelumnya.Text = Tools.isNull(dt.Rows[0]["QtyRetur"], "").ToString();
                txtQtyMemo.Text = Tools.isNull(dt.Rows[0]["QtyMemo"], "").ToString();
                txtQtyTarik.Text = Tools.isNull(dt.Rows[0]["QtyTarik"], "").ToString();
                if (Tools.isNull(dt.Rows[0]["QtyGudang"], "").ToString() != "" ||
                    Tools.isNull(dt.Rows[0]["QtyGudang"], "").ToString() != "0")
                {
                    txtQtyGudang.Text = Tools.isNull(dt.Rows[0]["QtyGudang"], "").ToString();
                }
                else
                {
                    txtQtyGudang.Text = Tools.isNull(dt.Rows[0]["QtyTarik"], "").ToString();
                }
                txtQtyTerima.Text = "0";
                txtDisc1.Text = Tools.isNull(dt.Rows[0]["Disc1"], "").ToString();
                txtDisc2.Text = Tools.isNull(dt.Rows[0]["Disc2"], "").ToString();
                txtDisc3.Text = Tools.isNull(dt.Rows[0]["Disc3"], "").ToString();
                txtKategori.Text = Tools.isNull(dt.Rows[0]["Kategori"], "").ToString();
                txtCatatan.Text = Tools.isNull(dt.Rows[0]["Catatan1"], "").ToString();

                if (_kodeRetur == "1")
                {                    
                    /* Versi retur jual */
                    txtHrgJualRetur.Text = Tools.isNull(dt.Rows[0]["HrgJual"], "").ToString();
                    txtJmlHrgRetur.Text = (txtQtyGudang.GetIntValue * double.Parse(txtHrgJualRetur.Text)).ToString();
                    txtJmlNetRetur.Text = Tools.isNull(dt.Rows[0]["HrgNetto"], "").ToString();
                    txtPotRetur.Text = Tools.isNull(dt.Rows[0]["Pot"], "").ToString();

                    txtHrgJualRetur.Enabled = false;
                    txtPotRetur.Enabled = false;

                    /* Versi nota jual */
                    txtHrgJualNota.Text = Tools.isNull(dt.Rows[0]["HrgJual"], "").ToString();
                    txtJmlHrgNota.Text = (txtQtyGudang.GetIntValue * double.Parse(txtHrgJualRetur.Text)).ToString();
                    txtJmlNetNota.Text = Tools.isNull(dt.Rows[0]["HrgNetto"], "").ToString();
                    txtPotNota.Text = Tools.isNull(dt.Rows[0]["Pot"], "").ToString();
                }
                else
                {
                    /* Versi retur jual */
                    txtHrgJualRetur.Text = Tools.isNull(dt.Rows[0]["HrgJual"], "").ToString();
                    txtJmlHrgRetur.Text = (txtQtyGudang.GetIntValue * double.Parse(txtHrgJualRetur.Text)).ToString();
                    txtJmlNetRetur.Text = Tools.isNull(dt.Rows[0]["HrgNetto"], "").ToString();
                    txtPotRetur.Text = Tools.isNull(dt.Rows[0]["Pot"], "").ToString();

                    /* Versi nota jual */
                    txtHrgJualNota.Text = "0";
                    txtJmlHrgNota.Text = "0";
                    txtPotNota.Text = "0";
                    txtJmlNetNota.Text = "0";
                }
                txtQtyGudang.Focus();
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

        private double HitungNet3Disc(double hrgBruto)
        {
            double hrgNet3Disc = 0;
            double _disc1, _disc2, _disc3;
            string _discFormula = "";

            _disc1 = double.Parse(txtDisc1.Text);
            _disc2 = double.Parse(txtDisc2.Text);
            _disc3 = double.Parse(txtDisc3.Text);
            _discFormula = Tools.isNull(dt.Rows[0]["DiscFormula"], "").ToString();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc")); //cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, hrgBruto));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return hrgNet3Disc;
        }

        private void txtQtyGudang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQtyGudang.Text == "" || txtQtyGudang.GetIntValue > txtQtyTarik.GetIntValue)
                {
                    txtQtyGudang.Text = txtQtyTarik.Text;
                }
                UpdateFieldHitungan();
            }
        }

        private void txtHrgJualRetur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtHrgJualRetur.Text == "")
                {
                    txtHrgJualRetur.Text = "0";
                }
                UpdateFieldHitungan();
            }
        }

        private void txtPotRetur_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtPotRetur.Text == "")
                {
                    txtPotRetur.Text = "0";
                }
                UpdateFieldHitungan();
            }
        }

        private void txtQtyGudang_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyGudang.GetIntValue > txtQtyTarik.GetIntValue || txtQtyGudang.Text == "")
            {
                txtQtyGudang.Text = txtQtyTarik.Text;
            }
            UpdateFieldHitungan();
        }

        private void txtHrgJualRetur_Validating(object sender, CancelEventArgs e)
        {
            if (txtHrgJualRetur.Text == "")
            {
                txtHrgJualRetur.Text = "0";
            }
            UpdateFieldHitungan();
        }

        private void txtPotRetur_Validating(object sender, CancelEventArgs e)
        {
            if (txtPotRetur.Text == "")
            {
                txtPotRetur.Text = "0";
            }
            UpdateFieldHitungan();
        }

        private void UpdateFieldHitungan()
        {
            txtJmlHrgRetur.Text = (double.Parse(txtHrgJualRetur.Text) * txtQtyGudang.GetIntValue).ToString();
            txtJmlNetRetur.Text = (HitungNet3Disc(double.Parse(txtJmlHrgRetur.Text))
                        - (txtQtyGudang.GetIntValue * double.Parse(txtPotRetur.Text))).ToString();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_kodeRetur == "1")
                {
                    // Update detail untuk retur Murni
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualanDetail_UPDATE")); //cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["HeaderID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, dt.Rows[0]["NotaJualDetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dt.Rows[0]["RecordID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, dt.Rows[0]["NotaJualDetailRecID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dt.Rows[0]["KodeRetur"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dt.Rows[0]["QtyMemo"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dt.Rows[0]["QtyTarik"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyGudang.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dt.Rows[0]["QtyTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dt.Rows[0]["Catatan1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dt.Rows[0]["Catatan2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dt.Rows[0]["Kategori"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        /**/
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dt.Rows[0]["HrgJual"]));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"]));
                        /**/
                        db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dt.Rows[0]["NoACC"]));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                else
                {
                    // Update detail untuk retur Tarikan
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_ReturPenjualanTarikanDetail_UPDATE")); //cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dt.Rows[0]["HeaderID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dt.Rows[0]["RecordID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dt.Rows[0]["ReturID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@notaAsal", SqlDbType.VarChar, dt.Rows[0]["NotaAsal"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeRetur", SqlDbType.VarChar, dt.Rows[0]["KodeRetur"]));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeSales", SqlDbType.VarChar, dt.Rows[0]["KodeSales"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyMemo", SqlDbType.Int, dt.Rows[0]["QtyMemo"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTarik", SqlDbType.Int, dt.Rows[0]["QtyTarik"]));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyGudang.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyTolak", SqlDbType.Int, dt.Rows[0]["QtyTolak"]));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(txtHrgJualRetur.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, double.Parse(txtPotRetur.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan1", SqlDbType.VarChar, dt.Rows[0]["Catatan1"]));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan2", SqlDbType.VarChar, dt.Rows[0]["Catatan2"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kategori", SqlDbType.VarChar, dt.Rows[0]["Kategori"]));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dt.Rows[0]["NoACC"]));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                    }
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

        private void frmNotaReturJualDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaReturJualBrowse)
                {
                    frmNotaReturJualBrowse frmCaller = (frmNotaReturJualBrowse)this.Caller;
                    frmCaller.RefreshDataReturJualDetail();
                    //frmCaller.RefreshRowDataReturJual(dt.Rows[0]["HeaderID"].ToString());
                    //frmCaller.RefreshRowDataReturJualDetail(_rowID.ToString());
                    frmCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }
    }
}
