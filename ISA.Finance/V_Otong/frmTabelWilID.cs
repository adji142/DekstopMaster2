using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.IO;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;
using ISA.Finance.DataTemplates;


namespace ISA.Finance.V_Otong
{
    public partial class frmTabelWilID : ISA.Finance.BaseForm
    {
#region "Procedure"
        DataTable dtHeader = new DataTable();
        public void RefreshHeader()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_UserWilID_List"));

                    dtHeader = db.Commands[0].ExecuteDataTable();
                }
                dataGridHeader.DataSource = dtHeader;
              
            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void FindGridHeader(string ColoumName_, string Value_)
        {
            dataGridHeader.FindRow(ColoumName_, Value_);
        }


        public void RefreshRowData(string CoulumName_,string Value_,DataTable dtRefresh_)
        {
           
            if (dtRefresh_.Rows.Count>0)
            {
                dataGridHeader.RefreshDataRow(dtRefresh_.Rows[0], CoulumName_, Value_);
            }
                
            
        }

#endregion
        public frmTabelWilID()
        {
            InitializeComponent();
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTabelWilID_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            dataGridHeader.AutoGenerateColumns = false;
            dataGridHeader.VirtualMode = true;
            RefreshHeader();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.RowCount== 0)
            {
                return;
               
            }
           String UserID_= dataGridHeader.SelectedCells[0].OwningRow.Cells["UserID"].Value.ToString();
           String UserName_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
           if (UserID_.Equals("ALL"))
           {
               return;
           }
            if (MessageBox.Show("Hapus user " + UserName_ +" ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
           
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("usp_UserWilID_Delete"));
                    db.Commands[0].Parameters.Add(new Parameter("@UserID", SqlDbType.VarChar, UserID_));
                    db.Commands[0].ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Error.LogError(ex);
            }
            finally
            {
                int i = 0;
           
                i = dataGridHeader.SelectedCells[0].RowIndex;
                DataRowView dv = (DataRowView)dataGridHeader.SelectedCells[0].OwningRow.DataBoundItem;
                DataRow dr = dv.Row;
                dr.Delete();
                dataGridHeader.Focus();
                if (dataGridHeader.RowCount>0)
                {
                    dataGridHeader.CurrentCell = dataGridHeader.Rows[i-1].Cells[0];
                    dataGridHeader.RefreshEdit();
                }
               
                this.Cursor = Cursors.Default;
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                String UserID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["UserID"].Value.ToString();
                String UserName_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                string WilID_ = dataGridHeader.SelectedCells[0].OwningRow.Cells["WilID"].Value.ToString();
                if (UserID_.Equals("ALL"))
                {
                    return;
                }
                V_Otong.frmTabelWilIDUpdate ifrmChild = new V_Otong.frmTabelWilIDUpdate(this,UserID_,UserName_,WilID_);
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();
            }
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (dataGridHeader.SelectedCells.Count > 0)
            {
                V_Otong.frmTabelWilIDUpdate ifrmChild = new V_Otong.frmTabelWilIDUpdate(this);
                ifrmChild.WindowState = FormWindowState.Normal;
                ifrmChild.ShowDialog();
            }
        }

        private void dataGridHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridHeader.RowCount==0)
            {
                return;
            }
            switch (e.KeyCode)
            {
            case Keys.Delete:
                    commandButton3.PerformClick();
            	break;
            }
        }
    }
}
