using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;


namespace ISA.Toko.PJ3
{
    public partial class frmKoreksiJualUpdate : ISA.Toko.BaseForm
    {
        DataTable _dtNotaDetail, _dtNotaHeader;
        int _qtyNota, _qtyRetur;
        double _hrgJual, _pot,  _nDnett;
        Guid _rowID;
        string docNoKoreksi = "KOREKSI PENJUALAN";
        int lebar;
        int iNomor;
        string depan;
        string belakang;
        string strNoKoreksi;
         
        public frmKoreksiJualUpdate(Form caller, DataTable dtNotaJualDetail)
        {
            InitializeComponent();
            _dtNotaDetail = dtNotaJualDetail;
            this.Caller = caller;
        }

        private void frmKoreksiJualUpdate_Load(object sender, EventArgs e)
        {
            try
            {                
                Guid _headerID = (Guid)_dtNotaDetail.Rows[0]["HeaderID"];
                _dtNotaHeader = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPenjualan_LIST_FILTER_RowID")); //cek heri 11032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID));                    
                    _dtNotaHeader = db.Commands[0].ExecuteDataTable();
                }

                _qtyNota = int.Parse(Tools.isNull(_dtNotaDetail.Rows[0]["QtyNota"], "0").ToString());
                _qtyRetur = int.Parse(Tools.isNull(_dtNotaDetail.Rows[0]["QtyRetur"], "0").ToString());
                _hrgJual = double.Parse(Tools.isNull(_dtNotaDetail.Rows[0]["HrgJual"], "0").ToString());
                _pot = double.Parse(Tools.isNull(_dtNotaDetail.Rows[0]["Pot"], "0").ToString());
                
                // Display data panel1
                txtTglKoreksi.DateValue = DateTime.Now;
                txtKodeSales.Text = Tools.isNull(_dtNotaHeader.Rows[0]["KodeSales"], "").ToString();
                txtNamaToko.Text = Tools.isNull(_dtNotaHeader.Rows[0]["NamaToko"], "").ToString();
                txtAlamat.Text = Tools.isNull(_dtNotaHeader.Rows[0]["AlamatKirim"], "").ToString();
                txtNoNota.Text = Tools.isNull(_dtNotaHeader.Rows[0]["NoNota"], "").ToString();
                if (_dtNotaHeader.Rows[0]["TglNota"].ToString().Trim()!="")
                {
                    txtTglNota.DateValue = (DateTime)_dtNotaHeader.Rows[0]["TglNota"];
                }
            

                // Display data panel2
                txtNamaBarang1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["NamaBarang"], "").ToString();
                txtQtyNota1.Text = (_qtyNota - _qtyRetur).ToString();
                txtSatuan1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Satuan"], "").ToString();

                txtQtyRetur1.Text = _qtyRetur.ToString();
                txtHrgSatuan1.Text = _hrgJual.ToString();
                txtPot1.Text = _pot.ToString();
                txtDisc1_1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Disc1"], "").ToString();
                txtDisc2_1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Disc2"], "").ToString();
                txtDisc3_1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Disc3"], "").ToString();
                txtCatatan1.Text = Tools.isNull(_dtNotaDetail.Rows[0]["Catatan"], "").ToString();
                txtJmlHrg1.Text = GetJmlHrg().ToString();
                txtJmlPot1.Text = GetJmlPot().ToString();
                txtJmlDisc1.Text = (GetNet3D(Tools.isNull(_dtNotaDetail.Rows[0]["DiscFormula"], "").ToString()) - _pot).ToString();
                txtHrgNetto1.Text = GetHrgNetto().ToString();

                // Display data panel3
                txtNamaBarang2.Text = Tools.isNull(_dtNotaDetail.Rows[0]["NamaBarang"], "").ToString();
                txtKodeBarang.Text = Tools.isNull(_dtNotaDetail.Rows[0]["BarangID"], "").ToString();
                txtQtyNota2.Text = _qtyNota.ToString();
                txtQtyRetur2.Text = _qtyRetur.ToString();
                txtQtyNet.Text = (_qtyNota - _qtyRetur).ToString();
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
                _nDnett = GetNet3D("") - _pot;

                //MessageBox.Show("pp");
                generateNoKoreksi();
                txtNoKoreksi.Text = strNoKoreksi;
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
            return (_qtyNota * _hrgJual);
        }

        private double GetJmlPot()
        {
            return (_qtyNota * _pot);
        }

