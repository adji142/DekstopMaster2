using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
namespace ISA.Trading.Master
{
    public partial class FrmTokoMitraBengkel : ISA.Trading.BaseForm
    {
        public FrmTokoMitraBengkel()
        {
            InitializeComponent();
        }

        private void FrmTokoMitraBengkel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                using (Database db = new Database()) {
                    db.Commands.Add(db.CreateCommand("psp_GetTokoMitraDetail"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dt;
            }
            catch (Exception ex) {
                Error.LogError(ex);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            GlobalVar.GetTokoMitra();
        }
    }
}
