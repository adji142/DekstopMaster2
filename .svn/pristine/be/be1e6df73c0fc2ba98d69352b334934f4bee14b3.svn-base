using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;

namespace ISA.Finance.Piutang
{
    public partial class FrmSaldoPiutangBrowse : ISA.Finance.BaseForm
    {
        public FrmSaldoPiutangBrowse()
        {
            InitializeComponent();
        }

        private void FrmSaldoPiutangBrowse_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Refresh()
        {
            try
            {
                DataTable dtList = new DataTable();
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_SaldoPiutang_List"));
                    dtList = db.Commands[0].ExecuteDataTable();
                    dataGridView2.DataSource = dtList;
                }
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            Communicator.FrmSaldoPiutangDownload ifrmChild = new Communicator.FrmSaldoPiutangDownload();
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

    }
}
