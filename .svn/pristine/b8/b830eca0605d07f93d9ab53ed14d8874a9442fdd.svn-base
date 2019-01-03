using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.Pembelian
{
    public partial class frmMPRBeliDetailUpdate : ISA.Trading.BaseForm
    {
        public enum enumFormMode { New, Update };
        enumFormMode _formMode;
        Guid _rowID, _headerID, _notaBeliDetailID, _notaIDBaru = Guid.Empty;
        DataTable dtReturHeader, dtReturDetail, dtNota, dtKategori;
        int _qtySisa = 0,_qtyBefore;

        public frmMPRBeliDetailUpdate(Form caller, Guid headerID)
        {
            InitializeComponent();
            _formMode = enumFormMode.New;
            _headerID = headerID;
            this.Caller = caller;
        }

        public frmMPRBeliDetailUpdate(Form caller, Guid headerID, Guid rowID, Guid notaBeliDetailID)
        {
            InitializeComponent();
            _formMode = enumFormMode.Update;
            _headerID = headerID;
            _rowID = rowID;
            _notaBeliDetailID = notaBeliDetailID;
            this.Caller = caller;
        }

        private void frmMPRBeliDetailUpdate_Load(object sender, EventArgs e)
        {
            this.Title = "MPR Detail";
            this.Text = "Retur Pembelian";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtKategori = new DataTable();
                switch (_formMode)
                {
                    case enumFormMode.New:

                        dtReturHeader = new DataTable();
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID)); 
                            db.Commands.Add(db.CreateCommand("usp_Kategori_LIST"));
                          //  db.Commands[1].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, "RB"));

                            dtReturHeader = db.Commands[0].ExecuteDataTable();
                            dtKategori = db.Commands[1].ExecuteDataTable();
                        }
                        break;
                    case enumFormMode.Update:
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _headerID)); 
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_LIST"));
                            db.Commands[1].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands.Add(db.CreateCommand("usp_Kategori_LIST"));
                            //db.Commands[2].Parameters.Add(new Parameter("@ket", SqlDbType.VarChar, "RB"));
                            dtReturHeader = db.Commands[0].ExecuteDataTable();
                            dtReturDetail = db.Commands[1].ExecuteDataTable();
                            dtKategori = db.Commands[2].ExecuteDataTable();

                            if (_notaBeliDetailID != Guid.Empty)
                            {
                                db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST_ForReturHistori"));
                                db.Commands[3].Parameters.Add(new Parameter("@notaBeliDetailID", SqlDbType.UniqueIdentifier, _notaBeliDetailID));
                                dtNota = db.Commands[3].ExecuteDataTable(); 
                                _notaIDBaru = (Guid)dtNota.Rows[0]["RowID"];
                            }
                        }
                        break;
                }
                DisplayData();
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

        private void DisplayData()
        {
            /* Isi combo box kode retur */
            DataTable dtKodeRetur = new DataTable();
            DataColumn cKode = new DataColumn("Kode", Type.GetType("System.String"));
            DataColumn cKet = new DataColumn("Ket", Type.GetType("System.String"));
            dtKodeRetur.Columns.Add(cKode);
            dtKodeRetur.Columns.Add(cKet);
            dtKodeRetur.Rows.Add("1", "Histori");
            dtKodeRetur.Rows.Add("2", "Manual");
            cboKodeRetur.DataSource = dtKodeRetur;
            cboKodeRetur.DisplayMember = "Ket";
            cboKodeRetur.ValueMember = "Kode";
            if (_formMode==enumFormMode.Update)
            {
                if (dtReturDetail.Rows[0]["KodeRetur"].ToString() == "2")
                {
                    cboKodeRetur.SelectedItem = "2";
                }
                else
                {
                    cboKodeRetur.SelectedItem = "1";
                }

                cboKodeRetur.Enabled = false;
            }else
            {
                cboKodeRetur.SelectedItem = "1";
            }
           
            /* ------------------------ */    

            /* Bind data combo box kategori */
            DataColumn cKatConcatenatedCol = new DataColumn("Concatenated", Type.GetType("System.String"));
            cKatConcatenatedCol.Expression = "Kategori + ' | ' + Keterangan";
            dtKategori.Columns.Add(cKatConcatenatedCol);
            cboKategori.DataSource = dtKategori;
            cboKategori.DisplayMember = "Concatenated";
            cboKategori.ValueMember = "Kategori";

            if (_formMode == enumFormMode.Update)
            {
                cboKodeRetur.SelectedValue = dtReturDetail.Rows[0]["KodeRetur"].ToString();
                lookupStock.NamaStock = dtReturDetail.Rows[0]["NamaBarang"].ToString();
                lookupStock.BarangID = dtReturDetail.Rows[0]["BarangID"].ToString();
                txtSatuan.Text = dtReturDetail.Rows[0]["Satuan"].ToString();
                txtQtyGudang.Text = dtReturDetail.Rows[0]["QtyGudang"].ToString();
                _qtyBefore = txtQtyGudang.GetIntValue;
                txtHrgBeli.Text = dtReturDetail.Rows[0]["HrgBeli"].ToString();
                txtJmlHrgRetur.Text = dtReturDetail.Rows[0]["JmlHrgRetur"].ToString();
                                
                string catatan = dtReturDetail.Rows[0]["Catatan"].ToString();
                DataRow[] dr = dtKategori.Select("Kategori = '" + dtReturDetail.Rows[0]["Catatan"].ToString().Substring(0, 1) + "'");
                int length = dr.Length;

                if (length == 0)
                {
                    cboKategori.SelectedValue = "A";
                }
                else
                {
                    cboKategori.SelectedValue = catatan.Substring(0, 1);
                }

                if (catatan.Length < 3)
                    txtCatatan.Text = "";
                else
                    txtCatatan.Text = catatan.Substring(2, catatan.Length - 2);

                if (cboKodeRetur.SelectedValue.ToString() == "1")
                {
                    _qtySisa = txtQtyGudang.GetIntValue + (int)dtNota.Rows[0]["QtySisa"];
                    MessageBox.Show("Qty Sisa = " + _qtySisa.ToString());
                }
            }

            SetTextBoxQtyGudang();
        }

        private void DisplayDataBarang()
        {
            switch (cboKodeRetur.SelectedValue.ToString())
            {
                case "1":
                    GetNotaBeli();
                    if (dtNota.Rows.Count == 0)
                    {
                        MessageBox.Show("Tidak ada transaksi pembelian");
                        Clear();
                    }
                    else
                    {
                        txtSatuan.Text = lookupStock.Satuan;
                        _notaIDBaru = (Guid)dtNota.Rows[0]["RowID"];
                        if (_formMode == enumFormMode.New)
                        {
                            txtQtyGudang.Text = dtNota.Rows[0]["QtySisa"].ToString();
                            _qtySisa = txtQtyGudang.GetIntValue;
                        }
                        else
                        {
                            // Bila barangnya sama (nota belinya sama)
                            // maka _qtySisa adalah QtyGudang yang tersimpan di retur ditambah
                            // dengan QtySisa dari nota tersebut.
                            if (_notaBeliDetailID == _notaIDBaru)
                            {
                                _qtySisa = (int)dtReturDetail.Rows[0]["QtyGudang"]
                                            + (int)dtNota.Rows[0]["QtySisa"];
                            }
                            else
                            {
                                _qtySisa = (int)dtNota.Rows[0]["QtySisa"];
                            }

                            txtQtyGudang.Text = dtReturDetail.Rows[0]["QtyGudang"].ToString();
                            if (txtQtyGudang.GetIntValue > _qtySisa)
                            {
                                txtQtyGudang.Text = "0";
                            }
                        }
                        txtHrgBeli.Text = dtNota.Rows[0]["HrgBeliNet"].ToString();
                        txtJmlHrgRetur.Text = GetHrgBrutto().ToString();
                    }
                    break;
                case "2":
                    txtSatuan.Text = lookupStock.Satuan;
                    if (_formMode == enumFormMode.New)
                    {
                        txtQtyGudang.Text = "1";
                    }
                    else
                    {
                        txtQtyGudang.Text = dtReturDetail.Rows[0]["QtyGudang"].ToString();
                    }
                    txtHrgBeli.Text = GetHargaBeli().ToString();
                    txtJmlHrgRetur.Text = GetHrgBrutto().ToString();
                    break;
            }
            SetTextBoxQtyGudang();
        }

        private void GetNotaBeli()
        {
            Guid notaID = Guid.Empty;
            // Jika mengupdate retur histori dengan memilih barang yang sama
            // maka nota yang sama seperti sebelumnya akan digunakan
            if (_formMode == enumFormMode.Update)
            {
                if (dtReturDetail.Rows[0]["BarangID"].ToString() == lookupStock.BarangID)
                {
                    notaID = _notaBeliDetailID;
                }
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtNota = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST_ForReturHistori"));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@tglKeluar", SqlDbType.DateTime, dtReturHeader.Rows[0]["TglKeluar"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, dtReturHeader.Rows[0]["Pemasok"]));
                    if (notaID != Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailID", SqlDbType.UniqueIdentifier, notaID));
                    }
                    dtNota = db.Commands[0].ExecuteDataTable();
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

        private void SetTextBoxQtyGudang()
        {
            string barangID = lookupStock.BarangID;

            if (lookupStock.BarangID == "" || lookupStock.BarangID == "[Code]")
            {
                txtQtyGudang.Enabled = false;
                txtQtyGudang.ReadOnly = true;
            }
            else
            {
                txtQtyGudang.Enabled = true;
                txtQtyGudang.ReadOnly = false;
            }
        }

        private double GetHrgBrutto()
        {
            return (txtQtyGudang.GetIntValue * double.Parse(txtHrgBeli.Text));
        }

        private double GetHargaBeli()
        {
            double hrgBeli = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_GetHrgBeli_returPembelian]"));
                    db.Commands[0].Parameters.Add(new Parameter("@kodeBarang", SqlDbType.VarChar, lookupStock.BarangID));
                    db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, dtReturHeader.Rows[0]["TglKeluar"]));
                    db.Commands[0].Parameters.Add(new Parameter("@Mode", SqlDbType.VarChar, "AVG"));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows[0]["HrgBeli"].ToString().Trim()=="")
                {
                    hrgBeli = 0;
                }else
                {
                    hrgBeli = double.Parse(dt.Rows[0]["HrgBeli"].ToString());
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
            return hrgBeli;
        }

        private void Clear()
        {
            lookupStock.NamaStock = "";
            lookupStock.BarangID = "";
            lookupStock.Satuan = "";
            txtSatuan.Text = "";
            txtQtyGudang.Text = "0";
            txtHrgBeli.Text = "0";
            txtJmlHrgRetur.Text = "0";
            if (_formMode == enumFormMode.New)
            {
                txtCatatan.Text = "";
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _notaIDBaru = Guid.Empty;
                string notaRecID = "";
                string catatan = cboKategori.SelectedValue.ToString() +  " " + txtCatatan.Text;
                if (cboKodeRetur.SelectedValue.ToString() == "1")
                {
                    _notaIDBaru = (Guid)dtNota.Rows[0]["RowID"];
                    notaRecID = dtNota.Rows[0]["RecordID"].ToString();
                }

                switch (_formMode)
                {
                    case enumFormMode.New:
#region "Stok Minus Lock New"

                        using (Stock st = new Stock())
                        {

                            st.AddList(lookupStock.BarangID, "", txtQtyGudang.GetIntValue);
                            

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
                        _rowID = Guid.NewGuid();
                        using (Database db = new Database())
                        {                            
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_INSERT"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailID", SqlDbType.UniqueIdentifier, _notaIDBaru));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, Tools.CreateFingerPrint()));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtReturHeader.Rows[0]["ReturID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailRecID", SqlDbType.VarChar, notaRecID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, cboKodeRetur.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyGudang.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgNet", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, catatan));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, dtReturHeader.Rows[0]["TglKeluar"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteDataTable();
                        }
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Data telah disimpan");
                        this.Clear();
                        lookupStock.Focus();
                        break;
                    case enumFormMode.Update:
#region "Stok Minus Lock New"

                        using (Stock st = new Stock())
                        {

                            st.AddList(lookupStock.BarangID, "", txtQtyGudang.GetIntValue-_qtyBefore);


                            // pass = st.Pass();
                            if (!st.Pass())
                            {
                                MessageBox.Show("Tidak Bisa Proses ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


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
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_UPDATE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                            db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                            db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailID", SqlDbType.UniqueIdentifier, _notaIDBaru));
                            db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtReturDetail.Rows[0]["RecordID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@returID", SqlDbType.VarChar, dtReturDetail.Rows[0]["ReturID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@notaBeliDetailRecID", SqlDbType.VarChar, notaRecID));
                            db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, lookupStock.BarangID));
                            db.Commands[0].Parameters.Add(new Parameter("@KodeRetur", SqlDbType.VarChar, cboKodeRetur.SelectedValue.ToString()));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyGudang", SqlDbType.Int, txtQtyGudang.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@qtyTerima", SqlDbType.Int, txtQtyGudang.GetIntValue));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgNet", SqlDbType.Money, 0));
                            db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, double.Parse(txtHrgBeli.Text)));
                            db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, catatan));
                            db.Commands[0].Parameters.Add(new Parameter("@TglKeluar", SqlDbType.DateTime, dtReturDetail.Rows[0]["TglKeluar"]));
                            db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                            db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                            db.Commands[0].ExecuteDataTable();
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
                this.Cursor = Cursors.Default;
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

            if (txtQtyGudang.Text == "0")
            {
                errorProvider1.SetError(txtQtyGudang, "Qty Gudang masih 0");
                valid = false;
            }
            return valid;
        }

        private void lookupStock_SelectData(object sender, EventArgs e)
        {
            DisplayDataBarang();
        }

        private void cboKodeRetur_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDataBarang();
        }

        private void txtQtyGudang_Validating(object sender, CancelEventArgs e)
        {
            int qtyGudang = txtQtyGudang.GetIntValue;

            if (txtQtyGudang.Text == "")
            {
                txtQtyGudang.Text = "0";
            }

            if (cboKodeRetur.SelectedValue.ToString() == "1")
            {
                if (qtyGudang > _qtySisa)
                {
                    txtQtyGudang.Text = "0";
                }
            }
            txtJmlHrgRetur.Text = GetHrgBrutto().ToString();
        }

        private void txtQtyGudang_Click(object sender, EventArgs e)
        {
            if (lookupStock.BarangID == "" || lookupStock.BarangID == "[CODE]")
            {
                MessageBox.Show("Isi barang dulu");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMPRBeliDetailUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmMPRBeliBrowser)
                {
                    frmMPRBeliBrowser formCaller = (frmMPRBeliBrowser)this.Caller;
                    formCaller.RefreshDataReturBeliDetail();
                    formCaller.FindDetail("DetailRowID", _rowID.ToString());
                }
            }
        }

        private void lookupStock_Leave(object sender, EventArgs e)
        {
            //txtQtyGudang.Focus();
            //txtQtyGudang.SelectAll();
        }
    }
}
