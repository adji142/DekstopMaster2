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
    public partial class frmDataCustomer : ISA.Finance.BaseForm
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
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_List]"));
                    //db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, Setorans.Year));
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
                    db.Commands.Add(db.CreateCommand("[usp_DataCustomer_Refresh]"));
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


        public frmDataCustomer()
        {
            InitializeComponent();
        }

        private void frmDataCustomer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            customGridView1.AutoGenerateColumns = false;
            customGridView1.ReadOnly = false;
            customGridView1.Columns[0].ReadOnly = true;
            customGridView1.Columns[1].ReadOnly = true;
            customGridView1.Columns[2].ReadOnly = true;
            customGridView1.Columns[3].ReadOnly = true;
            customGridView1.Columns[5].ReadOnly = true;
            LoadData();
        }


        
        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
