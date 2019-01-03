using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Controls
{
    public partial class frmBankAsalLookup : ISA.Finance.BaseForm
    {

        string _namaBank;
        string _lokasi;
        DataTable dt = new DataTable();

        public string NamaBank
        {
            get
            {
                return _namaBank;
            }
            set
            {
                _namaBank = value;
            }
        }

        public string Lokasi
        {
            get
            {
                return _lokasi;
            }
            set
            {
                _lokasi = value;
            }
        }

        public frmBankAsalLookup()
        {
            InitializeComponent();
        }

        public frmBankAsalLookup(string searchArg, DataTable dt)
        {
            
            InitializeComponent();
            txtSearch.Text = searchArg;
            this.dt = dt; 
        }

        public void RefreshData()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {

                db.Commands.Add(db.CreateCommand("usp_BankKota_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dt.DefaultView.Sort = "NamaBank,Lokasi";
                customGridView1.DataSource = dt.DefaultView;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();
                }
            }
        }

        public void RefreshRowData(Guid rowID)
        {
            DataTable dtRefresh = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_BankKota_LIST_ByRow"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();

            }

            customGridView1.RefreshDataRow(dtRefresh.Rows[0], "RowID", rowID.ToString());
            customGridView1.Rows[customGridView1.Rows.Count - 1].Cells[1].Selected = true;
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _namaBank = customGridView1.SelectedCells[0].OwningRow.Cells["cNamaBank"].Value.ToString();
                _lokasi= customGridView1.SelectedCells[0].OwningRow.Cells["cLokasi"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void frmBankAsalLookup_Load(object sender, EventArgs e)
        {
            dt.DefaultView.Sort = "NamaBank,Lokasi";
            customGridView1.DataSource = dt.DefaultView; 
        }

        private void customGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();

            }
            else if (e.KeyCode == Keys.Insert)
            {
                Kasir.frmBankKotaUpdate frm = new ISA.Finance.Kasir.frmBankKotaUpdate(this);
                frm.ShowDialog();
            }
        }

        private void frmBankAsalLookup_Shown(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

    }
}
