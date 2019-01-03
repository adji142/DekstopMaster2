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
using System.Data.SqlTypes;


namespace ISA.Bengkel.Transaksi
{
    public partial class frmServiceDetailPosUpdate : ISA.Bengkel.BaseForm
    {
        FormTools.enumFormMode _formMode;
        Guid _rowID;
        Guid _HeaderID;
        string _Caller;
        string _HtrID;

        public frmServiceDetailPosUpdate()
        {
            InitializeComponent();
        }

        public frmServiceDetailPosUpdate(Form caller, Guid rowID, Guid HeaderID_,string HtrID, FormTools.enumFormMode formMode)
        {
            InitializeComponent();
            _rowID = rowID;
            _HeaderID = HeaderID_;
            _formMode = formMode;
            _Caller = caller.ToString();
            this.Caller = caller;
        }

        private void frmServiceDetailPosUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtServicePart = new DataTable();
                    if (_formMode == FormTools.enumFormMode.Update)
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_DetailSparepart_LIST"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        dtServicePart = db.Commands[0].ExecuteDataTable();

                        txtNamaStok.Text = Tools.isNull(dtServicePart.Rows[0]["NamaStok"],"").ToString();
                        txtBarangID.Text = Tools.isNull(dtServicePart.Rows[0]["BarangID"], "").ToString();
                        txtQtyRQ.Text = Tools.isNull(dtServicePart.Rows[0]["QtySuratJalan"], "0").ToString();
                        txtQtyDO.Text = Tools.isNull(dtServicePart.Rows[0]["QtySuratJalan"], "0").ToString();
                        txtSelisih.Text = ((txtQtyRQ.GetIntValue) - (txtQtyDO.GetIntValue)).ToString();
                        txtSatuan.Text = Tools.isNull(dtServicePart.Rows[0]["SatJual"], "").ToString();
                        txtHrgJual.Text = Tools.isNull(dtServicePart.Rows[0]["HrgJual"], "").ToString();
                        txtJmlHrg.Text = HitungJmlHrg().ToString();

                        txtDisc1.Text = Tools.isNull(dtServicePart.Rows[0]["disc1"], "").ToString();
                        txtDisc2.Text = Tools.isNull(dtServicePart.Rows[0]["disc2"], "").ToString();
                        txtDisc3.Text = Tools.isNull(dtServicePart.Rows[0]["disc3"], "").ToString();
                        txtDisc.Text = HitungJmlDisc().ToString();

                        txtPotongan.Text = Tools.isNull(dtServicePart.Rows[0]["Pot"], "").ToString();
                        txtTotalPotongan.Text = HitungTotalPot().ToString();
                        txtNetto.Text = HitungHrgNetto().ToString();

                        txtNoACC.Text = Tools.isNull(dtServicePart.Rows[0]["NoACC"], "").ToString();
                        txtCatatan.Text = Tools.isNull(dtServicePart.Rows[0]["Catatan"], "").ToString();


                        //txtSatjual.Text = Tools.isNull(dtServicePart.Rows[0]["SatJual"], "").ToString();
                        //txtQty.Text = Tools.isNull(dtServicePart.Rows[0]["QtySuratJalan"], "0").ToString();
                        //txtHarga.Text = Tools.isNull(dtServicePart.Rows[0]["HrgJual"], "0").ToString();
                        //txtdisc1.Text = Tools.isNull(dtServicePart.Rows[0]["disc1"], "0").ToString();
                        //txtdisc2.Text = Tools.isNull(dtServicePart.Rows[0]["disc2"], "0").ToString();
                        //txtdisc3.Text = Tools.isNull(dtServicePart.Rows[0]["disc3"], "0").ToString();
                        //txtPot.Text = Tools.isNull(dtServicePart.Rows[0]["Pot"], "0").ToString();
                        //txtRpnet.Text = Tools.isNull(dtServicePart.Rows[0]["RpNetto"], "0").ToString();
                    }
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


        private double HitungHrgNetto()
        {
            return (HitungJmlHrg() - HitungJmlDisc() - HitungTotalPot());
        }


        private double HitungTotalPot()
        {
            int _qtyDO = 0;
            double _pot = 0;

            if (txtQtyDO.Text != "")
                _qtyDO = txtQtyDO.GetIntValue;
            if (txtPotongan.Text != "")
                _pot = double.Parse(txtPotongan.Text);
            return (_qtyDO * _pot);
        }


