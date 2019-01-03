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
    public partial class frmPerkiraanLookup : ISA.Finance.BaseForm
    {
        string _noPerkiraan;
        string _namaPerkiraan;
        int _perkiraantrn = 0;
        public string NoPerkiraan
        {
            get
            {
                return _noPerkiraan;
            }

            set
            {
                _noPerkiraan = value; 
            }
        }

        public string NamaPerkiraan
        {
            get
            {
                return _namaPerkiraan;
            }
            set
            {
                _namaPerkiraan = value;
            }
        }

        public frmPerkiraanLookup()
        {
            InitializeComponent();
        }
        public frmPerkiraanLookup(int tipetr)
        {
            InitializeComponent();
        }

        public frmPerkiraanLookup(string searchArg, DataTable dt,int tipetr)
        {
            InitializeComponent();
            txtPerkiraan.Text = searchArg;
            customGridView1.DataSource = dt;
            _perkiraantrn = tipetr;
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
                _noPerkiraan = customGridView1.SelectedCells[0].OwningRow.Cells["cNoPerkiraan"].Value.ToString();
                _namaPerkiraan = customGridView1.SelectedCells[0].OwningRow.Cells["cUraian"].Value.ToString();                
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

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@searchArg", SqlDbType.VarChar, txtPerkiraan.Text));
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

        private void frmPerkiraanLookup_Load(object sender, EventArgs e)
        {
            
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        private void frmPerkiraanLookup_Shown(object sender, EventArgs e)
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

    }
}
