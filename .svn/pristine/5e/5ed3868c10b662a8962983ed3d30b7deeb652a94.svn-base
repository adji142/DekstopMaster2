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
    public partial class frmLookupCollector : ISA.Toko.BaseForm
    {
        string kodeCollector, Nama, huruf;

        public string KodeCollector
        {
            get
            {
                return kodeCollector;
            }
        }

        public string NamaCollector
        {
            get
            {
                return Nama;
            }
        }
        public frmLookupCollector(string huruf)
        {
            InitializeComponent();
            this.huruf = huruf;
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                Nama = customGridView1.SelectedCells[0].OwningRow.Cells["NamaColl"].Value.ToString();
                kodeCollector = customGridView1.SelectedCells[0].OwningRow.Cells["Kode"].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
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
                ConfirmSelect();
            }
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void frmLookupCollector_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtCollector = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_Collector_LIST"));
                    dtCollector = db.Commands[0].ExecuteDataTable();
                }

                if (dtCollector.Rows.Count > 0)
                {
                   
                    dtCollector.DefaultView.RowFilter = "Nama like '%" + huruf + "%'";
                    DataView dv = dtCollector.DefaultView;
                    customGridView1.DataSource = dv.ToTable();
                    customGridView1.Focus();
                }
                else
                {
                    customGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }
    }
}
