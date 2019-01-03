using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Finance;

namespace ISA.Finance.Controls
{
    public partial class frmDKNLookup : ISA.Finance.BaseForm
    {
        string _noDKN, _tanggal, _jumlah;

        public string NoDKN
        {
            get
            {
                return _noDKN;
            }

            set
            {
                _noDKN = value;
            }
        }

        public string Tanggal
        {
            get
            {
                return _tanggal;
            }
            set
            {
                _tanggal = value;
            }
        }

        public string Jumlah
        {
            get
            {
                return _jumlah;
            }
            set
            {
                _jumlah = value;
            }
        }

        public frmDKNLookup()
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
        }

        public frmDKNLookup(string searchArg, DataTable dt)
        {
            InitializeComponent();
            customGridView1.AutoGenerateColumns = false;
            customGridView1.DataSource = dt;            
        }

        public void RefreshData(DateTime d1_, DateTime d2_)
        {            
            using (Database db = new Database(GlobalVar.DBName))
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_DKN_LOOKUP"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, d1_));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, d2_));
                dt = db.Commands[0].ExecuteDataTable();                
                customGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    customGridView1.Focus();
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (rangeDateBox1.FromDate.HasValue && rangeDateBox1.ToDate.HasValue)
            {
                RefreshData(rangeDateBox1.FromDate.Value, rangeDateBox1.ToDate.Value);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void customGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (customGridView1.SelectedCells.Count == 1)
            //{
            //    ConfirmSelect();
            //}
        }

        private void ConfirmSelect()
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                _noDKN = customGridView1.SelectedCells[0].OwningRow.Cells["No_DKN"].Value.ToString();
                _tanggal = customGridView1.SelectedCells[0].OwningRow.Cells["tgl"].Value.ToString();
                _jumlah = customGridView1.SelectedCells[0].OwningRow.Cells["jml"].Value.ToString();
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

        private void frmDKNLookup_Shown(object sender, EventArgs e)
        {
            if (customGridView1.Rows.Count > 0)
            {
                customGridView1.Focus();
            }
        }

        private void frmDKNLookup_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = DateTime.Now;
            rangeDateBox1.ToDate = DateTime.Now;
        }

        private void customGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customGridView1.SelectedCells.Count == 1)
            {
                ConfirmSelect();
            }
        }
    }
}
