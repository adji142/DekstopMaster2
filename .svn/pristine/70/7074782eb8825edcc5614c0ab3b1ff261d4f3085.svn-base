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
    public partial class frmTokoKhususBrowse : ISA.Controls.BaseForm
    {
        DataTable dt = new DataTable();

        public frmTokoKhususBrowse()
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
                    db.Commands.Add(db.CreateCommand("usp_TokoKhusus_LIST"));
                    //db.Commands[0].Parameters.Add(new Parameter("@namaSales", SqlDbType.VarChar, txtNama.Text));
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


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTokoKhususBrowse_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