        private double HitungJmlDisc()
        {
            double hrgNet3Disc = 0;
            try
            {
                double _jmlHrg = 0;
                double _disc1 = 0;
                double _disc2 = 0;
                double _disc3 = 0;
                if (txtJmlHrg.Text != "")
                    _jmlHrg = double.Parse(txtJmlHrg.Text);
                if (txtDisc1.Text != "")
                    _disc1 = double.Parse(txtDisc1.Text);
                if (txtDisc2.Text != "")
                    _disc2 = double.Parse(txtDisc2.Text);
                if (txtDisc3.Text != "")
                    _disc3 = double.Parse(txtDisc3.Text);

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc")); // 27042013
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, _jmlHrg));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = Math.Round(double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString()), 0);
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return (double.Parse(txtJmlHrg.Text) - hrgNet3Disc);
        }


        private double HitungJmlHrg()
        {
            double _hrgJual = 0;
            double _qtyDO = 0;
            txtQtyDO.Text = txtQtyRQ.Text;
            if (txtHrgJual.Text != "")
                _hrgJual = txtHrgJual.GetDoubleValue;
            if (txtQtyDO.Text != "")
                _qtyDO = txtQtyDO.GetDoubleValue;
            return (_qtyDO * _hrgJual);
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQtyDO_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtQtyDO.Text == "") txtQtyDO.Text = "0";
            txtQtyRQ.Text = txtQtyDO.Text;
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyRQ.Text, "0").ToString());
            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //SetNoACCDO();
        }

        private void txtHrgJual_Validating(object sender, CancelEventArgs e)
        {
            if (txtHrgJual.GetDoubleValue < 0)
            {
                e.Cancel = true;
                MessageBox.Show("Harga tidak boleh kurang dari 0");
                return;
            }

            if (txtHrgJual.Text == "")
                txtHrgJual.Text = "0";

            if (txtDisc1.Text == "")
                txtDisc1.Text = "0";

            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = HitungJmlDisc().ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
        }

        private void txtDisc1_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc1.Text == "")
                txtDisc1.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //SetNoACCDO();
        }

        private void txtDisc2_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc2.Text == "")
                txtDisc2.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //SetNoACCDO();
        }

        private void txtDisc3_Validating(object sender, CancelEventArgs e)
        {
            if (txtDisc3.Text == "")
                txtDisc3.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //SetNoACCDO();
        }

        private void txtPotongan_Validating(object sender, CancelEventArgs e)
        {
            if (txtPotongan.Text == "")
                txtPotongan.Text = "0";
            double JmlDisc = Math.Round(HitungJmlDisc(), 0) * Convert.ToDouble(Tools.isNull(txtQtyDO.Text, "0").ToString());
            txtJmlHrg.Text = HitungJmlHrg().ToString();
            txtDisc.Text = JmlDisc.ToString();
            txtTotalPotongan.Text = HitungTotalPot().ToString();
            txtNetto.Text = HitungHrgNetto().ToString();
            //SetNoACCDO();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (_formMode == FormTools.enumFormMode.Update)
                {
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_bkl_DetailSparepart_UPDATE"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@QtySJ", SqlDbType.Int, int.Parse(Tools.isNull(txtQtyDO.Text,"0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@HrgJual", SqlDbType.VarChar, double.Parse(Tools.isNull(txtHrgJual.Text,"0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, decimal.Parse(Tools.isNull(txtDisc1.Text,"0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, decimal.Parse(Tools.isNull(txtDisc2.Text, "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, decimal.Parse(Tools.isNull(txtDisc3.Text, "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Decimal, decimal.Parse(Tools.isNull(txtPotongan.Text, "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, txtCatatan.Text));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].ExecuteNonQuery();

                    }
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Data telah disimpan");
                    this.Close();
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
            int _qtyRQ = txtQtyRQ.GetIntValue;
            double _hrgJual = double.Parse(txtHrgJual.Text);

            if (txtNamaStok.Text.Trim() == "")
            {
                MessageBox.Show(txtHrgJual, "Barang tidak boleh kosong.");
                txtNamaStok.Focus();
                valid = false;
            }
            if (_qtyRQ <= 0)
            {
                MessageBox.Show(txtQtyDO, "Quantity Request tidak boleh <= 0");
                txtQtyDO.Focus();
                valid = false;
            }
            if (_hrgJual <= 0 && txtNoACC.Text.Trim() != "BONUSAN")
            {
                MessageBox.Show(txtHrgJual, "Harga Jual tidak boleh <= 0");
                txtHrgJual.Focus();
                valid = false;
            }
            return valid;
        }

        private void frmServiceDetailPosUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmServiceBrowser)
                {
                    frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
                    formCaller.RefreshDataService();
                    formCaller.FindRowBkl("RowID", _HeaderID.ToString());

                    //formCaller.FindRowNotaJualDetail("DetailRowID", _rowID.ToString());
                    //formCaller.FindRow(FormTools.detailIndex.detail1, "RowID", _rowID.ToString()); 

                    //frmServiceBrowser formCaller = (frmServiceBrowser)this.Caller;
                    //formCaller.RefreshDataService();
                    ////formCaller.RefreshDataNotaPOS();
                    //formCaller.FindRow(FormTools.detailIndex.detail2, "RowIDPart", _rowID.ToString()); 
                }
            }
        }
    }
}
