using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Pembelian
{
    public partial class frmKoreksiReturBeliUpdate : ISA.Toko.BaseForm
    {
        Guid _returBeliDetailID, _rowID;
        DataTable dtReturBeliDetail;
        double _hrgBeli, _pot;
        int _qtyNota;

        public frmKoreksiReturBeliUpdate(Form caller, Guid returBeliDetailID)
        {
            InitializeComponent();
            _returBeliDetailID = returBeliDetailID;
            this.Caller = caller;
        }

        private void frmKoreksiReturBeliUpdate_Load(object sender, EventArgs e)
        {

            this.txtCatatan.Text = "BATAL";
            this.Title = "Input Koreksi Retur Pembelian";
            this.Text = "Retur Pembelian";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtReturBeliDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _returBeliDetailID));
                    dtReturBeliDetail = db.Commands[0].ExecuteDataTable();
                }

                // Display data nota

                txtTglKoreksi.DateValue = GlobalVar.DateOfServer;
                txtNoNota.Text = dtReturBeliDetail.Rows[0]["NoRetur"].ToString();
                txtTglNota.DateValue = (DateTime)dtReturBeliDetail.Rows[0]["TglRetur"];
                txtBarangID1.Text = dtReturBeliDetail.Rows[0]["BarangID"].ToString();
                txtNamaStok1.Text = dtReturBeliDetail.Rows[0]["NamaBarang"].ToString();
                txtQtyNota1.Text = dtReturBeliDetail.Rows[0]["QtyGudang"].ToString();
                txtSatuan1.Text = dtReturBeliDetail.Rows[0]["Satuan"].ToString();
                txtHrgBeli1.Text = dtReturBeliDetail.Rows[0]["HrgBeli"].ToString();
                txtPot1.Text = dtReturBeliDetail.Rows[0]["Pot"].ToString();
                txtDisc1_1.Text = dtReturBeliDetail.Rows[0]["Disc1"].ToString();
                txtDisc2_1.Text = dtReturBeliDetail.Rows[0]["Disc2"].ToString();
                txtDisc3_1.Text = dtReturBeliDetail.Rows[0]["Disc3"].ToString();

                _hrgBeli = double.Parse(txtHrgBeli1.Text);
                _pot = double.Parse(txtPot1.Text);
                _qtyNota = txtQtyNota1.GetIntValue;

                txtJmlHrg1.Text = GetJmlHrg().ToString();
                txtJmlPot1.Text = GetJmlPot().ToString();
                txtJmlDisc1.Text = GetJmlDisc().ToString();
                txtHrgNet1.Text = GetJmlHrgNet().ToString();


                // Display data yang seharusnya (setelah koreksi)

                _hrgBeli = double.Parse(txtHrgBeli2.Text);
                _pot = double.Parse(txtPot2.Text);
                _qtyNota = txtQtyNota2.GetIntValue;

                txtBarangID2.Text = txtBarangID1.Text;
                txtNamaStok2.Text = txtNamaStok1.Text;
                txtQtyNota2.Text = "0"; //txtQtyNota1.Text;
                txtSatuan2.Text = txtSatuan1.Text;
                txtHrgBeli2.Text = txtHrgBeli1.Text;
                txtPot2.Text = txtPot1.Text;
                txtDisc1_2.Text = txtDisc1_1.Text;
                txtDisc2_2.Text = txtDisc2_1.Text;
                txtDisc3_2.Text = txtDisc3_1.Text;

                txtJmlHrg2.Text = GetJmlHrg().ToString();
                txtJmlPot2.Text = GetJmlPot().ToString();
                txtJmlDisc2.Text = GetJmlDisc().ToString();
                txtHrgNet2.Text = GetJmlHrgNet().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private double GetJmlHrg()
        {
            return _hrgBeli * _qtyNota;
        }

        private double GetJmlPot()
        {
            return _pot * _qtyNota;
        }

        private double HitNet3D()
        {
            double hrgNet3Disc = 0;
            try
            {
                double disc1 = double.Parse(txtDisc1_1.Text);
                double disc2 = double.Parse(txtDisc2_1.Text);
                double disc3 = double.Parse(txtDisc3_1.Text);
                string discFormula = dtReturBeliDetail.Rows[0]["DiscFormula"].ToString();

                DataTable dtNet3Disc = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_GetNet3Disc"));
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, GetJmlHrg()));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                hrgNet3Disc = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return hrgNet3Disc;
        }

        private double GetJmlDisc()
        {
            return GetJmlHrg() - HitNet3D();
        }

        private double GetJmlHrgNet()
        {
            return HitNet3D() - GetJmlPot();
        }

        private void txtQtyNota2_Validating(object sender, CancelEventArgs e)
        {
            if (txtQtyNota2.Text == "")
            {
                txtQtyNota2.Text = txtQtyNota1.Text;
            }
            _qtyNota = txtQtyNota2.GetIntValue;

            txtJmlHrg2.Text = GetJmlHrg().ToString();
            txtJmlPot2.Text = GetJmlPot().ToString();
            txtJmlDisc2.Text = GetJmlDisc().ToString();
            txtHrgNet2.Text = GetJmlHrgNet().ToString();
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                GlobalVar.LastClosingDate = (DateTime)txtTglKoreksi.DateValue;
                if ((DateTime)txtTglKoreksi.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(string.Format(ISA.Toko.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }
                double hrgKoreksi = double.Parse(txtHrgNet2.Text) - double.Parse(txtHrgNet1.Text);
                int qtyKoreksi = txtQtyNota2.GetIntValue - txtQtyNota1.GetIntValue;
                this.Cursor = Cursors.WaitCursor;

            #region "Stok Minus Lock New"
                if (qtyKoreksi>0)
                {
                    using (Stock st = new Stock())
                    {
                        st.AddList(dtReturBeliDetail.Rows[0]["BarangID"].ToString(), "", qtyKoreksi);

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
                }
               
            #endregion

                _rowID = Guid.NewGuid();
                DataTable dtMessage = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiReturPembelian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@returBeliDetailID", SqlDbType.UniqueIdentifier, dtReturBeliDetail.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@returBeliDetailRecID", SqlDbType.VarChar, dtReturBeliDetail.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtReturBeliDetail.Rows[0]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKoreksi", SqlDbType.DateTime, txtTglKoreksi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaBaru", SqlDbType.Int, txtQtyNota2.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeliBaru", SqlDbType.Money, double.Parse(txtHrgBeli2.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, dtReturBeliDetail.Rows[0]["Pemasok"]));
                    db.Commands[0].Parameters.Add(new Parameter("@sumber", SqlDbType.VarChar, "NRB"));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeliKoreksi", SqlDbType.Money, hrgKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaKoreksi", SqlDbType.Int, qtyKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtMessage = db.Commands[0].ExecuteDataTable();

                    if (dtMessage.Rows.Count > 0)
                    {
                        if (dtMessage.Rows[0]["pesan"].ToString() == "Data Berhasil Insert")
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else { MessageBox.Show(dtMessage.Rows[0]["pesan"].ToString()); return; }
                        //if (dt.Rows[0]["pesan"].ToString() == "Data Sudah Ada")
                        //{
                        //    txtKode.Text = string.Empty;
                        //    txtKode.Focus();
                        //    return;
                        //}
                    }
                }
                //this.DialogResult = DialogResult.OK;
                //MessageBox.Show("Data telah disimpan");
                //this.Close();

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

            //if (txtNoKoreksi.Text == "")
            //{
            //    errorProvider1.SetError(txtNoKoreksi, "Nomor Koreksi tidak boleh kosong");
            //    valid = false;
            //}

            if (txtTglKoreksi.Text == "")
            {
                errorProvider1.SetError(txtTglKoreksi, "Tgl Koreksi tidak boleh kosong");
                valid = false;
            }

            if (txtQtyNota1.Text == txtQtyNota2.Text)
            {
                errorProvider1.SetError(txtQtyNota2, "Tidak ada koreksi");
                valid = false;
            }
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKoreksiReturBeliUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKoreksiReturBeliBrowser)
                {
                    frmKoreksiReturBeliBrowser formCaller = (frmKoreksiReturBeliBrowser)this.Caller;
                    formCaller.RefreshDataKoreksiBeli();
                    formCaller.FindHeader("RowID", _rowID.ToString());
                }
                
            }
        }

    }
}
