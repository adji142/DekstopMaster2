using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ISA.DAL;
using ISA.Common;
using ISA.Finance.Class;
using ISA.Finance.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Data.SqlClient;


namespace ISA.Finance.Tac
{
    public partial class frmSales : ISA.Controls.BaseForm
    {
        public frmSales()
        {
            InitializeComponent();
        }


        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Sales_TabelTac_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt.DefaultView;
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            this.Location = new Point(390, 200);
            RefreshData();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Tac.frmSalesEntry ifrmChild = new Tac.frmSalesEntry(this);
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;

        }


        public void TokoFindRow(string column, string value)
        {
            RefreshData();
            customGridView1.FindRow(column, value);
            customGridView1.Focus();
        }


        public void FindRow(string columnName, string value)
        {
            foreach (DataGridViewRow row in customGridView1.Rows)
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
                        customGridView1.CurrentCell = row.Cells[i];
                        this.Focus();
                        row.Selected = true;
                        customGridView1.FirstDisplayedCell = customGridView1.CurrentCell;
                        break;
                    }
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string cSls = customGridView1.SelectedCells[0].OwningRow.Cells["SalesID"].Value.ToString();
                if (MessageBox.Show("Kode Sales : " + cSls + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Sales_TabelTac_DELETE"));
                            db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID_));
                            dt = db.Commands[0].ExecuteDataTable();
                        }

                        this.RefreshData();
                        MessageBox.Show("Record telah dihapus");
                    }
                    catch (Exception ex)
                    {
                        Error.LogError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show(Messages.Error.RowNotSelected);
            }

        }




    }
}
