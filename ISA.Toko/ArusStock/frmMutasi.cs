using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Toko;

namespace ISA.Toko.ArusStock
{
    public partial class frmMutasi : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        enum enumSelectedGrid { MutasiHeaderSelected, MutasiDetailSelected };
        enumSelectedGrid selectedGrid;

        //Punya Header
        Guid _rowID;
        string _MutasiID, _NomorMutasi, _Keterangan, _Type;
        DateTime _tglMutasi;

        //BuatDetail    _HeaderIDD=_rowID
        Guid _rowIDD, _HeaderIDD;
        DataTable dtMutasi = new DataTable();

        public void FillHeader()
        {   
            _tglMutasi = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
            _rowID = (Guid)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            _MutasiID = this.dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiID"].Value.ToString();
            _NomorMutasi = this.dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["NomorMutasi"].Value.ToString();
            _Type = this.dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["Type"].Value.ToString();
            _Keterangan = this.dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["KeteranganMutasi"].Value.ToString();
        }

        public void FillDetail()
        {
            _rowIDD = (Guid)dataGridMutasiDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
            _HeaderIDD = _rowID;
           
        }

        public void RefreshDataMutasi()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                   
                    db.Commands.Add(db.CreateCommand("usp_Mutasi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dtMutasi = db.Commands[0].ExecuteDataTable();
                    this.dataGridMutasiHeader.DataSource = dtMutasi;

                    if (dataGridMutasiHeader.RowCount > 0)
                    {
                        txtTotalPlus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiPlus"].Value.ToString();
                        txtTotalMinus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiMinus"].Value.ToString();
                    }
                }
                if (this.dataGridMutasiHeader.SelectedCells.Count > 0)
                {
                    RefreshDataMutasiDetail();
                }
                else
                {
                    this.dataGridMutasiDetail.DataSource = null;
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

        public void RefreshDataMutasiDetail()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {

                    DataTable dtMutasiDetail = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_MutasiDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier,_rowID));

                    dtMutasiDetail = db.Commands[0].ExecuteDataTable();
                    this.dataGridMutasiDetail.DataSource = dtMutasiDetail;

                    if (dataGridMutasiDetail.RowCount > 0)
                    {
                        lblNamaStok.Text = dataGridMutasiDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
                    }
                    else
                    {
                        lblNamaStok.Text = string.Empty;
                    }
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

        public frmMutasi()
        {
            InitializeComponent();
        }

        private void frmMutasi_Load(object sender, EventArgs e)
        {
            this.dataGridMutasiHeader.AutoGenerateColumns = false;
            this.dataGridMutasiDetail.AutoGenerateColumns = false;
            selectedGrid = enumSelectedGrid.MutasiHeaderSelected;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtInit.Text = GlobalVar.PerusahaanID;
            rgbTglDO.ToDate = DateTime.Now;
        }

        private void dataGridMutasiHeader_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.MutasiHeaderSelected;
            if (this.dataGridMutasiHeader.Rows.Count > 0)
            {
                FillHeader();
            }
            if (dataGridMutasiHeader.RowCount > 0)
            {
                txtTotalPlus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiPlus"].Value.ToString();
                txtTotalMinus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiMinus"].Value.ToString();
            }
        }

