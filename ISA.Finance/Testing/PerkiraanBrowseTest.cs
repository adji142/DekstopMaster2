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
    public partial class PerkiraanBrowseTest : ISA.Finance.BaseForm
    {
        public PerkiraanBrowseTest()
        {
            InitializeComponent();
        }

        private void PerkiraanBrowseTest_Load(object sender, EventArgs e)
        {
            customGridView1.ReadOnly = true;
            RefreshData();
        }

        public void RefreshData()
        {

            DataTable dt = new DataTable();
            using(Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }

            dt.DefaultView.Sort = "NoPerkiraan";
            customGridView1.DataSource = dt.DefaultView;
        }

        public void RefreshRowData(string rowID)
        {
            DataTable dt = new DataTable();
            DataTable dtRefresh;
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Perkiraan_LIST"));
                db.Commands[0].Parameters.Add(new Parameter("@noPerkiraan", SqlDbType.VarChar, rowID));
                dtRefresh = db.Commands[0].ExecuteDataTable();
            }
            if (dtRefresh.Rows.Count > 0)
            {
                customGridView1.RefreshDataRow(dtRefresh.Rows[0], "NoPerkiraan", rowID);
            }
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FindRow(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Testing.PerkiraanUpdateTest ifrmChild = new Testing.PerkiraanUpdateTest(this);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
            Testing.PerkiraanUpdateTest ifrmChild = new Testing.PerkiraanUpdateTest(this, rowID);
            //ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.ShowDialog();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Messages.Question.AskDelete, "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (Database db = new Database(GlobalVar.DBName))
                {
                    string rowID = customGridView1.SelectedCells[0].OwningRow.Cells["NoPerkiraan"].Value.ToString();
                    db.Commands.Add(db.CreateCommand("usp_Perkiraan_DELETE"));
                    db.Commands[0].Parameters.Add(new Parameter("@NoPerkiraan", SqlDbType.VarChar, rowID));
                    db.Commands[0].ExecuteNonQuery();
                }
                customGridView1.Rows.Remove(customGridView1.SelectedCells[0].OwningRow);
            }
        }









    }
}
