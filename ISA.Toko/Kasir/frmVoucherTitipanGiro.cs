using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Toko.Kasir
{
    public partial class frmVoucherTitipanGiro : ISA.Toko.BaseForm
    {
        int prevGrid1Row = -1;
        int _prefGrid = 0;
        enum enumFormMode { New, Update };
        enumFormMode formMode;
        Guid _rowIDBBM;

        public frmVoucherTitipanGiro(Form caller, Guid rowIDBBM)
        {
            InitializeComponent();
            _rowIDBBM = rowIDBBM;
            this.Caller = caller;
        }

        public frmVoucherTitipanGiro()
        {
            InitializeComponent();
        }

    

        private void frmVoucherTitipanGiro_Load(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_VoucherTitipanGiro_GiroCairTolakBatal"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowIDBBM", SqlDbType.UniqueIdentifier, _rowIDBBM));
                    dt = db.Commands[0].ExecuteDataTable();
                    gridVoucher.DataSource = dt;
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

        private void gridVoucher_DoubleClick(object sender, EventArgs e)
        {
            if (gridVoucher.SelectedCells.Count > 0)
            {
                string _BankID = "", _BankIDBBM = "";
                _BankID = gridVoucher.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
                _BankIDBBM = gridVoucher.SelectedCells[0].OwningRow.Cells["BankIDBBM"].Value.ToString();
                //if (_BankID != _BankIDBBM)
                //{
                //    MessageBox.Show("BankID Giro Tidak Sama Dengan BankID BBM");
                //    gridVoucher.Focus();
                //    return;
                //}
                Guid GiroID = (Guid)gridVoucher.SelectedCells[0].OwningRow.Cells["GiroID"].Value;
                DateTime _tglJT = (DateTime)gridVoucher.SelectedCells[0].OwningRow.Cells["TglJTempo"].Value;
                this.Close();
                Kasir.frmTransaksiPencairanGiro ifrmChild = new Kasir.frmTransaksiPencairanGiro(this.Caller, GiroID, _rowIDBBM, _tglJT);
                Program.MainForm.RegisterChild(ifrmChild);
                ifrmChild.ShowDialog();
            }            
        }

        private void gridVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridVoucher_DoubleClick(sender, e);
            }

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (gridVoucher.SelectedCells[0].ColumnIndex == 2)
                {
                    string search = tbSearch.Text;
                    if (search.Length > 0)
                    {
                        search = search.Substring(0, search.Length - 1);
                        tbSearch.Text = search;
                    }
                }
            }
        }

        private void gridVoucher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridVoucher.SelectedCells[0].ColumnIndex == 2)
            {
                if (char.IsNumber(e.KeyChar))
                {
                    string search = tbSearch.Text;
                    search += e.KeyChar;
                    tbSearch.Text = search;



                }
            }
        }

        private void gridVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVoucher.SelectedCells.Count > 0)
            {
                if (gridVoucher.SelectedCells[0].ColumnIndex != 2)
                {
                    tbSearch.Clear();
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 0)
            {
                string search = tbSearch.Text;
                for (int i = 0; i < (gridVoucher.Rows.Count); i++)
                {
                    if (gridVoucher.Rows[i].Cells["Nomor"].Value.ToString().StartsWith(search))
                    {
                        gridVoucher.Rows[i].Cells["Nomor"].Selected = true;
                        return; // stop looping
                    }
                }
            }
        }

    
    }
}