        private void dataGridMutasiDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.MutasiDetailSelected;
            if (this.dataGridMutasiDetail.Rows.Count > 0)
            {
                FillDetail();
            }
            if (dataGridMutasiDetail.RowCount > 0)
            {
                lblNamaStok.Text = dataGridMutasiDetail.SelectedCells[0].OwningRow.Cells["NamaStok"].Value.ToString();
            }
            else
            {
                lblNamaStok.Text = string.Empty;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDataMutasi();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.MutasiDetailSelected:
                    if (this.dataGridMutasiHeader.SelectedCells.Count > 0)
                    {
                        string typeMutasi= string.Empty;
                        if (dataGridMutasiHeader.RowCount > 0)
                        {
                            typeMutasi = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["Type"].Value.ToString().Trim();
                        }
                        FillHeader();
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
                            if ((DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            ArusStock.frmUpdateMutasiDetail ifrmChild = new ArusStock.frmUpdateMutasiDetail(this, _rowID, _MutasiID, typeMutasi);
                            ifrmChild.MdiParent = Program.MainForm;
                            Program.MainForm.RegisterChild(ifrmChild);
                            ifrmChild.Show();
                        }
                        catch (Exception ex)
                        {
                            Error.LogError(ex);
                        }
                    }
                    break;

                case enumSelectedGrid.MutasiHeaderSelected:
                    if (dataGridMutasiHeader.SelectedCells.Count > 0 || dataGridMutasiHeader.SelectedCells.Count == 0)
                    {
                       ArusStock.frmMutasiUpdate ifrmChild = new ArusStock.frmMutasiUpdate(this);
                        ifrmChild.MdiParent = Program.MainForm;
                        Program.MainForm.RegisterChild(ifrmChild);
                        ifrmChild.Show();
                    }
                    break;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.MutasiDetailSelected:
                    if (this.dataGridMutasiDetail.SelectedCells.Count > 0)
                    {
                        string typeMutasi = string.Empty;
                        if (dataGridMutasiHeader.RowCount > 0)
                        {
                            typeMutasi = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["Type"].Value.ToString().Trim();
                        }

                        FillDetail();
                        if (dataGridMutasiDetail.SelectedCells[0].OwningRow.Cells["SyncFlagD"].Value.ToString() == "1")
                        {
                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
                            if ((DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }
                            ArusStock.frmUpdateMutasiDetail ifrmChild = new ArusStock.frmUpdateMutasiDetail(this, _rowIDD, typeMutasi);

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

                case enumSelectedGrid.MutasiHeaderSelected:
                    if (this.dataGridMutasiHeader.SelectedCells.Count > 0)
                    {
                        FillHeader();
                        if(dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString()=="1")
                            {
                            if(!SecurityManager.AskPasswordManager())
                                {
                                return;
                                }
                            }
                        try
                        {
                            GlobalVar.LastClosingDate = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
                            if ((DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value <= GlobalVar.LastClosingDate)
                            {
                                throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                            }

                            ArusStock.frmMutasiUpdate ifrmChild = new ArusStock.frmMutasiUpdate(this, _rowID);
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

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdDelete_Click_1(object sender, EventArgs e)
        {
            switch (selectedGrid)
            {
                case enumSelectedGrid.MutasiDetailSelected:
                    if (this.dataGridMutasiDetail.SelectedCells.Count > 0)
                    {
                        if (dataGridMutasiDetail.SelectedCells[0].OwningRow.Cells["SyncFlagD"].Value.ToString() == "1")
                        {

                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                        }
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
                                if ((DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {

                                    DataTable dtMutasiDetail = new DataTable();
                                    db.Commands.Add(db.CreateCommand("usp_MutasiDetail_Delete"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowIDD));
                                    dtMutasiDetail = db.Commands[0].ExecuteDataTable();
                                }
                                this.RefreshDataMutasi();

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
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    break;

                case enumSelectedGrid.MutasiHeaderSelected:

                    if (this.dataGridMutasiHeader.SelectedCells.Count > 0)
                    {
                        //int rc;
                        //rc = dataGridMutasiDetail.Rows.Count;
                        //if (rc != 0)
                        //{
                        //    MessageBox.Show("Masih Terdapat Data !");
                        //    break;
                        //}
                        if(dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["SyncFlag"].Value.ToString()=="1")
                            {
                            if(!SecurityManager.AskPasswordManager())
                                {
                                return;
                                }
                            }
                        if (MessageBox.Show("Hapus record ini?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = (DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value;
                                if ((DateTime)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["TglMutasi"].Value <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(String.Format(Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }

                                using (Database db = new Database())
                                {
                                    Guid _rowID = (Guid)dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                                  
                                    db.Commands.Add(db.CreateCommand("usp_Mutasi_Delete"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _rowID));
                                    db.Commands[0].ExecuteDataTable();
                                }
                                int i = 0;
                                int n = 0;
                                i = dataGridMutasiHeader.SelectedCells[0].RowIndex;
                                n = dataGridMutasiHeader.SelectedCells[0].ColumnIndex;
                                DataRowView dv = (DataRowView)dataGridMutasiHeader.SelectedCells[0].OwningRow.DataBoundItem;
                                DataRow drr = dv.Row;
                                drr.Delete();
                                dtMutasi.AcceptChanges();
                                dataGridMutasiHeader.Focus();
                                if (dataGridMutasiHeader.RowCount > 0)
                                {
                                    if (i == 0)
                                    {
                                        dataGridMutasiHeader.CurrentCell = dataGridMutasiHeader.Rows[0].Cells[n];
                                        dataGridMutasiHeader.RefreshEdit();
                                    }
                                    else
                                    {
                                        dataGridMutasiHeader.CurrentCell = dataGridMutasiHeader.Rows[i - 1].Cells[n];
                                        dataGridMutasiHeader.RefreshEdit();
                                    }
                                }
                                RefreshDataMutasiDetail();
                            }
                            catch (Exception ex)
                            {
                                Error.LogError(ex);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Messages.Error.RowNotSelected);
                    }
                    break;
            }
        }

        private void cmdClose_Click_1(object sender, EventArgs e)
            {
            this.Close();
            }

        public void FindHeader(string columnName, string value)
        {
            dataGridMutasiHeader.FindRow(columnName, value);
            
            if (dataGridMutasiHeader.RowCount > 0)
            {
                txtTotalPlus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiPlus"].Value.ToString();
                txtTotalMinus.Text = dataGridMutasiHeader.SelectedCells[0].OwningRow.Cells["MutasiMinus"].Value.ToString();
            }
        }

        public void FindDetail(string columnName, string value)
        {
            dataGridMutasiDetail.FindRow(columnName, value);
        }

        private void dataGridMutasiHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridMutasiDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmdDelete.PerformClick();
            }
        }

        private void dataGridMutasiHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (this.dataGridMutasiHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDataMutasiDetail();
            }
        }
    }
}
