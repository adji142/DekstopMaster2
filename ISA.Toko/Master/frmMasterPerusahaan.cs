using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Toko.Master
{
    public partial class frmMasterPerusahaan : ISA.Toko.BaseForm
    {
        public frmMasterPerusahaan()
        {
            InitializeComponent();
        }

        private void frmMasterPerusahaan_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData() 
        {
            try
            {
                using (Database db = new Database())
                {
                    db.Open();

                    DataTable dt = new DataTable();
                    db.Commands.Add(db.CreateCommand("usp_Perusahaan_LIST"));

                    dt = db.Commands[0].ExecuteDataTable();

                    dataGridPerusahaan.DataSource = dt;
                    db.Close();
                }
            }
            catch (Exception exc)
            {
                Error.LogError(exc);
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
