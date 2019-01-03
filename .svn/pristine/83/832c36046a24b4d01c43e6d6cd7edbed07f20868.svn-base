using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko.Class;

namespace ISA.Toko.Pembelian
{
    public partial class frmKoreksiBeliUpdate : ISA.Toko.BaseForm
    {
        public enum enumFormMode { New, Update,};
        enumFormMode formMode;
        DataTable dtNotaBeliDetail;
        Guid _notaBeliDetailID, _rowID;
        Guid _KoreksiID = Guid.Empty;
        double _hrgBeli, _pot;
        int _qtyNota;
        DateTime TglTerima;

        public frmKoreksiBeliUpdate(Form caller, Guid notaBeliDetailID)
        {
            InitializeComponent();
            _notaBeliDetailID = notaBeliDetailID;
            formMode = enumFormMode.New;
            this.Caller = caller;
        }


        public frmKoreksiBeliUpdate(Form caller, Guid notaBeliDetailID, Guid KoreksiID)
        {
            InitializeComponent();
            _notaBeliDetailID = notaBeliDetailID;
            formMode = enumFormMode.Update;
            _KoreksiID = KoreksiID;
            this.Caller = caller;
        }

        private void LoadDataNota()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNotaBeliDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _notaBeliDetailID));
                    dtNotaBeliDetail = db.Commands[0].ExecuteDataTable();
                }

                // Display data nota

                txtTglKoreksi.DateValue = DateTime.Now;
                txtNoNota.Text = dtNotaBeliDetail.Rows[0]["NoNota"].ToString();
                txtTglNota.DateValue = (DateTime)dtNotaBeliDetail.Rows[0]["TglNota"];
                txtBarangID1.Text = dtNotaBeliDetail.Rows[0]["BarangID"].ToString();
                txtNamaStok1.Text = dtNotaBeliDetail.Rows[0]["NamaBarang"].ToString();
                txtQtyNota1.Text = dtNotaBeliDetail.Rows[0]["QtySuratJalan"].ToString();
                txtSatuan1.Text = dtNotaBeliDetail.Rows[0]["Satuan"].ToString();
                txtHrgBeli1.Text = dtNotaBeliDetail.Rows[0]["HrgBeli"].ToString();
                txtHrgBeli2.Text = txtHrgBeli1.Text;
                txtPot1.Text = dtNotaBeliDetail.Rows[0]["Pot"].ToString();
                txtDisc1_1.Text = dtNotaBeliDetail.Rows[0]["Disc1"].ToString();
                txtDisc2_1.Text = dtNotaBeliDetail.Rows[0]["Disc2"].ToString();
                txtDisc3_1.Text = dtNotaBeliDetail.Rows[0]["Disc3"].ToString();
                _hrgBeli = double.Parse(txtHrgBeli1.Text);
                _pot = double.Parse(txtPot1.Text);
                _qtyNota = txtQtyNota1.GetIntValue;

                txtJmlHrg1.Text = GetJmlHrg().ToString();
                txtJmlPot1.Text = GetJmlPot().ToString();
                txtJmlDisc1.Text = GetJmlDisc().ToString();
                txtHrgNet1.Text = GetJmlHrgNet().ToString();


                // Display data yang seharusnya (setelah koreksi)

                txtBarangID2.Text = txtBarangID1.Text;
                txtNamaStok2.Text = txtNamaStok1.Text;
                txtQtyNota2.Text = "0";//txtQtyNota1.Text;
                txtSatuan2.Text = txtSatuan1.Text;
                txtHrgBeli2.Text = txtHrgBeli1.Text;
                txtPot2.Text = "0"; //txtPot1.Text;
                txtDisc1_2.Text = txtDisc1_1.Text;
                txtDisc2_2.Text = txtDisc2_1.Text;
                txtDisc3_2.Text = txtDisc3_1.Text;

                txtHrgNet2.Text = "0";//txtHrgNet1.Text;
                txtJmlHrg2.Text = "0"; //txtJmlHrg1.Text;
                txtJmlPot2.Text = "0"; //txtJmlPot1.Text;
                txtJmlDisc2.Text = "0"; //txtJmlDisc1.Text;
                txtCatatan.Text = "BATAL";
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

        private void InsertKoreksi()
        {
            try
            {
                double hrgKoreksi = double.Parse(txtHrgNet2.Text) - double.Parse(txtHrgNet1.Text);
                int qtyKoreksi = txtQtyNota2.GetIntValue - txtQtyNota1.GetIntValue;
#region "Stok Minus Lock New"
                if (qtyKoreksi < 0)
                {
                    using (Stock st = new Stock())
                    {
                        st.AddList(dtNotaBeliDetail.Rows[0]["BarangID"].ToString(), "", Math.Abs(qtyKoreksi));

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

                this.Cursor = Cursors.WaitCursor;
                _rowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    DataTable dtMessage = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_KoreksiPembelian_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailID", SqlDbType.UniqueIdentifier, dtNotaBeliDetail.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailRecID", SqlDbType.VarChar, dtNotaBeliDetail.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtNotaBeliDetail.Rows[0]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKoreksi", SqlDbType.DateTime, txtTglKoreksi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@noKoreksi", SqlDbType.VarChar, txtNoKoreksi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaBaru", SqlDbType.Int, txtQtyNota2.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeliBaru", SqlDbType.Money, double.Parse(txtHrgBeli2.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, dtNotaBeliDetail.Rows[0]["Pemasok"]));
                    db.Commands[0].Parameters.Add(new Parameter("@sumber", SqlDbType.VarChar, "NPB"));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgBeliKoreksi", SqlDbType.Money, hrgKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaKoreksi", SqlDbType.Int, qtyKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    dtMessage = db.Commands[0].ExecuteDataTable();

                    db.Close();
                    db.Dispose();

                    if (dtMessage.Rows.Count > 0)
                    {
                        if (dtMessage.Rows[0]["pesan"].ToString() == "Insert Berhasil")
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
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Data telah disimpan");
                

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

        private void UpdateKoreksi()
        {
            if (txtTglKoreksi.DateValue<TglTerima)
            {
                MessageBox.Show("TglKoreksi Lebih Kecil Dari TglTerima","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.No;
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_KoreksiPembelian_UPDATE]"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _KoreksiID));
                    db.Commands[0].Parameters.Add(new Parameter("@TglKoreksi", SqlDbType.DateTime, txtTglKoreksi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyNotaBaru", SqlDbType.Int, txtQtyNota2.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@QtyNotaKoreksi", SqlDbType.Int, txtQtyNota2.GetIntValue-txtQtyNota1.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@HrgKoreksi", SqlDbType.Money, (txtQtyNota2.GetDoubleValue * txtHrgBeli2.GetDoubleValue) - (txtQtyNota1.GetDoubleValue * txtHrgBeli1.GetDoubleValue)));
                    db.Commands[0].ExecuteNonQuery();
                }
                _rowID = _KoreksiID;
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Data telah disimpan");
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.Close();
        }

        private void LoadDataKoreksi()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtk = new DataTable();
                dtk = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_KoreksiPembelian_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _KoreksiID));
                    dtk = db.Commands[0].ExecuteDataTable();
                }
                txtHrgBeli2.Text = Convert.ToDouble(dtk.Rows[0]["HrgBeliBaru"]).ToString("#,##0");
                txtNoKoreksi.Text = dtk.Rows[0]["NoKoreksi"].ToString();
                txtNoKoreksi.ReadOnly = true;
                txtQtyNota2.Text = Convert.ToDouble(dtk.Rows[0]["QtyNotaBaru"]).ToString("#,##0");
                txtQtyNota2.ReadOnly = false;
                txtCatatan.Text = dtk.Rows[0]["Catatan"].ToString();

                txtCatatan.ReadOnly = false;
                txtHrgNet2.ReadOnly = true;

                txtJmlHrg2.Text = (txtQtyNota2.GetDoubleValue * txtHrgNet2.GetDoubleValue).ToString("#,##0");

                if (dtk.Rows[0]["TglKoreksi"].ToString()!="")
                {
                    txtTglKoreksi.DateValue = Convert.ToDateTime(dtk.Rows[0]["TglKoreksi"]);
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
        }

        private void frmKoreksiBeliUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "Input Koreksi Pembelian";
            this.Text = "Pembelian";
            LoadDataNota();

            if (formMode==enumFormMode.Update)
            {

                LoadDataKoreksi();


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
                string discFormula = dtNotaBeliDetail.Rows[0]["DiscFormula"].ToString();

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
            if (formMode!=enumFormMode.Update)
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
           
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

           switch (formMode)
           {
           case enumFormMode.New:
                   InsertKoreksi();
           	break;
           case enumFormMode.Update:
            UpdateKoreksi();
            break;
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
            }else
            {
                if (PeriodeClosing.IsPJTClosed(txtTglKoreksi.DateValue.Value))
                {
                    errorProvider1.SetError(txtTglKoreksi, "Sudah Closing");
                    valid = false;
                }
            }

            if (txtQtyNota1.Text == txtQtyNota2.Text && formMode!=enumFormMode.Update)
            {
                errorProvider1.SetError(txtQtyNota2, "Tidak ada koreksi");
                valid = false;
            }
            if (txtTglKoreksi.DateValue != GlobalVar.DateOfServer)
            {
                errorProvider1.SetError(txtQtyNota2, "Tanggal Koreksi Tidak Sama Dengan Date of server");
                valid = false;
            }
            return valid;
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmKoreksiBeliUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                frmKoreksiBeliBrowser formCaller = (frmKoreksiBeliBrowser)this.Caller;
                formCaller.RefreshDataKoreksiBeli();
                formCaller.FindHeader("RowID", _rowID.ToString());
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtPot1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtHrgBeli1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
