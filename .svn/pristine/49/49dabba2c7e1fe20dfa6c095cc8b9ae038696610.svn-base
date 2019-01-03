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
    public partial class frmNotaBeliBrowser : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        string _format;
        bool _acak = true;

        public frmNotaBeliBrowser()
        {
            InitializeComponent();
        }

        private void frmNotaBeliBrowser_Load(object sender, EventArgs e)
        {
            this.Title = "Nota Pembelian";
            this.Text = "Pembelian";
            lblNamaBarang.Text = "";
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            rgbTglNota.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglNota.ToDate = DateTime.Now;
            rgbTglNota.Focus();
            //txtInit.Text = GlobalVar.PerusahaanID;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataNotaBeli();
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtHeader = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglNota.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglNota.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
                if (dtHeader.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridDetail.DataSource = null;
                }
                else
                {
                    RefreshDataNotaBeliDetail();
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDetail = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, headerID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dataGridDetail.DataSource = dtDetail;
                }

                if (dtDetail.Rows.Count == 0)
                {
                    lblNamaBarang.Text = "";
                    dataGridHeader.SelectedCells[0].OwningRow.Cells["RpBeli"].Value = 0;
                }
                else
                {
                    lblNamaBarang.Text = dataGridDetail.SelectedCells[0].OwningRow.Cells["NamaBarang"].Value.ToString();
                    dataGridHeader.SelectedCells[0].OwningRow.Cells["RpBeli"].Value = dtDetail.Compute("SUM(JmlHrgBeli)", string.Empty);
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

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void cmdADD_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected: InputHeader(Class.Enums.enumClsState.New); break;
                case enumSelectedGrid.DetailSelected:
                    {
                        if (!CekAddEditDel())
                        {
                            return;
                        }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value;
                            if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            Guid headerID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                            Pembelian.frmNotaBeliDetailUpdate ifrmChild =new Pembelian.frmNotaBeliDetailUpdate(this, headerID, frmNotaBeliDetailUpdate.enumFormMode.New);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();

                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }

                    }
                    break;
            }
        }

        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.HeaderSelected: InputHeader(Class.Enums.enumClsState.Update); break;
                //if (selectedGrid == enumSelectedGrid.DetailSelected)
                case enumSelectedGrid.DetailSelected:
                    {
                        if (!CekAddEditDel())
                        {
                            return;
                        }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value;
                            if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            Guid rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                            Pembelian.frmNotaBeliDetailUpdate ifrmChild =
                                new Pembelian.frmNotaBeliDetailUpdate(this, rowID, frmNotaBeliDetailUpdate.enumFormMode.Update);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }

                    }
                    break;
            }
        }

        private void cmdDELETE_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.DetailSelected)
            {
                if (!CekAddEditDel())
                {
                    return;
                }

                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                        Guid rowID = (Guid)dataGridDetail.SelectedCells[0].OwningRow.Cells["DetailRowID"].Value;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianDetail_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowID));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                        RefreshDataNotaBeliDetail();
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

            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                if (!CekAddEditDel())
                {
                    return;
                }
                if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        GlobalVar.LastClosingDate = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value;
                        if ((DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["TglNota"].Value <= GlobalVar.LastClosingDate)
                        {
                            throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                        }
                        this.Cursor = Cursors.WaitCursor;
                        Guid rowIDHeader = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        using (Database db = new Database())
                        {
                            db.Commands.Add(db.CreateCommand("usp_NotaPembelianHeader_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, rowIDHeader));
                            db.Commands[0].ExecuteNonQuery();
                        }
                        MessageBox.Show("Record telah dihapus");
                        RefreshDataNotaBeli();
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

        private bool CekAddEditDel()
        {
            bool result = true;

            try
            {
                //if (dataGridDetail.SelectedCells.Count == 0)
                //{
                //    MessageBox.Show(Messages.Error.RowNotSelected);
                //    result = false;
                //    goto Selesai;
                //}

                //if (dataGridDetail.SelectedCells[0].OwningRow.Cells["KodeGudang"].Value.ToString() != GlobalVar.Gudang)
                //{
                //    MessageBox.Show("Hanya untuk gudang " + GlobalVar.Gudang);
                //    result = false;
                //    goto Selesai;                
                //}

                // Bila sudah diterima gudang, nota tidak dapat apa2kan lagi
                if (dataGridHeader.SelectedCells.Count <= 0) MessageBox.Show("Tidak ada data yang dipilih.");
                //else 
                //if (dataGridHeader.SelectedCells[0].OwningRow.Cells["TglTerima"].Value.ToString() != "")
                //{
                //    MessageBox.Show("Sudah diterima gudang");
                //    result = false;
                //    goto Selesai;
                //}

                /*if (syncFlag == 1)
                {
                    ask password manager
                }*/
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

            goto Selesai;

            Selesai:
            return result;
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
                case Keys.Tab:
                    dataGridDetail.Focus();
                    selectedGrid = enumSelectedGrid.DetailSelected;
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
                case Keys.Tab:
                    dataGridHeader.Focus();
                    selectedGrid = enumSelectedGrid.HeaderSelected;
                    break;
            }
        }

        private void dataGridHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _rpBeli = double.Parse(dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Value.ToString());

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeli"].Style.Format = "#,##0";

            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Value = Tools.GetAntiNumeric(_rpBeli.ToString("#,##0"));
            
            dataGridHeader.Rows[e.RowIndex].Cells["RpBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridHeader.Rows[e.RowIndex].Cells["RpNet"].Style.Format = _format;
        }

        private void dataGridDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double _hrgBeli = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Value.ToString());
            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeli"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Value = Tools.GetAntiNumeric(_hrgBeli.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["HrgBeliAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            double _jmlHrgNet = double.Parse(dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgNet"].Value.ToString());
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgNet"].Style.Format = "#,##0";
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgNetAck"].Value = Tools.GetAntiNumeric(_jmlHrgNet.ToString("#,##0"));
            dataGridDetail.Rows[e.RowIndex].Cells["JmlHrgNetAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridHeader.Columns["RpBeli"].Visible = !_acak;
            dataGridDetail.Columns["HrgBeli"].Visible = !_acak;
            dataGridDetail.Columns["JmlHrgNet"].Visible = !_acak;

            dataGridHeader.Columns["RpBeliAck"].Visible = _acak;
            dataGridDetail.Columns["HrgBeliAck"].Visible = _acak;
            dataGridDetail.Columns["JmlHrgNetAck"].Visible = _acak;
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

        void InputHeader(Class.Enums.enumClsState tstate)
        {
            try
            {
                Guid g = Guid.Empty; 
                switch (tstate)
                {
                    case Class.Enums.enumClsState.New:
                        g = Guid.NewGuid();
                        break;
                    case Class.Enums.enumClsState.Update:
                        if (dataGridHeader.SelectedCells.Count > 0)
                        {
                            g = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["HeaderRowID"].Value;
                        }
                        break;
                }

                if (g != null && g != Guid.Empty)
                {
                    frmNotaBeliInput frmH = new frmNotaBeliInput(tstate, g);
                    frmH.FormClosed += new FormClosedEventHandler(frmH_FormClosed);
                    frmH.MdiParent = this.MdiParent;
                    frmH.Show();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        void frmH_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmNotaBeliInput f = (frmNotaBeliInput)sender;
                if (f.DialogResult == DialogResult.OK)
                {
                    RefreshDataNotaBeli();
                    dataGridHeader.FindRow("HeaderRowID", f.RowID.ToString());
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdAddv2_Click(object sender, EventArgs e)
        {
            Pembelian.frmNotaBeliUpdate ifrmChild = new Pembelian.frmNotaBeliUpdate(this);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }
    }
}
