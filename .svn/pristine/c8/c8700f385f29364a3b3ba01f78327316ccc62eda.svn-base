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
    public partial class frmLostSalesupdate : ISA.Trading.BaseForm
    {
        string _Mode = string.Empty;
        Guid _Row;
        public frmLostSalesupdate()
        {
            InitializeComponent();
        }
        public frmLostSalesupdate(Form caller,string Mode)
        {
            _Mode = Mode;
            this.Caller = caller;
            InitializeComponent();
        }
        public frmLostSalesupdate(Form caller,string Mode,Guid Row)
        {
            _Mode = Mode;
            _Row = Row;
            this.Caller = caller;
            InitializeComponent();
        }
        private void commandButton1_Click(object sender, EventArgs e)
        {
            
            Guid RowID ;
            if (_Mode == "ADD")
            {
                RowID = (Guid)Guid.NewGuid();
            }
            else {
                RowID = (Guid)_Row;
            }
            using (Database db = new Database())
            {
                db.Commands.Add(db.CreateCommand("usp_lostsalesWO"));
                db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, RowID));
                db.Commands[0].Parameters.Add(new Parameter("@tgl", SqlDbType.DateTime, GlobalVar.DateTimeOfServer));
                db.Commands[0].Parameters.Add(new Parameter("@BarangID", SqlDbType.VarChar, lookupStock1.BarangID));
                db.Commands[0].Parameters.Add(new Parameter("@Sales", SqlDbType.VarChar, lookupSales1.SalesID));
                db.Commands[0].Parameters.Add(new Parameter("@Cust", SqlDbType.VarChar, lookupToko1.KodeToko));
                db.Commands[0].Parameters.Add(new Parameter("@Keterangan", SqlDbType.VarChar, commonTextBox1.Text));
                db.Commands[0].Parameters.Add(new Parameter("@User", SqlDbType.VarChar, SecurityManager.UserID));
                db.Commands[0].ExecuteNonQuery();
            }
            frmLostSalles frmCaller = (frmLostSalles)this.Caller;
            frmCaller.refreshData();
            frmCaller.FindHeader("RowID", RowID.ToString());
            this.Close();
            frmCaller.Show();
            
        }

        private void frmLostSalesupdate_Load(object sender, EventArgs e)
        {
            if (_Mode == "ADD")
            {
                dateTextBox1.Enabled = true;
                dateTextBox1.DateValue = GlobalVar.DateOfServer;
                lookupStock1.Enabled = true;
                lookupSales1.Enabled = true;
                lookupToko1.Enabled = true;
                commonTextBox1.Enabled = true;
            }
            else {
                dateTextBox1.Enabled = false;
                lookupStock1.Enabled = false;
                lookupSales1.Enabled = false;
                lookupToko1.Enabled = false;
                commonTextBox1.Enabled = true;
                DataTable dt = new DataTable();
                using (Database db = new Database())
                {
                    db.Commands.Add(db.CreateCommand("usp_lostsale_list"));
                    db.Commands[0].Parameters.Add(new Parameter("@RowID", SqlDbType.UniqueIdentifier, _Row));
                    dt = db.Commands[0].ExecuteDataTable();
                }
                dateTextBox1.DateValue = (DateTime)dt.Rows[0]["Tanggal"];
                lookupStock1.BarangID = dt.Rows[0]["BarangID"].ToString();
                lookupSales1.SalesID = dt.Rows[0]["Sales"].ToString();
                lookupToko1.KodeToko = dt.Rows[0]["Customer"].ToString();
                commonTextBox1.Text = dt.Rows[0]["Keterangan"].ToString();
            }
        }

        private void commandButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
