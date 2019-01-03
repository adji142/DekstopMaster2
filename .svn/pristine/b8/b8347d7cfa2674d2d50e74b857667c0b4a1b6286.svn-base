using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Common;

namespace ISA.Finance.Testing
{
    public partial class Form1 : ISA.Finance.BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RefreshData()
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
    }
}
