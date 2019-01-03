using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISA.Finance.Kasir
{
    public partial class frmLookupBank : ISA.Finance.BaseForm
    {
        Guid rowIDBank2;
        string rowID, bankID2;
        DataTable dtBank;

        public Guid RowIDBank2
        {
            get
            {
                return rowIDBank2;
            }
        }

        public String  BankID2
        {
            get
            {
                return bankID2;
            }
        }

        public frmLookupBank(DataTable dtBank, string rowID)
        {
            InitializeComponent();
            this.dtBank = dtBank;
            this.rowID = rowID;
        }

        private void frmLookupBank_Load(object sender, EventArgs e)
        {
            string filter=@"RowID<>'"+rowID+"'";
            dtBank.DefaultView.RowFilter = filter;
            DataView dv = new DataView();
            dv = dtBank.DefaultView;
            dgHeaderBank.DataSource = dv.ToTable();
        }

        private void ConfirmSelect()
        {
            if (dgHeaderBank.SelectedCells.Count == 1)
            {
                rowIDBank2 = (Guid)dgHeaderBank.SelectedCells[0].OwningRow.Cells["RowIDH"].Value;
                bankID2 = dgHeaderBank.SelectedCells[0].OwningRow.Cells["BankID"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgHeaderBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgHeaderBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void dgHeaderBank_DoubleClick(object sender, EventArgs e)
        {
            if (dgHeaderBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dgHeaderBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
