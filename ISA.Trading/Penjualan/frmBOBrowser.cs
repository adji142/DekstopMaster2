using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using ISA.Trading.Class;

namespace ISA.Trading.Penjualan
{
    public partial class frmBOBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { DOSelected, DetailDOSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.DOSelected;
        bool _acak;
        DataTable dtDO, dtDetailDO, dtDOsum;
        DateTime _fromDate, _toDate;
        double JmlHrgTot = 0.00, HrgNetTot = 0.00, JmlHPPTot = 0.00, JmlPotTot = 0.00;
        string _rowID = string.Empty;
        string PrnAktif = "0";

       
        public frmBOBrowser()
        {
            InitializeComponent();
        }

        private void frmBOBrowse_Load(object sender, EventArgs e)
        {
            this.Title = "Back Order";
            this.Text = "Penjualan";
            _acak = true;
            AcakTampilTextBox();
            lblBarang.Text = "";
            dataGridDO.AutoGenerateColumns = false;
            dataGridDetailDO.AutoGenerateColumns = false;
            _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _toDate = DateTime.Now;
            rgbTglDO.FromDate = _fromDate;
            rgbTglDO.ToDate = _toDate;
            rgbTglDO.Focus();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataDO();
            dataGridDO.Focus();
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataDO()
        {
            _fromDate = (DateTime)rgbTglDO.FromDate;
            _toDate = (DateTime)rgbTglDO.ToDate;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDOsum = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_BO_UpdateSumQtyDO"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].ExecuteNonQuery();
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

            //-------------------------------------------
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDO = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_LIST_BO"));// udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    dtDO = db.Commands[0].ExecuteDataTable();
                }
                DataColumn cNoDOAndFlag = new DataColumn("NoDOAndFlag", Type.GetType("System.String"));
                cNoDOAndFlag.Expression = "NoDO + ' ' + FlagDO";
                dtDO.Columns.Add(cNoDOAndFlag);
                dtDO.DefaultView.Sort = "HtrID";
                dataGridDO.DataSource = dtDO;

                if (dataGridDO.SelectedCells.Count > 0)
                {
                    RefreshDataDetailDO();
                    lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                        + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                }
                else
                {
                    dataGridDetailDO.DataSource = null;
                    lblToko.Text = " ";
                    AcakTampilTextBox();
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

        public void RefreshDataDetailDO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    dtDetailDO = new DataTable();
                    Guid _headerID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_LIST_BO")); //udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, _headerID));
                    dtDetailDO = db.Commands[0].ExecuteDataTable();

                    dataGridDetailDO.DataSource = dtDetailDO;
                }

                if (dataGridDetailDO.SelectedCells.Count > 0)
                {
                    lblBarang.Text = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                }
                else
                {
                    lblBarang.Text = " ";
                }
                AcakTampilTextBox();
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

        private void dataGridDO_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DOSelected;
        }

        private void dataGridDetailDO_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailDOSelected;
        }

