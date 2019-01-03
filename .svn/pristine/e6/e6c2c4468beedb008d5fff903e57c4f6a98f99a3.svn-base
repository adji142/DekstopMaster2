using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.DKNForm
{
    public partial class frmDebetKreditNotaKelTransBrowse : ISA.Finance.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        string kodeCabang = "", _kodeTrans = "", _ket = "", _group = "", _dn = "";
        Guid _RowID;
        enum enumSelectedGrid { HeaderSelected, DetailSelected, SubDetailSelected };
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;

        public frmDebetKreditNotaKelTransBrowse()
        {
            InitializeComponent();
        }

        private void frmDebetKreditNotaKelTransBrowse_Load(object sender, EventArgs e)
        {
            gridCabang.AutoGenerateColumns = false;
            gridTrans.AutoGenerateColumns = false;
            RefreshCabang();
            
        }

        public void RefreshCabang()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    DataTable dtHeader = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_DKNCabang_List"));                                        
                    dtHeader = db.Commands[0].ExecuteDataTable();
                    

                    if (dtHeader.Rows.Count > 0)
                    {
                        gridCabang.DataSource = dtHeader;
                        RefreshTransaksi();
                    }
                    else
                    {
                        gridCabang.DataSource = null;
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
        public  void RefreshTransaksi()
        {
            try
            {
                string _kodeCabang = gridCabang.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                DataTable dtDetail = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_DKNKodeTransaksi_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeCabang", SqlDbType.VarChar, _kodeCabang));
                    dtDetail = db.Commands[0].ExecuteDataTable();
                    dtDetail.DefaultView.Sort = "KodeTransaksi";
                    gridTrans.DataSource = dtDetail.DefaultView.ToTable();
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
        public void FindRowTransaksi(string column, string value)
        {
            gridTrans.FindRow(column, value);
            selectedGrid = enumSelectedGrid.DetailSelected;
            gridTrans.Focus();
        }

        private void gridCabang_SelectionChanged(object sender, EventArgs e)
        {
            if (gridCabang.SelectedCells.Count > 0)
            {
                if (gridCabang.SelectedCells[0].RowIndex != prevGrid1Row)
                {
                    RefreshTransaksi();
                }
                prevGrid1Row = gridCabang.SelectedCells[0].RowIndex;
            }
            else
            {
                prevGrid1Row = -1;
                gridTrans.DataSource = null;
            }
        }

        private void gridCabang_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void gridCabang_Validated(object sender, EventArgs e)
        {
            if (gridCabang.Focused == true)
            {
                selectedGrid = enumSelectedGrid.HeaderSelected;
                _prefGrid = 1;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            
            if (selectedGrid == enumSelectedGrid.DetailSelected && gridCabang.SelectedCells.Count>0)
            { 
                kodeCabang=gridCabang.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                frmDebetKreditNotaKelTransUpdate frm = new frmDebetKreditNotaKelTransUpdate(this, kodeCabang);
                frm.ShowDialog();
            }
        }

        private void gridTrans_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.DetailSelected;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (selectedGrid == enumSelectedGrid.DetailSelected && gridTrans.SelectedCells.Count > 0)
            {
                _RowID = (Guid)gridTrans.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                _kodeTrans = gridTrans.SelectedCells[0].OwningRow.Cells["IDTrans"].Value.ToString();
                _ket = gridTrans.SelectedCells[0].OwningRow.Cells["keterangan"].Value.ToString();
                _group = gridTrans.SelectedCells[0].OwningRow.Cells["group"].Value.ToString();
                _dn = gridTrans.SelectedCells[0].OwningRow.Cells["DN"].Value.ToString();
                frmDebetKreditNotaKelTransUpdate frm = new frmDebetKreditNotaKelTransUpdate(this,_kodeTrans,_ket,_group,_dn,_RowID);
                frm.ShowDialog();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            
            if (selectedGrid == enumSelectedGrid.DetailSelected && gridTrans.SelectedCells.Count > 0)
            {
                if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _RowID = (Guid)gridTrans.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("usp_DKNKodeTransaksi_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].ExecuteNonQuery();
                        }

                        MessageBox.Show("Delete Berhasil");
                        RefreshTransaksi();
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
        }

        




    }
}
