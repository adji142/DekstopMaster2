using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Kasir
{
    public partial class frmLookupTransaksiBank : ISA.Toko.BaseForm
    {
        public string kdTransaksi, nmTransaksi, dk, noPerkiraan;

        public string KdTransaksi
        {
            get
            {
                return kdTransaksi;
            }
        }

        public string NmTransaksi
        {
            get
            {
                return nmTransaksi;
            }
        }

        public string Dk
        {
            get
            {
                return dk;
            }
        }

        public string NoPerkiraan
        {
            get
            {
                return noPerkiraan;
            }
        }

        public frmLookupTransaksiBank()
        {
            InitializeComponent();
        }

        private void frmLookupTransaksiBank_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void refreshGrid()
        {
            try
            {
                DataTable dt=new DataTable();
                using (Database db = new Database(GlobalVar.DBFinance))
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.DefaultView.Sort = "kd_trs";
                dgTransaksiBank.DataSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ConfirmSelect()
        {
            if (dgTransaksiBank.SelectedCells.Count == 1)
            {
                kdTransaksi = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["kd_trs"].Value.ToString();
                nmTransaksi = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["nm_trs"].Value.ToString();
                dk = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["dbcr"].Value.ToString();
                noPerkiraan = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["no_perk"].Value.ToString();

                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgTransaksiBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgTransaksiBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void dgTransaksiBank_DoubleClick(object sender, EventArgs e)
        {
            if (dgTransaksiBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (dgTransaksiBank.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }
    }
}
