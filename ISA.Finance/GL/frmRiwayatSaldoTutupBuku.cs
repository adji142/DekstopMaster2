using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.GL
{
    public partial class frmRiwayatSaldoTutupBuku : ISA.Finance.BaseForm
    {
        int prevRow=-1;

        public frmRiwayatSaldoTutupBuku()
        {
            InitializeComponent();
        }

        private void frmRiwayatSaldoTutupBuku_Load(object sender, EventArgs e)
        {
            RefreshHeader();
            RefreshDetail();
        }

        public void RefreshHeader()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            dt.DefaultView.Sort = "NoPerkiraan";
            customGridView1.DataSource = dt.DefaultView;
        }

        public void RefreshDetail()
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                string noPerk = customGridView1.SelectedCells[0].OwningRow.Cells["hNoPerkiraan"].Value.ToString();
                DataTable dt = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_ClosingGL_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, noPerk));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dt.DefaultView.Sort = "Periode";
                customGridView2.DataSource = dt.DefaultView;
            }
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (prevRow != customGridView1.SelectedCells[0].RowIndex)
                {
                    prevRow = customGridView1.SelectedCells[0].RowIndex;
                    RefreshDetail();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
