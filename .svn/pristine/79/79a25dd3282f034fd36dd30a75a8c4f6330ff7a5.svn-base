using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace ISA.Trading.Controls
{
    class CustomGridView:DataGridView
    {
        private bool generateRowNumber = false;

        public event EventHandler SelectionRowChanged;

        private int prevRow = -1;

        new public object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                string rowFilter="";
                if (base.DataSource != null)
                {
                    if (value is DataView)
                    {
                        DataView vwsource = (DataView) base.DataSource;
                        rowFilter = vwsource.RowFilter;
                    }
                    else
                    {
                        DataTable tblsource = (DataTable)base.DataSource;
                        rowFilter = tblsource.DefaultView.RowFilter;
                    }
                }

                if (value != null)
                {
                    if (value is DataView)
                    {
                        DataView vwTarget = (DataView) value;
                        vwTarget.RowFilter = rowFilter;
                    }
                    else
                    {
                        DataTable tblTarget = (DataTable)value;
                        tblTarget.DefaultView.RowFilter = rowFilter;
                    }
                }
                
                base.DataSource = value;
                
            }
        }

        public bool GenerateRowNumber
        {
            set
            {
                generateRowNumber = value;
            }
        }
        
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.StandardTab = true;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.MultiSelect = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AutoGenerateColumns = false;
            //this.GenerateRowNumber = true;
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
            if (this.SelectedCells.Count > 0)
            {
                if (prevRow != this.SelectedCells[0].RowIndex)
                {
                    if (this.SelectionRowChanged != null)
                    {
                        this.SelectionRowChanged(this, new EventArgs());
                    }
                    prevRow = this.SelectedCells[0].RowIndex;
                    return;
                }
            }
            if (this.SelectedRows.Count > 0)
            {
                if (prevRow != this.SelectedRows[0].Index)
                {
                    if (this.SelectionRowChanged != null)
                    {
                        this.SelectionRowChanged(this, new EventArgs());
                    }
                    prevRow = this.SelectedRows[0].Index;
                }
            }
        }

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseDown(e);
            
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex == -1)
                {
                    Dialog.frmFilterDialog ifrmDiag = new Dialog.frmFilterDialog();
                    ifrmDiag.ShowDialog();
                    DialogResult result = ifrmDiag.DialogResult;

                    if (result == DialogResult.OK)
                    {
                        
                        //Find
                        string strFind = ifrmDiag.FindValue.ToUpper();
                        if (ifrmDiag.IsFind)
                        {
                            if (ifrmDiag.FindValue != "")
                            {
                                foreach (DataGridViewRow row in this.Rows)
                                {
                                    if (row.Cells[e.ColumnIndex].Value != null)
                                    {
                                        if (row.Cells[e.ColumnIndex].Value.ToString().ToUpper().Contains(strFind))
                                        {
                                            this.CurrentCell = row.Cells[e.ColumnIndex];
                                            row.Selected = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else //Filter
                        {
                            if (this.CurrentCell != null)
                            {
                                this.CurrentRow.Selected = false;
                                this.CurrentCell = null;
                                this.ClearSelection();
                            }
                            DataTable dt = new DataTable();
                            DataView dv = new DataView();
                            if (this.DataSource is DataView)
                            {
                                dv = (DataView)this.DataSource;
                            }
                            else
                            {
                                dt = (DataTable) this.DataSource;
                                dv = dt.DefaultView;
                            }
                            if (ifrmDiag.FindValue != "")
                            {
                                if (dv.RowFilter == "")
                                {
                                    dv.RowFilter = String.Format("CONVERT({0}, System.String) LIKE '%{1}%'", this.Columns[e.ColumnIndex].DataPropertyName, ifrmDiag.FindValue);
                                }
                                else
                                {
                                    dv.RowFilter += String.Format(" AND CONVERT({0}, System.String) LIKE '%{1}%'", this.Columns[e.ColumnIndex].DataPropertyName, ifrmDiag.FindValue);
                                }
                            }
                            else
                            {
                                dv.RowFilter = ""; 
                            }
                            if (this.Rows.Count > 0)
                            {
                                DataGridViewRow row = this.Rows[0];
                                int i = 0;
                                for (i = 0; i < row.Cells.Count; i++)
                                {
                                    if (row.Cells[i].Visible == true)
                                    {
                                        break;
                                    }
                                }
                               
                                this.CurrentCell = row.Cells[i];
                                row.Selected = true;   
                                
                            }
                        }
                    }
                    if (this.SelectionRowChanged != null)
                    {
                        this.SelectionRowChanged(this, new EventArgs());
                    }
                }
            }                    
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        public void FindRow(string columnName, string value)
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString().ToUpper() == value.ToUpper())
                    {
                        int i = 0;
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Visible == true)
                            {
                                break;
                            }
                        }
                        this.CurrentCell = row.Cells[i];
                        this.Focus();
                        row.Selected = true;
                        this.FirstDisplayedCell = this.CurrentCell;                        
                        break;
                    }
                }
            }
        }

        public void RefreshDataRow(DataRow newDataRow, string KeyName, string keyValue)
        {
            DataView vwBind;
            if (this.DataSource != null)
            {

                if (this.DataSource is DataView)
                {

                    vwBind = (DataView)this.DataSource;
                }
                else
                {
                    DataTable dtBind = (DataTable)this.DataSource;
                    vwBind = dtBind.DefaultView;
                }
                bool found = false;
                foreach (DataRowView rowBind in vwBind)
                {
                    if (rowBind[KeyName].ToString() == keyValue)
                    {
                        rowBind.Row.BeginEdit();
                        for (int i = 0; i < rowBind.Row.ItemArray.Length; i++)
                        {
                            rowBind.Row[i] = newDataRow[i];
                        }
                        rowBind.Row.EndEdit();
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    DataRowView newEmptyRow = vwBind.AddNew();
                    newEmptyRow.Row.BeginEdit();
                    for (int i = 0; i < newEmptyRow.Row.ItemArray.Length; i++)
                    {
                        newEmptyRow.Row[i] = newDataRow[i];
                    }
                    newEmptyRow.Row.EndEdit();
                }
            }
            else
            {
                this.DataSource = newDataRow.Table.DefaultView;
            }
        }

        // Add by Iwan 7 July 2011 Ref: http://www.danielsoper.com/programming/DataGridViewNumberedRows.aspx
        // Purpose : Add row number on grid view
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            if (generateRowNumber)
            {
                //this method overrides the DataGridView's RowPostPaint event 
                //in order to automatically draw numbers on the row header cells
                //and to automatically adjust the width of the column containing
                //the row header cells so that it can accommodate the new row
                //numbers,

                //store a string representation of the row number in 'strRowNumber'
                string strRowNumber = (e.RowIndex + 1).ToString();

                //prepend leading zeros to the string if necessary to improve
                //appearance. For example, if there are ten rows in the grid,
                //row seven will be numbered as "07" instead of "7". Similarly, if 
                //there are 100 rows in the grid, row seven will be numbered as "007".
                while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

                //determine the display size of the row number string using
                //the DataGridView's current font.
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

                //adjust the width of the column that contains the row header cells 
                //if necessary
                if (this.RowHeadersWidth < (int)(size.Width + 20)) this.RowHeadersWidth = (int)(size.Width + 20);

                //this brush will be used to draw the row number string on the
                //row header cell using the system's current ControlText color
                Brush b = SystemBrushes.ControlText;

                //draw the row number string on the current row header cell using
                //the brush defined above and the DataGridView's default font
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

                //call the base object's OnRowPostPaint method
                base.OnRowPostPaint(e);
            }
        } 

    }
}
