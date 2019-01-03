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
using System.Data.SqlClient;

namespace ISA.Finance.Setoran
{
    public partial class frmRSaldoAwal : ISA.Finance.BaseForm
    {
#region "Procedure"
        DataTable dt = new DataTable();
        enum enumSelectedMod { Insert, Edit, View };
        enumSelectedMod formMode = enumSelectedMod.View;
        int _PrevGrid = -1;
        Guid _RowID = Guid.Empty;
        Double _RpAkhir = 0;
        bool _rr = false;
        int _PrevMonth = 0;
        int _PrevYear = 0;
        private DataTable LoadData(Guid RowID_)
        {
            DataTable dtmp = new DataTable();
            try
            {
                
                this.Cursor = Cursors.WaitCursor;
                using (Database db = new Database(GlobalVar.DBName))
                {
                    db.Commands.Add(db.CreateCommand("[usp_Saldo_List]"));

                    if (RowID_ == Guid.Empty)
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@rr", SqlDbType.Bit, 1));
                    }
                    else
                    {
                        db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                    }


                    dtmp = db.Commands[0].ExecuteDataTable();
            
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
            return dtmp;
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
                        _RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        _RpAkhir = Convert.ToDouble(customGridView1.SelectedCells[0].OwningRow.Cells["SaldoAkhir"].Value);
                        _rr = Convert.ToBoolean(customGridView1.SelectedCells[0].OwningRow.Cells["rr"].Value);
                        _PrevMonth = (int)customGridView1.SelectedCells[0].OwningRow.Cells["Bulan"].Value;
                        _PrevYear= (int)customGridView1.SelectedCells[0].OwningRow.Cells["Tahun"].Value;
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
        
        private void refreshData()
        {
            DataTable df = new DataTable();
            df = LoadData(_RowID).Copy();
            customGridView1.RefreshDataRow(df.Rows[0], "RowID", _RowID.ToString());
            formMode = enumSelectedMod.View;
            SetMode();
            customGridView1.FindRow("RowID", _RowID.ToString());
        }

#endregion

        public frmRSaldoAwal()
        {
            InitializeComponent();
        }

        private void frmRSaldoAwal_Load(object sender, EventArgs e)
        {
            dt = LoadData(Guid.Empty).Copy();
            customGridView1.DataSource = dt;
            SetMode();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    db.Commands.Add(db.CreateCommand("[usp_Saldo_Delete]"));
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            formMode = enumSelectedMod.View;
            SetMode();
            customGridView1.Focus();
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
                                db.Commands.Add(db.CreateCommand("[usp_Saldo_Update]"));
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, monthYearBox1.Year));
                                db.Commands[0].Parameters.Add(new Parameter("@bulan", SqlDbType.Int, monthYearBox1.Month));
                                db.Commands[0].Parameters.Add(new Parameter("@PrevMonth", SqlDbType.Int, _PrevMonth));
                                db.Commands[0].Parameters.Add(new Parameter("@PrevYear", SqlDbType.Int, _PrevYear));
                                db.Commands[0].Parameters.Add(new Parameter("@RpAwal", SqlDbType.Money,numericTextBox1.GetDoubleValue ));
                                db.Commands[0].Parameters.Add(new Parameter("@RpAkhir", SqlDbType.Money, _RpAkhir));
                                db.Commands[0].Parameters.Add(new Parameter("@rr", SqlDbType.Bit, _rr ? 1 : 0));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
                                db.Commands[0].ExecuteNonQuery();

                            }
                            refreshData();
                        }
                        catch (SqlException ex)
                        {
                            Error.LogError(ex);
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
                                db.Commands.Add(db.CreateCommand("[usp_Saldo_Insert]"));
                                _RowID = Guid.NewGuid();
                                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _RowID));
                                db.Commands[0].Parameters.Add(new Parameter("@Tahun", SqlDbType.Int, monthYearBox1.Year));
                                db.Commands[0].Parameters.Add(new Parameter("@bulan", SqlDbType.Int, monthYearBox1.Month));
                                db.Commands[0].Parameters.Add(new Parameter("@RpAwal", SqlDbType.Money, numericTextBox1.GetDoubleValue));
                                db.Commands[0].Parameters.Add(new Parameter("@RpAkhir", SqlDbType.Money, 0));
                                db.Commands[0].Parameters.Add(new Parameter("@rr", SqlDbType.Bit, 1));
                                db.Commands[0].Parameters.Add(new Parameter("@LastUpdatedBY", SqlDbType.VarChar, SecurityManager.UserName));
                                db.Commands[0].ExecuteNonQuery();

                            }
                            refreshData();
                        }
                        catch (SqlException ex)
                        {
                            Error.LogError(ex);
                        }
                        catch (System.Exception ex)
                        {
                            Error.LogError(ex);
                        }

                    }
                    break;
            }

      
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Setoran.frmPreferenceSetoran ifrmChild = new Setoran.frmPreferenceSetoran();
            ifrmChild.ShowDialog();
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                if (customGridView1.SelectedCells[0].RowIndex != _PrevGrid)
                {
                    monthYearBox1.Month = (int)customGridView1.SelectedCells[0].OwningRow.Cells["Bulan"].Value;
                    monthYearBox1.Year = (int)customGridView1.SelectedCells[0].OwningRow.Cells["Tahun"].Value;
                    numericTextBox1.Text = Convert.ToDouble(customGridView1.SelectedCells[0].OwningRow.Cells["SaldoAwal"].Value).ToString("#,##0");
                }
                _PrevGrid = customGridView1.SelectedCells[0].RowIndex;

            }
            else
            {
                _PrevGrid = -1;
            }

        }
    }
}
