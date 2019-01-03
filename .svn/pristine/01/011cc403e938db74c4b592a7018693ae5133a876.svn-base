using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Kasir
{
    public partial class frmTransaksiBankBrowse : ISA.Finance.BaseForm
    {
        public frmTransaksiBankBrowse()
        {
            InitializeComponent();
        }


        private void refreshGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiBank_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                }

                dt.DefaultView.Sort = "kd_trs";
                dgTransaksiBank.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

       
        private void frmTransaksiBankBrowse_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void dgTransaksiBank_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTransaksiBank.SelectedCells.Count > 0)
            {
                tbKd_Trs.Text = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["kd_trs"].Value.ToString();
                tbNama.Text = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["nm_trs"].Value.ToString();
                string dk = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["dbcr"].Value.ToString();
                string Chbg = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["bgch"].Value.ToString();
                tbNoPerk.Text = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["no_perk"].Value.ToString();
                tbKet.Text = dgTransaksiBank.SelectedCells[0].OwningRow.Cells["ke_ket"].Value.ToString();

                if (dk == "D")
                {
                    rbDebet.Checked = true;
                    rbKredit.Checked = false;
                }
                else
                {
                    rbDebet.Checked = false;
                    rbKredit.Checked = true;
                }

                if (Chbg == "Y")
                    rbChbg.Checked = true;
                else
                    rbChbg.Checked = false;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox1.Focus();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_TransaksiBank_UPDATE"));
                    db.Commands[0].Parameters.Add(new Parameter("@KodeTransaksi", SqlDbType.VarChar, tbKd_Trs.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, tbKet.Text));
                    db.Commands[0].Parameters.Add(new Parameter("@Noperkiraan", SqlDbType.VarChar, tbNoPerk.Text));
                    db.Commands[0].ExecuteNonQuery();
                }

                refreshGrid();
                dgTransaksiBank.FindRow("kd_trs", tbKd_Trs.Text);
                dgTransaksiBank_SelectionChanged(sender, e);
                cmdCancel_Click(sender, e);

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        
    }
}
