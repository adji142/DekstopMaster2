using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.Master;
using System.Data.SqlTypes;

namespace ISA.Trading.Penjualan
{
    public partial class frmNotaJualDetailUpdate : ISA.Trading.BaseForm
    {
        Guid _RowID, _DoRowID, _NotaRowID;
        DataTable dt = new DataTable();


        public frmNotaJualDetailUpdate()
        {
            InitializeComponent();
        }

        public frmNotaJualDetailUpdate(Form caller,Guid _rowID)
        {
            this.Caller = caller;
            _RowID = _rowID;
            InitializeComponent();
        }

        public frmNotaJualDetailUpdate(Form caller, Guid _rowID, Guid _doRowID, Guid _notaRowID)
        {
            this.Caller = caller;
            _RowID = _rowID;
            _DoRowID = _doRowID;
            _NotaRowID = _notaRowID;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmNotaJualDetailUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_LIST")); //udah cek heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count==0)
                {
                    return;
                }

                lookupStock1.NamaStock = dt.Rows[0]["NamaBarang"].ToString();
                lookupStock1.BarangID = dt.Rows[0]["BarangID"].ToString();
                numericTextBox1.Text = dt.Rows[0]["QtyDO"].ToString();
                numericTextBox2.Text = dt.Rows[0]["QtySuratJalan"].ToString();
                txtHrgJual.Text = dt.Rows[0]["HrgJual"].ToString();
                txtDisc1.Text = dt.Rows[0]["Disc1"].ToString();
                txtDisc2.Text = dt.Rows[0]["Disc2"].ToString();
                txtDisc3.Text = dt.Rows[0]["Disc3"].ToString();
                txtPot.Text = dt.Rows[0]["Pot"].ToString();
                txtJumlah.Text = dt.Rows[0]["HrgNet2"].ToString();

                if (GlobalVar.Gudang == "2803")
                {
                    lookupStock1.Enabled = false;
                    lookupStock1.TabStop = false;
                    numericTextBox2.ReadOnly = true;
                    numericTextBox2.TabStop = false;
                    txtJumlah.ReadOnly = true;
                    txtJumlah.TabStop = false;
                    txtHrgJual.Focus();
                }
                else
                {
                    lookupStock1.Enabled = false;
                    lookupStock1.TabStop = false;
                    numericTextBox2.ReadOnly = true;
                    numericTextBox2.TabStop = false;
                    txtJumlah.ReadOnly = true;
                    txtJumlah.TabStop = false;
                    txtHrgJual.ReadOnly = true;
                    txtHrgJual.TabStop = false;
                    txtDisc1.ReadOnly = true;
                    txtDisc1.TabStop = false;
                    txtDisc2.ReadOnly = true;
                    txtDisc2.TabStop = false;
                    txtDisc3.ReadOnly = true;
                    txtDisc3.TabStop = false;
                    txtHrgJual.Focus();

                    //lookupStock1.NamaStock = dt.Rows[0]["NamaBarang"].ToString();
                    //lookupStock1.BarangID = dt.Rows[0]["BarangID"].ToString();
                    //numericTextBox1.Text = dt.Rows[0]["QtyDO"].ToString();
                    //numericTextBox2.Text = dt.Rows[0]["QtySuratJalan"].ToString();
                    //numericTextBox2.Focus();
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

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (numericTextBox2.GetIntValue == 0)
            {
                this.Close();
            }
            else
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database())
                    {
                        db.Commands.Add(db.CreateCommand("usp_NotaPenjualanDetail_UPDATE")); // cek heri
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["HeaderID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@doID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["DoID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@doDetailID", SqlDbType.UniqueIdentifier, (Guid)dt.Rows[0]["DODetailID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dt.Rows[0]["htrID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@RecID", SqlDbType.VarChar, dt.Rows[0]["RecordID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dt.Rows[0]["BarangID"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, double.Parse(txtHrgJual.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, double.Parse(txtDisc1.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, double.Parse(txtDisc2.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, double.Parse(txtDisc3.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, double.Parse(txtPot.Text)));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dt.Rows[0]["discFormula"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, dt.Rows[0]["KodeGudang"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@qtySJ", SqlDbType.Int, numericTextBox2.GetIntValue));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, int.Parse(dt.Rows[0]["qtyNota"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyKoli", SqlDbType.Int, int.Parse(dt.Rows[0]["qtyKoli"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAwal", SqlDbType.Int, int.Parse(dt.Rows[0]["koliAwal"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@koliAkhir", SqlDbType.Int, int.Parse(dt.Rows[0]["koliAkhir"].ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@noKoli", SqlDbType.VarChar, dt.Rows[0]["noKoli"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dt.Rows[0]["catatan"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@ketKoli", SqlDbType.VarChar, dt.Rows[0]["ketKoli"].ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserName));
                        db.Commands[0].ExecuteNonQuery();
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                RefreshNotaDetail();
                this.Close();
            }
        }

        private void numericTextBox2_Validated(object sender, EventArgs e)
        {
            if (numericTextBox2.Text.Trim()=="")
            {
                numericTextBox2.Text = "0";
            }
        }

        private void RefreshNotaDetail()
        {
            frmNotaJualBrowser frmCaller = (frmNotaJualBrowser)this.Caller;
            frmCaller.RefreshDataDO();
            frmCaller.RefreshDataNotaJual();
            frmCaller.RefreshDataNotaJualDetail();

            frmCaller.FindHeaderDO("DORowID", _DoRowID.ToString());
            frmCaller.FindHeader("NotaRowID", _NotaRowID.ToString());
            frmCaller.FindDetail("NotaDetailRowID", _RowID.ToString());
        }

        private void txtHrgJual_Validating(object sender, CancelEventArgs e)
        {
            double JmlBrutto = 0, JmlDisc = 0, JmlPot = 0;
            JmlBrutto = HitungJmlHrg();
            JmlDisc = HitungJmlDisc();
            JmlPot = HitungTotalPot();
            txtJumlah.Text = (JmlBrutto - JmlDisc - JmlPot).ToString();
        }

        private double HitungJmlHrg()
        {
            double _hrgJual = 0;
            double _qtyDO = 0;
            if (txtHrgJual.Text != "")
                _hrgJual = txtHrgJual.GetDoubleValue;
            if (numericTextBox2.Text != "")
                _qtyDO = numericTextBox2.GetDoubleValue;
            return (_qtyDO * _hrgJual);
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
                if (numericTextBox2.Text != "" && txtHrgJual.Text != "")
                    _jmlHrg = double.Parse(numericTextBox2.Text) * double.Parse(txtHrgJual.Text);
                if (txtDisc1.Text != "")
                    _disc1 = double.Parse(txtDisc1.Text);
                if (txtDisc2.Text != "")
                    _disc2 = double.Parse(txtDisc2.Text);
                if (txtDisc3.Text != "")
                    _disc3 = double.Parse(txtDisc3.Text);

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
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

            return ((double.Parse(numericTextBox2.Text) * double.Parse(txtHrgJual.Text)) - hrgNet3Disc);
        }

        private double HitungTotalPot()
        {
            int _qtyDO = 0;
            double _pot = 0;

            if (numericTextBox2.Text != "")
                _qtyDO = numericTextBox2.GetIntValue;
            if (txtPot.Text != "")
                _pot = double.Parse(txtPot.Text);
            return (_qtyDO * _pot);
        }

        private void txtDisc1_Validating(object sender, CancelEventArgs e)
        {
            double JmlBrutto = 0, JmlDisc = 0, JmlPot = 0;
            JmlBrutto = HitungJmlHrg();
            JmlDisc = HitungJmlDisc();
            JmlPot = HitungTotalPot();
            txtJumlah.Text = (JmlBrutto - JmlDisc - JmlPot).ToString();
        }

        private void txtDisc2_Validating(object sender, CancelEventArgs e)
        {
            double JmlBrutto = 0, JmlDisc = 0, JmlPot = 0;
            JmlBrutto = HitungJmlHrg();
            JmlDisc = HitungJmlDisc();
            JmlPot = HitungTotalPot();
            txtJumlah.Text = (JmlBrutto - JmlDisc - JmlPot).ToString();
        }

        private void txtDisc3_Validating(object sender, CancelEventArgs e)
        {
            double JmlBrutto = 0, JmlDisc = 0, JmlPot = 0;
            JmlBrutto = HitungJmlHrg();
            JmlDisc = HitungJmlDisc();
            JmlPot = HitungTotalPot();
            txtJumlah.Text = (JmlBrutto - JmlDisc - JmlPot).ToString();
        }

        private void txtPot_Validating(object sender, CancelEventArgs e)
        {
            double JmlBrutto = 0, JmlDisc = 0, JmlPot = 0;
            JmlBrutto = HitungJmlHrg();
            JmlDisc = HitungJmlDisc();
            JmlPot = HitungTotalPot();
            txtJumlah.Text = (JmlBrutto - JmlDisc - JmlPot).ToString();
        }
    }
}
