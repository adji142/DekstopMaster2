using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using System.Drawing.Printing;
using ISA.Common;
using ISA.Finance.Class;
using System.Data.SqlTypes;
using ISA.Controls;

namespace ISA.Finance.Setoran
{
    public partial class frmStokTitipanGiro : ISA.Finance.BaseForm
    {
#region "Procedure"
        DataTable dt = new DataTable();
      
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_Inden_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
                    db.Commands[0].Parameters.Add(new Parameter("@KasBG", SqlDbType.VarChar, string.Empty));
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
       
        private void UpdateData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Setoran_Inden_Refresh]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TglSetoran", SqlDbType.DateTime, new DateTime(Setorans.Year, Setorans.Month, 1)));
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
            }
            
        }

#endregion


        public frmStokTitipanGiro()
        {
            InitializeComponent();
        }

        private void frmStokTitipanGiro_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customGridView1.AutoGenerateColumns = false;
            LoadData();
        }


        
        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount==0)
            {
                return;
            }
            UpdateData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
