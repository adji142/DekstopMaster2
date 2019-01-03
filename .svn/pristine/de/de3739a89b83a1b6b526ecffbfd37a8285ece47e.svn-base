using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;
using ISA.Toko.Class;

namespace ISA.Toko.Kasir
{
    public partial class frmPembelianTunai : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        DataTable dtDetail;
        DateTime _fromDate, _toDate;
        bool _acak = true;
        int _prefGrid = 0;
        public frmPembelianTunai()
        {
            InitializeComponent();
        }

        private void frmPembelianTunai_Load(object sender, EventArgs e)
        {
            this.Title = "Pembelian Tunai";
            this.Text = "Pembelian"; 
            lblNamaBarang.Text = "";
            AcakTampilTextBox();
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _toDate = DateTime.Now;
            rgbTglNota.FromDate = _fromDate;
            rgbTglNota.ToDate = _toDate;
            rgbTglNota.Focus();
            AcakTampilHrg();
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataNotaBeli();
            dataGridHeader.Focus();
        }

        private void rgbTglNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        public void RefreshDataNotaBeli()
        {
            _fromDate = (DateTime)rgbTglNota.FromDate;
            _toDate = (DateTime)rgbTglNota.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_PembelianTunai_LIST]"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridDetail.DataSource = null;
                    AcakTampilTextBox();
                }
                else
                {
                    //RefreshDataNotaBeliDetail();
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

        public void RefreshDataNotaBeliByID(string ID)
        {
            _fromDate = (DateTime)rgbTglNota.FromDate;
            _toDate = (DateTime)rgbTglNota.ToDate;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, _fromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, _toDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridDetail.DataSource = null;
                    AcakTampilTextBox();
                }
                else
                {
                    dataGridHeader.FindRow("HeaderRowID", ID);
                    //RefreshDataNotaBeliDetail();
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

        public void RefreshDataNotaBeliDetail()
        {
            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;

            Guid headerIDOpd = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["RowIDop"].Value;
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    db.Commands[0].Parameters.Add(new Parameter("@headerIDOpd", SqlDbType.UniqueIdentifier, headerIDOpd));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridDetail.DataSource = dtDetail;
                }

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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
            _prefGrid = 1;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
            _prefGrid = 2;
        }

        private void dataGridDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Space:
                    cmdLink.PerformClick();
                    break;
                case Keys.Tab:
                    dataGridHeader.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _rpBeli = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Value.ToString());
            double _rpNet = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Value.ToString());
            
            dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Style.Format = "#,##0";
            dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Style.Format = "#,##0";
            dataGridHeader.Rows[e.RowIndex].Cells["RpTerimaBarang"].Style.Format = "#,##0";

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Value = Tools.GetAntiNumeric(_rpBeli.ToString("#,##0"));
            dataGridHeader.Rows[e.RowIndex].Cells["RpNetAck"].Value = Tools.GetAntiNumeric(_rpNet.ToString("#,##0"));

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["RpNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridHeader.Rows[e.RowIndex].Cells["RpTerimaBarang"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dataGridHeader.Rows[e.RowIndex].Cells["SyncFlag"].Value.ToString() == "True")
            {
                dataGridHeader.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _hrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Value.ToString());
            double _jmlHrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeli"].Value.ToString());
            double _hpp = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HPP"].Value.ToString());
            double _jmlHPP = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHPP"].Value.ToString());

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["HPP"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPP"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlhTerima"].Style.Format = "#,##0";

            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value = Tools.GetAntiNumeric(_hrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeliAck"].Value = Tools.GetAntiNumeric(_jmlHrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["HPPAck"].Value = Tools.GetAntiNumeric(_hpp.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Value = Tools.GetAntiNumeric(_jmlHPP.ToString("#,##0"));
            
            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["HPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHPPAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDetail.Rows[e.RowIndex].Cells["JmlhTerima"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //if (dataGridDetail.Columns[e.ColumnIndex].Name.Equals("Koreksi"))
            //{
            //    if ((int)dataGridDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == 1)
            //    {
            //        dataGridDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            //    }
            //}
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["RpBeli"].Visible = !_acak;
            dataGridHeader.Columns["RpNet"].Visible = !_acak;            
            dataGridDetail.Columns["HrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["JmlHrgBeli"].Visible = !_acak;
            //dataGridDetail.Columns["HPP"].Visible = !_acak;
            dataGridDetail.Columns["JmlHPP"].Visible = !_acak;

            dataGridHeader.Columns["RpBeliAck"].Visible = _acak;
            dataGridHeader.Columns["RpNetAck"].Visible = _acak;
            dataGridDetail.Columns["HrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHrgBeliAck"].Visible = _acak;
            //dataGridDetail.Columns["HPPAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHPPAck"].Visible = _acak;

            AcakTampilTextBox();
        }

        private void AcakTampilTextBox()
        {
            double total = 0;
            double total2 = 0;

            if (dataGridDetail.RowCount > 0)
            {
                total = double.Parse(dtDetail.Compute("SUM(JmlHrgBeli)", string.Empty).ToString());
                total2 = double.Parse(dtDetail.Compute("SUM(JmlhHargaBeli)", string.Empty).ToString());
            }

            if (_acak)
            {
                txtTotJmlHrgBeli.Text = Tools.GetAntiNumeric(total.ToString("#,##0"));
                txtTotJmlHPP.Text = Tools.GetAntiNumeric(total2.ToString("#,##0"));
            }
            else
            {
                txtTotJmlHrgBeli.Text = total.ToString("#,##0");
                txtTotJmlHPP.Text = total2.ToString("#,##0"); 
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

        public void FindHeader(string columnName, string value)
        {
            dataGridHeader.FindRow(columnName, value);
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridDetail.FindRow(columnName, value);
        }

        private void dataGridHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridDetail_Validated(object sender, EventArgs e)
        {
            
           
        }

        private void dataGridHeader_Validated(object sender, EventArgs e)
        {
            if (dataGridHeader.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
            
           
        }

        private void dataGridDetail_TabIndexChanged(object sender, EventArgs e)
        {
            //if (dataGridDetail.Focused == false)
            //{
            //    selectedGrid = enumSelectedGrid.HeaderSelected;
            //}
        }

        private void dataGridDetail_Leave(object sender, EventArgs e)
        {
            if (_prefGrid==1 && selectedGrid!=enumSelectedGrid.HeaderSelected)
            {
                dataGridHeader.Focus();
                selectedGrid = enumSelectedGrid.HeaderSelected;
            }
        }

        private void cetakMemoKomplain(DataTable dt)
        {
            
            BuildString komplain = new BuildString();
            komplain.LeftMargin(3);
            foreach(DataRow dr in dt.Rows)
            {
                komplain.FontCondensed(false);
                komplain.FontBold(true);
                komplain.FontCPI(20);
                komplain.PROW(true, 1, "MEMO KOMPLAIN PEMBELIAN 0000");
                komplain.PROW(true, 1, "");
                komplain.FontCondensed(true);
                komplain.FontBold(false);

                komplain.PROW(true, 1, "No. Nota".PadRight(20) + dr["NoNota"].ToString().PadRight(40) + "Tanggal Nota".PadRight(20) +
                    string.Format("{0:dd-MMM-yyyy}", dr["TglNota"]));

                komplain.PROW(true, 1, "Pemasok".PadRight(20) + dr["pemasok"].ToString().PadRight(40) + "Tanggal Terima".PadRight(20) +
                    string.Format("{0:dd-MMM-yyyy}", dr["TglTerima"]));

                komplain.PROW(true,1,komplain.PrintHorizontalLine(130));


                //Tabel QTY
                komplain.PROW(true, 1, "Qty");

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(44) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(44, "QTY") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(83,"Nama Barang") + komplain.PrintTLeft() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + 
                    komplain.PrintHorizontalLine(14)+komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(14, "Nota") + komplain.PrintVerticalLine() + komplain.PadCenter(14, "Terima") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(14, "Selisih") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(83) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + dr["NamaStok"].ToString().PadRight(83) + komplain.PrintVerticalLine() +
                    dr["QtyNota"].ToString().PadLeft(14) + komplain.PrintVerticalLine() + dr["QtySuratJalan"].ToString().PadLeft(14)
                    + komplain.PrintVerticalLine() + dr["selisih"].ToString().PadLeft(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintBottomRightCorner());

                //Tabel koli
                komplain.PROW(true, 1, "KOLI");

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(44) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(44, "Koli") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(83, "Nama Barang") + komplain.PrintTLeft() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(14) + komplain.PrintTTOp() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.PadCenter(14, "Nota") + komplain.PrintVerticalLine() + komplain.PadCenter(14, "Terima") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(14, "Selisih") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(83) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(14) + komplain.PrintTMidlle() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + dr["NamaStok"].ToString().PadRight(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)+ komplain.PrintVerticalLine() + 
                    komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(83) + komplain.PrintVerticalLine() +
                    komplain.SPACE(14) + komplain.PrintVerticalLine() + komplain.SPACE(14)
                    + komplain.PrintVerticalLine() + komplain.SPACE(14) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(83) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(14) + komplain.PrintTBottom() +
                    komplain.PrintHorizontalLine(14) + komplain.PrintBottomRightCorner());

                //Kolom Tanda Tangan

                komplain.PROW(true, 1, komplain.PrintTopLeftCorner() + komplain.PrintHorizontalLine(42) + komplain.PrintTTOp()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTTOp() + komplain.PrintHorizontalLine(42) + komplain.PrintTopRightCorner());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.PadCenter(42,"Penghitung, Mengajukan") + komplain.PrintVerticalLine()
                    + komplain.PadCenter(42,"Ka. Gudang, Menyetujui") + komplain.PrintVerticalLine() + 
                    komplain.PadCenter(42,"Accounting, Mengetahui") + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(42) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());
                komplain.PROW(true, 1, komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine()
                    + komplain.SPACE(42) + komplain.PrintVerticalLine() + komplain.SPACE(42) + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintTLeft() + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTMidlle() + komplain.PrintHorizontalLine(42) + komplain.PrintTRight());

                komplain.PROW(true, 1, komplain.PrintVerticalLine() + "("+komplain.SPACE(40)+")" + komplain.PrintVerticalLine()
                    + "(" + komplain.SPACE(40) + ")" + komplain.PrintVerticalLine() + "(" + komplain.SPACE(40) + ")" + komplain.PrintVerticalLine());

                komplain.PROW(true, 1, komplain.PrintBottomLeftCorner() + komplain.PrintHorizontalLine(42) + komplain.PrintTBottom()
                    + komplain.PrintHorizontalLine(42) + komplain.PrintTBottom() + komplain.PrintHorizontalLine(42) + komplain.PrintBottomRightCorner());

                komplain.PROW(true, 1, string.Format("{0:dd-MMM-yyyy-hh-mm-ss}", DateTime.Now) + ", " + SecurityManager.UserID);
                komplain.Eject();
            }
            komplain.SendToPrinter("memokomplainpembelian.txt");
        }

        private void dataGridDetail_Validating(object sender, CancelEventArgs e)
        {
            if (dataGridDetail.Focused == true)
            {
                selectedGrid = enumSelectedGrid.DetailSelected;
                _prefGrid = 2;
            }
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                    RefreshDataNotaBeliDetail();
            }
        }

        private void dataGridDetail_SelectionRowChanged(object sender, EventArgs e)
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

        private void dataGridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtInit_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridDetail_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridDetail.Rows)
            {
                string status = dgvr.Cells["Koreksi"].Value.ToString();
                if (status == "1")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void dataGridDetail_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridDetail.Rows)
            {
                string status = dgvr.Cells["Koreksi"].Value.ToString();
                if (status == "1")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void cmdLink_Click(object sender, EventArgs e)
        {
            if (dataGridDetail.Rows.Count > 0)
            {
                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Barang belum diterima");
                    return;
                }

                Double _qtyTerima = Double.Parse(dataGridDetail.SelectedCells[0].OwningRow.Cells["QtySuratJalan"].Value.ToString());

                if (_qtyTerima <= 0)
                {
                    MessageBox.Show("Qty terima harus lebih besar dari 0");
                    return;
                }

                if (dataGridHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString() == "True")
                {
                    MessageBox.Show("Sudah di buat BKK");
                    return;
                }

                Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                string _uraian = "No Nota Pembelian : " +dataGridHeader.SelectedCells[0].OwningRow.Cells["NoNota"].Value.ToString();
                string _nominal = dataGridHeader.SelectedCells[0].OwningRow.Cells["RpNet"].Value.ToString();
                Kasir.frmBKKUpdate bkkupdate = new Kasir.frmBKKUpdate(this, _uraian, _nominal, headerID);
                bkkupdate.ShowDialog();



            }
        }

       
    }
}
