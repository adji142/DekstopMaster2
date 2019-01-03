using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Master
{
    public partial class frmSalesBrowser : ISA.Trading.BaseForm
    {
        DataTable dt = new DataTable();

        public frmSalesBrowser()
        {
            InitializeComponent();
        }
                
        public void RefreshData()
        {
            try
            {

               
                using (Database db = new Database())
                {
                    db.Open();
                    db.Commands.Add(db.CreateCommand("usp_Sales_LIST"));

                    db.Commands[0].Parameters.Add(new Parameter("@namaSales", SqlDbType.VarChar, txtNama.Text));
                    dt = db.Commands[0].ExecuteDataTable();
                    dataGridView1.DataSource = dt;

                    db.Close();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
        }
        
        
        private void frmSalesBrowser_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdSearch_Click_1(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue >= 65 && e.KeyValue <= 127)
            //{
            //    txtNama.Text += e.KeyCode;
            //    RefreshData2();
            //}

            //if (e.KeyValue == 8 && txtNama.Text.Length > 0)
            //{
            //    txtNama.Text = txtNama.Text.Remove(txtNama.Text.Length - 1);
            //}
        }
    }
}
