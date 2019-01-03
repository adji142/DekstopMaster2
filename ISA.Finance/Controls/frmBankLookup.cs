using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;



namespace ISA.Finance.Controls
{
    public partial class frmBankLookup : ISA.Finance.BaseForm
    {
        string _bankID;
        string _namaBank;
        Guid _rowID;

        public Guid RowID
        {
            get
            {
                return _rowID;
            }

            set
            {
                _rowID = value;
            }
        }

        public string BankID
        {
            get
            {
                return _bankID;
            }

            set
            {
                _bankID = value;
            }
        }

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
        public frmBankLookup()
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
        }

        public frmBankLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            txtSearch.Text = searchArg;
            customGridView1.DataSource = dt;            
        }   

        public void RefreshData()
        {            
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_Bank_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtSearch.Text));
                dt = db.Commands[0].ExecuteDataTable();                
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void customGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void frmBankLookup_Load(object sender, EventArgs e)
        {
            
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _bankID = customGridView1.SelectedCells[0].OwningRow.Cells["cBankID"].Value.ToString();
                _namaBank = customGridView1.SelectedCells[0].OwningRow.Cells["cNamaBank"].Value.ToString();
                _rowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["cRowID"].Value;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && customGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();

            }
        }

        private void frmBankLookup_Shown(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }
    }
}
