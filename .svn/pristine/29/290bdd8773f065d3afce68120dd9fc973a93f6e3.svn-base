using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.VLapW
{
    public partial class frmWilayahBrowse : ISA.Trading.BaseForm
    {
        public frmWilayahBrowse()
        {
            InitializeComponent();
        }

        private void frmWilayahBrowse_Load(object sender, EventArgs e)
        {
            RefreshDataHeader();
        }

        public void RefreshDataHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_WilTop_LIST"));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    RefreshDataDetail();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        public void RefreshDataDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    Guid rowID = (Guid)dataGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;

                    db.Commands.Add(db.CreateCommand("usp_WilTopDetail_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@headerID", SqlDbType.UniqueIdentifier, rowID));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dt;
                }
                
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                RefreshDataDetail();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
