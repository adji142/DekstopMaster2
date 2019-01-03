using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ISA.DAL;
using ISA.Trading.DataTemplates;
using Microsoft.Reporting.WinForms;
using System.IO;
using ISA.Trading.Class;
using System.Management;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Linq;
using ISA.Controls;
using ISA.DAL;
using ISA.Pin;

namespace ISA.Trading.Penjualan
{
    public partial class frmLostSalles : ISA.Trading.BaseForm
    {
        Guid _RowID;
        public frmLostSalles()
        {
            InitializeComponent();
        }

        private void frmLostSalles_Load(object sender, EventArgs e)
        {
            rangeDateBox1.FromDate = GlobalVar.DateOfServer;
            rangeDateBox1.ToDate = GlobalVar.DateOfServer;
            //refreshData();
        }
        public void refreshData() {
            DataTable dt = new DataTable();

            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_lostsale_list"));
                db.Commands[0].Parameters.Add(new Parameter("@fromdate", SqlDbType.Date, rangeDateBox1.FromDate));
                db.Commands[0].Parameters.Add(new Parameter("@todate", SqlDbType.Date, rangeDateBox1.ToDate));
                
                dt = db.Commands[0].ExecuteDataTable();
            }
            customGridView1.DataSource = dt.DefaultView;
        }
        public void FindHeader(string columnName, string value)
        {
            customGridView1.FindRow(columnName, value);
        }
        private void commandButton1_Click(object sender, EventArgs e)
        {
            Penjualan.frmLostSalesupdate ifrmChild = new Penjualan.frmLostSalesupdate(this,"ADD");
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            Guid RowID = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
            Penjualan.frmLostSalesupdate ifrmChild = new Penjualan.frmLostSalesupdate(this,"EDIT", RowID);
            ifrmChild.MdiParent = Program.MainForm;
            Program.MainForm.RegisterChild(ifrmChild);
            ifrmChild.Show();
        }

        private void customGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void commandButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void commandButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Lost Sale akan di hapus ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (Database db = new Database())
                    {
                        Guid RowDelete = (Guid)customGridView1.SelectedCells[0].OwningRow.Cells["RowID"].Value;
                        DeleteData(db, "usp_Deletelostsale", RowDelete, "@RowID");
                    }
                    refreshData();
                }
                catch (Exception ex) {
                    Error.LogError(ex);
                }
            }
        }
        private void DeleteData(Database db, string namaSP, Guid RowID, string namaParameter)
        {
            db.Commands.Clear();
            db.Commands.Add(db.CreateCommand(namaSP));
            db.Commands[0].Parameters.Add(new Parameter(namaParameter, SqlDbType.UniqueIdentifier, RowID));

            db.Commands[0].ExecuteNonQuery();
        }
    }
}
