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
    public partial class frmToko : ISA.Controls.BaseForm
    {
        public frmToko()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmToko_Load(object sender, EventArgs e)
        {
            InitializeComponents();
            RefreshData();
        }

        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Toko_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt.DefaultView;
        }


        public void InitializeComponents()
        {
            this.Location = new Point(300, 165);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Tac.frmTokoEntry ifrmChild = new Tac.frmTokoEntry(this);
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
                string cNamaToko = customGridView1.SelectedCells[0].OwningRow.Cells["NamaToko"].Value.ToString();
                if (MessageBox.Show("Hapus Toko : " + cNamaToko + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Toko_DELETE"));
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
