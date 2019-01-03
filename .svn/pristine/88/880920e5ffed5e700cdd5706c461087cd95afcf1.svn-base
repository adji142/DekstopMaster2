using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Controls
{
    public partial class frmLookupBarcode : ISA.Controls.BaseForm
    {
        UserControl _caller;
       

        public frmLookupBarcode(UserControl caller)
        {
            InitializeComponent();
            this.Caller = caller;
        }
        public UserControl Caller {
            get { return _caller; }
            set { _caller = value;  }
        }
        private void frmLookupBarcode_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void RefreshData()
        {
            using (Database db = new Database())
            {
                DataTable dt = new DataTable();

                db.Commands.Add(db.CreateCommand("usp_barcode_SEARCH"));
                db.Commands[0].Parameters.Add(new Parameter("@search", SqlDbType.VarChar, txtNama.Text));
                dt = db.Commands[0].ExecuteDataTable();
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Focus();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
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
                string[] dataSend = { dataGridView1.SelectedCells[0].OwningRow.Cells["nmBrgdg"].Value.ToString(),
                                       dataGridView1.SelectedCells[0].OwningRow.Cells["barcode"].Value.ToString()};

                if (this.Caller is LookupBarcode) {
                    LookupBarcode frmCaller = (LookupBarcode)this.Caller;
                    frmCaller.DataGet(dataSend);
                }

                this.Close();


            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
