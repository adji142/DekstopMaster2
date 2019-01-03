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
    public partial class frmPerencanaan : ISA.Finance.BaseForm
    {
#region "Procedure"
        DataTable dt = new DataTable();
        DateTime Tanggal1  = new DateTime();
        DateTime Tanggal2 = new DateTime();
        TimeSpan ts1;
        private void LoadData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_InOut_List]"));
                    db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, Setorans.Year.ToString() + ISA.Common.Tools.Right("00" + Setorans.Month.ToString(), 2)));
                    db.Commands[0].Parameters.Add(new Parameter("@rr", SqlDbType.Bit, 0));
                    db.Commands[0].Parameters.Add(new Parameter("@IO", SqlDbType.VarChar, "I"));
                    dt = db.Commands[0].ExecuteDataTable();
                  
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

        private void GenerateGrid()
        {
            ISA.Controls.MonthYearBox my = new ISA.Controls.MonthYearBox();
            my.Year = Setorans.Year;
            my.Month = Setorans.Month;
            Tanggal1 = my.FirstDateOfMonth;
            Tanggal2 = my.LastDateOfMonth;
            TimeSpan ts = my.LastDateOfMonth.Subtract(my.FirstDateOfMonth);
            ts1 = ts;
            int d = 0;
            bool valid = true;
            for (int i = 0; i < customGridView1.ColumnCount;i++ )
            {
                if (Tools.Left(customGridView1.Columns[i].Name,1)=="T")
                {
                    customGridView1.Columns[i].HeaderText = SetColoum(customGridView1.Columns[i].HeaderText, d,out valid);
                    customGridView1.Columns[i].ReadOnly = false;
                    customGridView1.Columns[i].Visible = valid;
                     d++;
                }
               
            }
           
        }

        private string SetColoum(string HeaderText,int day, out bool valid )
        {
            string HeaderText_ = string.Empty;
            if (day<=ts1.Days)
            {
                HeaderText_ = Tanggal1.AddDays(day).ToString("dd-MMM-yyyy");
                valid = true;
            }else
            {
                valid = false;
                HeaderText_ = HeaderText;
            }
           
            return HeaderText_;
        }

        private void SetData()
        {
            if (dt.Rows.Count==0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    using (Database db = new Database(GlobalVar.DBName))
                    {
                        db.Commands.Add(db.CreateCommand("[usp_InOut_Init]"));
                        db.Commands[0].Parameters.Add(new Parameter("@TahunBulan", SqlDbType.VarChar, Setorans.Year.ToString() + Tools.Right("00" + Setorans.Month.ToString(), 2)));
                        db.Commands[0].ExecuteNonQuery();

                    }
                    LoadData();
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

            customGridView1.DataSource = dt;
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
                        db.Commands.Add(db.CreateCommand("[usp_InOut_Update]"));
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier,(Guid) dr["RowID"]));
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (Tools.Left(dc.ColumnName, 1) == "T" && Tools.Left(dc.ColumnName, 2) != "Ta")
                            {
                                db.Commands[0].Parameters.Add(new Parameter("@"+dc.ColumnName, SqlDbType.Money, Convert.ToDouble(dr[dc.ColumnName])));
                            }
                        }
                       
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
        

        public frmPerencanaan()
        {
            InitializeComponent();
        }

        private void frmPerencanaan_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            customGridView1.AutoGenerateColumns = false;
            customGridView1.ReadOnly = false;
            customGridView1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            GenerateGrid();
            customGridView1.Columns["Keterangan"].ReadOnly = true;
            LoadData();
            SetData();
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
                    if (Tools.Left(customGridView1.Columns[i].Name, 1) == "T")
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
