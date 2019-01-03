using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading;

namespace ISA.Trading.Pembelian
{
    public partial class frmNotaBeliUpdate : ISA.Controls.BaseForm
    {
        DataTable dt;
        DataTable dtResult;
        DataTable dtResultPO;

        Guid _rowID;
        Guid _detailRowID;
        Guid RowIDDetailPO;

        int QtyRQ = 0;
        int QtyFaktur = 0;
        int QtySJ = 0;
        double Harga = 0;
        double D1 = 0;
        double D2 = 0;
        double D3 = 0;
        double Potrp = 0;
        double HargaNet = 0;
        double JmlBeli = 0;

        DateTime fromDate;
        DateTime toDate;
        

        public frmNotaBeliUpdate(Form caller)
        {
            this.Caller = caller;
            InitializeComponent();
        }

        private void frmNotaBeliUpdate_Load(object sender, EventArgs e)
        {
            int tgl = 1;
            int bln = DateTime.Parse(GlobalVar.DateTimeOfServer.ToString()).AddMonths(-1).Month;
            int thn = DateTime.Parse(GlobalVar.DateTimeOfServer.ToString()).Year;

            fromDate = new DateTime(thn, bln, tgl);
            toDate = GlobalVar.DateTimeOfServer;
            txtTanggal.DateValue = GlobalVar.DateTimeOfServer;
            rdbPO.FromDate = fromDate;
            rdbPO.ToDate = toDate;

            try
            {
                DataTable dtp = DBTools.DBGetDataTable("usp_Pemasok_LIST", new List<Parameter>());
                cboSupplier.DisplayMember = "Nama";
                cboSupplier.ValueMember = "PemasokID";
                cboSupplier.DataSource = dtp;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            
            DataTable dt = new DataTable();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryOrderPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    if (Tools.isNull(txtNoPO.Text, "").ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NoPO", SqlDbType.VarChar, txtNoPO.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada PO");
                    return;
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

            dtResultPO = new DataTable();
            dtResultPO.Columns.Add("RowID", typeof(System.Guid));
            dtResultPO.Columns.Add("NoRequest", typeof(System.String));
            dtResultPO.Columns.Add("TglRequest", typeof(System.DateTime));
            dtResultPO.Columns.Add("Pemasok", typeof(System.String));
            dtResultPO.Columns.Add("BarangID", typeof(System.String));
            dtResultPO.Columns.Add("NamaStok", typeof(System.String));
            dtResultPO.Columns.Add("SatJual", typeof(System.String));
            dtResultPO.Columns.Add("QtyBO", typeof(System.Int32));
            dtResultPO.Columns.Add("QtyDO", typeof(System.Int32));
            dtResultPO.Columns.Add("QtyRealisasi", typeof(System.Int32));
            DataColumn[] pkResultPO = new DataColumn[1];
            pkResultPO[0] = dtResultPO.Columns["RowID"];
            dtResultPO.PrimaryKey = pkResultPO;

            dtResult = new DataTable();
            dtResult.Columns.Add("OrderPembelianDetailRowID", typeof(System.Guid));
            dtResult.Columns.Add("NoRequestBeli", typeof(System.String));
            dtResult.Columns.Add("TglRequestBeli", typeof(System.DateTime));
            dtResult.Columns.Add("PemasokBeli", typeof(System.String));
            dtResult.Columns.Add("BarangIDBeli", typeof(System.String));
            dtResult.Columns.Add("NamaStokBeli", typeof(System.String));
            dtResult.Columns.Add("SatJualBeli", typeof(System.String));
            dtResult.Columns.Add("QtyPOBeli", typeof(System.Int32));
            dtResult.Columns.Add("QtyRealBeli", typeof(System.Int32));
            dtResult.Columns.Add("QtyBOBeli", typeof(System.Int32));
            dtResult.Columns.Add("QtyNotaBeli", typeof(System.Int32));
            dtResult.Columns.Add("QtyTerima", typeof(System.Int32));
            dtResult.Columns.Add("HrgBeli", typeof(System.Double));
            dtResult.Columns.Add("Disc1", typeof(System.Double));
            dtResult.Columns.Add("Disc2", typeof(System.Double));
            dtResult.Columns.Add("Disc3", typeof(System.Double));
            dtResult.Columns.Add("Pot", typeof(System.Double));
            dtResult.Columns.Add("HrgNetto", typeof(System.Double));
            dtResult.Columns.Add("Jumlah", typeof(System.Double));
            DataColumn[] pkResult = new DataColumn[1];
            pkResult[0] = dtResult.Columns["OrderPembelianDetailRowID"];
            dtResult.PrimaryKey = pkResult;
            dataGridBeli.DataSource = dtResult;


            foreach (DataRow dr in dt.Rows)
            {
                DataRow drPo = dtResultPO.NewRow();
                drPo["RowID"] = dr["RowID"];
                drPo["NoRequest"] = dr["NoRequest"];
                drPo["TglRequest"] = dr["TglRequest"];
                drPo["Pemasok"] = dr["Pemasok"];
                drPo["BarangID"] = dr["BarangID"];
                drPo["NamaStok"] = dr["NamaStok"];
                drPo["SatJual"] = dr["SatJual"];
                drPo["QtyDO"] = dr["QtyDO"];
                drPo["QtyRealisasi"] = dr["QtyRealisasi"];
                drPo["QtyBO"] = dr["QtyBO"];
                dtResultPO.Rows.Add(drPo);
            }
            dataGridPO.DataSource = dtResultPO;
            txtTanggal.Focus();
        }



        private void dataGridPO_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridPO.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Tidak ada data yang dipilih.");
                return;
            }
            cmdPilih.PerformClick();
        }

