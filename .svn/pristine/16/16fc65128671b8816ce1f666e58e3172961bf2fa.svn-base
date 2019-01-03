using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Bengkel;
using ISA.Bengkel.Helper;
using System.Data.SqlTypes;
using ISA.Bengkel.Library;

namespace ISA.Bengkel.Master
{
    public partial class FrmInstansi : ISA.Bengkel.BaseForm
    {
        enum enumSelectedGrid { HeaderSelected, Detail1Selected};
        enumSelectedGrid selectedGrid = enumSelectedGrid.HeaderSelected;
        public FrmInstansi()
        {
            InitializeComponent();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            switch (selectedGrid){
                case enumSelectedGrid.HeaderSelected:
                    
                break;
                case enumSelectedGrid.Detail1Selected:
                    Guid RowIDInstansi = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    string NamaInstansi = customGridView1.SelectedCells[0].OwningRow.Cells["NamaInstansi"].Value.ToString();
                    string KodeToko = customGridView1.SelectedCells[0].OwningRow.Cells["KodeToko"].Value.ToString();
                    FrmInstansiEdit frm = new FrmInstansiEdit(RowIDInstansi,NamaInstansi,KodeToko);
                    frm.ShowDialog();
                break;
        }
        }

        private void FrmInstansi_Load(object sender, EventArgs e)
        {
            try
            {
                using (Database db = new Database()) {
                    DataTable dt = new DataTable();

                    db.Commands.Add(db.CreateCommand("Usp_InstansiLoad"));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView1.DataSource = dt;
                }
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customGridView1_SelectionRowChanged(object sender, EventArgs e)
        {
            try
            {
                Guid RowIDInstansi = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                DataTable dt = new DataTable();
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("Usp_InstansiDetailLoad"));
                    db.Commands[0].Parameters.Add(new Parameter("@Headerid", SqlDbType.UniqueIdentifier, RowIDInstansi));
                    dt = db.Commands[0].ExecuteDataTable();
                    customGridView2.DataSource = dt;
                }
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }

        private void customGridView1_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.HeaderSelected;
        }

        private void customGridView2_Click(object sender, EventArgs e)
        {
            selectedGrid = enumSelectedGrid.Detail1Selected;
        }
    }
}
