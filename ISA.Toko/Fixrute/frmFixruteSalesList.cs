using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Fixrute
{
    public partial class frmFixruteSalesList : ISA.Toko.BaseForm
    {
        public frmFixruteSalesList()
        {
            InitializeComponent();
        }

        private void frmFixruteSalesList_Load(object sender, EventArgs e)
        {
            RefreshFixrute();
        }

        private void RefreshFixrute()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_fixrutesales_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
                customGridView1.DataSource = dt;
            }
        }
    }
}
