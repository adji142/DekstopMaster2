using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Pembelian
{
    public partial class frmBrgDiterimaSupplierBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtDetail;
        string _format;
        bool _acak = true;

        public frmBrgDiterimaSupplierBrowser()
        {
            InitializeComponent();
        }

        private void frmBrgDiterimaSupplierBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Barang diterima Supplier";
            this.Text = "Retur Pembelian";
            lblNamaBarang.Text = "";
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglMPR.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglMPR.ToDate = DateTime.Now;
            rgbTglMPR.Focus();
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataReturBeli();
        }

        private void rgbTglMPR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataReturBeli()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglMPR.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglMPR.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    dataGridHeader.DataSource = dtHeader;
                }
                if (dataGridHeader.Rows.Count == 0)
                {
                    dataGridDetail.DataSource = null;
                    lblNamaBarang.Text = "";
                    AcakTampilTextBox();
                }
                else
                {
                    RefreshDataReturBeliDetail();
                    dataGridHeader.Focus();
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

        public void RefreshDataReturBeliDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_ReturPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                }
                dataGridDetail.DataSource = dtDetail;

                if (dtDetail.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                }
                else
                {
                    lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
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

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["ReturID"].Value.ToString().Substring(0, 3) !=
                    GlobalVar.PerusahaanID)
                {
                    MessageBox.Show("Hanya untuk cabang " + GlobalVar.PerusahaanID);
                    return;
                }
                //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRetur"].Value.ToString() != '')
                //{
                //    ***ASK PASSWORD MNGR***
                //}
                Guid rowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                Pembelian.frmBrgDiterimaSupplierUpdate ifrmChild = new Pembelian.frmBrgDiterimaSupplierUpdate(this, rowID);
                ifrmChild.MdiParent = Program.MainForm;
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.Show();
            }
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void dataGridDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
            }
            else
            {
                lblNamaBarang.Text = "";
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    selectedGrid = enumSelectedGrid.DetailSelected;
                    dataGridDetail.Focus();
                    break;
            }
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.F11:
                    // koreksi penjualan
                    if (!SecurityManager.IsAuditor())
                    {
                        KoreksiReurBeli();
                    }
                    break;
                case Keys.Tab:
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    dataGridHeader.Focus();
                    break;
            }
        }

        private void KoreksiReurBeli()
        {
            if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeGudang"].Value.ToString() != GlobalVar.Gudang)
            {
                MessageBox.Show("Hanya untuk gudang " + GlobalVar.Gudang);
                return;
            }
            if(dataGridHeader.SelectedCells[0].OwningRow.Cells["TglRetur"].Value.ToString()=="")
            {
                MessageBox.Show("Barang Belum diterima supplier, tidak bisa dikoreksi");
                return;
            }
            Guid rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
            Pembelian.frmKoreksiReturBeliBrowser ifrmChild = new Pembelian.frmKoreksiReturBeliBrowser(rowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _niliaRetur = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Value.ToString());

            dataGridHeader.Rows[e.RowIndex].Cells["NilaiRetur"].Style.Format = "#,##0";

            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Value = Tools.GetAntiNumeric(_niliaRetur.ToString("#,##0"));

            dataGridHeader.Rows[e.RowIndex].Cells["NilaiReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _hrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Value.ToString());
            double _jmlHrgRetur = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgRetur"].Value.ToString());
            double _pot = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["Pot"].Value.ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgRetur"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["Pot"].Style.Format = "#,##0";

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value = Tools.GetAntiNumeric(_hrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgReturAck"].Value = Tools.GetAntiNumeric(_jmlHrgRetur.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["PotAck"].Value = Tools.GetAntiNumeric(_pot.ToString("#,##0"));

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgReturAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["PotAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["NilaiRetur"].Visible = !_acak;
            dataGridDetail.Columns["HrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["JmlHrgRetur"].Visible = !_acak;
            dataGridDetail.Columns["Pot"].Visible = !_acak;
            
            dataGridHeader.Columns["NilaiReturAck"].Visible = _acak;
            dataGridDetail.Columns["HrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHrgReturAck"].Visible = _acak;
            dataGridDetail.Columns["PotAck"].Visible = _acak;

            AcakTampilTextBox();

        }

        private void AcakTampilTextBox()
        {
            double nilaiRetur = 0;
            double totPot = 0;

            if (dataGridDetail.RowCount > 0)
            {
                nilaiRetur = double.Parse(dtDetail.Compute("SUM(JmlHrgRetur)", string.Empty).ToString());
                totPot = double.Parse(dtDetail.Compute("SUM(Pot)", string.Empty).ToString()); 
            }

            if (_acak)
            {
                txtNilaiRetur.Text = Tools.GetAntiNumeric(nilaiRetur.ToString("#,##0"));
                txtTotalPot.Text = Tools.GetAntiNumeric(totPot.ToString("#,##0"));
            }
            else
            {
                txtNilaiRetur.Text = nilaiRetur.ToString("#,##0");
                txtTotalPot.Text = totPot.ToString("#,##0");
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                RefreshDataReturBeliDetail();
            }
        }
    }
}
