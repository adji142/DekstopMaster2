using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.RJ3
{
    public partial class frmKoreksiReturJualUpdate : ISA.Toko.BaseForm
    {
        Guid _rowID;
        DataTable _dtReturJualDetail, _dtReturJual;
        int _qtyNota;
        double _hrgJual, _pot;
        string _discFormula = "";

        public frmKoreksiReturJualUpdate(Form caller, DataTable dtRetJualDetail)
        {
            InitializeComponent();
            _dtReturJualDetail = dtRetJualDetail;
            this.Caller = caller;
        }

        private void frmKoreksiReturJualUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                Guid _headerID = (Guid)_dtReturJualDetail.Rows[0]["HeaderID"];
                this.Cursor = Cursors.WaitCursor;
                _dtReturJual = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));
                    _dtReturJual = db.Commands[0].ExecuteDataTable();
                }
                
                // Display Data Panel 1
                txtTglKoreksi.DateValue = DateTime.Now;
                txtKodeSales.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["KodeSales"], "").ToString();
                txtNamaToko.Text = Tools.isNull(_dtReturJual.Rows[0]["NamaToko"], "").ToString();
                txtAlamat.Text = Tools.isNull(_dtReturJual.Rows[0]["AlamatKirim"], "").ToString();
                txtNoNota.Text = Tools.isNull(_dtReturJual.Rows[0]["NoNotaRetur"], "").ToString();
                txtTglNota.DateValue = (DateTime)_dtReturJual.Rows[0]["TglNotaRetur"];

                _qtyNota = int.Parse(Tools.isNull(_dtReturJualDetail.Rows[0]["QtyGudang"], "0").ToString());
                _hrgJual = double.Parse(Tools.isNull(_dtReturJualDetail.Rows[0]["HrgJual"], "0").ToString());
                _pot = double.Parse(Tools.isNull(_dtReturJualDetail.Rows[0]["Pot"], "0").ToString());
                _discFormula = Tools.isNull(_dtReturJualDetail.Rows[0]["DiscFormula"], "").ToString();
                
                // Display Data Panel 2
                txtNamaBarang1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["NamaStok"], "").ToString();
                txtQtyNota1.Text = _qtyNota.ToString();
                txtSatuan1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["Satuan"], "").ToString();

                txtHrgSatuan1.Text = _hrgJual.ToString();
                txtPot1.Text = _pot.ToString();
                txtDisc1_1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["Disc1"], "").ToString();
                txtDisc2_1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["Disc2"], "").ToString();
                txtDisc3_1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["Disc3"], "").ToString();
                txtCatatan1.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["Catatan1"], "").ToString();
                txtJmlHrg1.Text = GetJmlHrg(_qtyNota).ToString();
                txtJmlPot1.Text = GetJmlPot(_qtyNota).ToString();
                txtJmlDisc1.Text = GetJmlDisc(double.Parse(txtJmlHrg1.Text)).ToString();
                txtHrgNetto1.Text = GetHrgNetto(double.Parse(txtJmlHrg1.Text), double.Parse(txtJmlDisc1.Text), double.Parse(txtJmlPot1.Text)).ToString();

                // Display data panel3
                txtNamaBarang2.Text = txtNamaBarang1.Text;
                txtKodeBarang.Text = Tools.isNull(_dtReturJualDetail.Rows[0]["BarangID"], "").ToString();
                txtQtyNota2.Text = txtQtyNota1.Text;
                txtSatuan2.Text = txtSatuan1.Text;
                txtHrgSatuan2.Text = txtHrgSatuan1.Text;
                txtPot2.Text = _pot.ToString();
                txtDisc1_2.Text = txtDisc1_1.Text;
                txtDisc2_2.Text = txtDisc2_1.Text;
                txtDisc3_2.Text = txtDisc3_1.Text;
                txtHrgNetto2.Text = txtHrgNetto1.Text;
                txtCatatan2.Text = txtCatatan1.Text;
                txtJmlHrg2.Text = txtJmlHrg1.Text;
                txtJmlPot2.Text = txtJmlPot1.Text;
                txtJmlDisc2.Text = txtJmlDisc1.Text;

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

        private double GetJmlHrg(int qtyNota)
        {
            return (qtyNota * _hrgJual);
        }

        private double GetJmlPot(int qtyNota)
        {
            return (qtyNota * _pot);
        }

        private double GetJmlDisc(double hrgBruto)
        {
            double _hrgNet3Disc = 0;
            try
            {
                double _disc1 = double.Parse(txtDisc1_1.Text);
                double _disc2 = double.Parse(txtDisc2_1.Text);
                double _disc3 = double.Parse(txtDisc3_1.Text);

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, hrgBruto));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, _discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                _hrgNet3Disc = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return (hrgBruto - _hrgNet3Disc);
        }

        private double GetHrgNetto(double hrgBruto, double jmlDisc, double jmlPot)
        {
            return (hrgBruto - jmlDisc - jmlPot);
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (txtNoKoreksi.Text == "")
            {
                MessageBox.Show("No Koreksi tidah boleh kosong");
                return;
            }

            if (txtQtyNota2.GetIntValue - txtQtyNota1.GetIntValue==0)
            {
                ErrorProvider ep = new ErrorProvider();
                ep.SetError(txtQtyNota2, "Tidak bisa diisi dengan nilai sama dengan Qty Nota sebelumnya!");
                return;
            }
            try
            {
                GlobalVar.LastClosingDate = (DateTime)txtTglKoreksi.DateValue;
                if (txtTglKoreksi.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                double hrgKoreksi = double.Parse(txtHrgNetto2.Text) - double.Parse(txtHrgNetto1.Text);
                int qtyKoreksi = txtQtyNota2.GetIntValue - txtQtyNota1.GetIntValue;
                if (qtyKoreksi<0)
                {
#region "Stok Minus Lock New"

                    using (Stock st = new Stock())
                    {

                        st.AddList(_dtReturJualDetail.Rows[0]["BarangID"].ToString(), "", Math.Abs(qtyKoreksi));


                        // pass = st.Pass();
                        if (!st.Pass())
                        {
                            MessageBox.Show("Tidak Bisa Proses,\n nilai transaksi menyebabkan stok minus! ", "Warning");


                            st.ReportMinus();
                            if (MessageBox.Show("Cetak Form Opname?", "Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                st.PrintOutMinus();
                            }

                            this.Close();
                            return;


                        }
                    }
  
#endregion
                }
                this.Cursor = Cursors.WaitCursor;
                _rowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiReturPenjualan_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@returJualDetailID", SqlDbType.UniqueIdentifier, _dtReturJualDetail.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@returJualDetailRecID", SqlDbType.VarChar, _dtReturJualDetail.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKoreksi", SqlDbType.DateTime, txtTglKoreksi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _dtReturJualDetail.Rows[0]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noKoreksi", SqlDbType.VarChar, txtNoKoreksi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaBaru", SqlDbType.Int, txtQtyNota2.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJualBaru", SqlDbType.Money, double.Parse(txtHrgSatuan2.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan2.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _dtReturJual.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@sumber", SqlDbType.VarChar, "NRJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJualKoreksi", SqlDbType.Money, hrgKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaKoreksi", SqlDbType.Int, qtyKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
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

        private void txtNoKoreksi_Validating(object sender, CancelEventArgs e)
        {
            if (txtNoKoreksi.Text == "")
            {
                txtNoKoreksi.Focus();
            }
        }

        private void txtQtyNota2_Validating(object sender, CancelEventArgs e)
        {
            _qtyNota = txtQtyNota2.GetIntValue;
            txtJmlHrg2.Text = GetJmlHrg(_qtyNota).ToString();
            txtJmlPot2.Text = GetJmlPot(_qtyNota).ToString();
            txtJmlDisc2.Text = GetJmlDisc(double.Parse(txtJmlHrg2.Text)).ToString();
            txtHrgNetto2.Text = GetHrgNetto(double.Parse(txtJmlHrg2.Text), double.Parse(txtJmlDisc2.Text), double.Parse(txtJmlPot2.Text)).ToString();
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmKoreksiReturJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKoreksiReturJualBrowser)
                {
                    frmKoreksiReturJualBrowser frmCaller = (frmKoreksiReturJualBrowser)this.Caller;
                    frmCaller.RefreshDataKoreksiReturJual();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }


    }
}
