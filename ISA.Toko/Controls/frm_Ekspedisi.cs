using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Toko.Controls
{
    public partial class frm_Ekspedisi : ISA.Toko.BaseForm
    {
        private string _KodeExpedisi = string.Empty;

        private string _Expedisi = string.Empty;

        public string KodeExpedisi
        {
            get { return _KodeExpedisi; }
        }

        public string Expedisi
        {
            get { return _Expedisi; }
        }

        public frm_Ekspedisi()
        {
            InitializeComponent();
        }

        public frm_Ekspedisi(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dt.DefaultView.Sort = "KodeExpedisi";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void frm_Ekspedisi_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Focus();
            }
        }

        public void RefreshData()
        {
            try
            {
                using (Database db = new Database())
                {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("usp_ExpedisiCbo_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@Aktif", SqlDbType.Bit, true));
                    db.Commands[0].Parameters.Add(new Parameter("@SearchArg", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dt.DefaultView.Sort = "Expedisi";
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt.DefaultView;
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {                
            if (dataGridView1.SelectedCells.Count == 1)
            {                
                ConfirmSelect();
            }
        }

        private void ConfirmSelect()
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                _KodeExpedisi = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["KodeEkspedisi"].Value, string.Empty).ToString();
                _Expedisi = Tools.isNull(dataGridView1.SelectedCells[0].OwningRow.Cells["Ekspedisi"].Value, string.Empty).ToString();
                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }


    }
}
