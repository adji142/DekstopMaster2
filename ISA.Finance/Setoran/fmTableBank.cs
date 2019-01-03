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
    public partial class fmTableBank : ISA.Finance.BaseForm
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
                    db.Commands.Add(db.CreateCommand("usp_DataBank_List"));
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

        private void UpdateData(DataTable du)
        {
            try
            {
                foreach (DataRow dr in du.Rows)
                {
                
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_DataBank_Update]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,(Guid) dr["RowID"]));
                        db.Commands[0].Parameters.Add(new Parameter("@LamaCair", SqlDbType.Int, Convert.ToInt32(dr["LamaCair"])));
                        db.Commands[0].ExecuteNonQuery();
                    }

                }
                MessageBox.Show("Data has Been Saved");

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


        public fmTableBank()
        {
            InitializeComponent();
        }

        private void fmTableBank_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            customGridView1.AutoGenerateColumns = false;
            customGridView1.ReadOnly = false;
            customGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            
            customGridView1.Columns["LamaCair"].ReadOnly = false;
            customGridView1.Columns["NamaBank"].ReadOnly = true;
            customGridView1.Columns["Kota"].ReadOnly = true;
            LoadData();
        }

        private void customGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = customGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
            if (cell.Value.ToString().Trim() != string.Empty)
            {
                bool aaaa_ = false;
                double a_ = 0;
                aaaa_ = double.TryParse(cell.Value.ToString(), out a_);

                if (aaaa_ == false)
                {
                    MessageBox.Show("Hanya Angka");
                    customGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
                }
            }
            else
            {
                customGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
            }

           

        }

        private void customGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (customGridView1.RowCount > 0)
            {
               

                for (int i = 0; i < customGridView1.ColumnCount; i++)
                {
                    if (Tools.Left(customGridView1.Columns[i].Name, 1) == "L")
                    {
                        
                        bool aaaa_ = false;
                        double a_ = 0;
                        aaaa_ = double.TryParse(customGridView1.Rows[e.RowIndex].Cells[i].Value.ToString(), out a_);

                        if (aaaa_ == false)
                        {
                           
                            customGridView1[e.ColumnIndex, e.RowIndex].Value = 0;
                        }
                       
                    }

                }
               
               


            }
        }

        private void customGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }

        
        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton1_Click(object sender, EventArgs e)
        {
            if (customGridView1.RowCount > 0)
            {
                DataTable dti = new DataTable();
                if (dt.GetChanges(DataRowState.Modified) == null)
                {
                    return;
                }
                if (dt.GetChanges(DataRowState.Modified).Rows.Count > 0)
                {
                    dti = dt.GetChanges(DataRowState.Modified);
                    UpdateData(dti);
                }
                dt.AcceptChanges();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }
    }
}