        private double GetNet3D(string discFormula)
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
                    db.Commands[0].Parameters.Add(new Parameter("@jmlHrg", SqlDbType.Money, _hrgJual));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, _disc1));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, _disc2));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, _disc3));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, discFormula));
                    dtNet3Disc = db.Commands[0].ExecuteDataTable();
                }
                _hrgNet3Disc = double.Parse(Tools.isNull(dtNet3Disc.Rows[0]["HrgNet3Disc"], "0").ToString());
            }

            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            return (_hrgNet3Disc);
        }

        private double GetHrgNetto()
        {
            return (double.Parse(txtJmlDisc1.Text) * _qtyNota);
        }

        private void cmdSAVE_Click(object sender, EventArgs e)
        {
            if (txtNoKoreksi.Text == "")
            {
                MessageBox.Show("No Koreksi tidah boleh kosong");
                return;
            }
            double hrgKoreksi = txtHrgNetto2.GetDoubleValue- (_nDnett * _qtyNota);
            int qtyKoreksi = txtQtyNota2.GetIntValue - txtQtyNota1.GetIntValue;
            if (hrgKoreksi==0)
            {
                MessageBox.Show("Tidak bisa diisi dengan nilai sama dengan Harga satuan sebelumnya");
                return;
            }

            if (qtyKoreksi < 0)
            {
#region "Stok Minus Lock New"

                using (Stock st = new Stock())
                {

                    st.AddList(_dtNotaDetail.Rows[0]["BarangID"].ToString(), "", Math.Abs(qtyKoreksi));


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

            try
            {
                if (txtTglKoreksi.DateValue <= GlobalVar.LastClosingDate)
                {
                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                }

                this.Cursor = Cursors.WaitCursor;
                _rowID = Guid.NewGuid();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_INSERT")); //cek heri 11032013
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, _dtNotaDetail.Rows[0]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailRecID", SqlDbType.VarChar, _dtNotaDetail.Rows[0]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKoreksi", SqlDbType.DateTime, txtTglKoreksi.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@noKoreksi", SqlDbType.VarChar, txtNoKoreksi.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaBaru", SqlDbType.Int, txtQtyNota2.GetIntValue));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJualBaru", SqlDbType.Money, double.Parse(txtHrgSatuan2.Text)));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, txtCatatan2.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, _dtNotaHeader.Rows[0]["KodeToko"]));
                    db.Commands[0].Parameters.Add(new Parameter("@sumber", SqlDbType.VarChar, "NPJ"));
                    db.Commands[0].Parameters.Add(new Parameter("@linkID", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJualKoreksi", SqlDbType.Money, hrgKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyNotaKoreksi", SqlDbType.Int, qtyKoreksi));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                   MessageBox.Show("Docknokoreksi=" + docNoKoreksi.ToString() + "depan =" + depan.ToString() + "belakang =" + belakang.ToString() + "Nomor =" + iNomor.ToString() + "Lebar =" + lebar.ToString());

                    db.Commands.Add(db.CreateCommand("usp_Numerator_UPDATE"));
                    db.Commands[1].Parameters.Add(new Parameter("@doc", SqlDbType.VarChar, docNoKoreksi));
                    db.Commands[1].Parameters.Add(new Parameter("@depan", SqlDbType.VarChar, depan));
                    db.Commands[1].Parameters.Add(new Parameter("@belakang", SqlDbType.VarChar, belakang));
                    db.Commands[1].Parameters.Add(new Parameter("@nomor", SqlDbType.Int, iNomor));
                    db.Commands[1].Parameters.Add(new Parameter("@lebar", SqlDbType.VarChar, lebar));
                    db.Commands[1].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    db.Commands[0].ExecuteNonQuery();
                    db.Commands[1].ExecuteNonQuery();
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

        private void txtQtyNota2_Validating(object sender, CancelEventArgs e)
        {
            _qtyNota = txtQtyNota2.GetIntValue;
            txtJmlHrg2.Text = GetJmlHrg().ToString();
            txtJmlPot2.Text = GetJmlPot().ToString();
            txtJmlDisc2.Text = (GetNet3D(Tools.isNull(_dtNotaHeader.Rows[0]["DiscFormula"], "").ToString()) - _pot).ToString();
            txtHrgNetto2.Text = (double.Parse(txtJmlDisc2.Text) * _qtyNota).ToString();
        }

        private void txtNoKoreksi_Validating(object sender, CancelEventArgs e)
        {
            if (txtNoKoreksi.Text == "")
            {
                txtNoKoreksi.Focus();
            }
        }

        private void cmdCLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmKoreksiJualUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmKoreksiJualBrowser)
                {
                    frmKoreksiJualBrowser frmCaller = (frmKoreksiJualBrowser)this.Caller;
                    frmCaller.RefreshDataKoreksiJual();
                    frmCaller.FindRow("RowID", _rowID.ToString());
                }
            }
        }

        private void generateNoKoreksi()
        {
            DataTable dtNum = Tools.GetGeneralNumerator(docNoKoreksi);
            lebar = int.Parse(dtNum.Rows[0]["Lebar"].ToString());
            iNomor = int.Parse(dtNum.Rows[0]["Nomor"].ToString());
            depan = dtNum.Rows[0]["Depan"].ToString();
            belakang = dtNum.Rows[0]["Belakang"].ToString();
            iNomor++;
            strNoKoreksi = Tools.FormatNumerator(iNomor, lebar, depan, belakang);
        }

        private void txtQtyNota2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHrgSatuan2_Validating(object sender, CancelEventArgs e)
        {
            _hrgJual = double.Parse(txtHrgSatuan2.Text);
            _qtyNota = txtQtyNota2.GetIntValue;
            txtJmlHrg2.Text = GetJmlHrg().ToString();
            txtJmlPot2.Text = GetJmlPot().ToString();
            txtJmlDisc2.Text = (GetNet3D(Tools.isNull(_dtNotaHeader.Rows[0]["DiscFormula"], "").ToString()) - _pot).ToString();
            txtHrgNetto2.Text = (double.Parse(txtJmlDisc2.Text) * _qtyNota).ToString();
        }
    }
}
