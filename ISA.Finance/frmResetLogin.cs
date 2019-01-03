using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.Finance;
using ISA.DAL;


namespace ISA.Finance
{
    public partial class frmResetLogin : ISA.Finance.BaseForm
    {
        public frmResetLogin()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_LoginUser_List]"));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                customGridView1.DataSource = dt;
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void frmResetLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            customGridView1.AutoGenerateColumns = true;
            RefreshData();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount==0)
            {
                MessageBox.Show("No data");
                return;
            }
            string UserID = customGridView1.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
            if (MessageBox.Show("Hapus Session Login User:" + UserID + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = new DataTable();
               
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("[usp_LoginUser_Delete]"));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, UserID));
                    db.Commands[0].ExecuteNonQuery();
                }
                
            }
            catch (System.Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                RefreshData();
            }
        }

        private void customGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
            case Keys.Delete:
                    commandButton3.PerformClick();
            	break;
            }
        }
    }
}
