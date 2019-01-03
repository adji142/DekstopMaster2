using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Data.SqlTypes;

namespace ISA.Finance.Piutang
{
    public partial class frmPotonganPenjualanBelumIden : ISA.Finance.BaseForm
    {
        string _kodetoko = string.Empty;
        enum enumSelectedGrid { gvDIL };
        enumSelectedGrid selectedGrid;

        public Guid RowIDNota {
            get { return (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowNota"].Value; }
        }
        public Guid RowIDPotongan
        {
            get { return (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowPotongan"].Value; }
        }
        public double Saldo
        {
            get { return Convert.ToDouble(customGridView1.SelectedCells[0].OwningRow.Cells["SaldoDIL"].Value.ToString()); }
        }
        
        public frmPotonganPenjualanBelumIden()
        {
            InitializeComponent();
        }
        public frmPotonganPenjualanBelumIden(string kodetoko)
        {
            _kodetoko = kodetoko;
            InitializeComponent();
        }
        private void frmPotonganPenjualanBelumIden_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_getSaldoDIL"));
                    db.Commands[0].Parameters.Add(new Parameter("@Kodetoko", SqlDbType.VarChar, _kodetoko));
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

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (selectedGrid != enumSelectedGrid.gvDIL) {
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedGrid = enumSelectedGrid.gvDIL;
        }
    }
}
