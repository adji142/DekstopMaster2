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
    public partial class frmKota : ISA.Controls.BaseForm
    {
        public frmKota()
        {
            InitializeComponent();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKota_Load(object sender, EventArgs e)
        {
            InitializeComponents(); 
            RefreshData(); 
        }

        public void RefreshData()
        {
            DataTable dt = new DataTable();
            using (Database db = new Database(GlobalVar.DBName))
            {
                db.Commands.Add(db.CreateCommand("usp_Kota_LIST"));
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt.DefaultView;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Tac.frmKotaTmp ifrmChild = new Tac.frmKotaTmp();
            ifrmChild.Show();
            ifrmChild.WindowState = FormWindowState.Normal;
            RefreshData();
        }

        private void InitializeComponents()
        {
            this.Location = new Point(390, 200);
        }

        private void frmKota_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (customGridView1.SelectedCells.Count > 0)
            {
                Guid RowID_ = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                string cKota = customGridView1.SelectedCells[0].OwningRow.Cells["Kota"].Value.ToString();
                if (MessageBox.Show("Hapus Kota : " + cKota + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Database db = new Database(GlobalVar.DBName))
                        {
                            DataTable dt = new DataTable();
                            db.Commands.Add(db.CreateCommand("usp_Kota_DELETE"));
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