        private void dataGridDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    /* Flag BO untuk header */
                    if (!SecurityManager.IsAuditor())
                    {
                        FlagBO();
                    }
                    break;
                case Keys.F4:
                    /* Tutup BO */
                    if (!SecurityManager.IsAuditor())
                    {
                        TutupBO();
                    }
                    break;
                case Keys.F5:
                    // Cetak BO
                    if (!SecurityManager.IsAuditor())
                    {
                        CekCetakBO();
                    }
                    break;
                case Keys.F6:
                    // Referesh DO-BO
                    if (!SecurityManager.IsAuditor())
                    {
                        RefreshDataDO();
                    }
                    break;
                case Keys.F9:
                    /* Acak / Tampil */
                    AcakTampilHrg();
                    break;
                case Keys.F12:
                    // Filter barang
                    Penjualan.frmDOFilterBarangBrowser ifrmChild = new Penjualan.frmDOFilterBarangBrowser(_fromDate, _toDate,this);
                    ifrmChild.MdiParent = Program.MainForm;
                    Program.MainForm.RegisterChild(ifrmChild);
                    ifrmChild.Show();
                    break;
                case Keys.Tab:
                    dataGridDetailDO.Focus();
                    selectedGrid = enumSelectedGrid.DetailDOSelected;
                    break;
                case Keys.Home:
                    break;
                case Keys.End:
                    break;
            }
        }

        private void dataGridDetailDO_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    /* Flag BO untuk Detail */
                    FlagBO();
                    break;
                case Keys.F9:
                    /* Acak / Tampil */
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    dataGridDO.Focus();
                    selectedGrid = enumSelectedGrid.DOSelected;
                    break;
                case Keys.Home:
                    break;
                case Keys.End:
                    break;
            }
        }

        private void TutupBO()
        {
            string noDO = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString();
            int index = dataGridDO.SelectedCells[0].RowIndex;
            if (MessageBox.Show("BO dari DO : "+noDO+"akan ditutup...?", "Perhatian", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                UpdateHeader(index, dtDO.Rows[0]["NoDOBO"], true);
            }
        }

        private double GetRpBo()
        {
            double rpBo = 0;

            if (dataGridDO.SelectedCells.Count > 0)
            {
                rpBo = Convert.ToDouble(dataGridDetailDO.SelectedCells[0].OwningRow.Cells["HrgNet"].Value);

                double hrgNet = 0;
                foreach (DataGridViewRow row in dataGridDetailDO.Rows)
                {
                    if (row.DefaultCellStyle.ForeColor == Color.Red)
                    {
                        hrgNet = Convert.ToDouble(row.Cells["HrgNet"].Value);
                        rpBo += hrgNet;
                    }
                }
            }

            return rpBo;
        }

        private void FlagBO()
        {
            string c1 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString();
            string c2 = dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString();
            if (c1 == GlobalVar.CabangID && c2 != GlobalVar.CabangID)
            {
                MessageBox.Show("Flag DO BO hanya untuk cabang pengirim...!");
                return;
            }

            string noDOBO;
            int index;
            switch (selectedGrid)
            {
                case enumSelectedGrid.DOSelected:
                    noDOBO = dataGridDO.SelectedCells[0].OwningRow.Cells["NoDOBO"].Value.ToString();
                    index = dataGridDO.SelectedCells[0].OwningRow.Index;
                    if (noDOBO == "")
                    {
                        noDOBO = CreateNoDOBO();
                    }
                    else
                    {
                        if (CekFlagDetail())
                        {
                            MessageBox.Show("Sebelum lepas flag header, lepas dulu flag detailnya....!");
                            return;
                        }
                        noDOBO = "";
                    }
                    UpdateHeader(index, noDOBO, dtDO.Rows[index]["StatusBO"]);
                    break;
                case enumSelectedGrid.DetailDOSelected:
                    noDOBO = dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoDOBO"].Value.ToString();
                    index = dataGridDetailDO.SelectedCells[0].OwningRow.Index;
                    if (noDOBO == "")
                    {
                        if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoDOBO"].Value.ToString() == "")
                        {
                            MessageBox.Show("Sebelum flag detail, flag dulu headernya....!");
                            return;
                        }

                        string jenisTransaksi = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value);
                        string kodeToko = Convert.ToString(dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value);
                        double rpBO = GetRpBo();
                        double sisaPlafon = TokoPlafon.SisaPlafon(kodeToko, jenisTransaksi);
                        if (rpBO > sisaPlafon)
                        {
                            MessageBox.Show("Tidak bisa buat BO. Rp BO melebihi Sisa Plafon toko. \n" +
                                            "Rp BO = " + rpBO.ToString("N0") + ", Sisa Plafon: " + sisaPlafon.ToString("N0") + "\n" +
                                            "Silahkan melakukan pengajuan plafon ke PS HO");
                            return;
                        }

                        noDOBO = CreateNoDOBO();                      
                    }
                    else
                    {
                        noDOBO = "";
                    }
                    UpdateDetail(index, noDOBO);
                    break;
            }
        }

        private bool CekFlagDetail()
        {
            bool result = false;
            for (int i = 0; i < dataGridDetailDO.RowCount; i++)
            {
                if (dataGridDetailDO.Rows[i].Cells["DetailNoDOBO"].Value.ToString() != "")
                {
                    result = true;
                }
            }

            return result;
        }

        private string CreateNoDOBO()
        {
            string result = "BO";
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            if (month < 10)
                result = result + "0" + month.ToString();
            else
                result = result + month.ToString();

            if (day < 10)
                result = result + "0" + day.ToString();
            else
                result = result + day.ToString();

            result = result + "_";

            return result;
        }

        private void UpdateHeader(int index, object noDOBO, object statusBO)
        {
            try
            {
                Console.WriteLine(dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString());
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualan_UPDATE"));//udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@HtrID", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["HtrID"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang1", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang2", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Cabang3", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang3"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoRequest", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["NoRequest"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglRequest", SqlDbType.DateTime, (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglRequest"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDO", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["NoDO"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglDO", SqlDbType.DateTime, (DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglDO"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPusat", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPusat"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@ACCPiutangID", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["ACCPiutangID"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@NoACCPiutang", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["NoACCPiutang"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@TglACCPiutang", SqlDbType.DateTime, dataGridDO.SelectedCells[0].OwningRow.Cells["TglACCPiutang"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBatal", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["StatusBatal"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKredit", SqlDbType.Int, Convert.ToInt32(dataGridDO.SelectedCells[0].OwningRow.Cells["HariKredit"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeToko", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["KodeSales"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@StsToko", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["StsToko"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@AlamatKirim", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Kota", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@DiscFormula", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["DiscFormula"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc1", SqlDbType.Decimal, Convert.ToDecimal(dataGridDO.SelectedCells[0].OwningRow.Cells["Disc1"].Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc2", SqlDbType.Decimal, Convert.ToDecimal(dataGridDO.SelectedCells[0].OwningRow.Cells["Disc2"].Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@Disc3", SqlDbType.Decimal, Convert.ToDecimal(dataGridDO.SelectedCells[0].OwningRow.Cells["Disc3"].Value)));
                    db.Commands[0].Parameters.Add(new Parameter("@isClosed", SqlDbType.Bit, (Boolean)dataGridDO.SelectedCells[0].OwningRow.Cells["isClosed"].Value));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan1", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan1"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan2", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan2"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan3", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan3"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan4", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan4"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Catatan5", SqlDbType.VarChar, /*dataGridDO.SelectedCells[0].OwningRow.Cells["Catatan5"]*/""));
                    db.Commands[0].Parameters.Add(new Parameter("@NoDOBO", SqlDbType.VarChar, noDOBO));
                    db.Commands[0].Parameters.Add(new Parameter("@TglReorder", SqlDbType.DateTime, /*(DateTime)dataGridDO.SelectedCells[0].OwningRow.Cells["TglReorder"].Value)*/null));
                    db.Commands[0].Parameters.Add(new Parameter("@StatusBO", SqlDbType.Bit, statusBO));
                    db.Commands[0].Parameters.Add(new Parameter("@SyncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@LinkID", SqlDbType.VarChar, /*dataGridDO.SelectedCells[0].OwningRow.Cells["LinkID"]*/""));
                    db.Commands[0].Parameters.Add(new Parameter("@TransactionType", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["TransactionType"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@Expedisi", SqlDbType.VarChar, dataGridDO.SelectedCells[0].OwningRow.Cells["Expedisi"].Value.ToString()));
                    db.Commands[0].Parameters.Add(new Parameter("@HariKirim", SqlDbType.Int, Convert.ToInt32(dataGridDO.SelectedCells[0].OwningRow.Cells["HariKirim"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@HariSales", SqlDbType.Int, Convert.ToInt32(dataGridDO.SelectedCells[0].OwningRow.Cells["HariSales"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@NPrint", SqlDbType.Int, Convert.ToInt32(dataGridDO.SelectedCells[0].OwningRow.Cells["NPrint"].Value.ToString())));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                //dtDO.Rows[index]["NoDOBO"] = noDOBO;
                
                bool status = (bool)statusBO;
                if (status)
                {
                    //dtDO.Rows.RemoveAt(index);
                    //dataGridDO.SelectedCells[0].OwningRow.Cells.RemoveAt(index);
                    RefreshDataDO();
                }
                else
                {
                    RefreshHeader(dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].ToString(), index, noDOBO.ToString());
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

        private void UpdateDetail(int index, object noDOBO)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_OrderPenjualanDetail_UPDATE")); //udah heri
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, dtDetailDO.Rows[index]["RowID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, dtDetailDO.Rows[index]["HeaderID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@recordID", SqlDbType.VarChar, dtDetailDO.Rows[index]["RecordID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@htrID", SqlDbType.VarChar, dtDetailDO.Rows[index]["HtrID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@barangID", SqlDbType.VarChar, dtDetailDO.Rows[index]["BarangID"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyRequest", SqlDbType.Int, dtDetailDO.Rows[index]["QtyRequest"]));
                    db.Commands[0].Parameters.Add(new Parameter("@qtyDO", SqlDbType.Int, dtDetailDO.Rows[index]["QtyDO"]));
                    db.Commands[0].Parameters.Add(new Parameter("@hrgJual", SqlDbType.Money, dtDetailDO.Rows[index]["HrgJual"]));
                    //db.Commands[0].Parameters.Add(new Parameter("@kodeToko", SqlDbType.VarChar, dtDetailDO.Rows[index]["KodeToko"]));
                    //db.Commands[0].Parameters.Add(new Parameter("@tglSuratJalan", SqlDbType.DateTime, dtDetailDO.Rows[index]["TglSuratJalan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc1", SqlDbType.Decimal, dtDetailDO.Rows[index]["Disc1"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc2", SqlDbType.Decimal, dtDetailDO.Rows[index]["Disc2"]));
                    db.Commands[0].Parameters.Add(new Parameter("@disc3", SqlDbType.Decimal, dtDetailDO.Rows[index]["Disc3"]));
                    db.Commands[0].Parameters.Add(new Parameter("@pot", SqlDbType.Money, dtDetailDO.Rows[index]["Pot"]));
                    db.Commands[0].Parameters.Add(new Parameter("@discFormula", SqlDbType.VarChar, dtDetailDO.Rows[index]["DiscFormula"]));
                    db.Commands[0].Parameters.Add(new Parameter("@noDOBO", SqlDbType.VarChar, noDOBO));
                    db.Commands[0].Parameters.Add(new Parameter("@noACC", SqlDbType.VarChar, dtDetailDO.Rows[index]["NoACC"]));
                    db.Commands[0].Parameters.Add(new Parameter("@catatan", SqlDbType.VarChar, dtDetailDO.Rows[index]["Catatan"]));
                    db.Commands[0].Parameters.Add(new Parameter("@syncFlag", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                dtDetailDO.Rows[index]["NoDOBO"] = noDOBO;
                RefreshDetail(dtDetailDO.Rows[index]["RowID"].ToString(), index, noDOBO.ToString());
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

        private void CekCetakBO()
        {
            if (dataGridDO.SelectedCells[0].OwningRow.Cells["NoDOBO"].Value.ToString() == "")
            {
                MessageBox.Show("DO belum diberi flag BO");
                return;
            }

            if (!CekFlagDetail())
            {
                MessageBox.Show("Tidak ada detail yang memiliki flag BO");
                return;
            }
            CetakBO();
        }

        private void CetakBO()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_cekPrinterAktif"));
                    db.Commands[0].Parameters.Add(new Parameter("@LookupCode", SqlDbType.VarChar, "BACKORDER"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (dt.Rows.Count == 0)
                    PrnAktif = "0";
                else
                    PrnAktif = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


            Guid rowID = (Guid)dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            string boRecID = Tools.CreateFingerPrint();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("rsp_CetakBackOrder"));
                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                    db.Commands[0].Parameters.Add(new Parameter("@BORecID", SqlDbType.VarChar, boRecID));
                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                    dt = db.Commands[0].ExecuteDataTable();
                }
                if (PrnAktif == "0")
                    CetakBORaw(dt);
                else
                    DisplayReport(dt);
                    
                RefresALL();
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

        private string CetakHeaderBO(DataTable dt, int nUrut, int nMaxHal, out int nHlm)
        {

            BuildString header = new BuildString();

            const int RowsPerPage = 16;

            int nHal = (int)Math.Round((nUrut / RowsPerPage) + 0.4, 0) + 1;
            nHlm = nHal;

            string cat1 = dt.Rows[0]["Catatan1"].ToString();
            string cat2 = dt.Rows[0]["Catatan2"].ToString();
            string sales = GetSales();
            string namaToko = dt.Rows[0]["NamaToko"].ToString();
            string cClass = dt.Rows[0]["StsToko"].ToString();
            string TglDO = header.GetDayName(DateTime.Now.DayOfWeek.ToString()) + ", " + DateTime.Now.ToString("dd-MMM-yyyy");
            string DO = dt.Rows[0]["NoDO"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglDO"].ToString()).ToString("dd-MMM-yyyy");
            string noRq = dt.Rows[0]["NoRequest"].ToString() + " " + header.GetDayName(Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).DayOfWeek.ToString()) + ", " + Convert.ToDateTime(dt.Rows[0]["TglRequest"].ToString()).ToString("dd-MMM-yyyy");
            string alamatKirim = header.Alamat(dt.Rows[0]["Alamat"].ToString());
            string nSpace = namaToko.Trim() + header.SPACE(namaToko.Trim().Length + (15 - namaToko.Trim().Length) - 7) + cClass;
            string waktu = dt.Rows[0]["HariKredit"].ToString() + " Hari / ";
            string wilID = dt.Rows[0]["WilID"].ToString().Trim();
            string daerah = header.Daerah(dt.Rows[0]["Daerah"].ToString()) + "(Wil: " + wilID + ") ";
            string kota = header.Kota(dt.Rows[0]["Kota"].ToString());
            string expedisi = dt.Rows[0]["Expedisi"].ToString();
            string namaExpedisi = dt.Rows[0]["NamaExpedisi"].ToString();
            double plafon = double.Parse(dt.Rows[0]["Plafon"].ToString());
            string grade = dt.Rows[0]["Grade"].ToString();

            #region Cetak Header
            header.Initialize();
            header.FontCondensed(false);
            header.FontCPI(12);
            header.PageLLine(33);
            header.LeftMargin(1);
            header.BottomMargin(1);
            header.DoubleHeight(true);
            header.DoubleWidth(true);
            header.PROW(true, 1, "DELIVERY ORDER  (BO)");
            header.DoubleHeight(false);
            header.DoubleWidth(false);
            header.LetterQuality(true);
            header.FontCPI(12);
            header.FontBold(true);
            header.PROW(true, 1, header.Sales(sales));
            header.FontBold(false);
            header.FontItalic(false);
            header.LineSpacing("1/6");
            header.FontItalic(true);
            header.AddCR();
            header.Append(" ");
            header.FontItalic(false);
            header.FontCondensed(true);
            header.PROW(false, 53, header.PrintTopLeftCorner() + header.PrintHorizontalLine(2) + " Pengiriman kepada Toko " + header.PrintHorizontalLine(14) + header.PrintTopRightCorner());
            header.PROW(true, 1, cat1.PadRight(47, ' '));
            header.PROW(false, 51, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontBold(true);
            header.AddCR();
            header.PROW(false, 55, nSpace);
            header.FontBold(false);
            header.FontBold(true);
            header.PROW(true, 1, "TGL.DOBO  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, TglDO);
            header.FontItalic(false);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            //header.FontCondensed(true);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 92, alamatKirim);
            header.FontItalic(false);
            //header.FontCondensed(false);
            header.FontBold(true);
            header.PROW(true, 1, "ASAL D.O  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, DO);
            header.FontItalic(false);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, daerah);
            header.FontItalic(false);
            header.FontBold(true);
            header.PROW(true, 1, "JK.WAKTU  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, waktu + cat2.PadRight(20, ' '));
            header.FontItalic(false);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(40) + header.PrintVerticalLine());
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, kota);
            header.FontItalic(false);
            header.FontBold(true);
            header.PROW(true, 1, "NOMOR RQ. : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, noRq);
            header.FontItalic(false);
            header.PROW(false, 53, header.PrintVerticalLine() + header.SPACE(31) + "Grade:   " + header.PrintVerticalLine());
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 55, "PLAFON :" + plafon.ToString("#,###").PadLeft(14, ' '));
            header.FontItalic(false);
            header.PROW(false, 91, header.STR(2,grade));
            header.FontItalic(false);
            header.FontBold(true);
            header.PROW(true, 1, "EXPEDISI  : ");
            header.FontBold(false);
            header.FontItalic(true);
            header.AddCR();
            header.PROW(false, 13, expedisi + " (" + namaExpedisi + ")");
            header.FontItalic(false);
            header.PROW(false, 53, header.PrintBottomLeftCorner() + header.PrintHorizontalLine(40) + header.PrintBottomRightCorner());
            header.LetterQuality(false);
            //header.FontCondensed(true);
            header.LineSpacing("1/6");
            header.PROW(true, 1, "No. N a m a   B a r a n g                                            RAK   Dipesan            Dikirim             H.Sat.   Disc./Pot. Jml.Net    Stok");
            header.PROW(true, 1, header.PrintDoubleLine(151));
           
            #endregion

            return header.GenerateString();
        }

        private void CetakBORaw(DataTable dt)
        {
            BuildString detail = new BuildString();
            
            const int RowsPerPage = 16;
            int nMaxHal = dt.Rows.Count;
            int nHal = 0;
            int nUrut = 0;
            double x = (nMaxHal / RowsPerPage);
            nMaxHal = nMaxHal % RowsPerPage == 0 ? (int)Math.Round(x, 0) : (int)(nMaxHal / RowsPerPage) + 1;
            detail.Append(CetakHeaderBO(dt, nUrut, nMaxHal, out nHal));

            #region Cetak Detail
            double nJumlah = 0;

            string NamaStok = string.Empty;
            string KodeRak = string.Empty;
            string Satuan = string.Empty;
            string Dikirim = string.Empty;
            string tempQSisa = string.Empty;
            string JumlahDo = string.Empty;
            string HargaJual = string.Empty;
            string HargaNet = string.Empty;
            string JumlahDiskon = string.Empty;
            int QtyDO = 0;
            int QtySuratJalan = 0;

            int QSisa = 0;
            double Net = 0;

            detail.FontCondensed(true);
            foreach (DataRow dr in dt.Rows)
            {
                nUrut++;
                NamaStok = dr["NamaBarang"].ToString().PadRight(65, '.');
                KodeRak = detail.STR(7, dr["KodeRak"].ToString());
                Satuan = detail.STR(3, dr["Satuan"].ToString());
                QtyDO = int.Parse(dr["QtyDO"].ToString());
                QtySuratJalan = int.Parse(Tools.isNull(dr["QtySuratJalan"],"0").ToString());
                Dikirim = nUrut % 2 == 1 ? detail.STR(3, nUrut.ToString()) + ".[_______]             " : detail.STR(16, nUrut.ToString()) + ".[_______]";
                QSisa = int.Parse(Tools.isNull(dr["QtySisa"],"0").ToString());
                Net = double.Parse(Tools.isNull(dr["HrgNet"],"0").ToString());
                JumlahDo = Convert.ToString((QtyDO - QtySuratJalan));
                nJumlah = nJumlah + Net;
                tempQSisa = QSisa == 0 ? "      0" : QSisa.ToString("#,###").PadLeft(7, ' ');
                HargaJual = double.Parse(dr["HrgJual"].ToString()).ToString("#,###");
                HargaNet = double.Parse(dr["HrgNet"].ToString()).ToString("#,###");
                JumlahDiskon = double.Parse(dr["JmlDisc"].ToString()).ToString("#,###");

                JumlahDiskon = string.IsNullOrEmpty(JumlahDiskon) == true ? "0" : JumlahDiskon;

                detail.PROW(true, 1, detail.STR(2, nUrut.ToString()) + ". " + NamaStok + " " + KodeRak + " " + detail.STR(5,JumlahDo) + " " + Satuan + Dikirim + detail.STR(9,HargaJual) + " " + detail.STR(10, JumlahDiskon) + " " + detail.STR(10, HargaNet) + " " + tempQSisa);

                if ((nUrut % RowsPerPage == 0) && (nHal < nMaxHal))
                {
                    detail.PROW(true, 1, detail.PrintDoubleLine(164));
                    detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
                    detail.PROW(true, 1, "");
                    detail.PROW(true, 1, "  (    Bag. Piutang    )          (    Bag. Penjualan    )          (    Bag. Gudang    )        (   Bag. Cheker I   )        (   Bag. Cheker II   )");
                    detail.Eject();
                    detail.Append(CetakHeaderBO(dt, nUrut, nMaxHal, out nHal));
                }
            }
            if (nUrut % RowsPerPage != 0)
            {
                for (int i = nUrut + 1; i <= nUrut + (RowsPerPage - (nUrut % RowsPerPage)); i++)
                {
                    detail.PROW(true, 1, detail.STR(2, i.ToString()) + ". ");
                }
            }
            #endregion

            #region Footer

            detail.PROW(true, 1, detail.PrintDoubleLine(151));
            detail.PROW(true, 1, "A/R-SAS : " + SecurityManager.UserName + ", Tgl." + DateTime.Now.ToString("dd-MMM-yyy") + " Jam " + DateTime.Now.ToShortTimeString());
            detail.DoubleWidth(true);
            detail.FontItalic(true);
            detail.AddCR();
            detail.PROW(false, 43, "Total D.O ");
            detail.PROW(false, 59, "Rp." + nJumlah.ToString("#,###").PadLeft(14, ' '));
            detail.DoubleWidth(false);
            detail.FontItalic(false);
            detail.PROW(true, 1, "  (    Bag. Piutang    )          (    Bag. Penjualan    )          (    Bag. Gudang    )        (   Bag. Cheker I   )        (   Bag. Cheker II   )");
            detail.Eject();
            #endregion

            //detail.SendToPrinter("bo.txt");
            detail.SendToFile("bo.txt");
        }

        private void DisplayReport(DataTable dt)
        {
            string NoDO = dt.Rows[0]["NoDO"].ToString();
            string TglDO = dt.Rows[0]["TglDO"].ToString();
            string NoRQ = dt.Rows[0]["NoRequest"].ToString();
            string TglRQ = dt.Rows[0]["TglRequest"].ToString();
            string Expedisi = dt.Rows[0]["Expedisi"].ToString();
            string NamaToko = dt.Rows[0]["NamaToko"].ToString();
            string Alamat = dt.Rows[0]["Alamat"].ToString();
            string Daerah = dt.Rows[0]["Daerah"].ToString();
            string Kota = dt.Rows[0]["Kota"].ToString();
            string WilID = dt.Rows[0]["WilID"].ToString();

            List<ReportParameter> rptParams = new List<ReportParameter>();
            rptParams.Add(new ReportParameter("UserID", SecurityManager.UserID));
            rptParams.Add(new ReportParameter("Sales", GetSales()));
            rptParams.Add(new ReportParameter("NoDO", NoDO));
            rptParams.Add(new ReportParameter("TglDO", NoDO));
            rptParams.Add(new ReportParameter("NoRQ", NoRQ));
            rptParams.Add(new ReportParameter("TglRQ", TglRQ));
            rptParams.Add(new ReportParameter("Expedisi", Expedisi));
            rptParams.Add(new ReportParameter("NamaToko", NamaToko));
            rptParams.Add(new ReportParameter("Alamat", Alamat));
            rptParams.Add(new ReportParameter("Daerah", Daerah));
            rptParams.Add(new ReportParameter("Kota", Kota));
            rptParams.Add(new ReportParameter("WilID", WilID));


            if (int.Parse(Tools.isNull(PrnAktif, "0").ToString()) > 0)
            {
                frmReportViewer ifrmReport = new frmReportViewer("Penjualan.rptCetakBObaru.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                ifrmReport.Print();
                //ifrmReport.Show();

                if (int.Parse(Tools.isNull(PrnAktif, "0").ToString()) >= 2)
                {
                    ifrmReport = new frmReportViewer("Penjualan.rptCetakBObaru_copy1.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }

                if (int.Parse(Tools.isNull(PrnAktif, "0").ToString()) > 2)
                {
                    ifrmReport = new frmReportViewer("Penjualan.rptCetakBObaru_copy2.rdlc", rptParams, dt, "dsOrderPenjualan_Data");
                    ifrmReport.Print();
                    //ifrmReport.Show();
                }
            }
        }


        private string GetSales()
        {
            string konfersi = " ABCDEFGH1JKLMNOPQRSTUVWXYZ";
            int c1 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang1"].Value.ToString()) % 26;
            int c2 = int.Parse(dataGridDO.SelectedCells[0].OwningRow.Cells["Cabang2"].Value.ToString()) % 26;
            string namaSales = dataGridDO.SelectedCells[0].OwningRow.Cells["NamaSales"].Value.ToString();

            string result = konfersi.Substring(c1-1, 1) + "\\" + konfersi.Substring(c2-1, 1)
                            + "\\" + namaSales;

            return result;
        }

        private void dataGridDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* Do yang sudah di flag BO, NoDO nya tampil dengan warna merah */
            if (dataGridDO.Rows[e.RowIndex].Cells["NoDOBO"].Value.ToString() != "")
                dataGridDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            else
                dataGridDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;


            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //Isi Acak
            double harga = double.Parse(dataGridDO.Rows[e.RowIndex].Cells["RpJual"].Value.ToString());
            double rpPot = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpPot"].Value, 0).ToString());
            double rpNet = double.Parse(Tools.isNull(dataGridDO.Rows[e.RowIndex].Cells["RpNet"].Value, 0).ToString());

            dataGridDO.Rows[e.RowIndex].Cells["RpJualAck"].Value = Tools.GetAntiNumeric(harga.ToString("#,##0"));
            dataGridDO.Rows[e.RowIndex].Cells["RpPotAck"].Value = Tools.GetAntiNumeric(rpPot.ToString("#,##0"));
            dataGridDO.Rows[e.RowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(rpNet.ToString("#,##0"));

        }

        private void dataGridDetailDO_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /* DO detail yang sudah di flag BO, rownya akan tampil dengan warna merah */
            if (dataGridDetailDO.Rows[e.RowIndex].Cells["DetailNoDOBO"].Value.ToString() != "")
                dataGridDetailDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            else
                dataGridDetailDO.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;


            double HrgBMK = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["HrgBMK"].Value, 0).ToString());
            double HrgJual = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["HrgJual"].Value, 0).ToString());
            double JmlHarga = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHarga"].Value, 0).ToString());
            double Pot = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["Pot"].Value, 0).ToString());
            double JmlPot = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["JmlPot"].Value, 0).ToString());
            double HrgNet = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["HrgNet"].Value, 0).ToString());
            double HPPSolo = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["HPPSolo"].Value, 0).ToString());
            double JmlHPP = double.Parse(Tools.isNull(dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHPP"].Value, 0).ToString());

            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgBMKAck"].Value = Tools.GetAntiNumeric(HrgBMK.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(HrgJual.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHargaAck"].Value = Tools.GetAntiNumeric(JmlHarga.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["PotAck"].Value = Tools.GetAntiNumeric(Pot.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlPotAck"].Value = Tools.GetAntiNumeric(JmlPot.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgNetAck"].Value = Tools.GetAntiNumeric(HrgNet.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["HPPSoloAck"].Value = Tools.GetAntiNumeric(HPPSolo.ToString("#,##0"));
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHPPAck"].Value = Tools.GetAntiNumeric(JmlHPP.ToString("#,##0"));

            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgBMKAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHargaAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["PotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlPotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["HPPSoloAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetailDO.Rows[e.RowIndex].Cells["JmlHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AcakTampilHrg()
        {
            bool normal = true;
            dataGridDO.Columns["RpJual"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpPot"].DefaultCellStyle.Format = "#,##0";
            dataGridDO.Columns["RpNet"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgBMK"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgJual"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlHarga"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["Pot"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlPot"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HrgNet"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["HPPSolo"].DefaultCellStyle.Format = "#,##0";
            dataGridDetailDO.Columns["JmlHPP"].DefaultCellStyle.Format = "#,##0";

            normal = !_acak;
            dataGridDO.Columns["RpJual"].Visible = _acak;
            dataGridDO.Columns["RpPot"].Visible = _acak;
            dataGridDO.Columns["RpNet"].Visible = _acak;
            dataGridDetailDO.Columns["HrgBMK"].Visible = _acak;
            dataGridDetailDO.Columns["HrgJual"].Visible = _acak;
            dataGridDetailDO.Columns["JmlHarga"].Visible = _acak;
            dataGridDetailDO.Columns["Pot"].Visible = _acak;
            dataGridDetailDO.Columns["JmlPot"].Visible = _acak;
            dataGridDetailDO.Columns["HrgNet"].Visible = _acak;
            dataGridDetailDO.Columns["HPPSolo"].Visible = _acak;
            dataGridDetailDO.Columns["JmlHPP"].Visible = _acak;

            //acak
            dataGridDO.Columns["RpJualAck"].Visible = normal;
            dataGridDO.Columns["RpPotAck"].Visible = normal;
            dataGridDO.Columns["RpNetAck"].Visible = normal;
            dataGridDetailDO.Columns["HrgBMKAck"].Visible = normal;
            dataGridDetailDO.Columns["HrgJualAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlHargaAck"].Visible = normal;
            dataGridDetailDO.Columns["PotAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlPotAck"].Visible = normal;
            dataGridDetailDO.Columns["HrgNetAck"].Visible = normal;
            dataGridDetailDO.Columns["HPPSoloAck"].Visible = normal;
            dataGridDetailDO.Columns["JmlHPPAck"].Visible = normal;
            _acak = normal;
            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            JmlHrgTot = 0;
            JmlPotTot = 0;
            HrgNetTot = 0;
            JmlHPPTot = 0;
            if (dataGridDetailDO.RowCount > 0)
            {
                if (dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHrgTot = 0;
                }
                else
                {
                    JmlHrgTot = double.Parse(dtDetailDO.Compute("SUM(JmlHrg)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlPotTot = 0;
                }
                else
                {
                    JmlPotTot = double.Parse(dtDetailDO.Compute("SUM(JmlPot)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString().Equals(string.Empty))
                {
                    HrgNetTot = 0;
                }
                else
                {
                    HrgNetTot = double.Parse(dtDetailDO.Compute("SUM(HrgNet)", string.Empty).ToString());
                }
                if (dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString().Equals(string.Empty))
                {
                    JmlHPPTot = 0;
                }
                else
                {
                    JmlHPPTot = double.Parse(dtDetailDO.Compute("SUM(JmlHPP)", string.Empty).ToString());
                }
            }
            if (_acak)
            {
                txtJumlahHarga2.Text = Tools.GetAntiNumeric(JmlHrgTot.ToString("#,##0"));
                txtJumlahPotongan2.Text = Tools.GetAntiNumeric(JmlPotTot.ToString("#,##0"));
                txtHargaNett2.Text = Tools.GetAntiNumeric(HrgNetTot.ToString("#,##0"));
                txtJumlahHPP2.Text = Tools.GetAntiNumeric(JmlHPPTot.ToString("#,##0"));
            }
            else
            {
                txtJumlahHarga2.Text = JmlHrgTot.ToString("#,##0");
                txtJumlahPotongan2.Text = JmlPotTot.ToString("#,##.00");
                txtHargaNett2.Text = HrgNetTot.ToString("#,##0");
                txtJumlahHPP2.Text = JmlHPPTot.ToString("#,##0");
            }       
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolTipButton1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(helpToolTipButton1, toolTip1.GetToolTip(helpToolTipButton1));
        }

        private void RefreshHeader(string rowID_,int index, string nodobo_)
        {
            FindHeader("RowID", rowID_);
            dataGridDO.SelectedCells[0].OwningRow.Cells["NoDOBO"].Value = nodobo_;
            this.dataGridDO.Refresh();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridDO.FindRow(columnName, value);
        }

        private void RefreshDetail(string rowID_, int index, string nodobo_)
        {
            FindDetail("DetailRowID", rowID_);
            dataGridDetailDO.SelectedCells[0].OwningRow.Cells["DetailNoDOBO"].Value = nodobo_;
            this.dataGridDetailDO.Refresh();
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetailDO.FindRow(columnName, value);
        }

        private void RefresALL()
        {
            if (dataGridDetailDO.RowCount>0 && dataGridDO.RowCount>0)
            {
                //Lepas Header
                dataGridDO.SelectedCells[0].OwningRow.Cells["NoDOBO"].Value = string.Empty;
                for (int i = 0; i < dataGridDetailDO.RowCount; i++)
                {
                    if (dataGridDetailDO.Rows[i].Cells["DetailNoDOBO"].Value.ToString() != "")
                    {
                        dataGridDetailDO.Rows[i].Cells["DetailNoDOBO"].Value = string.Empty;
                    }
                }

                this.dataGridDO.RefreshEdit();
                this.dataGridDetailDO.RefreshEdit();
            }
        }

        private void dataGridDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDO.SelectedCells.Count > 0)
            {
                RefreshDataDetailDO();
                lblToko.Text = "\"" + dataGridDO.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString() + "\" "
                    + dataGridDO.SelectedCells[0].OwningRow.Cells["AlamatKirim"].Value.ToString();
                _rowID = dataGridDO.SelectedCells[0].OwningRow.Cells["RowID"].Value.ToString();
            }
            else
            {
                lblToko.Text = " ";
            }
        }

        private void dataGridDetailDO_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridDetailDO.SelectedCells.Count > 0)
            {
                lblBarang.Text = "\"" + dataGridDetailDO.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString() + "\""; ;
            }
            else
            {
                lblBarang.Text = " ";
            }
        }

        private void dataGridDetailDO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rgbTglDO_Load(object sender, EventArgs e)
        {

        }
    }
}