        private void cmdPilih_Click(object sender, EventArgs e)
        {
            if (dataGridPO.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Tidak ada data yang dipilih.");
                return;
            }

            Guid RowIDDetailPO = (Guid)dataGridPO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string NoPO = Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value, "").ToString();
            DateTime TglPO = Convert.ToDateTime(Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["TglRequest"].Value, DateTime.MinValue.ToString()));
            string Pemasok = Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["Pemasok"].Value, "").ToString();
            string BarangID = Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["BarangID"].Value, "").ToString();
            string NamaStok = Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value, "").ToString();
            string SatJual = Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["SatJual"].Value, "").ToString();
            int QtyDO = Convert.ToInt32(Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["QtyDO"].Value, "0").ToString());
            int QtyReal = Convert.ToInt32(Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["QtyRealisasi"].Value, "0").ToString());
            int QtyBO = Convert.ToInt32(Tools.isNull(dataGridPO.SelectedCells[0].OwningRow.Cells["QtyBO"].Value, "0").ToString());

            DataRow drFind = dtResult.Rows.Find(RowIDDetailPO);
            bool isRegistered = false;

            if (drFind != null)
            {
                isRegistered = true;
            }
            if (!isRegistered)
            {
                DataRow drNew = dtResult.NewRow();
                drNew["OrderPembeliandetailRowID"] = RowIDDetailPO;
                drNew["NoRequestBeli"] = NoPO;
                drNew["TglRequestBeli"] = TglPO;
                drNew["PemasokBeli"] = Pemasok;
                drNew["BarangIDBeli"] = BarangID;
                drNew["NamaStokBeli"] = NamaStok;
                drNew["SatJualBeli"] = SatJual;
                drNew["QtyPOBeli"] = QtyDO;
                drNew["QtyRealBeli"] = QtyReal;
                drNew["QtyBOBeli"] = QtyBO;
                drNew["QtyNotaBeli"] = 0;
                drNew["QtyTerima"] = 0;
                drNew["HrgBeli"] = 0;
                drNew["Disc1"] = 0;
                drNew["Disc1"] = 0;
                drNew["Disc3"] = 0;
                drNew["Pot"] = 0;
                drNew["HrgNetto"] = 0;
                drNew["Jumlah"] = 0;
                dtResult.Rows.Add(drNew);
            }
            dataGridBeli.DataSource = dtResult;
            FindDetail("OrderPembelianDetailRowID", RowIDDetailPO.ToString());
            RefreshGridAfterDelete(dataGridPO);
            dataGridPO.Focus();
        }


        public void FindDetail(string columnName, string value)
        {
            dataGridBeli.FindRow(columnName, value);
        }

        public void FindDetailPO(string columnName, string value)
        {
            dataGridPO.FindRow(columnName, value);
        }


        private void RefreshGridAfterDelete(Controls.CustomGridView dgv)
        {
            int i = 0;
            int n = 0;
            i = dgv.SelectedCells[0].RowIndex;
            n = dgv.SelectedCells[0].ColumnIndex;
            DataRowView dv = (DataRowView)dgv.SelectedCells[0].OwningRow.DataBoundItem;
            DataRow dr = dv.Row;
            dr.Delete();
            //dt.AcceptChanges();
            dgv.Focus();
            dgv.RefreshEdit();
            if (dgv.RowCount > 0)
            {
                if (i == 0)
                {
                    dgv.CurrentCell = dgv.Rows[0].Cells[n];
                }
                else
                {
                    dgv.CurrentCell = dgv.Rows[i - 1].Cells[n];
                }
            }
        }

        private void dataGridBeli_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 9)
            {
                HargaBeliNetto();
                dataGridBeli.SelectedCells[0].OwningRow.Cells["HrgNet"].Value = HargaNet;
                dataGridBeli.SelectedCells[0].OwningRow.Cells["Jumlah"].Value = QtySJ * HargaNet;
            }
        }

        private void HargaBeliNetto()
        {
            double H1 = 0, H2 = 0, H3 = 0;
            RowIDDetailPO = (Guid)dataGridBeli.SelectedCells[0].OwningRow.Cells["OrderPembelianDetailRowID"].Value;
            QtyRQ = Convert.ToInt32(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["QtyPOBeli"].Value, "0").ToString());
            QtyFaktur = Convert.ToInt32(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["QtyNotaBeli"].Value, "0").ToString());
            QtySJ = Convert.ToInt32(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["QtyTerima"].Value, "0").ToString());
            Harga = Convert.ToDouble(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["HrgBeli"].Value, "0").ToString());
            D1 = Convert.ToDouble(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["Disc1"].Value, "0").ToString());
            D2 = Convert.ToDouble(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["Disc2"].Value, "0").ToString());
            D3 = Convert.ToDouble(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["Disc3"].Value, "0").ToString());
            Potrp = Convert.ToDouble(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["Pot"].Value, "0").ToString());
            H1 = Harga - ((D1 * 0.01) * Harga);
            H2 = H1 - ((D2 * 0.01) * H1);
            H3 = H2 - ((D3 * 0.01) * H2);
            HargaNet = H3 - Potrp;
            JmlBeli = QtySJ * HargaNet;
        }

        private void dataGridBeli_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridBeli.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Tidak ada data yang dipilih.");
                return;
            }
            cmdPilihBeli.PerformClick();
        }

        private void cmdPilihBeli_Click(object sender, EventArgs e)
        {
            if (dataGridBeli.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Tidak ada data yang dipilih.");
                return;
            }

            Guid RowID = (Guid)dataGridBeli.SelectedCells[0].OwningRow.Cells["OrderPembelianDetailRowID"].Value;
            string NoPO_Beli = Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["NoRequestBeli"].Value, "").ToString();
            DateTime TglPO_Beli = Convert.ToDateTime(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["TglRequestBeli"].Value, DateTime.MinValue.ToString()));
            string Pemasok_Beli = Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["PemasokBeli"].Value, "").ToString();
            string BarangID_Beli = Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["BarangIDBeli"].Value, "").ToString();
            string NamaStok_Beli = Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["NamaStokBeli"].Value, "").ToString();
            string SatJual_Beli = Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["SatJualBeli"].Value, "").ToString();
            int QtyPO_Beli = Convert.ToInt32(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["QtyPOBeli"].Value, "0").ToString());
            int QtyReal_Beli = Convert.ToInt32(Tools.isNull(dataGridBeli.SelectedCells[0].OwningRow.Cells["QtyTerima"].Value, "0").ToString());
            int QtyBO_Beli = QtyPO_Beli - QtyReal_Beli;

            DataRow drFind = dtResultPO.Rows.Find(RowID);
            bool isRegistered = false;

            if (drFind != null)
            {
                isRegistered = true;
            }
            if (!isRegistered)
            {
                DataRow drNew2 = dtResultPO.NewRow();
                drNew2["RowID"] = RowID;
                drNew2["NoRequest"] = NoPO_Beli;
                drNew2["TglRequest"] = TglPO_Beli;
                drNew2["Pemasok"] = Pemasok_Beli;
                drNew2["BarangID"] = BarangID_Beli;
                drNew2["NamaStok"] = NamaStok_Beli;
                drNew2["SatJual"] = SatJual_Beli;
                drNew2["QtyDO"] = QtyPO_Beli;
                drNew2["QtyRealisasi"] = 0;
                drNew2["QtyBO"] = QtyBO_Beli;
                dtResultPO.Rows.Add(drNew2);
            }
            dataGridPO.DataSource = dtResultPO;
            FindDetailPO("RowID", RowID.ToString());
            RefreshGridAfterDelete(dataGridBeli);
            dataGridBeli.Focus();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Tools.isNull(txtTanggal.Text, "").ToString() == "")
            {
                MessageBox.Show("Tanggal belum diisi.");
                txtTanggal.Focus();
                return;
            }
            if (Tools.isNull(txtNoBukti.Text, "").ToString() == "")
            {
                MessageBox.Show("Nomor Bukti belum diisi.");
                txtTanggal.Focus();
                return;
            }
            if (Tools.isNull(cboSupplier.Text, "").ToString() == "")
            {
                MessageBox.Show("Pemasok belum diisi.");
                cboSupplier.Focus();
                return;
            }
            if (dataGridBeli.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Tidak ada data Pembelian.");
                return;
            }


            /*insert NOta Pembelian Header*/
            #region insert header
            _rowID = Guid.NewGuid();
            string _recordID = Tools.CreateFingerPrint();
            DateTime Tgl = DateTime.Parse(Tools.isNull(txtTanggal.DateValue, DateTime.MinValue).ToString());

            using (Database db = new Database())
            {
                try
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianHeader_INSERT"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordID));
                    db.Commands[0].Parameters.Add(new Parameter("@noRequest", SqlDbType.VarChar, Tools.isNull(txtNoBukti.Text, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglRequest", SqlDbType.DateTime, Tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@noDO", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTransaksi", SqlDbType.DateTime, Tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@noNota", SqlDbType.VarChar, Tools.isNull(txtNoBukti.Text, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglNota", SqlDbType.DateTime, txtTanggal.DateValue));
                    db.Commands[0].Parameters.Add(new Parameter("@noSuratJalan", SqlDbType.VarChar, Tools.isNull(txtNoBukti.Text, "").ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, Tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, Tgl));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@hariKredit", SqlDbType.Int, txtTOP.Value));
                    db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Decimal, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@pemasok", SqlDbType.VarChar, cboSupplier.Text.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@expedisi", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@cabang", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, false));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, false));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            #endregion


            /*insert Nota Pembelian Detail*/
            #region insert detail
            using (Database db = new Database())
            {
                try
                {
                    int no = 0;
                    foreach (DataRow dr1 in dtResult.Rows)
                    {
                        no++;
                        Guid _detailRowID = Guid.NewGuid();
                        string _recordIDD = Tools.CreateFingerPrint().Substring(0,19)+no.ToString().PadLeft(3,'0');
                        db.Commands.Clear();
                        db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_INSERT"));
                        db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _detailRowID));
                        db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _rowID));
                        db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, _recordIDD));
                        db.Commands[0].Parameters.Add(new Parameter("@headerRecID", SqlDbType.VarChar, _recordID));
                        db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, Tools.isNull(dr1["BarangIDBeli"],"0").ToString()));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr1["QtyPOBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr1["QtyNotaBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@qtySuratJalan", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr1["QtyTerima"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@qtyNota", SqlDbType.Int, Convert.ToInt32(Tools.isNull(dr1["QtyNotaBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@tglTerima", SqlDbType.DateTime, txtTanggal.DateValue));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgBeli", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr1["HrgBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@hrgPokok", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr1["HrgBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@hppSolo", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr1["HrgBeli"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, Convert.ToDouble(Tools.isNull(dr1["Pot"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Float, Convert.ToDouble(Tools.isNull(dr1["Disc1"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Float, Convert.ToDouble(Tools.isNull(dr1["Disc2"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Float, Convert.ToDouble(Tools.isNull(dr1["Disc3"], "0").ToString())));
                        db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, ""));
                        db.Commands[0].Parameters.Add(new Parameter("@ppn", SqlDbType.Float, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@kodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                        db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                        db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                        db.Commands[0].Parameters.Add(new Parameter("@OrderPembelianDetailRowID", SqlDbType.UniqueIdentifier, Tools.isNull(dr1["OrderPembelianDetailRowID"],Guid.Empty)));
                        db.Commands[0].ExecuteNonQuery();
                    }
                    dtResult.Rows.Clear();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Error.LogError(ex);
                }
            }
            #endregion


        }


        private void frmNotaBeliUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.Caller is frmNotaBeliBrowser)
                {
                    Pembelian.frmNotaBeliBrowser frmcaller = (Pembelian.frmNotaBeliBrowser)this.Caller;
                    frmcaller.RefreshDataNotaBeli();
                    frmcaller.RefreshDataNotaBeliDetail();
                    frmcaller.FindHeader("HeaderRowID", _rowID.ToString());
                }
            }
        }


        private void cmdSearch_Click(object sender, EventArgs e)
        {
            fromDate = DateTime.Parse(rdbPO.FromDate.ToString());
            toDate = DateTime.Parse(rdbPO.ToDate.ToString());

            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtpo = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_HistoryOrderPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, toDate));
                    if (Tools.isNull(txtNoPO.Text, "").ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@NoPO", SqlDbType.VarChar, txtNoPO.Text));
                    }
                    db.Commands[0].ExecuteDataSet();
                    dtpo = db.Commands[0].ExecuteDataTable();
                }
                if (dtpo.Rows.Count > 0)
                {
                    dtResultPO.Clear();
                    foreach (DataRow dr in dtpo.Rows)
                    {
                        DataRow drPo = dtResultPO.NewRow();
                        drPo["RowID"] = dr["RowID"];
                        drPo["NoRequest"] = dr["NoRequest"];
                        drPo["TglRequest"] = dr["TglRequest"];
                        drPo["Pemasok"] = dr["Pemasok"];
                        drPo["BarangID"] = dr["BarangID"];
                        drPo["NamaStok"] = dr["NamaStok"];
                        drPo["SatJual"] = dr["SatJual"];
                        drPo["QtyDO"] = dr["QtyDO"];
                        drPo["QtyRealisasi"] = dr["QtyRealisasi"];
                        drPo["QtyBO"] = dr["QtyBO"];
                        dtResultPO.Rows.Add(drPo);
                    }
                    dataGridPO.DataSource = dtResultPO;

                }
                else
                {
                    MessageBox.Show(Messages.Error.NotFound);
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
    }
}
