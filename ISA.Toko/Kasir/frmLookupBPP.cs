using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Kasir
{
    public partial class frmLookupBPP : ISA.Toko.BaseForm
    {
        string _NoBPP,_KodeGudang,_KodeCollector = string.Empty;
        public frmLookupBPP()
        {
            InitializeComponent();
        }

        public frmLookupBPP(string searchArg, DataTable dt)
        {
            InitializeComponent();
            txtPerkiraan.Text = searchArg;
            customGridView1.DataSource = dt;            
        }

        public frmLookupBPP(string searchArg, DataTable dt, string kodegudang, string KodeCollector)
        {
            InitializeComponent();
            txtPerkiraan.Text = searchArg;
            customGridView1.DataSource = dt;
            _KodeGudang = kodegudang;
            _KodeCollector = KodeCollector;
        }


        public string BPP
        {
            get
            {
                return _NoBPP;
            }

            set
            {
                _NoBPP = value;
            }
        }

        private void frmLookupBPP_Load(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
            else
            {
                txtPerkiraan.Focus();
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void txtPerkiraan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _NoBPP = customGridView1.SelectedCells[0].OwningRow.Cells["NoBPP"].Value.ToString();
                
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

        public void RefreshData()
        {
            using (Database db = new Database(GlobalVar.DBFinance))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_LoadBPP_Lookup"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtPerkiraan.Text));
                db.Commands[0].Parameters.Add(new Parameter("@KodeCollector", SqlDbType.VarChar, _KodeCollector));
                db.Commands[0].Parameters.Add(new Parameter("@KodeGudang", SqlDbType.VarChar, GlobalVar.Gudang));
                
                dt = db.Commands[0].ExecuteDataTable();
                
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();
                }
            }
        }

        private void customGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }

        private void frmLookupBPP_Shown(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        private void customGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
