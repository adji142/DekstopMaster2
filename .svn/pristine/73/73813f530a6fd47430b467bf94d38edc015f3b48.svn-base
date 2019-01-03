using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.PJ3
{
    public partial class frmKoreksiJualBrowser2 : ISA.Trading.BaseForm
    {
        Guid _notaJualDetailID;
        DataTable dtNotaDetail;
        bool _acak;
        string _format, _recID;

        public frmKoreksiJualBrowser2(Form caller, Guid notaJualDetailID, string recID)
        {            
            InitializeComponent();
            _notaJualDetailID = notaJualDetailID;
            _recID = recID;
            this.Caller = caller;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKoreksiJualBrowser2_Load(object sender, EventArgs e)
        {
            _acak = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Focus();
            RefreshDataKoreksiJual();
        }

        public void RefreshDataKoreksiJual()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtKoreksi = new DataTable();
                using (Database db = new Database())
                {
                    
                    db.Commands.Add(db.CreateCommand("usp_KoreksiPenjualan_LIST"));
                    db.Commands[0].Parameters.Add(new Parameter("@notaJualDetailID", SqlDbType.UniqueIdentifier, _notaJualDetailID));

                    dtKoreksi = db.Commands[0].ExecuteDataTable();
                    
                }
                dataGridView1.DataSource = dtKoreksi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AcakTampilHrg()
        {
            _acak = !_acak;

            dataGridView1.Columns["HrgJual"].Visible = !_acak;
            dataGridView1.Columns["HrgJualKoreksi"].Visible = !_acak;

            dataGridView1.Columns["HrgJualAck"].Visible = _acak;
            dataGridView1.Columns["HrgJualKoreksiAck"].Visible = _acak;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    AcakTampilHrg();
                    break;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double hrgJualBaru = double.Parse(Tools.isNull(dataGridView1.Rows[e.RowIndex].Cells["HrgJual"].Value, 0).ToString());
            double hrgJualKor = double.Parse(Tools.isNull(dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksi"].Value, 0).ToString());

            dataGridView1.Rows[e.RowIndex].Cells["HrgJual"].Style.Format = "#,##0";
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksi"].Style.Format = "#,##0";

            dataGridView1.Rows[e.RowIndex].Cells["HrgJualAck"].Value = Tools.GetAntiNumeric(hrgJualBaru.ToString("#,##0"));
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksiAck"].Value = Tools.GetAntiNumeric(hrgJualKor.ToString("#,##0"));

            dataGridView1.Rows[e.RowIndex].Cells["HrgJualAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Rows[e.RowIndex].Cells["HrgJualKoreksiAck"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void FindRow(string columnName, string value)
        {
            dataGridView1.FindRow(columnName, value);
        }
    }
}
