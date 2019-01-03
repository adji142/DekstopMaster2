using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Trading.Administrasi
{
    public partial class frmErrorBrowse : ISA.Trading.BaseForm
    {
        public frmErrorBrowse()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database())
            {
                db.Open();                
                db.Commands.Add(db.CreateCommand("usp_ErrorLog_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@fromDate", SqlDbType.DateTime, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@toDate", SqlDbType.DateTime, rangeDateBox1.ToDate));
                dt = db.Commands[0].ExecuteDataTable();
                dataGridView1.DataSource = dt;
                db.Close();
                db.Dispose();
            }
            dt.DefaultView.Sort = "RowID DESC";
        }
        

        private void frmErrorBrowse_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rangeDateBox1.ToDate = DateTime.Now;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void rangeDateBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmdSearch.PerformClick();
            }
        }        
    }
}
