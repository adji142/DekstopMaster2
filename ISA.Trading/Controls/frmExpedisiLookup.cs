using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;


namespace ISA.Trading.Controls
{
    public partial class frmExpedisiLookup : ISA.Controls.BaseForm
    {
        string _kodeExpedisi;
        string _namaExpedisi;

        public frmExpedisiLookup()
        {
            InitializeComponent();
        }

        public frmExpedisiLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtNama.Text = searchArg;
            dataGridView1.DataSource = dt;            
        }

        public string KodeExpedisi
        {
            get
            {
                return _kodeExpedisi;
            }
        }

        public string namaExpedisi
        {
            get
            {
                return _namaExpedisi;
            }
        }


        private void frmExpedisiLookup_Load(object sender, EventArgs e)
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

                    db.Commands.Add(db.CreateCommand("usp_Expedisi_LIST"));
                    if (Tools.isNull(txtNama.Text, "").ToString() != "")
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@namaExpedisi", SqlDbType.VarChar, txtNama.Text));
                    }
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
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
                _kodeExpedisi = dataGridView1.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString();
                _namaExpedisi = dataGridView1.SelectedCells[0].OwningRow.Cells["NamaExpedisi"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView1.SelectedCells.Count == 1)
            {
                e.SuppressKeyPress = true;
                ConfirmSelect();

            }

        }
    }
}
