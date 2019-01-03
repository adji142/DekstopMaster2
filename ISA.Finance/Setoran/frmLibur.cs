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

namespace ISA.Finance.Setoran
{
    public partial class frmLibur : ISA.Finance.BaseForm
    {

#region "Procedure"
        DataTable dt = new DataTable();
        DataTable dtT = new DataTable();
        enum enumSelectedMod { Insert, Edit, View };
        enumSelectedMod formMode = enumSelectedMod.View;
        int _PrevGrid = -1;
        Guid _RowID = Guid.Empty;

        private void LoadData(Guid RowID_)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Libur_List]"));

                    if (RowID_ == Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Setorans.Year));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    }


                    dt = db.Commands[0].ExecuteDataTable();
                    SetData();
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

        private void SetData()
        {
            if (dt.Rows.Count > 0)
            {
                customGridView1.DataSource = dt;
            }
            else
            {


                DateTime date1 = new DateTime(Setorans.Year, 1, 1);
                DateTime date2 = new DateTime(Setorans.Year + 1, 1, 1);
                TimeSpan ts;
                ts = date2.Subtract(date1);

                DateTime date3 = new DateTime(Setorans.Year, 1, 1);
                for (double i = 0; i < ts.Days; i++)
                {
                    date3 = date1.AddDays(+i);

                    if (date3.DayOfWeek == DayOfWeek.Sunday || date3.DayOfWeek == DayOfWeek.Saturday)
                    {
                        dt.Rows.Add(Guid.NewGuid(), date3.Day, date3.Month, date3.Year);
                    }
                }



                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_Libur_Insert]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, (Guid)dr["RowID"]));
                            db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Convert.ToInt32(dr["Tahun"])));
                            db.Commands[0].Parameters.Add(new Parameter("@Month", SqlDbType.Int, Convert.ToInt32(dr["Bulan"])));
                            db.Commands[0].Parameters.Add(new Parameter("@day", SqlDbType.Int, Convert.ToInt32(dr["Tanggal"])));
                            db.Commands[0].ExecuteNonQuery();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Error.LogError(ex);
                }

            }
            dt.DefaultView.Sort = "Bulan, Tanggal ASC";
            customGridView1.DataSource = dt.DefaultView.ToTable();

        }

        private void SetMonth()
        {
            cboMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonth.Items.Add("Januari");
            cboMonth.Items.Add("Februari");
            cboMonth.Items.Add("Maret");
            cboMonth.Items.Add("April");
            cboMonth.Items.Add("Mei");
            cboMonth.Items.Add("Juni");
            cboMonth.Items.Add("Juli");
            cboMonth.Items.Add("Agustus");
            cboMonth.Items.Add("September");
            cboMonth.Items.Add("Oktober");
            cboMonth.Items.Add("November");
            cboMonth.Items.Add("Desember");

            cboMonth.SelectedIndex = 0;
        }


        private void SetMode()
        {
            switch (formMode)
            {
                case enumSelectedMod.View:
                    {
                        groupBox1.Enabled = false;
                        cmdAdd.Enabled = true;
                        cmdEdit.Enabled = true;
                        cmdDelete.Enabled = true;
                        customGridView1.Enabled = true;
                    }
                    break;

                case enumSelectedMod.Edit:
                    {
                        groupBox1.Enabled = true;
                        cmdAdd.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdDelete.Enabled = false;
                        customGridView1.Enabled = false;
                       _RowID= (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                    }
                    break;
                case enumSelectedMod.Insert:
                    {
                        groupBox1.Enabled = true;
                        cmdAdd.Enabled = false;
                        cmdEdit.Enabled = false;
                        cmdDelete.Enabled = false;
                        customGridView1.Enabled = false;
                    }
                    break;
               

            }
        }
#endregion
       
        public frmLibur()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }

        private void frmLibur_Load(object sender, EventArgs e)
        {   SetMonth();
            LoadData(Guid.Empty);
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count>0)
            {
                if (customGridView1.SelectedCells[0].RowIndex != _PrevGrid)
                {
                    cboMonth.SelectedIndex = (int)customGridView1.SelectedCells[0].OwningRow.Cells["Bulan"].Value - 1;
                    txtTanggal.Value = (int)customGridView1.SelectedCells[0].OwningRow.Cells["Tanggal"].Value;
                }
                _PrevGrid = customGridView1.SelectedCells[0].RowIndex;
               
            }else
            {
                _PrevGrid = -1;
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case enumSelectedMod.Edit:
                    { 
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            db.Commands.Add(db.CreateCommand("[usp_Libur_Update]"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                            db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, Setorans.Year));
                            db.Commands[0].Parameters.Add(new Parameter("@bulan", SqlDbType.Int, cboMonth.SelectedIndex+1));
                            db.Commands[0].Parameters.Add(new Parameter("@Tanggal", SqlDbType.Int, txtTanggal.Value));
                            db.Commands[0].ExecuteNonQuery();

                        }
                    }
                    catch (System.Exception ex)
                    {
                        Error.LogError(ex);
                    }
                    
                    }
                    break;

                case enumSelectedMod.Insert:
                    {
                        try
                        {
                            using (Database db = new Database(GlobalVar.DBName))
                            {
                                db.Commands.Add(db.CreateCommand("[usp_Libur_Insert]"));
                                _RowID = Guid.NewGuid();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Year", SqlDbType.Int, Setorans.Year));
                                db.Commands[0].Parameters.Add(new Parameter("@MOnth", SqlDbType.Int, cboMonth.SelectedIndex + 1));
                                db.Commands[0].Parameters.Add(new Parameter("@Day", SqlDbType.Int, txtTanggal.Value));
                                db.Commands[0].ExecuteNonQuery();

                            }
                          
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }

                    }
                    break;
            }

            DataTable df = new DataTable();
            df = dt.Clone();
            df.Rows.Add(_RowID, txtTanggal.Value, cboMonth.SelectedIndex + 1, Setorans.Year);
            customGridView1.RefreshDataRow(df.Rows[0], "RowID", _RowID.ToString());
            formMode = enumSelectedMod.View;
            SetMode();
            customGridView1.FindRow("RowID", _RowID.ToString());

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            formMode = enumSelectedMod.View;
            SetMode();
            customGridView1.Focus();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            formMode = enumSelectedMod.Insert;
            SetMode();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            formMode = enumSelectedMod.Edit;
            SetMode();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count==0 || customGridView1.RowCount==0)
            {
                return;
            }
            if (MessageBox.Show("Hapus Data Ini ?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid RowID_ = Guid.Empty;
                RowID_=    (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Libur_Delete]"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    db.Commands[0].ExecuteNonQuery();
       
                }


                int i = customGridView1.SelectedCells[0].RowIndex;
                int n = customGridView1.SelectedCells[0].ColumnIndex;
                DataRowView dv = (DataRowView)customGridView1.SelectedCells[0].OwningRow.DataBoundItem;

                DataRow dr = dv.Row;

                dr.Delete();
                dt.AcceptChanges();
                customGridView1.Focus();
                if (customGridView1.RowCount > 0)
                {
                    if (i == 0)
                    {
                        customGridView1.CurrentCell = customGridView1.Rows[0].Cells[n];
                       
                    }
                    else
                    {
                        customGridView1.CurrentCell = customGridView1.Rows[i - 1].Cells[n];
                      
                    }

                }
                customGridView1.RefreshEdit();


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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
