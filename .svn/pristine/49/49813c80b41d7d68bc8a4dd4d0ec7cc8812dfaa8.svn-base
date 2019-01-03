using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Trading.ArusStock
{
    public partial class frmBarangKembaliKeGudang : ISA.Trading.BaseForm
    {
        int prevGrid1Row = -1;

        #region "Var & Procedure"
        enum enumSelectedGrid { HeaderSelected, DetailSelected };
       

        //for Header
        Guid _RowID;
        string _KodeSales,_Catatan;
        String _TglKembaliGudang;
        DateTime _TglKembaliPenjualan;

        //for Detail
        Guid   _HeaderIDD;
        #region "Function"

        public void FillHeader()
        {
           
            _RowID = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["rowid"].Value;
            _KodeSales = dataGridHeader.SelectedCells[0].OwningRow.Cells["kodesales"].Value.ToString();
           
            _TglKembaliPenjualan = (DateTime)dataGridHeader.SelectedCells[0].OwningRow.Cells["tglkembalipj"].Value;
            _TglKembaliGudang = dataGridHeader.SelectedCells[0].OwningRow.Cells["tglkembaligdg"].Value.ToString();
            _Catatan = dataGridHeader.SelectedCells[0].OwningRow.Cells["catatan"].Value.ToString();
            
        }

        public void FillDetail()
        {
            _HeaderIDD = _RowID;
        }

        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Pengembalian_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rgbTglDO.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rgbTglDO.ToDate));
                    db.Commands[0].Parameters.Add(new Parameter("@InitPers", SqlDbType.VarChar, txtInit.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridHeader.DataSource = dt;

                }

                if (dataGridDetail.SelectedCells.Count > 0)
                {
                    RefreshDetail();
                }
                else
                {
                    dataGridDetail.DataSource = null;
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

        public void RefreshDetail()
        {
            try
            {

                _HeaderIDD = (Guid)dataGridHeader.SelectedCells[0].OwningRow.Cells["rowid"].Value;
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_PengembalianDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@HeaderID", SqlDbType.UniqueIdentifier, _HeaderIDD));
                    dt = db.Commands[0].ExecuteDataTable();
                    this.dataGridDetail.DataSource = dt;
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
        #endregion

        #endregion
        public frmBarangKembaliKeGudang()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshHeader();
        }

        private void frmBarangKembaliKeGudang_Load(object sender, EventArgs e)
        {
            dataGridHeader.AutoGenerateColumns = false;
            dataGridDetail.AutoGenerateColumns = false;
            txtInit.Text = GlobalVar.PerusahaanID;
            rgbTglDO.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rgbTglDO.ToDate = DateTime.Now;
            _TglKembaliGudang="";
        }

        private void rgbTglDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridHeader_Click(object sender, EventArgs e)
        {
            
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
            }
            
        }

        private void dataGridDetail_Click(object sender, EventArgs e)
        {
            
            if (dataGridDetail.SelectedCells.Count > 0)
            {
                FillDetail();
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                if (e.KeyCode == Keys.F12)
                {
                    if (!SecurityManager.IsAuditor())
                    {
                        if (_TglKembaliGudang != "") //Delete
                        {

                            if (!SecurityManager.AskPasswordManager())
                            {
                                return;
                            }
                            try
                            {
                                GlobalVar.LastClosingDate=Convert.ToDateTime(_TglKembaliGudang) ;
                                if (Convert.ToDateTime(_TglKembaliGudang) <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Pengembalian_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, _Catatan));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglPengembalianPJ", SqlDbType.DateTime, _TglKembaliPenjualan));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglPEngembalianGdg", SqlDbType.DateTime, SqlDateTime.Null));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                    db.Commands[0].ExecuteNonQuery();


                                }
                            }
                            catch (System.Exception ex)
                            {
                                Error.LogError(ex);
                            }
                            finally
                            {
                                this.Cursor = Cursors.Default;
                                RefreshHeader();
                            }
                        }
                        else   //Fill
                        {
                            try
                            {
                                GlobalVar.LastClosingDate = DateTime.Now;
                                if (DateTime.Now <= GlobalVar.LastClosingDate)
                                {
                                    throw new Exception(string.Format(ISA.Trading.Messages.Error.AlreadyClosingPJT, GlobalVar.LastClosingDate));
                                }
                                this.Cursor = Cursors.WaitCursor;
                                using (Database db = new Database())
                                {
                                    db.Commands.Add(db.CreateCommand("usp_Pengembalian_UPDATE"));
                                    db.Commands[0].Parameters.Add(new Parameter("@rowID", SqlDbType.UniqueIdentifier, _RowID));
                                    db.Commands[0].Parameters.Add(new Parameter("@Catatan", SqlDbType.VarChar, _Catatan));
                                    db.Commands[0].Parameters.Add(new Parameter("@KodeSales", SqlDbType.VarChar, _KodeSales));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglPengembalianPJ", SqlDbType.DateTime, _TglKembaliPenjualan));
                                    db.Commands[0].Parameters.Add(new Parameter("@TglPEngembalianGdg", SqlDbType.DateTime, DateTime.Now));
                                    db.Commands[0].Parameters.Add(new Parameter("@lastUpdatedBy", SqlDbType.VarChar, SecurityManager.UserID));

                                    db.Commands[0].ExecuteNonQuery();


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


                        RefreshHeader();
                    }
                }
            }
            
        }

        private void dataGridHeader_SelectionRowChanged(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                FillHeader();
                RefreshDetail();
            }
        }
    }
}
