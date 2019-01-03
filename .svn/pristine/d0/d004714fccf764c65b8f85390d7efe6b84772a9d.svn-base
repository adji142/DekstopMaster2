using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ISA;
using ISA.Common;
using ISA.DAL;
using ISA.Finance.Class;

namespace ISA.Finance.DKNForm
{
    public partial class frmHiRegisterBrowse : Form
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        string LastClosingGL;

        public frmHiRegisterBrowse()
        {
            InitializeComponent();

        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            string _recordID = gridUtm.SelectedCells[0].OwningRow.Cells["RecordID"].Value.ToString();
            //DKNForm.frmHIRegisterCetak ifrmChild = new DKNForm.frmHIRegisterCetak(this, _recordID);
            //ifrmChild.MdiParent = Program.MainForm;
            //Program.MainForm.RegisterChild(ifrmChild);
            //ifrmChild.ShowDialog();
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            if (((selectedGrid == enumSelectedGrid.HeaderSelected && gridUtm.SelectedCells.Count > 0) ||
                 (selectedGrid == enumSelectedGrid.DetailSelected && gridDetail.SelectedCells.Count > 0)) &&
                 (gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString() != GlobalVar.Gudang && gridUtm.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() == "DKN"))
            {
                DateTime TglTrans = Convert.ToDateTime(gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                string TahunBulan = TglTrans.Year.ToString() + TglTrans.Month.ToString().PadLeft(2, '0');
                if (Convert.ToInt32(TahunBulan) > Convert.ToInt32(LastClosingGL))
                {
                    if (MessageBox.Show("Anda yakin?", "Hapus data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (selectedGrid == enumSelectedGrid.HeaderSelected)
                        {
                            Guid HeaderID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, HeaderID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            RefreshDkn();
                        }
                        else
                        {
                            Guid DetailID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_DETAIL_DELETE"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, DetailID));
                                db.Commands[0].ExecuteNonQuery();
                            }
                            RefreshDknDetail();
                        }
                    }
                }
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (((selectedGrid == enumSelectedGrid.HeaderSelected && gridUtm.SelectedCells.Count > 0) ||
                 (selectedGrid == enumSelectedGrid.DetailSelected && gridDetail.SelectedCells.Count > 0)) &&
                 (gridUtm.SelectedCells[0].OwningRow.Cells["Cabang"].Value.ToString() != GlobalVar.Gudang && gridUtm.SelectedCells[0].OwningRow.Cells["Src"].Value.ToString() == "DKN"))
            {
                DateTime TglTrans = Convert.ToDateTime(gridUtm.SelectedCells[0].OwningRow.Cells["Tanggal"].Value);
                string TahunBulan = TglTrans.Year.ToString() + TglTrans.Month.ToString().PadLeft(2, '0');
                if (Convert.ToInt32(TahunBulan) > Convert.ToInt32(LastClosingGL))
                {
                    if (selectedGrid == enumSelectedGrid.HeaderSelected)
                    {
                        Guid HeaderID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        frmHiRegisterUpdate ifrm = new frmHiRegisterUpdate(this, HeaderID);
                        ifrm.Show();
                    }
                    else
                    {
                        Guid HeaderID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["HeaderID"].Value;
                        Guid DetailID = (Guid)gridDetail.SelectedCells[0].OwningRow.Cells["RowIDD"].Value;
                        frmHiRegisterUpdate ifrm = new frmHiRegisterUpdate(this, HeaderID, DetailID);
                        ifrm.Show();
                    }
                }
                else MessageBox.Show("Sudah tutup buku, tidak bisa diEDIT !");
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.HeaderSelected)
            {
                frmHiRegisterUpdate ifrm = new frmHiRegisterUpdate(this);
                ifrm.Show();
            }
            else
            {
                Guid HeaderID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                Guid DetailID = (Guid)Guid.Empty;
                frmHiRegisterUpdate ifrm = new frmHiRegisterUpdate(this, HeaderID, DetailID);
                ifrm.Show();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshDkn();
        }

        public void RefreshDkn()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                    db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    gridUtm.DataSource = dtHeader;

                    if (gridUtm.SelectedCells.Count > 0)
                    {
                        RefreshDknDetail();
                    }
                    else
                    {
                        gridDetail.DataSource = null;                        
                    }
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

        public void RefreshDknDetail() {
            try
            {
                Guid _rowID = (Guid)gridUtm.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_HI_REGISTER_DETAIL_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _rowID));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    gridDetail.DataSource = dtDetail;
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

        private void frmHiRegisterBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            gridUtm.AutoGenerateColumns = false;
            gridDetail.AutoGenerateColumns = false;
            LastClosingGL = PeriodeClosing.LastClosingGL;
            RefreshDkn();
        }

        private void gridUtm_SelectionChanged(object sender, EventArgs e)
        {
            
            if (gridUtm.SelectedCells.Count > 0)
            {
                if (gridUtm.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshDknDetail();
                }
                prevGrid1Row = gridUtm.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                gridDetail.DataSource = null;
            }
        }

        private void gridUtm_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void gridUtm_Validated(object sender, EventArgs e)
        {
            if (gridUtm.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
        }

        private void gridDetail_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void gridUtm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
